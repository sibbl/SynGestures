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

#include "SYNCOMLib_TLB.h"

#if !defined(__PRAGMA_PACKAGE_SMART_INIT)
#define      __PRAGMA_PACKAGE_SMART_INIT
#pragma package(smart_init)
#endif

namespace Syncomlib_tlb
{


// *********************************************************************//
// In der Typbibliothek deklarierte GUIDS                                      
// *********************************************************************//
const GUID LIBID_SYNCOMLib = {0xE2489565, 0x2CE5, 0x4690,{ 0x91, 0x11, 0x76,0xE7, 0x9A, 0x9F,0x6C, 0xCD} };
const GUID CLSID_SynAPI = {0x9C042297, 0xD1CD, 0x4F0D,{ 0xB1, 0xAB, 0x9F,0x48, 0xAD, 0x6A,0x6D, 0xFF} };
const GUID IID_ISynAPI = {0x41320763, 0xF0EC, 0x4B7F,{ 0x9A, 0x2E, 0xB4,0xDA, 0x92, 0xC8,0x0F, 0xE7} };
const GUID IID_ISynDevice = {0xE7D5F8AC, 0x866C, 0x4C8C,{ 0xAF, 0x5F, 0xF2,0x8D, 0xE4, 0x91,0x86, 0x47} };
const GUID IID_ISynPacket = {0xBF9D398B, 0xF631, 0x44B4,{ 0x8E, 0xC0, 0xD3,0xFB, 0x3E, 0x38,0x8B, 0x62} };
const GUID IID_ISynDisplay = {0xA398ED6B, 0xA2CC, 0x471D,{ 0x96, 0xF7, 0x95,0x96, 0x10, 0x87,0x0A, 0xE0} };
const GUID GUID__RemotableHandle = {0x00000000, 0x0000, 0x0000,{ 0x00, 0x00, 0x00,0x00, 0x00, 0x00,0x00, 0x00} };
const GUID IID__ISynDisplayEvents = {0x4B55D73C, 0x87D6, 0x4C49,{ 0x9C, 0xF2, 0xAE,0x76, 0x54, 0x22,0x6D, 0x68} };
const GUID GUID__userHBITMAP = {0x00000000, 0x0000, 0x0000,{ 0x00, 0x00, 0x00,0x00, 0x00, 0x00,0x00, 0x00} };
const GUID GUID__userBITMAP = {0x00000000, 0x0000, 0x0000,{ 0x00, 0x00, 0x00,0x00, 0x00, 0x00,0x00, 0x00} };
const GUID IID__ISynDeviceEvents = {0xAE255EED, 0x248F, 0x4998,{ 0x83, 0x76, 0xF0,0x63, 0xEC, 0xB9,0xE2, 0x20} };
const GUID IID__ISynAPIEvents = {0x2566B5BA, 0xADDC, 0x4CC6,{ 0xBB, 0xFB, 0xB7,0x77, 0xE5, 0xC8,0x60, 0xCC} };
const GUID CLSID_SynDevice = {0x9345312C, 0xD098, 0x4BB1,{ 0xB2, 0xB2, 0xD5,0x29, 0xEB, 0x99,0x51, 0x73} };
const GUID CLSID_SynPacket = {0xE0C6335D, 0x27F8, 0x424B,{ 0xA5, 0xC2, 0x56,0x12, 0x91, 0xA9,0x02, 0xA0} };
const GUID CLSID_SynDisplay = {0x248AFB1A, 0x27C4, 0x4A30,{ 0xBF, 0x45, 0x65,0x44, 0x14, 0x66,0x48, 0xBC} };

};     // namespace Syncomlib_tlb
