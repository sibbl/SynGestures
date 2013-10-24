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
#ifndef   SYNCOMLib_TLBH
#define   SYNCOMLib_TLBH

#pragma option push -b -a4 -w-inl

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
#if defined(USING_ATLVCL) || defined(USING_ATL)
#if !defined(__TLB_NO_EVENT_WRAPPERS)
#include <atl/atlmod.h>
#endif
#endif


// *********************************************************************//
// Forward-Referenz einiger VCL-Typen (zur Vermeidung des Einbeziehens von STDVCL.HPP)    
// *********************************************************************//
namespace Stdvcl {class IStrings; class IStringsDisp;}
using namespace Stdvcl;
typedef TComInterface<IStrings> IStringsPtr;
typedef TComInterface<IStringsDisp> IStringsDispPtr;

namespace Syncomlib_tlb
{

// *********************************************************************//
// Hilfe-String: SynCom 2.0 Type Library
// Version:    2.0
// *********************************************************************//

// *********************************************************************//
// In der Typbibliothek deklarierte GUIDS. Die folgenden Präfixe werden verwendet:        
//   Typbibliotheken      : LIBID_xxxx                                      
//   CoClasses            : CLSID_xxxx                                      
//   DISPInterfaces       : DIID_xxxx                                       
//   Nicht-DISP-Interfaces: IID_xxxx                                        
// *********************************************************************//
extern __declspec (package) const GUID LIBID_SYNCOMLib;
extern __declspec (package) const GUID IID_ISynAPI;
extern __declspec (package) const GUID CLSID_SynAPI;
extern __declspec (package) const GUID IID_ISynDevice;
extern __declspec (package) const GUID IID_ISynPacket;
extern __declspec (package) const GUID IID_ISynDisplay;
extern __declspec (package) const GUID GUID_wireHDC;
extern __declspec (package) const GUID GUID___MIDL_IWinTypes_0009;
extern __declspec (package) const GUID GUID__RemotableHandle;
extern __declspec (package) const GUID IID__ISynDisplayEvents;
extern __declspec (package) const GUID GUID_wireHBITMAP;
extern __declspec (package) const GUID GUID__userBITMAP;
extern __declspec (package) const GUID GUID___MIDL_IWinTypes_0007;
extern __declspec (package) const GUID GUID__userHBITMAP;
extern __declspec (package) const GUID IID__ISynDeviceEvents;
extern __declspec (package) const GUID IID__ISynAPIEvents;
extern __declspec (package) const GUID GUID_UINT_PTR;
extern __declspec (package) const GUID GUID_LONG_PTR;
extern __declspec (package) const GUID CLSID_SynDevice;
extern __declspec (package) const GUID CLSID_SynPacket;
extern __declspec (package) const GUID CLSID_SynDisplay;
// *********************************************************************//
// Forward-Deklaration von in der Typbibliothek definierten Typen                    
// *********************************************************************//

union     __MIDL_IWinTypes_0009;
struct    _RemotableHandle;
struct    _userBITMAP;
union     __MIDL_IWinTypes_0007;
struct    _userHBITMAP;
interface DECLSPEC_UUID("{41320763-F0EC-4B7F-9A2E-B4DA92C80FE7}") ISynAPI;
typedef TComInterface<ISynAPI, &IID_ISynAPI> ISynAPIPtr;

interface DECLSPEC_UUID("{E7D5F8AC-866C-4C8C-AF5F-F28DE4918647}") ISynDevice;
typedef TComInterface<ISynDevice, &IID_ISynDevice> ISynDevicePtr;

interface DECLSPEC_UUID("{BF9D398B-F631-44B4-8EC0-D3FB3E388B62}") ISynPacket;
typedef TComInterface<ISynPacket, &IID_ISynPacket> ISynPacketPtr;

interface DECLSPEC_UUID("{A398ED6B-A2CC-471D-96F7-959610870AE0}") ISynDisplay;
typedef TComInterface<ISynDisplay, &IID_ISynDisplay> ISynDisplayPtr;

interface DECLSPEC_UUID("{4B55D73C-87D6-4C49-9CF2-AE7654226D68}") _ISynDisplayEvents;
typedef TComInterface<_ISynDisplayEvents, &IID__ISynDisplayEvents> _ISynDisplayEventsPtr;

interface DECLSPEC_UUID("{AE255EED-248F-4998-8376-F063ECB9E220}") _ISynDeviceEvents;
typedef TComInterface<_ISynDeviceEvents, &IID__ISynDeviceEvents> _ISynDeviceEventsPtr;

interface DECLSPEC_UUID("{2566B5BA-ADDC-4CC6-BBFB-B777E5C860CC}") _ISynAPIEvents;
typedef TComInterface<_ISynAPIEvents, &IID__ISynAPIEvents> _ISynAPIEventsPtr;


// *********************************************************************//
//  Deklaration von in der Typbibliothek definierten CoClasses             
// (HINWEIS: Hier wird jede CoClass ihrem Standard-Interface zugewiesen)       
//                                                                        
// Die Makros LIBID_OF_ weisen einen LIBID_OF_CoClassName der GUID dieser  
// Typbibliothek zu. Dies erleichtert die Aktualisierung von Makros bei   
// der Änderung von CoClass-Namen.                                                                
// *********************************************************************//

typedef ISynAPI SynAPI;
typedef ISynAPIPtr SynAPIPtr;
typedef ISynDevice SynDevice;
typedef ISynDevicePtr SynDevicePtr;
typedef ISynPacket SynPacket;
typedef ISynPacketPtr SynPacketPtr;
typedef ISynDisplay SynDisplay;
typedef ISynDisplayPtr SynDisplayPtr;

#define LIBID_OF_SynAPI (&LIBID_SYNCOMLib)
#define LIBID_OF_SynDevice (&LIBID_SYNCOMLib)
#define LIBID_OF_SynPacket (&LIBID_SYNCOMLib)
#define LIBID_OF_SynDisplay (&LIBID_SYNCOMLib)

// *********************************************************************//
// Deklaration von in der Typbibliothek definierten Aliasen                         
// *********************************************************************//


typedef Syncomlib_tlb::_RemotableHandle* wireHDC;
typedef Syncomlib_tlb::_userHBITMAP* wireHBITMAP;
typedef unsigned_long UINT_PTR;
typedef long LONG_PTR;

// *********************************************************************//
// Deklaration von in der Typbibliothek definierten Strukturen und Unions           
// *********************************************************************//

union  __MIDL_IWinTypes_0009
{
  long hInproc;
  long hRemote;
};

struct _RemotableHandle
{
  long fContext;
  Syncomlib_tlb::__MIDL_IWinTypes_0009 u;
};

struct _userBITMAP
{
  long bmType;
  long bmWidth;
  long bmHeight;
  long bmWidthBytes;
  unsigned_short bmPlanes;
  unsigned_short bmBitsPixel;
  unsigned_long cbSize;
  unsigned_char* pBuffer;
};

#pragma pack(push, 8)
union  __MIDL_IWinTypes_0007
{
  long hInproc;
  Syncomlib_tlb::_userBITMAP* hRemote;
  __int64 hInproc64;
};
#pragma pack(pop)

#pragma pack(push, 8)
struct _userHBITMAP
{
  long fContext;
  Syncomlib_tlb::__MIDL_IWinTypes_0007 u;
};
#pragma pack(pop)

// *********************************************************************//
// Interface: ISynAPI
// Flags:     (0)
// GUID:      {41320763-F0EC-4B7F-9A2E-B4DA92C80FE7}
// *********************************************************************//
interface ISynAPI  : public IUnknown
{
public:
  // [-1] method Initialize
  virtual HRESULT STDMETHODCALLTYPE Initialize(void) = 0;
  // [-1] method FindDevice
  virtual HRESULT STDMETHODCALLTYPE FindDevice(long lConnectionType, long lDeviceType, 
                                               long* ulHandle) = 0;
  // [-1] method CreateDevice
  virtual HRESULT STDMETHODCALLTYPE CreateDevice(long lHandle, Syncomlib_tlb::ISynDevice** ppDevice) = 0;
  // [-1] method GetProperty
  virtual HRESULT STDMETHODCALLTYPE GetProperty(long lSpecifier, long* pValue) = 0;
  // [-1] method GetStringProperty
  virtual HRESULT STDMETHODCALLTYPE GetStringProperty(long lSpecifier, unsigned_char* pBuffer, 
                                                      long* ulBufLen) = 0;
  // [-1] method SetProperty
  virtual HRESULT STDMETHODCALLTYPE SetProperty(long lSpecifier, long lValue) = 0;
  // [-1] method SetEventNotification
  virtual HRESULT STDMETHODCALLTYPE SetEventNotification(void* hEvent) = 0;
  // [-1] method GetEventParameter
  virtual HRESULT STDMETHODCALLTYPE GetEventParameter(long* lParameter) = 0;
  // [-1] method PersistState
  virtual HRESULT STDMETHODCALLTYPE PersistState(long lStateFlags) = 0;
  // [-1] method RestoreState
  virtual HRESULT STDMETHODCALLTYPE RestoreState(long lStateFlags) = 0;
  // [-1] method HardwareBroadcast
  virtual HRESULT STDMETHODCALLTYPE HardwareBroadcast(long lAction) = 0;
  // [-1] method SetSynchronousNotification
  virtual HRESULT STDMETHODCALLTYPE SetSynchronousNotification(Syncomlib_tlb::_ISynAPIEvents* pCallbackInstance) = 0;
  // [-1] method ForwardSystemMessage
  virtual HRESULT STDMETHODCALLTYPE ForwardSystemMessage(unsigned uMsg, 
                                                         Syncomlib_tlb::UINT_PTR wParam, 
                                                         Syncomlib_tlb::LONG_PTR lParam) = 0;
};

// *********************************************************************//
// Interface: ISynDevice
// Flags:     (0)
// GUID:      {E7D5F8AC-866C-4C8C-AF5F-F28DE4918647}
// *********************************************************************//
interface ISynDevice  : public IUnknown
{
public:
  // [-1] method GetProperty
  virtual HRESULT STDMETHODCALLTYPE GetProperty(long lSpecifier, long* pValue) = 0;
  // [-1] (Deprecated)
  virtual HRESULT STDMETHODCALLTYPE GetBooleanProperty(long lSpecifier, long* pValue) = 0;
  // [-1] method GetStringProperty
  virtual HRESULT STDMETHODCALLTYPE GetStringProperty(long lSpecifier, unsigned_char* pBuffer, 
                                                      long* ulBufLen) = 0;
  // [-1] method SetProperty
  virtual HRESULT STDMETHODCALLTYPE SetProperty(long lSpecifier, long lValue) = 0;
  // [-1] method SetEventNotification
  virtual HRESULT STDMETHODCALLTYPE SetEventNotification(void* hEvent) = 0;
  // [-1] method CreatePacket
  virtual HRESULT STDMETHODCALLTYPE CreatePacket(Syncomlib_tlb::ISynPacket** ppPacket) = 0;
  // [-1] method LoadPacket
  virtual HRESULT STDMETHODCALLTYPE LoadPacket(Syncomlib_tlb::ISynPacket* pPacket) = 0;
  // [-1] method ForceMotion
  virtual HRESULT STDMETHODCALLTYPE ForceMotion(long lDeltaX, long lDeltaY, long lButtonState) = 0;
  // [-1] method ForcePacket
  virtual HRESULT STDMETHODCALLTYPE ForcePacket(Syncomlib_tlb::ISynPacket* pPacket) = 0;
  // [-1] method Acquire
  virtual HRESULT STDMETHODCALLTYPE Acquire(long lFlags) = 0;
  // [-1] method Unacquire
  virtual HRESULT STDMETHODCALLTYPE Unacquire(void) = 0;
  // [-1] method CreateDisplay
  virtual HRESULT STDMETHODCALLTYPE CreateDisplay(Syncomlib_tlb::ISynDisplay** ppDisplay) = 0;
  // [-1] method Select
  virtual HRESULT STDMETHODCALLTYPE Select(long lHandle) = 0;
  // [-1] method PeekPacket
  virtual HRESULT STDMETHODCALLTYPE PeekPacket(long* plSequence) = 0;
  // [-1] method SetSynchronousNotification
  virtual HRESULT STDMETHODCALLTYPE SetSynchronousNotification(Syncomlib_tlb::_ISynDeviceEvents* pCallbackInstance) = 0;
  // [-1] method GetPropertyDefault
  virtual HRESULT STDMETHODCALLTYPE GetPropertyDefault(long lSpecifier, long* pValue) = 0;
  // [-1] method BulkTransaction
  virtual HRESULT STDMETHODCALLTYPE BulkTransaction(unsigned_long ulWriteLength, 
                                                    unsigned_char* ucWriteBuffer, 
                                                    unsigned_long ulReadLength, 
                                                    unsigned_char* ucReadBuffer) = 0;
  // [-1] method DiagnosticTransaction
  virtual HRESULT STDMETHODCALLTYPE DiagnosticTransaction(unsigned_long ulWriteLength, 
                                                          unsigned_char* ucWriteBuffer, 
                                                          unsigned_long ulReadLength, 
                                                          unsigned_char* ucReadBuffer) = 0;
  // [-1] method DiagnosticSelect
  virtual HRESULT STDMETHODCALLTYPE DiagnosticSelect(long lHandle, long lFlags) = 0;
  // [-1] method ForceMotionWithWheel
  virtual HRESULT STDMETHODCALLTYPE ForceMotionWithWheel(long lDeltaX, long lDeltaY, 
                                                         long lButtonState, long lWheelDelta) = 0;
  // [-1] method ValidateProperty
  virtual HRESULT STDMETHODCALLTYPE ValidateProperty(long lSpecifier, long lSynAccessRightType) = 0;
  // [-1] method ForceSecondaryFingerPacket
  virtual HRESULT STDMETHODCALLTYPE ForceSecondaryFingerPacket(Syncomlib_tlb::ISynPacket* pPacket) = 0;
};

// *********************************************************************//
// Interface: ISynPacket
// Flags:     (0)
// GUID:      {BF9D398B-F631-44B4-8EC0-D3FB3E388B62}
// *********************************************************************//
interface ISynPacket  : public IUnknown
{
public:
  // [-1] method GetProperty
  virtual HRESULT STDMETHODCALLTYPE GetProperty(long lSpecifier, long* pValue) = 0;
  // [-1] method SetProperty
  virtual HRESULT STDMETHODCALLTYPE SetProperty(long lSpecifier, long lValue) = 0;
  // [-1] method GetStringProperty
  virtual HRESULT STDMETHODCALLTYPE GetStringProperty(long lSpecifier, unsigned_char* pBuffer, 
                                                      long* ulBufLen) = 0;
  // [-1] method Copy
  virtual HRESULT STDMETHODCALLTYPE Copy(Syncomlib_tlb::ISynPacket* pFrom) = 0;
};

// *********************************************************************//
// Interface: ISynDisplay
// Flags:     (0)
// GUID:      {A398ED6B-A2CC-471D-96F7-959610870AE0}
// *********************************************************************//
interface ISynDisplay  : public IUnknown
{
public:
  // [-1] method GetProperty
  virtual HRESULT STDMETHODCALLTYPE GetProperty(long lSpecifier, long* pValue) = 0;
  // [-1] method SetProperty
  virtual HRESULT STDMETHODCALLTYPE SetProperty(long lSpecifier, long lValue) = 0;
  // [-1] method PixelToTouch
  virtual HRESULT STDMETHODCALLTYPE PixelToTouch(long PixelX, long PixelY, long* pTouchX, 
                                                 long* pTouchY) = 0;
  // [-1] method TouchToPixel
  virtual HRESULT STDMETHODCALLTYPE TouchToPixel(long TouchX, long TouchY, long* pPixelX, 
                                                 long* pPixelY) = 0;
  // [-1] method GetDC
  virtual HRESULT STDMETHODCALLTYPE GetDC(Syncomlib_tlb::wireHDC* pHDC) = 0;
  // [-1] method FlushDC
  virtual HRESULT STDMETHODCALLTYPE FlushDC(long lFlags) = 0;
  // [-1] method Acquire
  virtual HRESULT STDMETHODCALLTYPE Acquire(long lDisplayAcquisitionMethod) = 0;
  // [-1] method Unacquire
  virtual HRESULT STDMETHODCALLTYPE Unacquire(void) = 0;
  // [-1] method Select
  virtual HRESULT STDMETHODCALLTYPE Select(long lDeviceHandle) = 0;
  // [-1] method SetEventNotification
  virtual HRESULT STDMETHODCALLTYPE SetEventNotification(void* hEvent) = 0;
  // [-1] method GetEventParameter
  virtual HRESULT STDMETHODCALLTYPE GetEventParameter(long* lParameter) = 0;
  // [-1] method SetSynchronousNotification
  virtual HRESULT STDMETHODCALLTYPE SetSynchronousNotification(Syncomlib_tlb::_ISynDisplayEvents* pCallbackInstance) = 0;
  // [-1] method GetStringProperty
  virtual HRESULT STDMETHODCALLTYPE GetStringProperty(long lSpecifier, unsigned_char* pBuffer, 
                                                      long* ulBufLen) = 0;
  // [-1] method SetBackgroundImage
  virtual HRESULT STDMETHODCALLTYPE SetBackgroundImage(Syncomlib_tlb::wireHBITMAP hBmp) = 0;
  // [-1] method CloneBackgroundImage
  virtual HRESULT STDMETHODCALLTYPE CloneBackgroundImage(Syncomlib_tlb::wireHBITMAP* pHBmp) = 0;
};

// *********************************************************************//
// Interface: _ISynDisplayEvents
// Flags:     (0)
// GUID:      {4B55D73C-87D6-4C49-9CF2-AE7654226D68}
// *********************************************************************//
interface _ISynDisplayEvents 
{
public:
  // [-1] method OnSynDisplayMessage
  virtual HRESULT STDMETHODCALLTYPE OnSynDisplayMessage(long lMessage) = 0;
};

// *********************************************************************//
// Interface: _ISynDeviceEvents
// Flags:     (0)
// GUID:      {AE255EED-248F-4998-8376-F063ECB9E220}
// *********************************************************************//
interface _ISynDeviceEvents 
{
public:
  // [-1] method OnSynDevicePacket
  virtual HRESULT STDMETHODCALLTYPE OnSynDevicePacket(long lSequenceNumber) = 0;
};

// *********************************************************************//
// Interface: _ISynAPIEvents
// Flags:     (0)
// GUID:      {2566B5BA-ADDC-4CC6-BBFB-B777E5C860CC}
// *********************************************************************//
interface _ISynAPIEvents 
{
public:
  // [-1] method OnSynAPINotify
  virtual HRESULT STDMETHODCALLTYPE OnSynAPINotify(long lReason) = 0;
};

#if !defined(__TLB_NO_INTERFACE_WRAPPERS)
// *********************************************************************//
// SmartIntf: TCOMISynAPI
// Interface: ISynAPI
// *********************************************************************//
template <class T /* ISynAPI */ >
class TCOMISynAPIT : public TComInterface<ISynAPI>, public TComInterfaceBase<IUnknown>
{
public:
  TCOMISynAPIT() {}
  TCOMISynAPIT(ISynAPI *intf, bool addRef = false) : TComInterface<ISynAPI>(intf, addRef) {}
  TCOMISynAPIT(const TCOMISynAPIT& src) : TComInterface<ISynAPI>(src) {}
  TCOMISynAPIT& operator=(const TCOMISynAPIT& src) { Bind(src, true); return *this;}

