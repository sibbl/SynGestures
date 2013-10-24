//---------------------------------------------------------------------------

#include <vcl.h>
#include <mmsystem.h>
#pragma hdrstop

const int IDC_TRAY1 = 1005;
const char *HINT_MESSAGE = "FoxPro";
const int WM_TRAYNOTIFY = WM_USER + 1001;

enum SWIPE_ACTION {
	SWIPE_UNKNOWN = 0,
	SWIPE_BROWSER_BACK = 1,
	SWIPE_BROWSER_FORWARD = 2,
	SWIPE_SHOW_DESKTOP = 3,
	SWIPE_SHOW_WINDOWS = 4,
	SWIPE_ARROW_LEFT = 5,
	SWIPE_ARROW_RIGHT = 6,
	SWIPE_TAB_NEXT = 7,
	SWIPE_TAB_PREVIOUS = 8,
	SWIPE_WINDOW_NEXT = 9,
	SWIPE_WINDOW_PREVIOUS = 10,
	SWIPE_SHOW_WINDOWS_FLIP = 11,
	SWIPE_BROWSER_CLOSE_TAB = 12,
	SWIPE_BROWSER_NEW_TAB = 13,
	SWIPE_BROWSER_REOPEN_LAST_TAB = 14,
	SWIPE_HOME = 15,
	SWIPE_END = 16
};
enum SCROLL_DIRECTION {
	SCROLL_NONE,
	SCROLL_TOP,
	SCROLL_RIGHT,
	SCROLL_BOTTOM,
	SCROLL_LEFT
};
struct TSwipeInfo {
	char* label;
	SWIPE_ACTION action;
};
#define LEN_swipeTwoFingerOptions 5
static const TSwipeInfo swipeTwoFingerOptions[] = {
	{"Disabled",SWIPE_UNKNOWN},
	{"Left arrow key (picture gallery)",SWIPE_ARROW_LEFT},
	{"Right arrow key (picture gallery)",SWIPE_ARROW_RIGHT},
	{"Browser/Explorer back",SWIPE_BROWSER_BACK},
	{"Browser/Explorer forward",SWIPE_BROWSER_FORWARD},
};
#define LEN_swipeTwoFingerOptionsSmall 3
static const TSwipeInfo swipeTwoFingerOptionsSmall[] = {
	{"Disabled",SWIPE_UNKNOWN},
	{"Left arrow key (picture gallery)",SWIPE_ARROW_LEFT},
	{"Right arrow key (picture gallery)",SWIPE_ARROW_RIGHT},
};
#define LEN_swipeThreeFingerOptions 17
static const TSwipeInfo swipeThreeFingerOptions[] = {
	{"Disabled",SWIPE_UNKNOWN},
	{"Left arrow key (picture gallery)",SWIPE_ARROW_LEFT},
	{"Right arrow key (picture gallery)",SWIPE_ARROW_RIGHT},
	{"Browser/Explorer back",SWIPE_BROWSER_BACK},
	{"Browser/Explorer forward",SWIPE_BROWSER_FORWARD},
	{"Switch to next window (Alt+Tab)",SWIPE_WINDOW_NEXT},
	{"Switch to previous window (Alt+Shift+Tab)",SWIPE_WINDOW_PREVIOUS},
	{"Show desktop",SWIPE_SHOW_DESKTOP},
	{"Show all open windows",SWIPE_SHOW_WINDOWS},
	{"Open Windows Flip 3D",SWIPE_SHOW_WINDOWS_FLIP},
	{"Next browser/IM tab (Ctrl+Tab)",SWIPE_TAB_NEXT},
	{"Previous browser/IM tab (Ctrl+Shift+Tab)",SWIPE_TAB_PREVIOUS},
	{"Close current browser/IM tab (Ctrl+W)",SWIPE_BROWSER_CLOSE_TAB},
	{"Open new browser tab (Ctrl+T)",SWIPE_BROWSER_NEW_TAB},
	{"Reopen closed browser tab (Ctrl+Shift+T)",SWIPE_BROWSER_REOPEN_LAST_TAB},
	{"Go to top of page (Home key)",SWIPE_HOME},
	{"Go to bottom of page (End key)",SWIPE_END},
};



#include "mainwindow.h"
#include "SynComDefs.h"
#include <shlwapi.h>
#include <psapi.h>
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma link "SYNCOMLib_OCX"
#pragma link "LMDCustomComponent"
#pragma link "LMDTrayIcon"
#pragma link "LMDWndProcComponent"
#pragma resource "*.dfm"

static const UnicodeString regKey = "Software\\SynGestures";


struct TTapInfo {
	DWORD eventDown, eventUp, x;
};
static const TTapInfo tapInfo[] = {
	{0, 0, 0}, // disabled
	{MOUSEEVENTF_LEFTDOWN, MOUSEEVENTF_LEFTUP, 0},
	{MOUSEEVENTF_MIDDLEDOWN, MOUSEEVENTF_MIDDLEUP, 0},
	{MOUSEEVENTF_RIGHTDOWN, MOUSEEVENTF_RIGHTUP, 0},
	{MOUSEEVENTF_XDOWN, MOUSEEVENTF_XUP, XBUTTON1},
	{MOUSEEVENTF_XDOWN, MOUSEEVENTF_XUP, XBUTTON2}
};



TForm1 *Form1;
//---------------------------------------------------------------------------

UnicodeString __fastcall GetForegroundWindowBaseModuleName()
{
	HWND hWnd;

	hWnd = GetForegroundWindow();
	if (hWnd) {
		DWORD dwProcessId;
		HANDLE hProcess;

		GetWindowThreadProcessId(hWnd, &dwProcessId);
		hProcess = OpenProcess(PROCESS_QUERY_INFORMATION |
			PROCESS_VM_READ, false, dwProcessId);
		if (hProcess != NULL) {
			HMODULE hMod;
			DWORD cbNeeded;

			if (EnumProcessModules(hProcess, &hMod, sizeof(hMod), &cbNeeded)) {
				char szModule[MAX_PATH];

				GetModuleBaseName(hProcess, hMod, szModule, MAX_PATH);
				CloseHandle(hProcess);
				return UnicodeString(szModule);
			}

			CloseHandle(hProcess);
		}
	}

	return UnicodeString();
}
//---------------------------------------------------------------------------

