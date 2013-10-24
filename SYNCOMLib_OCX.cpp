// ************************************************************************ //
// WARNUNG                                                                    
// -------                                                                    
// Die in dieser Datei deklarierten Typen wurden aus Daten einer Typbibliothek
// generiert. Wenn diese Typbibliothek explizit oder indirekt (über eine     
// andere Typbibliothek) reimportiert wird oder wenn der Befehl            
// 'Aktualisieren' im Typbibliotheks-Editor während des Bearbeitens der     
// Typbibliothek aktiviert ist, wird der Inhalt dieser Datei neu generiert und 
// alle manuell vorgenommenen Änderungen gehen verloren.                                        
// ************************************************************************ //

// $Rev: 16580 $
// Datei am 13.10.2008 18:16:29 erzeugt aus der unten beschriebenen Typbibliothek.

// ************************************************************************  //
// Typbib.: C:\WINDOWS\system32\SynCOM.dll (1)
// LIBID: {E2489565-2CE5-4690-9111-76E79A9F6CCD}
// LCID: 0
// Hilfedatei: 
// Hilfe-String: SynCom 2.0 Type Library
// Liste der Abhäng.: 
//   (1) v2.0 stdole, (C:\WINDOWS\System32\stdole2.tlb)
// Fehler//   Fehler beim Erzeugen von Palettenbitmap von (TSynAPI) : Server C:\WINDOWS\system32\SynCOM.dll enthält keine Symbole
//   Fehler beim Erzeugen von Palettenbitmap von (TSynDevice) : Server C:\WINDOWS\system32\SynCOM.dll enthält keine Symbole
//   Fehler beim Erzeugen von Palettenbitmap von (TSynPacket) : Server C:\WINDOWS\system32\SynCOM.dll enthält keine Symbole
//   Fehler beim Erzeugen von Palettenbitmap von (TSynDisplay) : Server C:\WINDOWS\system32\SynCOM.dll enthält keine Symbole
// ************************************************************************ //

#include <vcl.h>
#pragma hdrstop

#include <olectrls.hpp>
#include <oleserver.hpp>
#if defined(USING_ATL)
#include <atl\atlvcl.h>
#endif

#include "SYNCOMLib_OCX.h"

#if !defined(__PRAGMA_PACKAGE_SMART_INIT)
#define      __PRAGMA_PACKAGE_SMART_INIT
#pragma package(smart_init)
#endif

