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
// ************************************************************************ //
#ifndef   SYNCOMLib_OCXH
#define   SYNCOMLib_OCXH

#pragma option push -b -a4 -w-inl

#include <olectrls.hpp>
#include <oleserver.hpp>
#if !defined(__UTILCLS_H)
#include <utilcls.h>
#endif
#if !defined(__UTILCLS_H_VERSION) || (__UTILCLS_H_VERSION < 0x0700)
//
// Der vom Hilfsprogramm TLIBIMP erzeugte Code oder die Funktionen Importieren|Typbibliothek 
// und Importieren|ActiveX von C++Builder arbeiten mit speziellen Versionen der
// Header-Datei UTILCLS.H aus dem Verzeichnis INCLUDE\VCL. Wenn eine 
// ältere Version dieser Datei gefunden wird, müssen Sie eine Aktualisierung/Patchen ausführen.
//
#error "Für diese Datei ist eine neuere Version des Headers UTILCLS.H erforderlich" \r
       "Sie müssen eine Aktualisierung/Patchen für Ihre C++Builder-Version durchführen"
#endif
#include <olectl.h>
#include <ocidl.h>
#if !defined(_NO_VCL)
#include <stdvcl.hpp>
#endif  //   _NO_VCL
#include <ocxproxy.h>

#include "SYNCOMLib_TLB.h"
namespace Syncomlib_tlb
{

// *********************************************************************//
// Hilfe-String: SynCom 2.0 Type Library
// Version:    2.0
// *********************************************************************//


// *********************************************************************//
// Deklaration der Proxy-Klasse der COM-Komponente
// Komponentenname   : TSynAPI
// Hilfe-String      : SynAPI Class
// Standard-Interface: ISynAPI
// Def. Intf. Objekt: ISynAPIPtr
// Def. Intf. DISP? : No
// Ereignis-Interface: 
// TypeFlags        : (2) CanCreate
// *********************************************************************//
class PACKAGE TSynAPI : public Oleserver::TOleServer
{
  ISynAPIPtr m_DefaultIntf;
  _di_IUnknown __fastcall GetDunk();
public:
  __fastcall TSynAPI(TComponent* owner) : Oleserver::TOleServer(owner)
  {}

  ISynAPIPtr& GetDefaultInterface();
  void __fastcall InitServerData();
  void __fastcall Connect();
  void __fastcall Disconnect();
  void __fastcall BeforeDestruction();
  void __fastcall ConnectTo(ISynAPIPtr intf);


  void            __fastcall Initialize(void);
  void            __fastcall FindDevice(long lConnectionType, long lDeviceType, long* ulHandle);
  void            __fastcall CreateDevice(long lHandle, Syncomlib_tlb::ISynDevice** ppDevice);
  void            __fastcall GetProperty(long lSpecifier, long* pValue);
  void            __fastcall GetStringProperty(long lSpecifier, unsigned_char* pBuffer, 
                                               long* ulBufLen);
  void            __fastcall SetProperty(long lSpecifier, long lValue);
  void            __fastcall SetEventNotification(void* hEvent);
  void            __fastcall GetEventParameter(long* lParameter);
  void            __fastcall PersistState(long lStateFlags);
  void            __fastcall RestoreState(long lStateFlags);
  void            __fastcall HardwareBroadcast(long lAction);
  void            __fastcall SetSynchronousNotification(Syncomlib_tlb::_ISynAPIEvents* pCallbackInstance);
  void            __fastcall ForwardSystemMessage(unsigned uMsg, Syncomlib_tlb::UINT_PTR wParam, 
                                                  Syncomlib_tlb::LONG_PTR lParam);
};


// *********************************************************************//
// Deklaration der Proxy-Klasse der COM-Komponente
// Komponentenname   : TSynDevice
// Hilfe-String      : SynDevice Class
// Standard-Interface: ISynDevice
// Def. Intf. Objekt: ISynDevicePtr
// Def. Intf. DISP? : No
// Ereignis-Interface: 
// TypeFlags        : (2) CanCreate
// *********************************************************************//
class PACKAGE TSynDevice : public Oleserver::TOleServer
{
  ISynDevicePtr m_DefaultIntf;
  _di_IUnknown __fastcall GetDunk();
public:
  __fastcall TSynDevice(TComponent* owner) : Oleserver::TOleServer(owner)
  {}

  ISynDevicePtr& GetDefaultInterface();
  void __fastcall InitServerData();
  void __fastcall Connect();
  void __fastcall Disconnect();
  void __fastcall BeforeDestruction();
  void __fastcall ConnectTo(ISynDevicePtr intf);