int __fastcall GetScrollMode()
{
	UnicodeString name = GetForegroundWindowBaseModuleName();
	int mode = 1;

	if (name != "") {
		TRegistry *reg;

		reg = new TRegistry();
		reg->RootKey = HKEY_CURRENT_USER;
		if (reg->OpenKeyReadOnly(regKey + "\\scrollModeApps")) {
			if (reg->ValueExists(name)) {
				mode = reg->ReadInteger(name);
			}
			reg->CloseKey();
		}
		delete reg;
	}
	return mode;
}
//---------------------------------------------------------------------------

void __fastcall SetScrollMode(int mode)
{
	UnicodeString name = GetForegroundWindowBaseModuleName();

	if (name != "") {
		TRegistry *reg;

		reg = new TRegistry();
		reg->RootKey = HKEY_CURRENT_USER;
		reg->Access = KEY_ALL_ACCESS;
		if (reg->OpenKey(regKey + "\\scrollModeApps", true)) {
			if (mode != 1) {
				reg->WriteInteger(name, mode);
			}
			else {
				reg->DeleteValue(name);
            }
			reg->CloseKey();
		}
		delete reg;
	}
}

__fastcall TForm1::TForm1(TComponent* Owner)
	: TForm(Owner)
{
	synAPI = new TSynAPI(this);
	synTouchPad = new TSynDevice(this);

	synAPI->Initialize();

	long devHandle = -1;

	synAPI->FindDevice(SE_ConnectionAny,
		SE_DeviceTouchPad,
		&devHandle);

	if (devHandle < 0) {
		Application->MessageBox(L"No Synaptics TouchPad device found!",
			L"SynGestures");
		Application->Terminate();
	}

	synTouchPad->Select(devHandle);
	synTouchPad->CreatePacket(&synPacket);

	long multi;

	synTouchPad->GetProperty(SP_IsMultiFingerCapable, &multi);
	if (!multi) {
		TRegistry *reg = new TRegistry();
		reg->RootKey = HKEY_LOCAL_MACHINE;
		reg->Access = KEY_ALL_ACCESS;
		if (!reg->OpenKey("System\\CurrentControlSet\\Services\\SynTP\\Parameters", false)) {
			Application->MessageBox(L"Synaptics kernel driver registry keys missing. Reinstall drivers.",
				L"SynGestures");
			Application->Terminate();
		}
		unsigned int mask = 0;
		if (reg->ValueExists("CapabilitiesMask")) {
			mask = reg->ReadInteger("CapabilitiesMask");
			if (mask == 0xFFFFFFFF) {
				Application->MessageBox(L"Driver support for multiple fingers is already enabled but\n"
					"the driver still doesn't report multiple fingers. Either you haven't restarted\n"
					"the system yet or your TouchPad doesn't support multiple fingers.",
					L"SynGestures");
				Application->Terminate();
			}
		}
		if (mask != 0xFFFFFFFF) {
			reg->WriteInteger("CapabilitiesMask", 0xFFFFFFFF);
			reg->CloseKey();
			Application->MessageBox(L"Driver support for multiple fingers has been enabled.\n"
            	"\n"
				"Restart system for the changes to take effect.",
				L"SynGestures");
			Application->Terminate();
		}
		reg->CloseKey();
	}

	// activate the OnPacket event
	synTouchPad->SetSynchronousNotification(this);

	settings = new TRegistry();
	SettingsLoad();
}
//---------------------------------------------------------------------------

void __fastcall TForm1::SettingsLoad(bool defaults)
{
	settings->RootKey = HKEY_CURRENT_USER;
	if (!defaults) settings->OpenKeyReadOnly(regKey);

	if (settings->ValueExists("scrollX")) {
		switch (settings->ReadInteger("scrollX")) {
		case 1:
			scrollLinearX->Checked = true;
			break;
		default:
			scrollOffX->Checked = true;
		}
	}
	else scrollLinearX->Checked = true;
	scrollLinearXClick(NULL);

	if (settings->ValueExists("scrollY")) {
		switch (settings->ReadInteger("scrollY")) {
		case 1:
			scrollLinearY->Checked = true;
			break;
		default:
			scrollOffY->Checked = true;
		}
	}
	else scrollLinearY->Checked = true;
	scrollLinearYClick(NULL);

	if (settings->ValueExists("scrollLinearEdgeX"))
		scrollLinearEdgeX->Checked = settings->ReadInteger("scrollLinearEdgeX");
	else scrollLinearEdgeX->Checked = true;

	if (settings->ValueExists("scrollLinearEdgeX"))
		scrollLinearEdgeX->Checked = settings->ReadInteger("scrollLinearEdgeX");
	else scrollLinearEdgeX->Checked = true;

	if (settings->ValueExists("scrollSpeed")) {
		scrollSpeed->Position =
			settings->ReadInteger("scrollSpeed");
	}
	else scrollSpeed->Position = 30;

	if (settings->ValueExists("scrollAccEnabled")) {
		scrollAccEnabled->Checked =
			settings->ReadInteger("scrollAccEnabled");
	}
	else scrollAccEnabled->Checked = true;
	scrollAccEnabledClick(NULL);

	if (settings->ValueExists("scrollAcc")) {
		scrollAcc->Position =
			settings->ReadInteger("scrollAcc");
	}
	else scrollAcc->Position = 50;

	if (settings->ValueExists("scrollMode")) {
		switch (settings->ReadInteger("scrollMode")) {
		case 1:
			scrollSmooth->Checked = true;
			break;
		default:
			scrollCompatible->Checked = true;
		}
	}
	else scrollSmooth->Checked = true;

	if (settings->ValueExists("scrollReverse")) {
		scrollReverse->Checked =
			settings->ReadInteger("scrollReverse");
	}
	else scrollReverse->Checked = false;

	if (settings->ValueExists("tapOneOne")) {
		tapOneOne->ItemIndex =
			settings->ReadInteger("tapOneOne");
	}
	else tapOneOne->ItemIndex = 0;

	if (settings->ValueExists("tapTwo")) {
		tapTwo->ItemIndex =
			settings->ReadInteger("tapTwo");
	}
	else tapTwo->ItemIndex = 0;

	if (settings->ValueExists("tapTwoOne")) {
		tapTwoOne->ItemIndex =
			settings->ReadInteger("tapTwoOne");
	}
	else tapTwoOne->ItemIndex = 0;

	if (settings->ValueExists("tapThree")) {
		tapThree->ItemIndex =
			settings->ReadInteger("tapThree");
	}
	else tapThree->ItemIndex = 0;

	if (settings->ValueExists("tapMaxDistance")) {
		tapMaxDistance->Position =
			settings->ReadInteger("tapMaxDistance");
	}
	else tapMaxDistance->Position = 50;


	UpdateDropdowns();  //load all items and select them:
	if (settings->ValueExists("swipeTwoLeft"))
		swipeTwoLeft->ItemIndex = settings->ReadInteger("swipeTwoLeft");
	else swipeTwoLeft->ItemIndex = 0;
	if (settings->ValueExists("swipeTwoRight"))
		swipeTwoRight->ItemIndex = settings->ReadInteger("swipeTwoRight");
	else swipeTwoRight->ItemIndex = 0;
	if (settings->ValueExists("swipeThreeTop"))
		swipeThreeTop->ItemIndex = settings->ReadInteger("swipeThreeTop");
	else swipeThreeTop->ItemIndex = 0;
	if (settings->ValueExists("swipeThreeRight"))
		swipeThreeRight->ItemIndex = settings->ReadInteger("swipeThreeRight");
	else swipeThreeRight->ItemIndex = 0;
	if (settings->ValueExists("swipeThreeBottom"))
		swipeThreeBottom->ItemIndex = settings->ReadInteger("swipeThreeBottom");
	else swipeThreeBottom->ItemIndex = 0;
	if (settings->ValueExists("swipeThreeLeft"))
		swipeThreeLeft->ItemIndex = settings->ReadInteger("swipeThreeLeft");
	else swipeThreeLeft->ItemIndex = 0;

	settings->CloseKey();

	TRegistry *reg = new TRegistry();
	reg->RootKey = HKEY_CURRENT_USER;
	if (!defaults)
		reg->OpenKeyReadOnly("Software\\Microsoft\\Windows\\CurrentVersion\\Run");

	if (reg->ValueExists("SynGestures")) {
		 startWithWindows->Checked = (reg->ReadString("SynGestures") ==
			Application->ExeName);
	}
	else startWithWindows->Checked = false;

	reg->CloseKey();
}
//---------------------------------------------------------------------------