  HRESULT         __fastcall Initialize(void);
  HRESULT         __fastcall FindDevice(long lConnectionType, long lDeviceType, long* ulHandle);
  HRESULT         __fastcall CreateDevice(long lHandle, Syncomlib_tlb::ISynDevice** ppDevice);
  HRESULT         __fastcall GetProperty(long lSpecifier, long* pValue);
  HRESULT         __fastcall GetStringProperty(long lSpecifier, unsigned_char* pBuffer, 
                                               long* ulBufLen);
  HRESULT         __fastcall SetProperty(long lSpecifier, long lValue);
  HRESULT         __fastcall SetEventNotification(void* hEvent);
  HRESULT         __fastcall GetEventParameter(long* lParameter);
  HRESULT         __fastcall PersistState(long lStateFlags);
  HRESULT         __fastcall RestoreState(long lStateFlags);
  HRESULT         __fastcall HardwareBroadcast(long lAction);
  HRESULT         __fastcall SetSynchronousNotification(Syncomlib_tlb::_ISynAPIEvents* pCallbackInstance);
  HRESULT         __fastcall ForwardSystemMessage(unsigned uMsg, Syncomlib_tlb::UINT_PTR wParam, 
                                                  Syncomlib_tlb::LONG_PTR lParam);

};
typedef TCOMISynAPIT<ISynAPI> TCOMISynAPI;

// *********************************************************************//
// SmartIntf: TCOMISynDevice
// Interface: ISynDevice
// *********************************************************************//
template <class T /* ISynDevice */ >
class TCOMISynDeviceT : public TComInterface<ISynDevice>, public TComInterfaceBase<IUnknown>
{
public:
  TCOMISynDeviceT() {}
  TCOMISynDeviceT(ISynDevice *intf, bool addRef = false) : TComInterface<ISynDevice>(intf, addRef) {}
  TCOMISynDeviceT(const TCOMISynDeviceT& src) : TComInterface<ISynDevice>(src) {}
  TCOMISynDeviceT& operator=(const TCOMISynDeviceT& src) { Bind(src, true); return *this;}