namespace Syncomlib_tlb
{

ISynAPIPtr& TSynAPI::GetDefaultInterface()
{
  if (!m_DefaultIntf)
    Connect();
  return m_DefaultIntf;
}

_di_IUnknown __fastcall TSynAPI::GetDunk()
{
  _di_IUnknown diUnk;
  if (m_DefaultIntf) {
    IUnknownPtr punk = m_DefaultIntf;
    diUnk = LPUNKNOWN(punk);
  }
  return diUnk;
}

void __fastcall TSynAPI::Connect()
{
  if (!m_DefaultIntf) {
    _di_IUnknown punk = GetServer();
    m_DefaultIntf = punk;
    if (ServerData->EventIID != GUID_NULL)
      ConnectEvents(GetDunk());
  }
}

void __fastcall TSynAPI::Disconnect()
{
  if (m_DefaultIntf) {

    if (ServerData->EventIID != GUID_NULL)
      DisconnectEvents(GetDunk());
    m_DefaultIntf.Reset();
  }
}

void __fastcall TSynAPI::BeforeDestruction()
{
  Disconnect();
}

void __fastcall TSynAPI::ConnectTo(ISynAPIPtr intf)
{
  Disconnect();
  m_DefaultIntf = intf;
  if (ServerData->EventIID != GUID_NULL)
    ConnectEvents(GetDunk());
}

void __fastcall TSynAPI::InitServerData()
{
  static Oleserver::TServerData sd;
  sd.ClassID = CLSID_SynAPI;
  sd.IntfIID = __uuidof(ISynAPI);
  sd.EventIID= GUID_NULL;
  ServerData = &sd;
}

void __fastcall TSynAPI::Initialize(void)
{
  GetDefaultInterface()->Initialize();
}

void __fastcall TSynAPI::FindDevice(long lConnectionType, long lDeviceType, long* ulHandle)
{
  GetDefaultInterface()->FindDevice(lConnectionType, lDeviceType, ulHandle);
}

void __fastcall TSynAPI::CreateDevice(long lHandle, Syncomlib_tlb::ISynDevice** ppDevice)
{
  GetDefaultInterface()->CreateDevice(lHandle, ppDevice);
}

void __fastcall TSynAPI::GetProperty(long lSpecifier, long* pValue)
{
  GetDefaultInterface()->GetProperty(lSpecifier, pValue);
}

void __fastcall TSynAPI::GetStringProperty(long lSpecifier, unsigned_char* pBuffer, long* ulBufLen)
{
  GetDefaultInterface()->GetStringProperty(lSpecifier, pBuffer, ulBufLen);
}

void __fastcall TSynAPI::SetProperty(long lSpecifier, long lValue)
{
  GetDefaultInterface()->SetProperty(lSpecifier, lValue);
}

void __fastcall TSynAPI::SetEventNotification(void* hEvent)
{
  GetDefaultInterface()->SetEventNotification(hEvent);
}

void __fastcall TSynAPI::GetEventParameter(long* lParameter)
{
  GetDefaultInterface()->GetEventParameter(lParameter);
}

void __fastcall TSynAPI::PersistState(long lStateFlags)
{
  GetDefaultInterface()->PersistState(lStateFlags);
}

void __fastcall TSynAPI::RestoreState(long lStateFlags)
{
  GetDefaultInterface()->RestoreState(lStateFlags);
}

void __fastcall TSynAPI::HardwareBroadcast(long lAction)
{
  GetDefaultInterface()->HardwareBroadcast(lAction);
}

void __fastcall TSynAPI::SetSynchronousNotification(Syncomlib_tlb::_ISynAPIEvents* pCallbackInstance)
{
  GetDefaultInterface()->SetSynchronousNotification(pCallbackInstance);
}

void __fastcall TSynAPI::ForwardSystemMessage(unsigned uMsg, Syncomlib_tlb::UINT_PTR wParam, 
                                              Syncomlib_tlb::LONG_PTR lParam)
{
  GetDefaultInterface()->ForwardSystemMessage(uMsg, wParam, lParam);
}

ISynDevicePtr& TSynDevice::GetDefaultInterface()
{
  if (!m_DefaultIntf)
    Connect();
  return m_DefaultIntf;
}

_di_IUnknown __fastcall TSynDevice::GetDunk()
{
  _di_IUnknown diUnk;
  if (m_DefaultIntf) {
    IUnknownPtr punk = m_DefaultIntf;
    diUnk = LPUNKNOWN(punk);
  }
  return diUnk;
}

void __fastcall TSynDevice::Connect()
{
  if (!m_DefaultIntf) {
    _di_IUnknown punk = GetServer();
    m_DefaultIntf = punk;
    if (ServerData->EventIID != GUID_NULL)
      ConnectEvents(GetDunk());
  }
}

void __fastcall TSynDevice::Disconnect()
{
  if (m_DefaultIntf) {

    if (ServerData->EventIID != GUID_NULL)
      DisconnectEvents(GetDunk());
    m_DefaultIntf.Reset();
  }
}

void __fastcall TSynDevice::BeforeDestruction()
{
  Disconnect();
}

void __fastcall TSynDevice::ConnectTo(ISynDevicePtr intf)
{
  Disconnect();
  m_DefaultIntf = intf;
  if (ServerData->EventIID != GUID_NULL)
    ConnectEvents(GetDunk());
}

void __fastcall TSynDevice::InitServerData()
{
  static Oleserver::TServerData sd;
  sd.ClassID = CLSID_SynDevice;
  sd.IntfIID = __uuidof(ISynDevice);
  sd.EventIID= GUID_NULL;
  ServerData = &sd;
}

void __fastcall TSynDevice::GetProperty(long lSpecifier, long* pValue)
{
  GetDefaultInterface()->GetProperty(lSpecifier, pValue);
}

void __fastcall TSynDevice::GetBooleanProperty(long lSpecifier, long* pValue)
{
  GetDefaultInterface()->GetBooleanProperty(lSpecifier, pValue);
}

void __fastcall TSynDevice::GetStringProperty(long lSpecifier, unsigned_char* pBuffer, 
                                              long* ulBufLen)
{
  GetDefaultInterface()->GetStringProperty(lSpecifier, pBuffer, ulBufLen);
}

void __fastcall TSynDevice::SetProperty(long lSpecifier, long lValue)
{
  GetDefaultInterface()->SetProperty(lSpecifier, lValue);
}

void __fastcall TSynDevice::SetEventNotification(void* hEvent)
{
  GetDefaultInterface()->SetEventNotification(hEvent);
}

void __fastcall TSynDevice::CreatePacket(Syncomlib_tlb::ISynPacket** ppPacket)
{
  GetDefaultInterface()->CreatePacket(ppPacket);
}

void __fastcall TSynDevice::LoadPacket(Syncomlib_tlb::ISynPacket* pPacket)
{
  GetDefaultInterface()->LoadPacket(pPacket);
}

void __fastcall TSynDevice::ForceMotion(long lDeltaX, long lDeltaY, long lButtonState)
{
  GetDefaultInterface()->ForceMotion(lDeltaX, lDeltaY, lButtonState);
}

void __fastcall TSynDevice::ForcePacket(Syncomlib_tlb::ISynPacket* pPacket)
{
  GetDefaultInterface()->ForcePacket(pPacket);
}

void __fastcall TSynDevice::Acquire(long lFlags)
{
  GetDefaultInterface()->Acquire(lFlags);
}

void __fastcall TSynDevice::Unacquire(void)
{
  GetDefaultInterface()->Unacquire();
}

void __fastcall TSynDevice::CreateDisplay(Syncomlib_tlb::ISynDisplay** ppDisplay)
{
  GetDefaultInterface()->CreateDisplay(ppDisplay);
}

void __fastcall TSynDevice::Select(long lHandle)
{
  GetDefaultInterface()->Select(lHandle);
}

void __fastcall TSynDevice::PeekPacket(long* plSequence)
{
  GetDefaultInterface()->PeekPacket(plSequence);
}

void __fastcall TSynDevice::SetSynchronousNotification(Syncomlib_tlb::_ISynDeviceEvents* pCallbackInstance)
{
  GetDefaultInterface()->SetSynchronousNotification(pCallbackInstance);
}

void __fastcall TSynDevice::GetPropertyDefault(long lSpecifier, long* pValue)
{
  GetDefaultInterface()->GetPropertyDefault(lSpecifier, pValue);
}

void __fastcall TSynDevice::BulkTransaction(unsigned_long ulWriteLength, 
                                            unsigned_char* ucWriteBuffer, unsigned_long ulReadLength, 
                                            unsigned_char* ucReadBuffer)
{
  GetDefaultInterface()->BulkTransaction(ulWriteLength, ucWriteBuffer, ulReadLength, ucReadBuffer);
}

void __fastcall TSynDevice::DiagnosticTransaction(unsigned_long ulWriteLength, 
                                                  unsigned_char* ucWriteBuffer, 
                                                  unsigned_long ulReadLength, 
                                                  unsigned_char* ucReadBuffer)
{
  GetDefaultInterface()->DiagnosticTransaction(ulWriteLength, ucWriteBuffer, ulReadLength, 
                                               ucReadBuffer);
}

void __fastcall TSynDevice::DiagnosticSelect(long lHandle, long lFlags)
{
  GetDefaultInterface()->DiagnosticSelect(lHandle, lFlags);
}

void __fastcall TSynDevice::ForceMotionWithWheel(long lDeltaX, long lDeltaY, long lButtonState, 
                                                 long lWheelDelta)
{
  GetDefaultInterface()->ForceMotionWithWheel(lDeltaX, lDeltaY, lButtonState, lWheelDelta);
}

void __fastcall TSynDevice::ValidateProperty(long lSpecifier, long lSynAccessRightType)
{
  GetDefaultInterface()->ValidateProperty(lSpecifier, lSynAccessRightType);
}

void __fastcall TSynDevice::ForceSecondaryFingerPacket(Syncomlib_tlb::ISynPacket* pPacket)
{
  GetDefaultInterface()->ForceSecondaryFingerPacket(pPacket);
}

ISynPacketPtr& TSynPacket::GetDefaultInterface()
{
  if (!m_DefaultIntf)
    Connect();
  return m_DefaultIntf;
}

_di_IUnknown __fastcall TSynPacket::GetDunk()
{
  _di_IUnknown diUnk;
  if (m_DefaultIntf) {
    IUnknownPtr punk = m_DefaultIntf;
    diUnk = LPUNKNOWN(punk);
  }
  return diUnk;
}

void __fastcall TSynPacket::Connect()
{
  if (!m_DefaultIntf) {
    _di_IUnknown punk = GetServer();
    m_DefaultIntf = punk;
    if (ServerData->EventIID != GUID_NULL)
      ConnectEvents(GetDunk());
  }
}

void __fastcall TSynPacket::Disconnect()
{
  if (m_DefaultIntf) {

    if (ServerData->EventIID != GUID_NULL)
      DisconnectEvents(GetDunk());
    m_DefaultIntf.Reset();
  }
}

void __fastcall TSynPacket::BeforeDestruction()
{
  Disconnect();
}

void __fastcall TSynPacket::ConnectTo(ISynPacketPtr intf)
{
  Disconnect();
  m_DefaultIntf = intf;
  if (ServerData->EventIID != GUID_NULL)
    ConnectEvents(GetDunk());
}

void __fastcall TSynPacket::InitServerData()
{
  static Oleserver::TServerData sd;
  sd.ClassID = CLSID_SynPacket;
  sd.IntfIID = __uuidof(ISynPacket);
  sd.EventIID= GUID_NULL;
  ServerData = &sd;
}

void __fastcall TSynPacket::GetProperty(long lSpecifier, long* pValue)
{
  GetDefaultInterface()->GetProperty(lSpecifier, pValue);
}

void __fastcall TSynPacket::SetProperty(long lSpecifier, long lValue)
{
  GetDefaultInterface()->SetProperty(lSpecifier, lValue);
}

void __fastcall TSynPacket::GetStringProperty(long lSpecifier, unsigned_char* pBuffer, 
                                              long* ulBufLen)
{
  GetDefaultInterface()->GetStringProperty(lSpecifier, pBuffer, ulBufLen);
}

void __fastcall TSynPacket::Copy(Syncomlib_tlb::ISynPacket* pFrom)
{
  GetDefaultInterface()->Copy(pFrom);
}

ISynDisplayPtr& TSynDisplay::GetDefaultInterface()
{
  if (!m_DefaultIntf)
    Connect();
  return m_DefaultIntf;
}

_di_IUnknown __fastcall TSynDisplay::GetDunk()
{
  _di_IUnknown diUnk;
  if (m_DefaultIntf) {
    IUnknownPtr punk = m_DefaultIntf;
    diUnk = LPUNKNOWN(punk);
  }
  return diUnk;
}

void __fastcall TSynDisplay::Connect()
{
  if (!m_DefaultIntf) {
    _di_IUnknown punk = GetServer();
    m_DefaultIntf = punk;
    if (ServerData->EventIID != GUID_NULL)
      ConnectEvents(GetDunk());
  }
}

void __fastcall TSynDisplay::Disconnect()
{
  if (m_DefaultIntf) {

    if (ServerData->EventIID != GUID_NULL)
      DisconnectEvents(GetDunk());
    m_DefaultIntf.Reset();
  }
}

void __fastcall TSynDisplay::BeforeDestruction()
{
  Disconnect();
}

void __fastcall TSynDisplay::ConnectTo(ISynDisplayPtr intf)
{
  Disconnect();
  m_DefaultIntf = intf;
  if (ServerData->EventIID != GUID_NULL)
    ConnectEvents(GetDunk());
}

void __fastcall TSynDisplay::InitServerData()
{
  static Oleserver::TServerData sd;
  sd.ClassID = CLSID_SynDisplay;
  sd.IntfIID = __uuidof(ISynDisplay);
  sd.EventIID= GUID_NULL;
  ServerData = &sd;
}

void __fastcall TSynDisplay::GetProperty(long lSpecifier, long* pValue)
{
  GetDefaultInterface()->GetProperty(lSpecifier, pValue);
}

void __fastcall TSynDisplay::SetProperty(long lSpecifier, long lValue)
{
  GetDefaultInterface()->SetProperty(lSpecifier, lValue);
}

void __fastcall TSynDisplay::PixelToTouch(long PixelX, long PixelY, long* pTouchX, long* pTouchY)
{
  GetDefaultInterface()->PixelToTouch(PixelX, PixelY, pTouchX, pTouchY);
}

void __fastcall TSynDisplay::TouchToPixel(long TouchX, long TouchY, long* pPixelX, long* pPixelY)
{
  GetDefaultInterface()->TouchToPixel(TouchX, TouchY, pPixelX, pPixelY);
}

void __fastcall TSynDisplay::GetDC(Syncomlib_tlb::wireHDC* pHDC)
{
  GetDefaultInterface()->GetDC(pHDC);
}

void __fastcall TSynDisplay::FlushDC(long lFlags)
{
  GetDefaultInterface()->FlushDC(lFlags);
}

void __fastcall TSynDisplay::Acquire(long lDisplayAcquisitionMethod)
{
  GetDefaultInterface()->Acquire(lDisplayAcquisitionMethod);
}

void __fastcall TSynDisplay::Unacquire(void)
{
  GetDefaultInterface()->Unacquire();
}

void __fastcall TSynDisplay::Select(long lDeviceHandle)
{
  GetDefaultInterface()->Select(lDeviceHandle);
}

void __fastcall TSynDisplay::SetEventNotification(void* hEvent)
{
  GetDefaultInterface()->SetEventNotification(hEvent);
}

void __fastcall TSynDisplay::GetEventParameter(long* lParameter)
{
  GetDefaultInterface()->GetEventParameter(lParameter);
}

void __fastcall TSynDisplay::SetSynchronousNotification(Syncomlib_tlb::_ISynDisplayEvents* pCallbackInstance)
{
  GetDefaultInterface()->SetSynchronousNotification(pCallbackInstance);
}

void __fastcall TSynDisplay::GetStringProperty(long lSpecifier, unsigned_char* pBuffer, 
                                               long* ulBufLen)
{
  GetDefaultInterface()->GetStringProperty(lSpecifier, pBuffer, ulBufLen);
}

void __fastcall TSynDisplay::SetBackgroundImage(Syncomlib_tlb::wireHBITMAP hBmp)
{
  GetDefaultInterface()->SetBackgroundImage(hBmp);
}

void __fastcall TSynDisplay::CloneBackgroundImage(Syncomlib_tlb::wireHBITMAP* pHBmp)
{
  GetDefaultInterface()->CloneBackgroundImage(pHBmp);
}


};     // namespace Syncomlib_tlb


// *********************************************************************//
// Die Funktion Register wird aufgerufen, wenn dieses Modul 
// in einem Package installiert wird. Sie stellt die Liste der von 
// diesem Modul implementierten Komponenten (inkl. OCX) 
// zur Verfügung. Die folgende Implementierung informiert die IDE über 
// die OCX-Proxy-Klassen, die hier implementiert sind.
// *********************************************************************//
namespace Syncomlib_ocx
{

void __fastcall PACKAGE Register()
{
  // [4]
  TComponentClass cls_svr[] = {
                              __classid(Syncomlib_tlb::TSynAPI), 
                              __classid(Syncomlib_tlb::TSynDevice), 
                              __classid(Syncomlib_tlb::TSynPacket), 
                              __classid(Syncomlib_tlb::TSynDisplay)
                           };
  RegisterComponents("Zusätzlich", cls_svr,
                     sizeof(cls_svr)/sizeof(cls_svr[0])-1);
}

};     // namespace Syncomlib_ocx