void __fastcall TForm1::SettingsSave()
{
	settings->RootKey = HKEY_CURRENT_USER;
	settings->Access = KEY_ALL_ACCESS;
	if (!settings->OpenKey(regKey, true))
		return;

	settings->WriteInteger("scrollX", scrollLinearX->Checked ? 1 : 0);
	settings->WriteInteger("scrollLinearEdgeX", scrollLinearEdgeX->Checked);
	settings->WriteInteger("scrollY", scrollLinearY->Checked ? 1 : 0);
	settings->WriteInteger("scrollLinearEdgeY", scrollLinearEdgeY->Checked);
	settings->WriteInteger("scrollSpeed", scrollSpeed->Position);
	settings->WriteInteger("scrollAccEnabled", scrollAccEnabled->Checked);
	settings->WriteInteger("scrollAcc", scrollAcc->Position);
	settings->WriteInteger("scrollMode", scrollSmooth->Checked ? 1 : 0);
	settings->WriteInteger("scrollReverse", scrollReverse->Checked ? 1 : 0);
	settings->WriteInteger("tapOneOne", tapOneOne->ItemIndex);
	settings->WriteInteger("tapTwo", tapTwo->ItemIndex);
	settings->WriteInteger("tapTwoOne", tapTwoOne->ItemIndex);
	settings->WriteInteger("tapThree", tapThree->ItemIndex);
	settings->WriteInteger("tapMaxDistance", tapMaxDistance->Position);
	settings->WriteInteger("swipeTwoLeft", swipeTwoLeft->ItemIndex);
	settings->WriteInteger("swipeTwoRight", swipeTwoRight->ItemIndex);
	settings->WriteInteger("swipeThreeTop", swipeThreeTop->ItemIndex);
	settings->WriteInteger("swipeThreeRight", swipeThreeRight->ItemIndex);
	settings->WriteInteger("swipeThreeBottom", swipeThreeBottom->ItemIndex);
	settings->WriteInteger("swipeThreeLeft", swipeThreeLeft->ItemIndex);

	settings->CloseKey();

	TRegistry *reg = new TRegistry();
	reg->RootKey = HKEY_CURRENT_USER;
	reg->Access = KEY_ALL_ACCESS;
	reg->OpenKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run", false);

	if (startWithWindows->Checked) {
		reg->WriteString("SynGestures", Application->ExeName);
	}
	else if (reg->ValueExists("SynGestures")) {
		reg->DeleteValue("SynGestures");
	}

	reg->CloseKey();
}
//---------------------------------------------------------------------------

void __fastcall TForm1::AcquirePad(bool acquire)
{
	if (acquire && !IsPadAcquired) {
		synTouchPad->Acquire(0);
	}
	else if (!acquire && IsPadAcquired) {
		synTouchPad->Unacquire();
	}
	IsPadAcquired = acquire;
}
//---------------------------------------------------------------------------

void __fastcall TForm1::LockDeviceTap(bool lock)
{
	long gest;

	if (lock != IsDeviceTapLocked) {
		if (lock) {
			synTouchPad->GetProperty(SP_Gestures, &gest);
			if (gest & SF_GestureTap) {
				synTouchPad->SetProperty(SP_Gestures, gest & (~SF_GestureTap));
				synTapState = true;
			}
			else synTapState = false;
		}
		else {
			synTouchPad->GetProperty(SP_Gestures, &gest);
			if (synTapState) gest |= SF_GestureTap;
			else gest &= ~SF_GestureTap;
			synTouchPad->SetProperty(SP_Gestures, gest);
		}
		IsDeviceTapLocked = lock;
	}
}
//---------------------------------------------------------------------------

void __fastcall TForm1::Settings1Click(TObject *Sender)
{
	pages->ActivePageIndex = 0;
	Show();
	ok->SetFocus();
	SetForegroundWindow(Handle);
}
//---------------------------------------------------------------------------