  HRESULT         __fastcall GetProperty(long lSpecifier, long* pValue);
  HRESULT         __fastcall GetBooleanProperty(long lSpecifier, long* pValue);
  HRESULT         __fastcall GetStringProperty(long lSpecifier, unsigned_char* pBuffer, 
                                               long* ulBufLen);
  HRESULT         __fastcall SetProperty(long lSpecifier, long lValue);
  HRESULT         __fastcall SetEventNotification(void* hEvent);
  HRESULT         __fastcall CreatePacket(Syncomlib_tlb::ISynPacket** ppPacket);
  HRESULT         __fastcall LoadPacket(Syncomlib_tlb::ISynPacket* pPacket);
  HRESULT         __fastcall ForceMotion(long lDeltaX, long lDeltaY, long lButtonState);
  HRESULT         __fastcall ForcePacket(Syncomlib_tlb::ISynPacket* pPacket);
  HRESULT         __fastcall Acquire(long lFlags);
  HRESULT         __fastcall Unacquire(void);
  HRESULT         __fastcall CreateDisplay(Syncomlib_tlb::ISynDisplay** ppDisplay);
  HRESULT         __fastcall Select(long lHandle);
  HRESULT         __fastcall PeekPacket(long* plSequence);
  HRESULT         __fastcall SetSynchronousNotification(Syncomlib_tlb::_ISynDeviceEvents* pCallbackInstance);
  HRESULT         __fastcall GetPropertyDefault(long lSpecifier, long* pValue);
  HRESULT         __fastcall BulkTransaction(unsigned_long ulWriteLength, 
                                             unsigned_char* ucWriteBuffer, 
                                             unsigned_long ulReadLength, unsigned_char* ucReadBuffer);
  HRESULT         __fastcall DiagnosticTransaction(unsigned_long ulWriteLength, 
                                                   unsigned_char* ucWriteBuffer, 
                                                   unsigned_long ulReadLength, 
                                                   unsigned_char* ucReadBuffer);
  HRESULT         __fastcall DiagnosticSelect(long lHandle, long lFlags);
  HRESULT         __fastcall ForceMotionWithWheel(long lDeltaX, long lDeltaY, long lButtonState, 
                                                  long lWheelDelta);
  HRESULT         __fastcall ValidateProperty(long lSpecifier, long lSynAccessRightType);
  HRESULT         __fastcall ForceSecondaryFingerPacket(Syncomlib_tlb::ISynPacket* pPacket);

};
typedef TCOMISynDeviceT<ISynDevice> TCOMISynDevice;

// *********************************************************************//
// SmartIntf: TCOMISynPacket
// Interface: ISynPacket
// *********************************************************************//
template <class T /* ISynPacket */ >
class TCOMISynPacketT : public TComInterface<ISynPacket>, public TComInterfaceBase<IUnknown>
{
public:
  TCOMISynPacketT() {}
  TCOMISynPacketT(ISynPacket *intf, bool addRef = false) : TComInterface<ISynPacket>(intf, addRef) {}
  TCOMISynPacketT(const TCOMISynPacketT& src) : TComInterface<ISynPacket>(src) {}
  TCOMISynPacketT& operator=(const TCOMISynPacketT& src) { Bind(src, true); return *this;}