  void            __fastcall GetProperty(long lSpecifier, long* pValue);
  void            __fastcall GetBooleanProperty(long lSpecifier, long* pValue);
  void            __fastcall GetStringProperty(long lSpecifier, unsigned_char* pBuffer, 
                                               long* ulBufLen);
  void            __fastcall SetProperty(long lSpecifier, long lValue);
  void            __fastcall SetEventNotification(void* hEvent);
  void            __fastcall CreatePacket(Syncomlib_tlb::ISynPacket** ppPacket);
  void            __fastcall LoadPacket(Syncomlib_tlb::ISynPacket* pPacket);
  void            __fastcall ForceMotion(long lDeltaX, long lDeltaY, long lButtonState);
  void            __fastcall ForcePacket(Syncomlib_tlb::ISynPacket* pPacket);
  void            __fastcall Acquire(long lFlags);
  void            __fastcall Unacquire(void);
  void            __fastcall CreateDisplay(Syncomlib_tlb::ISynDisplay** ppDisplay);
  void            __fastcall Select(long lHandle);
  void            __fastcall PeekPacket(long* plSequence);
  void            __fastcall SetSynchronousNotification(Syncomlib_tlb::_ISynDeviceEvents* pCallbackInstance);
  void            __fastcall GetPropertyDefault(long lSpecifier, long* pValue);
  void            __fastcall BulkTransaction(unsigned_long ulWriteLength, 
                                             unsigned_char* ucWriteBuffer, 
                                             unsigned_long ulReadLength, unsigned_char* ucReadBuffer);
  void            __fastcall DiagnosticTransaction(unsigned_long ulWriteLength, 
                                                   unsigned_char* ucWriteBuffer, 
                                                   unsigned_long ulReadLength, 
                                                   unsigned_char* ucReadBuffer);
  void            __fastcall DiagnosticSelect(long lHandle, long lFlags);
  void            __fastcall ForceMotionWithWheel(long lDeltaX, long lDeltaY, long lButtonState, 
                                                  long lWheelDelta);
  void            __fastcall ValidateProperty(long lSpecifier, long lSynAccessRightType);
  void            __fastcall ForceSecondaryFingerPacket(Syncomlib_tlb::ISynPacket* pPacket);
};


// *********************************************************************//
// Deklaration der Proxy-Klasse der COM-Komponente
// Komponentenname   : TSynPacket
// Hilfe-String      : SynPacket Class
// Standard-Interface: ISynPacket
// Def. Intf. Objekt: ISynPacketPtr
// Def. Intf. DISP? : No
// Ereignis-Interface: 
// TypeFlags        : (2) CanCreate
// *********************************************************************//
class PACKAGE TSynPacket : public Oleserver::TOleServer
{
  ISynPacketPtr m_DefaultIntf;
  _di_IUnknown __fastcall GetDunk();
public:
  __fastcall TSynPacket(TComponent* owner) : Oleserver::TOleServer(owner)
  {}

  ISynPacketPtr& GetDefaultInterface();
  void __fastcall InitServerData();
  void __fastcall Connect();
  void __fastcall Disconnect();
  void __fastcall BeforeDestruction();
  void __fastcall ConnectTo(ISynPacketPtr intf);


  void            __fastcall GetProperty(long lSpecifier, long* pValue);
  void            __fastcall SetProperty(long lSpecifier, long lValue);
  void            __fastcall GetStringProperty(long lSpecifier, unsigned_char* pBuffer, 
                                               long* ulBufLen);
  void            __fastcall Copy(Syncomlib_tlb::ISynPacket* pFrom);
};


// *********************************************************************//
// Deklaration der Proxy-Klasse der COM-Komponente
// Komponentenname   : TSynDisplay
// Hilfe-String      : SynDisplay Class
// Standard-Interface: ISynDisplay
// Def. Intf. Objekt: ISynDisplayPtr
// Def. Intf. DISP? : No
// Ereignis-Interface: 
// TypeFlags        : (2) CanCreate
// *********************************************************************//
class PACKAGE TSynDisplay : public Oleserver::TOleServer
{
  ISynDisplayPtr m_DefaultIntf;
  _di_IUnknown __fastcall GetDunk();
public:
  __fastcall TSynDisplay(TComponent* owner) : Oleserver::TOleServer(owner)
  {}

  ISynDisplayPtr& GetDefaultInterface();
  void __fastcall InitServerData();
  void __fastcall Connect();
  void __fastcall Disconnect();
  void __fastcall BeforeDestruction();
  void __fastcall ConnectTo(ISynDisplayPtr intf);


  void            __fastcall GetProperty(long lSpecifier, long* pValue);
  void            __fastcall SetProperty(long lSpecifier, long lValue);
  void            __fastcall PixelToTouch(long PixelX, long PixelY, long* pTouchX, long* pTouchY);
  void            __fastcall TouchToPixel(long TouchX, long TouchY, long* pPixelX, long* pPixelY);
  void            __fastcall GetDC(Syncomlib_tlb::wireHDC* pHDC);
  void            __fastcall FlushDC(long lFlags);
  void            __fastcall Acquire(long lDisplayAcquisitionMethod);
  void            __fastcall Unacquire(void);
  void            __fastcall Select(long lDeviceHandle);
  void            __fastcall SetEventNotification(void* hEvent);
  void            __fastcall GetEventParameter(long* lParameter);
  void            __fastcall SetSynchronousNotification(Syncomlib_tlb::_ISynDisplayEvents* pCallbackInstance);
  void            __fastcall GetStringProperty(long lSpecifier, unsigned_char* pBuffer, 
                                               long* ulBufLen);
  void            __fastcall SetBackgroundImage(Syncomlib_tlb::wireHBITMAP hBmp);
  void            __fastcall CloneBackgroundImage(Syncomlib_tlb::wireHBITMAP* pHBmp);
};

};     // namespace Syncomlib_tlb

#if !defined(NO_IMPLICIT_NAMESPACE_USE)
using  namespace Syncomlib_tlb;
#endif

#pragma option pop

#endif // SYNCOMLib_OCXH