void __fastcall TForm1::FormClose(TObject *Sender, TCloseAction &Action)
{
	Hide();
	SettingsLoad();
	Action = caNone;
}
//---------------------------------------------------------------------------

void __fastcall TForm1::scrollLinearXClick(TObject *Sender)
{
	bool e = scrollLinearX->Checked;
	scrollLinearEdgeX->Enabled = e;
	lblHintScrolling->Visible = e;
	UpdateDropdowns();
	/*scrollSpeedLabel->Enabled = e;
	scrollSpeed->Enabled = e;
	scrollAccEnabled->Enabled = e;
	scrollAcc->Enabled = e; */
}
//---------------------------------------------------------------------------

void __fastcall TForm1::scrollLinearYClick(TObject *Sender)
{
	bool e = scrollLinearY->Checked;
	scrollLinearEdgeY->Enabled = e;
}

//---------------------------------------------------------------------------

void __fastcall TForm1::Exit1Click(TObject *Sender)
{
	Application->Terminate();
}
//---------------------------------------------------------------------------

HRESULT STDMETHODCALLTYPE TForm1::OnSynDevicePacket(long seqNum)
{
	long nof, fstate, xd, yd;

	// get the pointing data packet
	synTouchPad->LoadPacket(synPacket);

	if (!globalActive->Checked)
		return 0;

	// extract relevant data
	synPacket->GetProperty(SP_ExtraFingerState, &nof);
	nof &= 3;
	synPacket->GetProperty(SP_FingerState, &fstate);
	synPacket->GetProperty(SP_XDelta, &xd);
	synPacket->GetProperty(SP_YDelta, &yd);

	// handle tapping
	if (nof > tapLastNof) {
		if (nof >= 2) {
			synPacket->GetProperty(SP_TimeStamp,
				&tapStartTime);
			tapDistance = 0;
			LockDeviceTap(true);
		}
		if (tapLastNof == 0) {
			synPacket->GetProperty(SP_TimeStamp,
				&tapTouchTime);
			GetCursorPos(&tapTouchPos);
		}
	}
	else if (nof < tapLastNof) {
		if ((tapDistance < tapMaxDistance->Position) &&
			(tapLastNof >= 2))
		{
			bool ok = false;
			long tstamp;
			synPacket->GetProperty(SP_TimeStamp, &tstamp);
			if (tstamp - tapTouchTime < 175) {
				if (tapLastNof == 2)
					ok = DoTap(tapTwo->ItemIndex);
				else if (tapLastNof == 3)
					ok = DoTap(tapThree->ItemIndex);
			}
			else if (tstamp - tapStartTime < 175) {
				if (tapLastNof == 2)
					ok = DoTap(tapOneOne->ItemIndex);
				else if (tapLastNof == 3)
					ok = DoTap(tapTwoOne->ItemIndex);
			}
			if (ok)
				SetCursorPos(tapTouchPos.x, tapTouchPos.y);

			// prevent tap trigger until initiated again
			tapStartTime -= 175;
			tapLastNof = nof;
			return 0;
		}
	}
	if (IsDeviceTapLocked) {
		if (abs(xd) < 800) tapDistance += abs(xd);
		if (abs(yd) < 800) tapDistance += abs(yd);
		if (!(fstate & SF_FingerPresent))
			LockDeviceTap(false);
	}
	tapLastNof = nof;

	// handle scrolling
	//if (scrollLinear->Checked) {
		if (fstate & SF_FingerPresent) {
			if (scrollTouchTime == 0) {
				GetCursorPos(&scrollTouchPos);
				synPacket->GetProperty(SP_TimeStamp,
						&scrollTouchTime);
			}
			if (nof == 2) {
				long y, ylo, yhi, x, xlo, xhi;
				synPacket->GetProperty(SP_Y, &y);
				synTouchPad->GetProperty(SP_YLoBorder, &ylo);
				synTouchPad->GetProperty(SP_YHiBorder, &yhi);
				synPacket->GetProperty(SP_X, &x);
				synTouchPad->GetProperty(SP_XLoBorder, &xlo);
				synTouchPad->GetProperty(SP_XHiBorder, &xhi);
				if (IsPadAcquired && scrollLinearEdgeY->Checked &&
					(scrollDir==SCROLL_TOP||scrollDir==SCROLL_BOTTOM) ) {
					if (ylo <= y && y <= yhi) {
						scrollNotEdgeY = true;
					}
					else if (scrollNotEdgeY && ((y < ylo && scrollLastYDelta < 0) ||
							(y > yhi && scrollLastYDelta > 0))) {
						DoScroll(scrollLastXDelta, scrollLastYDelta);
						return 0;
					}
				}
				if (IsPadAcquired && scrollLinearEdgeX->Checked &&
					(scrollDir==SCROLL_LEFT||scrollDir==SCROLL_RIGHT) ) {
					if (xlo <= x && x <= xhi) {
						scrollNotEdgeX = true;
					}
					else if (scrollNotEdgeX && ((x < xlo && scrollLastXDelta < 0) ||
							(x > xhi && scrollLastXDelta > 0))) {
						DoScroll(scrollLastXDelta, scrollLastYDelta);
						return 0;
					}
				}
				if (fstate & SF_FingerMotion) {
					if (!IsPadAcquired) {
						swipeDone=false;    //start left/right swipe

						AcquirePad(true);
						long tstamp;
						synPacket->GetProperty(SP_TimeStamp, &tstamp);
						if (tstamp - scrollTouchTime < 1000) {
							SetCursorPos(scrollTouchPos.x,
								scrollTouchPos.y);
						}
						if (scrollCompatible->Checked) {
							scrollMode = 0;
						}
						else if (scrollSmooth->Checked) {
							scrollMode = 1;
						}
						/*else {   //KOMPATIBILITÄTSMODUS
							scrollMode = GetScrollMode();
							if ((GetKeyState(VK_SHIFT) & 0x8000) &&
									(GetKeyState(VK_CONTROL) & 0x8000) &&
									(GetKeyState(VK_MENU) & 0x8000)) {
								// toggle scroll mode
								if (scrollMode == 1) scrollMode = 0;
								else scrollMode = 1;
								SetScrollMode(scrollMode);
							}

						}  */
					}
					int abstandRichtung = 150;
					int abweichung = 100;
					if (IsPadAcquired) {
						swipeXDelta += xd;
						swipeYDelta += yd;
						if(swipeXDelta < -1*abstandRichtung && abs(swipeYDelta) < abweichung) {  //links
							scrollDir = SCROLL_LEFT;
							if(!swipeDone) DoSwipeAction(SWIPE_TWO_LEFT);
							swipeDone=true;
						} else if(swipeXDelta > abstandRichtung && abs(swipeYDelta) < abweichung) {  //rechts
							scrollDir = SCROLL_RIGHT;
							if(!swipeDone) DoSwipeAction(SWIPE_TWO_RIGHT);
							swipeDone=true;
						}else if(abs(swipeXDelta) < abweichung && swipeYDelta < -1*abstandRichtung) { //runter
							swipeDone = true;
							scrollDir = SCROLL_BOTTOM;
						}else if(abs(swipeXDelta) < abweichung && swipeYDelta > abstandRichtung) { //hoch
							swipeDone = true;
							scrollDir = SCROLL_TOP;
						}
						scrollLastXDelta = xd;
						scrollLastYDelta = yd;
						if(scrollDir != SCROLL_NONE) {
							DoScroll(xd, yd);
						}
					}
				}
			}
			else if(nof == 3) {
				if (fstate & SF_FingerMotion) {
					if (!IsPadAcquired) {
						AcquirePad(true);
						swipeDone=false;
					}
					if (IsPadAcquired && !swipeDone) {
						swipeXDelta += xd;
						swipeYDelta += yd;
						if(swipeXDelta < -100 && abs(swipeYDelta) < 50) {  //links
							swipeDone=true;
							DoSwipeAction(SWIPE_THREE_LEFT);
						} else if(swipeXDelta > 100 && abs(swipeYDelta) < 50) {  //rechts
							swipeDone=true;
							DoSwipeAction(SWIPE_THREE_RIGHT);
						} else if(abs(swipeXDelta) < 50 && swipeYDelta < -100) { //runter
							swipeDone=true;
							DoSwipeAction(SWIPE_THREE_BOTTOM);
						} else if(abs(swipeXDelta) < 50 && swipeYDelta > 100) {  //hoch
							swipeDone=true;
							DoSwipeAction(SWIPE_THREE_TOP);
						}
					}
				}
			}
			else {
				scrollLastXDelta = scrollLastYDelta = 0;
				swipeXDelta = swipeYDelta = 0;
				swipeDone=false;
				scrollDir = SCROLL_NONE;
				AcquirePad(false);
				scrollBufferX = scrollBufferY = 0;
				scrollNotEdgeX = scrollNotEdgeY = false;
			}
		}
		else {
			scrollTouchTime = 0;
			scrollLastXDelta = scrollLastYDelta = 0;
			swipeXDelta = swipeYDelta = 0;
			swipeDone=false;
			scrollDir = SCROLL_NONE;
			AcquirePad(false);
			scrollBufferX = scrollBufferY = 0;
			scrollNotEdgeX = scrollNotEdgeY = false;
		}
	//}

	return 0;
}
//---------------------------------------------------------------------------