  HRESULT         __fastcall GetProperty(long lSpecifier, long* pValue);
  HRESULT         __fastcall SetProperty(long lSpecifier, long lValue);
  HRESULT         __fastcall GetStringProperty(long lSpecifier, unsigned_char* pBuffer, 
                                               long* ulBufLen);
  HRESULT         __fastcall Copy(Syncomlib_tlb::ISynPacket* pFrom);

};
typedef TCOMISynPacketT<ISynPacket> TCOMISynPacket;

// *********************************************************************//
// SmartIntf: TCOMISynDisplay
// Interface: ISynDisplay
// *********************************************************************//
template <class T /* ISynDisplay */ >
class TCOMISynDisplayT : public TComInterface<ISynDisplay>, public TComInterfaceBase<IUnknown>
{
public:
  TCOMISynDisplayT() {}
  TCOMISynDisplayT(ISynDisplay *intf, bool addRef = false) : TComInterface<ISynDisplay>(intf, addRef) {}
  TCOMISynDisplayT(const TCOMISynDisplayT& src) : TComInterface<ISynDisplay>(src) {}
  TCOMISynDisplayT& operator=(const TCOMISynDisplayT& src) { Bind(src, true); return *this;}

  HRESULT         __fastcall GetProperty(long lSpecifier, long* pValue);
  HRESULT         __fastcall SetProperty(long lSpecifier, long lValue);
  HRESULT         __fastcall PixelToTouch(long PixelX, long PixelY, long* pTouchX, long* pTouchY);
  HRESULT         __fastcall TouchToPixel(long TouchX, long TouchY, long* pPixelX, long* pPixelY);
  HRESULT         __fastcall GetDC(Syncomlib_tlb::wireHDC* pHDC);
  HRESULT         __fastcall FlushDC(long lFlags);
  HRESULT         __fastcall Acquire(long lDisplayAcquisitionMethod);
  HRESULT         __fastcall Unacquire(void);
  HRESULT         __fastcall Select(long lDeviceHandle);
  HRESULT         __fastcall SetEventNotification(void* hEvent);
  HRESULT         __fastcall GetEventParameter(long* lParameter);
  HRESULT         __fastcall SetSynchronousNotification(Syncomlib_tlb::_ISynDisplayEvents* pCallbackInstance);
  HRESULT         __fastcall GetStringProperty(long lSpecifier, unsigned_char* pBuffer, 
                                               long* ulBufLen);
  HRESULT         __fastcall SetBackgroundImage(Syncomlib_tlb::wireHBITMAP hBmp);
  HRESULT         __fastcall CloneBackgroundImage(Syncomlib_tlb::wireHBITMAP* pHBmp);

};
typedef TCOMISynDisplayT<ISynDisplay> TCOMISynDisplay;

typedef TComInterface<_ISynDisplayEvents>  TCOM_ISynDisplayEvents;

typedef TComInterface<_ISynDeviceEvents>  TCOM_ISynDeviceEvents;

typedef TComInterface<_ISynAPIEvents>  TCOM_ISynAPIEvents;

// *********************************************************************//
// SmartIntf: TCOMISynAPI
// Interface: ISynAPI
// *********************************************************************//
template <class T> HRESULT __fastcall
TCOMISynAPIT<T>::Initialize(void)
{
  return (*this)->Initialize();
}

template <class T> HRESULT __fastcall
TCOMISynAPIT<T>::FindDevice(long lConnectionType, long lDeviceType, long* ulHandle)
{
  return (*this)->FindDevice(lConnectionType, lDeviceType, ulHandle);
}

template <class T> HRESULT __fastcall
TCOMISynAPIT<T>::CreateDevice(long lHandle, Syncomlib_tlb::ISynDevice** ppDevice)
{
  return (*this)->CreateDevice(lHandle, ppDevice);
}

template <class T> HRESULT __fastcall
TCOMISynAPIT<T>::GetProperty(long lSpecifier, long* pValue)
{
  return (*this)->GetProperty(lSpecifier, pValue);
}

template <class T> HRESULT __fastcall
TCOMISynAPIT<T>::GetStringProperty(long lSpecifier, unsigned_char* pBuffer, long* ulBufLen)
{
  return (*this)->GetStringProperty(lSpecifier, pBuffer, ulBufLen);
}

template <class T> HRESULT __fastcall
TCOMISynAPIT<T>::SetProperty(long lSpecifier, long lValue)
{
  return (*this)->SetProperty(lSpecifier, lValue);
}

template <class T> HRESULT __fastcall
TCOMISynAPIT<T>::SetEventNotification(void* hEvent)
{
  return (*this)->SetEventNotification(hEvent);
}

template <class T> HRESULT __fastcall
TCOMISynAPIT<T>::GetEventParameter(long* lParameter)
{
  return (*this)->GetEventParameter(lParameter);
}

template <class T> HRESULT __fastcall
TCOMISynAPIT<T>::PersistState(long lStateFlags)
{
  return (*this)->PersistState(lStateFlags);
}

template <class T> HRESULT __fastcall
TCOMISynAPIT<T>::RestoreState(long lStateFlags)
{
  return (*this)->RestoreState(lStateFlags);
}

template <class T> HRESULT __fastcall
TCOMISynAPIT<T>::HardwareBroadcast(long lAction)
{
  return (*this)->HardwareBroadcast(lAction);
}

template <class T> HRESULT __fastcall
TCOMISynAPIT<T>::SetSynchronousNotification(Syncomlib_tlb::_ISynAPIEvents* pCallbackInstance)
{
  return (*this)->SetSynchronousNotification(pCallbackInstance);
}

template <class T> HRESULT __fastcall
TCOMISynAPIT<T>::ForwardSystemMessage(unsigned uMsg, Syncomlib_tlb::UINT_PTR wParam, 
                                      Syncomlib_tlb::LONG_PTR lParam)
{
  return (*this)->ForwardSystemMessage(uMsg, wParam, lParam);
}

// *********************************************************************//
// SmartIntf: TCOMISynDevice
// Interface: ISynDevice
// *********************************************************************//
template <class T> HRESULT __fastcall
TCOMISynDeviceT<T>::GetProperty(long lSpecifier, long* pValue)
{
  return (*this)->GetProperty(lSpecifier, pValue);
}

template <class T> HRESULT __fastcall
TCOMISynDeviceT<T>::GetBooleanProperty(long lSpecifier, long* pValue)
{
  return (*this)->GetBooleanProperty(lSpecifier, pValue);
}

template <class T> HRESULT __fastcall
TCOMISynDeviceT<T>::GetStringProperty(long lSpecifier, unsigned_char* pBuffer, long* ulBufLen)
{
  return (*this)->GetStringProperty(lSpecifier, pBuffer, ulBufLen);
}

template <class T> HRESULT __fastcall
TCOMISynDeviceT<T>::SetProperty(long lSpecifier, long lValue)
{
  return (*this)->SetProperty(lSpecifier, lValue);
}

template <class T> HRESULT __fastcall
TCOMISynDeviceT<T>::SetEventNotification(void* hEvent)
{
  return (*this)->SetEventNotification(hEvent);
}

template <class T> HRESULT __fastcall
TCOMISynDeviceT<T>::CreatePacket(Syncomlib_tlb::ISynPacket** ppPacket)
{
  return (*this)->CreatePacket(ppPacket);
}

template <class T> HRESULT __fastcall
TCOMISynDeviceT<T>::LoadPacket(Syncomlib_tlb::ISynPacket* pPacket)
{
  return (*this)->LoadPacket(pPacket);
}

template <class T> HRESULT __fastcall
TCOMISynDeviceT<T>::ForceMotion(long lDeltaX, long lDeltaY, long lButtonState)
{
  return (*this)->ForceMotion(lDeltaX, lDeltaY, lButtonState);
}

template <class T> HRESULT __fastcall
TCOMISynDeviceT<T>::ForcePacket(Syncomlib_tlb::ISynPacket* pPacket)
{
  return (*this)->ForcePacket(pPacket);
}

template <class T> HRESULT __fastcall
TCOMISynDeviceT<T>::Acquire(long lFlags)
{
  return (*this)->Acquire(lFlags);
}

template <class T> HRESULT __fastcall
TCOMISynDeviceT<T>::Unacquire(void)
{
  return (*this)->Unacquire();
}

template <class T> HRESULT __fastcall
TCOMISynDeviceT<T>::CreateDisplay(Syncomlib_tlb::ISynDisplay** ppDisplay)
{
  return (*this)->CreateDisplay(ppDisplay);
}

template <class T> HRESULT __fastcall
TCOMISynDeviceT<T>::Select(long lHandle)
{
  return (*this)->Select(lHandle);
}

template <class T> HRESULT __fastcall
TCOMISynDeviceT<T>::PeekPacket(long* plSequence)
{
  return (*this)->PeekPacket(plSequence);
}

template <class T> HRESULT __fastcall
TCOMISynDeviceT<T>::SetSynchronousNotification(Syncomlib_tlb::_ISynDeviceEvents* pCallbackInstance)
{
  return (*this)->SetSynchronousNotification(pCallbackInstance);
}

template <class T> HRESULT __fastcall
TCOMISynDeviceT<T>::GetPropertyDefault(long lSpecifier, long* pValue)
{
  return (*this)->GetPropertyDefault(lSpecifier, pValue);
}

template <class T> HRESULT __fastcall
TCOMISynDeviceT<T>::BulkTransaction(unsigned_long ulWriteLength, unsigned_char* ucWriteBuffer, 
                                    unsigned_long ulReadLength, unsigned_char* ucReadBuffer)
{
  return (*this)->BulkTransaction(ulWriteLength, ucWriteBuffer, ulReadLength, ucReadBuffer);
}

template <class T> HRESULT __fastcall
TCOMISynDeviceT<T>::DiagnosticTransaction(unsigned_long ulWriteLength, unsigned_char* ucWriteBuffer, 
                                          unsigned_long ulReadLength, unsigned_char* ucReadBuffer)
{
  return (*this)->DiagnosticTransaction(ulWriteLength, ucWriteBuffer, ulReadLength, ucReadBuffer);
}

template <class T> HRESULT __fastcall
TCOMISynDeviceT<T>::DiagnosticSelect(long lHandle, long lFlags)
{
  return (*this)->DiagnosticSelect(lHandle, lFlags);
}

template <class T> HRESULT __fastcall
TCOMISynDeviceT<T>::ForceMotionWithWheel(long lDeltaX, long lDeltaY, long lButtonState, 
                                         long lWheelDelta)
{
  return (*this)->ForceMotionWithWheel(lDeltaX, lDeltaY, lButtonState, lWheelDelta);
}

template <class T> HRESULT __fastcall
TCOMISynDeviceT<T>::ValidateProperty(long lSpecifier, long lSynAccessRightType)
{
  return (*this)->ValidateProperty(lSpecifier, lSynAccessRightType);
}

template <class T> HRESULT __fastcall
TCOMISynDeviceT<T>::ForceSecondaryFingerPacket(Syncomlib_tlb::ISynPacket* pPacket)
{
  return (*this)->ForceSecondaryFingerPacket(pPacket);
}

// *********************************************************************//
// SmartIntf: TCOMISynPacket
// Interface: ISynPacket
// *********************************************************************//
template <class T> HRESULT __fastcall
TCOMISynPacketT<T>::GetProperty(long lSpecifier, long* pValue)
{
  return (*this)->GetProperty(lSpecifier, pValue);
}

template <class T> HRESULT __fastcall
TCOMISynPacketT<T>::SetProperty(long lSpecifier, long lValue)
{
  return (*this)->SetProperty(lSpecifier, lValue);
}

template <class T> HRESULT __fastcall
TCOMISynPacketT<T>::GetStringProperty(long lSpecifier, unsigned_char* pBuffer, long* ulBufLen)
{
  return (*this)->GetStringProperty(lSpecifier, pBuffer, ulBufLen);
}

template <class T> HRESULT __fastcall
TCOMISynPacketT<T>::Copy(Syncomlib_tlb::ISynPacket* pFrom)
{
  return (*this)->Copy(pFrom);
}

// *********************************************************************//
// SmartIntf: TCOMISynDisplay
// Interface: ISynDisplay
// *********************************************************************//
template <class T> HRESULT __fastcall
TCOMISynDisplayT<T>::GetProperty(long lSpecifier, long* pValue)
{
  return (*this)->GetProperty(lSpecifier, pValue);
}

template <class T> HRESULT __fastcall
TCOMISynDisplayT<T>::SetProperty(long lSpecifier, long lValue)
{
  return (*this)->SetProperty(lSpecifier, lValue);
}

template <class T> HRESULT __fastcall
TCOMISynDisplayT<T>::PixelToTouch(long PixelX, long PixelY, long* pTouchX, long* pTouchY)
{
  return (*this)->PixelToTouch(PixelX, PixelY, pTouchX, pTouchY);
}

template <class T> HRESULT __fastcall
TCOMISynDisplayT<T>::TouchToPixel(long TouchX, long TouchY, long* pPixelX, long* pPixelY)
{
  return (*this)->TouchToPixel(TouchX, TouchY, pPixelX, pPixelY);
}

template <class T> HRESULT __fastcall
TCOMISynDisplayT<T>::GetDC(Syncomlib_tlb::wireHDC* pHDC)
{
  return (*this)->GetDC(pHDC);
}

template <class T> HRESULT __fastcall
TCOMISynDisplayT<T>::FlushDC(long lFlags)
{
  return (*this)->FlushDC(lFlags);
}

template <class T> HRESULT __fastcall
TCOMISynDisplayT<T>::Acquire(long lDisplayAcquisitionMethod)
{
  return (*this)->Acquire(lDisplayAcquisitionMethod);
}

template <class T> HRESULT __fastcall
TCOMISynDisplayT<T>::Unacquire(void)
{
  return (*this)->Unacquire();
}

template <class T> HRESULT __fastcall
TCOMISynDisplayT<T>::Select(long lDeviceHandle)
{
  return (*this)->Select(lDeviceHandle);
}

template <class T> HRESULT __fastcall
TCOMISynDisplayT<T>::SetEventNotification(void* hEvent)
{
  return (*this)->SetEventNotification(hEvent);
}

template <class T> HRESULT __fastcall
TCOMISynDisplayT<T>::GetEventParameter(long* lParameter)
{
  return (*this)->GetEventParameter(lParameter);
}

template <class T> HRESULT __fastcall
TCOMISynDisplayT<T>::SetSynchronousNotification(Syncomlib_tlb::_ISynDisplayEvents* pCallbackInstance)
{
  return (*this)->SetSynchronousNotification(pCallbackInstance);
}

template <class T> HRESULT __fastcall
TCOMISynDisplayT<T>::GetStringProperty(long lSpecifier, unsigned_char* pBuffer, long* ulBufLen)
{
  return (*this)->GetStringProperty(lSpecifier, pBuffer, ulBufLen);
}

template <class T> HRESULT __fastcall
TCOMISynDisplayT<T>::SetBackgroundImage(Syncomlib_tlb::wireHBITMAP hBmp)
{
  return (*this)->SetBackgroundImage(hBmp);
}

template <class T> HRESULT __fastcall
TCOMISynDisplayT<T>::CloneBackgroundImage(Syncomlib_tlb::wireHBITMAP* pHBmp)
{
  return (*this)->CloneBackgroundImage(pHBmp);
}

// *********************************************************************//
// Die folgenden typedefs stellen Klassen dar (CoCoClassName), die die 
// statischen Methoden Create() und CreateRemote(LPWSTR machineName) bereit-   
// stellen, um eine Instanz eines dargestellten Objekts zu erzeugen.     
// Diese Funktionen können von einem Client benutzt werden,   
// der die CoClasses automatisieren möchte, die von dieser                
// Typbibliothek dargestellt werden.                                               
// *********************************************************************//


// *********************************************************************//
// COCLASS STANDARD-INTERFACE ERZEUGUNG
// CoClass  : SynAPI
// Interface: TCOMISynAPI
// *********************************************************************//

typedef TCoClassCreatorT<TCOMISynAPI, ISynAPI, &CLSID_SynAPI, &IID_ISynAPI> CoSynAPI;

// *********************************************************************//
// COCLASS STANDARD-INTERFACE ERZEUGUNG
// CoClass  : SynDevice
// Interface: TCOMISynDevice
// *********************************************************************//

typedef TCoClassCreatorT<TCOMISynDevice, ISynDevice, &CLSID_SynDevice, &IID_ISynDevice> CoSynDevice;

// *********************************************************************//
// COCLASS STANDARD-INTERFACE ERZEUGUNG
// CoClass  : SynPacket
// Interface: TCOMISynPacket
// *********************************************************************//

typedef TCoClassCreatorT<TCOMISynPacket, ISynPacket, &CLSID_SynPacket, &IID_ISynPacket> CoSynPacket;

// *********************************************************************//
// COCLASS STANDARD-INTERFACE ERZEUGUNG
// CoClass  : SynDisplay
// Interface: TCOMISynDisplay
// *********************************************************************//

typedef TCoClassCreatorT<TCOMISynDisplay, ISynDisplay, &CLSID_SynDisplay, &IID_ISynDisplay> CoSynDisplay;
#endif  //   __TLB_NO_INTERFACE_WRAPPERS


};     // namespace Syncomlib_tlb

#if !defined(NO_IMPLICIT_NAMESPACE_USE)
using  namespace Syncomlib_tlb;
#endif

#pragma option pop

#endif // SYNCOMLib_TLBH
