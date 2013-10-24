//---------------------------------------------------------------------------

#ifndef mainwindowH
#define mainwindowH
//---------------------------------------------------------------------------
#include <Classes.hpp>
#include <Controls.hpp>
#include <StdCtrls.hpp>
#include <Forms.hpp>
#include <ComCtrls.hpp>
#include <ExtCtrls.hpp>
#include <Menus.hpp>
#include <Registry.hpp>
#include <OleCtrls.hpp>
#include "SYNCOMLib_OCX.h"
#include <AppEvnts.hpp>
#include "LMDCustomComponent.hpp"
#include "LMDTrayIcon.hpp"
#include "LMDWndProcComponent.hpp"
#define WM_TRAYNOTIFY  WM_USER + 1001

//---------------------------------------------------------------------------
class TForm1 : public TForm, public _ISynDeviceEvents
{
__published:	// IDE-verwaltete Komponenten
	TButton *ok;
	TButton *cancel;
	TPopupMenu *PopupMenu1;
	TMenuItem *Settings1;
	TMenuItem *About1;
	TMenuItem *Exit1;
	TMenuItem *globalActive;
	TMenuItem *N1;
	TButton *defaults;
	TTimer *reactivateTimer;
	TPageControl *pages;
	TTabSheet *generalTab;
	TGroupBox *GroupBox4;
	TTabSheet *scrollTab;
	TGroupBox *GroupBox2;
	TLabel *scrollSpeedLabel;
	TTrackBar *scrollAcc;
	TCheckBox *scrollAccEnabled;
	TTrackBar *scrollSpeed;
	TTabSheet *tapTab;
	TGroupBox *GroupBox5;
	TLabel *tapMaxDistanceLabel;
	TLabel *Label2;
	TLabel *Label3;
	TLabel *Label4;
	TLabel *Label5;
	TTrackBar *tapMaxDistance;
	TComboBox *tapOneOne;
	TComboBox *tapThree;
	TComboBox *tapTwo;
	TComboBox *tapTwoOne;
	TCheckBox *startWithWindows;
	TTabSheet *swipeTab;
	TGroupBox *GroupBox6;
	TLabel *Label1;
	TComboBox *swipeTwoLeft;
	TLabel *Label6;
	TLabel *Label7;
	TComboBox *swipeTwoRight;
	TGroupBox *GroupBox8;
	TCheckBox *scrollLinearEdgeY;
	TRadioButton *scrollOffY;
	TRadioButton *scrollLinearY;
	TGroupBox *GroupBox1;
	TCheckBox *scrollLinearEdgeX;
	TRadioButton *scrollLinearX;
	TRadioButton *scrollOffX;
	TGroupBox *GroupBox3;
	TRadioButton *scrollCompatible;
	TRadioButton *scrollSmooth;
	TLabel *Label8;
	TLabel *lblHintScrolling;
	TGroupBox *GroupBox7;
	TLabel *Label9;
	TLabel *Label10;
	TComboBox *swipeThreeTop;
	TComboBox *swipeThreeBottom;
	TLabel *Label11;
	TLabel *Label12;
	TComboBox *swipeThreeRight;
	TComboBox *swipeThreeLeft;
	TTrayIcon *TrayIcon1;
	TCheckBox *scrollReverse;
	void __fastcall Settings1Click(TObject *Sender);
	void __fastcall FormClose(TObject *Sender, TCloseAction &Action);
	void __fastcall scrollLinearXClick(TObject *Sender);
	void __fastcall Exit1Click(TObject *Sender);
	void __fastcall okClick(TObject *Sender);
	void __fastcall cancelClick(TObject *Sender);
	void __fastcall About1Click(TObject *Sender);
	void __fastcall defaultsClick(TObject *Sender);
	void __fastcall reactivateTimerTimer(TObject *Sender);
	void __fastcall Label1Click(TObject *Sender);
	void __fastcall scrollAccEnabledClick(TObject *Sender);
	void __fastcall scrollLinearYClick(TObject *Sender);

protected:
    void __fastcall Dispatch(void *Message);
private:	// Benutzer Deklarationen
	enum SWIPE_ACTIONCODE {
		SWIPE_TWO_LEFT=1,
		SWIPE_TWO_RIGHT=2,
		SWIPE_THREE_TOP=3,
		SWIPE_THREE_RIGHT=4,
		SWIPE_THREE_BOTTOM=5,
		SWIPE_THREE_LEFT=6
    };
	TRegistry *settings;
	HRESULT STDMETHODCALLTYPE OnSynDevicePacket(long);
	TSynAPI *synAPI;
	TSynDevice *synTouchPad;
	ISynPacket *synPacket;
	bool IsPadAcquired;
	bool synTapState;
	bool IsDeviceTapLocked;
	long tapLastNof;
	long tapStartTime, tapTouchTime, scrollTouchTime;
	long tapDistance;
	POINT tapTouchPos, scrollTouchPos;
	long scrollBufferX, scrollBufferY;
	long scrollLastXDelta, scrollLastYDelta;
	long swipeXDelta, swipeYDelta;
	bool swipeDone;
	bool scrollNotEdgeX, scrollNotEdgeY;
	int scrollMode;
	SCROLL_DIRECTION scrollDir;
	void __fastcall SettingsLoad(bool=false);
	void __fastcall SettingsSave();
	void __fastcall AcquirePad(bool);
	void __fastcall LockDeviceTap(bool);
	bool __fastcall DoTap(int);
	bool __fastcall DoScroll(long, long);
	bool __fastcall DoSwipeAction(SWIPE_ACTIONCODE);
    void __fastcall UpdateDropdowns();

public:		// Benutzer Deklarationen
	__fastcall TForm1(TComponent* Owner);
};
//---------------------------------------------------------------------------
extern PACKAGE TForm1 *Form1;
//---------------------------------------------------------------------------
#endif