bool __fastcall TForm1::DoTap(int index)
{
	INPUT i[2];
	const TTapInfo *info = &tapInfo[index];

	if (info->eventDown == 0) return false; // tapping disabled

	ZeroMemory(i, sizeof(INPUT)*2);
	i[0].type = INPUT_MOUSE;
	i[0].mi.dwFlags = info->eventDown;
	i[0].mi.mouseData = info->x;
	i[1].type = INPUT_MOUSE;
	i[1].mi.dwFlags = info->eventUp;
	i[1].mi.mouseData = info->x;
	SendInput(2, i, sizeof(INPUT));

	return true;
}
//---------------------------------------------------------------------------


bool __fastcall TForm1::DoScroll(long dx, long dy)
{
	bool isHorizontal = (scrollDir==SCROLL_LEFT||scrollDir==SCROLL_RIGHT);
	if(!scrollLinearX->Checked && isHorizontal) return false;
	if(!scrollLinearY->Checked && !isHorizontal) return false;

	long d, dd = isHorizontal?dx:dy;

	if (abs(dy) > 800 || abs(dx) > 800)
		return false;

	// scrollSpeed
	dd = dd * scrollSpeed->Position / 100;

	// scrollAcc
	if (scrollAccEnabled->Checked) {
		d = dd * dd / (scrollAcc->Max - scrollAcc->Position + scrollAcc->Min);
		if (d < 4)
			d = 4;
		if (dd < 0)
			d = -d;
	}
	else d = dd;

	if (scrollMode == 0) {
		// compatibility mode
		if(isHorizontal) scrollBufferX += d;
		else scrollBufferY += d;
		d = isHorizontal?scrollBufferX:scrollBufferY - isHorizontal?scrollBufferX:scrollBufferY % WHEEL_DELTA;
	}

	d = scrollReverse->Checked?d*-1:d;

	if (d != 0) {
		INPUT i;
		ZeroMemory(&i, sizeof(INPUT));
		i.type = INPUT_MOUSE;
		i.mi.dwFlags = isHorizontal?MOUSEEVENTF_HWHEEL:MOUSEEVENTF_WHEEL;
		i.mi.mouseData = d;
		SendInput(1, &i, sizeof(INPUT));
		if (scrollMode == 0) {// compatibility mode
			if(isHorizontal) scrollBufferX -= d;
			else scrollBufferY -= d;
        }
	}

	return true;
}
//---------------------------------------------------------------------------

void __fastcall TForm1::okClick(TObject *Sender)
{
	Hide();
	SettingsSave();
}
//---------------------------------------------------------------------------

void __fastcall TForm1::cancelClick(TObject *Sender)
{
	Hide();
	SettingsLoad();
}
//---------------------------------------------------------------------------

void __fastcall TForm1::About1Click(TObject *Sender)
{
	Application->MessageBox(L"SynGestures 0.1\n"
		"\n"
		"Copyright 2011 by Sibbl\n"
		"\nWebsite: http://www.klickin-webdesign.de\n"
		"Twitter: @sibbl",
		L"About");
}
//---------------------------------------------------------------------------

void __fastcall TForm1::defaultsClick(TObject *Sender)
{
	SettingsLoad(true);
}
//---------------------------------------------------------------------------

void __fastcall TForm1::Dispatch(void *Message)
{
	// the Synaptics API seems to have a problem with
	// power state changes; in particullar, the events
	// get deactivated after standby or hibernation;
	// here we ensure that they stay activated

	if (((TMessage *)Message)->Msg == WM_POWERBROADCAST) {
		reactivateTimer->Tag = 20;
		reactivateTimer->Enabled = true;
	}

	TForm::Dispatch(Message);
}
//---------------------------------------------------------------------------

void __fastcall TForm1::reactivateTimerTimer(TObject *Sender)
{
	synTouchPad->SetSynchronousNotification(this);
	reactivateTimer->Tag--;
	if (!reactivateTimer->Tag) {
		reactivateTimer->Enabled = false;
	}
}
//---------------------------------------------------------------------------

void __fastcall TForm1::Label1Click(TObject *Sender)
{
	Application->MessageBox(
		L"Compatible:\n"
		"The scroll closely simulates a mouse scroll wheel. This mode works with\n"
		"most applications.\n"
		"\n"
		"Smooth:\n"
		"Smooth scrolling. Some older applications may not work propery in this\n"
		"scroll mode.\n"
		"\n"
		"Smart:\n"
		"Uses smooth scrolling by default. Compatible mode can be enabled for\n"
		"specifc applications by scrolling within them while keeping SHIFT, CTRL\n"
		"and ALT keys pressed down. The setting is remembered, all future scrolls\n"
		"in the same application will use the compatible mode. Scrolling with the\n"
		"keys again reverts back to the smooth mode.",
		L"Scroll mode");
}
//---------------------------------------------------------------------------

void __fastcall TForm1::scrollAccEnabledClick(TObject *Sender)
{
	scrollAcc->Enabled = scrollAccEnabled->Checked;
}
//---------------------------------------------------------------------------

void __fastcall TForm1::UpdateDropdowns() {
	int indexLeft = swipeTwoLeft->ItemIndex;
	int indexRight = swipeTwoRight->ItemIndex;
	if(!scrollLinearX->Checked) {  //show everything
		swipeTwoLeft->Items->Clear();
		swipeTwoRight->Items->Clear();
		for(int i=0;i<LEN_swipeTwoFingerOptions;i++) {
			swipeTwoLeft->Items->Add(UnicodeString(swipeTwoFingerOptions[i].label));
			swipeTwoRight->Items->Add(UnicodeString(swipeTwoFingerOptions[i].label));
		}
		swipeTwoLeft->ItemIndex = indexLeft>=LEN_swipeTwoFingerOptions?0:indexLeft;
		swipeTwoRight->ItemIndex = indexRight>=LEN_swipeTwoFingerOptions?0:indexRight;
	}else{  //show less options
		swipeTwoLeft->Items->Clear();
		swipeTwoRight->Items->Clear();
		for(int i=0;i<LEN_swipeTwoFingerOptionsSmall;i++) {
			swipeTwoLeft->Items->Add(UnicodeString(swipeTwoFingerOptionsSmall[i].label));
			swipeTwoRight->Items->Add(UnicodeString(swipeTwoFingerOptionsSmall[i].label));
		}
		swipeTwoLeft->ItemIndex = indexLeft>=LEN_swipeTwoFingerOptionsSmall?0:indexLeft;
		swipeTwoRight->ItemIndex = indexRight>=LEN_swipeTwoFingerOptionsSmall?0:indexRight;
	}
	swipeThreeTop->Items->Clear();
	swipeThreeRight->Items->Clear();
	swipeThreeBottom->Items->Clear();
	swipeThreeLeft->Items->Clear();
	for(int i=0;i<LEN_swipeThreeFingerOptions;i++) {
		swipeThreeTop->Items->Add(UnicodeString(swipeThreeFingerOptions[i].label));
		swipeThreeRight->Items->Add(UnicodeString(swipeThreeFingerOptions[i].label));
		swipeThreeBottom->Items->Add(UnicodeString(swipeThreeFingerOptions[i].label));
		swipeThreeLeft->Items->Add(UnicodeString(swipeThreeFingerOptions[i].label));
	}
}
bool __fastcall TForm1::DoSwipeAction(SWIPE_ACTIONCODE code) {
	SWIPE_ACTION id = SWIPE_UNKNOWN;

	if(code==SWIPE_TWO_LEFT) {
		if(scrollLinearX->Checked) { //small range
			id = swipeTwoFingerOptionsSmall[swipeTwoLeft->ItemIndex].action;
		}else{ //full range
			id = swipeTwoFingerOptions[swipeTwoLeft->ItemIndex].action;
		}
    } else if(code==SWIPE_TWO_RIGHT) {
		if(scrollLinearX->Checked) { //small range
			id = swipeTwoFingerOptionsSmall[swipeTwoRight->ItemIndex].action;
		}else{ //full range
			id = swipeTwoFingerOptions[swipeTwoRight->ItemIndex].action;
		}
	} else if(code==SWIPE_THREE_TOP)
		id = swipeThreeFingerOptions[swipeThreeTop->ItemIndex].action;
	else if(code==SWIPE_THREE_RIGHT)
		id = swipeThreeFingerOptions[swipeThreeRight->ItemIndex].action;
	else if(code==SWIPE_THREE_BOTTOM)
		id = swipeThreeFingerOptions[swipeThreeBottom->ItemIndex].action;
	else if(code==SWIPE_THREE_LEFT)
		id = swipeThreeFingerOptions[swipeThreeLeft->ItemIndex].action;

	if(id==SWIPE_UNKNOWN) return false;
	// Browser back/forward:
	if(id==SWIPE_BROWSER_BACK || id==SWIPE_BROWSER_FORWARD) {
		INPUT i[4];
		ZeroMemory(i, sizeof(INPUT)*4);
		i[0].type = INPUT_KEYBOARD;
		i[0].ki.wVk = VK_MENU;
		i[1].type = INPUT_KEYBOARD;
		i[1].ki.wVk = id==SWIPE_BROWSER_BACK?VK_LEFT:VK_RIGHT;
		i[2].type = INPUT_KEYBOARD;
		i[2].ki.wVk = id==SWIPE_BROWSER_BACK?VK_LEFT:VK_RIGHT;
		i[2].ki.dwFlags = KEYEVENTF_KEYUP;
		i[3].type = INPUT_KEYBOARD;
		i[3].ki.wVk = VK_MENU;
		i[3].ki.dwFlags = KEYEVENTF_KEYUP;
		SendInput(4, i, sizeof(INPUT));
	// Show Desktop:
	}else if(id==SWIPE_SHOW_DESKTOP) {
		INPUT i[4];
		ZeroMemory(i, sizeof(INPUT)*4);
		i[0].type = INPUT_KEYBOARD;
		i[0].ki.wVk = VK_LWIN;
		i[1].type = INPUT_KEYBOARD;
		i[1].ki.dwFlags = KEYEVENTF_SCANCODE;
		i[1].ki.wScan = MapVirtualKey( LOBYTE(VkKeyScan('d')), 0 );
		i[2].type = INPUT_KEYBOARD;
		i[2].ki.wScan = MapVirtualKey( LOBYTE(VkKeyScan('d')), 0 );
		i[2].ki.dwFlags = KEYEVENTF_SCANCODE | KEYEVENTF_KEYUP;
		i[3].type = INPUT_KEYBOARD;
		i[3].ki.wVk = VK_LWIN;
		i[3].ki.dwFlags = KEYEVENTF_KEYUP;
		SendInput(4, i, sizeof(INPUT));
	// Show windows overview
	}else if(id==SWIPE_SHOW_WINDOWS) {
		 INPUT i[6];
		ZeroMemory(i, sizeof(INPUT)*6);
		i[0].type = INPUT_KEYBOARD;
		i[0].ki.wVk = VK_MENU;
		i[1].type = INPUT_KEYBOARD;
		i[1].ki.wVk = VK_CONTROL;
		i[2].type = INPUT_KEYBOARD;
		i[2].ki.wVk = VK_TAB;
		i[3].type = INPUT_KEYBOARD;
		i[3].ki.wVk = VK_TAB;
		i[3].ki.dwFlags = KEYEVENTF_KEYUP;
		i[4].type = INPUT_KEYBOARD;
		i[4].ki.wVk = VK_CONTROL;
		i[4].ki.dwFlags = KEYEVENTF_KEYUP;
		i[5].type = INPUT_KEYBOARD;
		i[5].ki.wVk = VK_MENU;
		i[5].ki.dwFlags = KEYEVENTF_KEYUP;
		SendInput(6, i, sizeof(INPUT));
	// Arrow left/right
	}else if(id==SWIPE_ARROW_LEFT || id==SWIPE_ARROW_RIGHT) {
		INPUT i[2];
		ZeroMemory(i, sizeof(INPUT)*2);
		i[0].type = INPUT_KEYBOARD;
		i[0].ki.wVk = id==SWIPE_ARROW_LEFT?VK_LEFT:VK_RIGHT;
		i[1].type = INPUT_KEYBOARD;
		i[1].ki.wVk = id==SWIPE_ARROW_LEFT?VK_LEFT:VK_RIGHT;
		i[1].ki.dwFlags = KEYEVENTF_KEYUP;
		SendInput(2, i, sizeof(INPUT));
	// Next (Browser) Tab
	}else if(id==SWIPE_TAB_NEXT) {
		INPUT i[4];
		ZeroMemory(i, sizeof(INPUT)*4);
		i[0].type = INPUT_KEYBOARD;
		i[0].ki.wVk = VK_CONTROL;
		i[1].type = INPUT_KEYBOARD;
		i[1].ki.wVk = VK_TAB;
		i[2].type = INPUT_KEYBOARD;
		i[2].ki.wVk = VK_TAB;
		i[2].ki.dwFlags = KEYEVENTF_KEYUP;
		i[3].type = INPUT_KEYBOARD;
		i[3].ki.wVk = VK_CONTROL;
		i[3].ki.dwFlags = KEYEVENTF_KEYUP;
		SendInput(4, i, sizeof(INPUT));
	// Previous (Browser) Tab
	}else if(id==SWIPE_TAB_PREVIOUS) {
		INPUT i[6];
		ZeroMemory(i, sizeof(INPUT)*6);
		i[0].type = INPUT_KEYBOARD;
		i[0].ki.wVk = VK_CONTROL;
		i[1].type = INPUT_KEYBOARD;
		i[1].ki.wVk = VK_SHIFT;
		i[2].type = INPUT_KEYBOARD;
		i[2].ki.wVk = VK_TAB;
		i[3].type = INPUT_KEYBOARD;
		i[3].ki.wVk = VK_TAB;
		i[3].ki.dwFlags = KEYEVENTF_KEYUP;
		i[4].type = INPUT_KEYBOARD;
		i[4].ki.wVk = VK_SHIFT;
		i[4].ki.dwFlags = KEYEVENTF_KEYUP;
		i[5].type = INPUT_KEYBOARD;
		i[5].ki.wVk = VK_CONTROL;
		i[5].ki.dwFlags = KEYEVENTF_KEYUP;
		SendInput(6, i, sizeof(INPUT));
	// next window (ALT+TAB)
	} else if(id==SWIPE_WINDOW_NEXT) {
		INPUT i[4];
		ZeroMemory(i, sizeof(INPUT)*4);
		i[0].type = INPUT_KEYBOARD;
		i[0].ki.wVk = VK_MENU;
		i[1].type = INPUT_KEYBOARD;
		i[1].ki.wVk = VK_TAB;
		i[2].type = INPUT_KEYBOARD;
		i[2].ki.wVk = VK_TAB;
		i[2].ki.dwFlags = KEYEVENTF_KEYUP;
		i[3].type = INPUT_KEYBOARD;
		i[3].ki.wVk = VK_MENU;
		i[3].ki.dwFlags = KEYEVENTF_KEYUP;
		SendInput(4, i, sizeof(INPUT));
	// previous window (ALT+SHIFT+TAB)
	} else if(id==SWIPE_WINDOW_PREVIOUS) {
		INPUT i[6];
		ZeroMemory(i, sizeof(INPUT)*6);
		i[0].type = INPUT_KEYBOARD;
		i[0].ki.wVk = VK_MENU;
		i[1].type = INPUT_KEYBOARD;
		i[1].ki.wVk = VK_SHIFT;
		i[2].type = INPUT_KEYBOARD;
		i[2].ki.wVk = VK_TAB;
		i[3].type = INPUT_KEYBOARD;
		i[3].ki.wVk = VK_TAB;
		i[3].ki.dwFlags = KEYEVENTF_KEYUP;
		i[4].type = INPUT_KEYBOARD;
		i[4].ki.wVk = VK_SHIFT;
		i[4].ki.dwFlags = KEYEVENTF_KEYUP;
		i[5].type = INPUT_KEYBOARD;
		i[5].ki.wVk = VK_MENU;
		i[5].ki.dwFlags = KEYEVENTF_KEYUP;
		SendInput(6, i, sizeof(INPUT));
	// show windows flip
	} else if(id==SWIPE_SHOW_WINDOWS_FLIP) {
		INPUT i[6];
		ZeroMemory(i, sizeof(INPUT)*6);
		i[0].type = INPUT_KEYBOARD;
		i[0].ki.wVk = VK_LWIN;
		i[1].type = INPUT_KEYBOARD;
		i[1].ki.wVk = VK_CONTROL;
		i[2].type = INPUT_KEYBOARD;
		i[2].ki.wVk = VK_TAB;
		i[3].type = INPUT_KEYBOARD;
		i[3].ki.wVk = VK_TAB;
		i[3].ki.dwFlags = KEYEVENTF_KEYUP;
		i[4].type = INPUT_KEYBOARD;
		i[4].ki.wVk = VK_CONTROL;
		i[4].ki.dwFlags = KEYEVENTF_KEYUP;
		i[5].type = INPUT_KEYBOARD;
		i[5].ki.wVk = VK_LWIN;
		i[5].ki.dwFlags = KEYEVENTF_KEYUP;
		SendInput(6, i, sizeof(INPUT));
	// close current (browser) tab (send ctrl+w)
	} else if(id==SWIPE_BROWSER_CLOSE_TAB) {
		INPUT i[4];
		ZeroMemory(i, sizeof(INPUT)*4);
		i[0].type = INPUT_KEYBOARD;
		i[0].ki.wVk = VK_CONTROL;
		i[1].type = INPUT_KEYBOARD;
		i[1].ki.dwFlags = KEYEVENTF_SCANCODE;
		i[1].ki.wScan = MapVirtualKey( LOBYTE(VkKeyScan('w')), 0 );
		i[2].type = INPUT_KEYBOARD;
		i[2].ki.wScan = MapVirtualKey( LOBYTE(VkKeyScan('w')), 0 );
		i[2].ki.dwFlags = KEYEVENTF_SCANCODE | KEYEVENTF_KEYUP;
		i[3].type = INPUT_KEYBOARD;
		i[3].ki.wVk = VK_CONTROL;
		i[3].ki.dwFlags = KEYEVENTF_KEYUP;
		SendInput(4, i, sizeof(INPUT));
	// open new tab (ctrl+t)
	} else if(id==SWIPE_BROWSER_NEW_TAB) {
		INPUT i[4];
		ZeroMemory(i, sizeof(INPUT)*4);
		i[0].type = INPUT_KEYBOARD;
		i[0].ki.wVk = VK_CONTROL;
		i[1].type = INPUT_KEYBOARD;
		i[1].ki.dwFlags = KEYEVENTF_SCANCODE;
		i[1].ki.wScan = MapVirtualKey( LOBYTE(VkKeyScan('t')), 0 );
		i[2].type = INPUT_KEYBOARD;
		i[2].ki.wScan = MapVirtualKey( LOBYTE(VkKeyScan('t')), 0 );
		i[2].ki.dwFlags = KEYEVENTF_SCANCODE | KEYEVENTF_KEYUP;
		i[3].type = INPUT_KEYBOARD;
		i[3].ki.wVk = VK_CONTROL;
		i[3].ki.dwFlags = KEYEVENTF_KEYUP;
		SendInput(4, i, sizeof(INPUT));
	// reopen last tab (ctrl+shift+t)
	} else if(id==SWIPE_BROWSER_REOPEN_LAST_TAB) {
		INPUT i[4];
		ZeroMemory(i, sizeof(INPUT)*4);
		i[0].type = INPUT_KEYBOARD;
		i[0].ki.wVk = VK_CONTROL;
		i[1].type = INPUT_KEYBOARD;
		i[1].ki.wVk = VK_SHIFT;
		i[2].type = INPUT_KEYBOARD;
		i[2].ki.dwFlags = KEYEVENTF_SCANCODE;
		i[2].ki.wScan = MapVirtualKey( LOBYTE(VkKeyScan('t')), 0 );
		i[3].type = INPUT_KEYBOARD;
		i[3].ki.wScan = MapVirtualKey( LOBYTE(VkKeyScan('t')), 0 );
		i[3].ki.dwFlags = KEYEVENTF_SCANCODE | KEYEVENTF_KEYUP;
		i[4].type = INPUT_KEYBOARD;
		i[4].ki.wVk = VK_SHIFT;
		i[4].ki.dwFlags = KEYEVENTF_KEYUP;
		i[5].type = INPUT_KEYBOARD;
		i[5].ki.wVk = VK_CONTROL;
		i[5].ki.dwFlags = KEYEVENTF_KEYUP;
		SendInput(4, i, sizeof(INPUT));
	// send home key
	} else if(id==SWIPE_HOME) {
		INPUT i[2];
		ZeroMemory(i, sizeof(INPUT)*2);
		i[0].type = INPUT_KEYBOARD;
		i[0].ki.wVk = VK_HOME;
		i[1].type = INPUT_KEYBOARD;
		i[1].ki.wVk = VK_HOME;
		i[1].ki.dwFlags = KEYEVENTF_KEYUP;
		SendInput(2, i, sizeof(INPUT));
	// send end key
	} else if(id==SWIPE_END) {
		INPUT i[2];
		ZeroMemory(i, sizeof(INPUT)*2);
		i[0].type = INPUT_KEYBOARD;
		i[0].ki.wVk = VK_END;
		i[1].type = INPUT_KEYBOARD;
		i[1].ki.wVk = VK_END;
		i[1].ki.dwFlags = KEYEVENTF_KEYUP;
		SendInput(2, i, sizeof(INPUT));
	}
	return true;
}


