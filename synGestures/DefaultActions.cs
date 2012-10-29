using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WindowsInput;
using System.Data;

namespace synGestures
{
    public static class DefaultActions
    {
        public static InvokeItem getDefaultAction(DefaultAction action)
        {
            var holdKeys = new List<VirtualKeyCode>();
            switch (action)
            {
                case DefaultAction.LeftClick:
                    return new InvokeItem(MouseKeyCode.Left);
                case DefaultAction.MiddleClick:
                    return new InvokeItem(MouseKeyCode.Middle);
                case DefaultAction.RightClick:
                    return new InvokeItem(MouseKeyCode.Right);
                case DefaultAction.ScrollToTop:
                    return new InvokeItem(VirtualKeyCode.HOME);
                case DefaultAction.ScrollToBottom:
                    return new InvokeItem(VirtualKeyCode.END);
                case DefaultAction.Left:
                    return new InvokeItem(VirtualKeyCode.LEFT);
                case DefaultAction.Right:
                    return new InvokeItem(VirtualKeyCode.RIGHT);
                case DefaultAction.NextTab:
                    return new InvokeItem(VirtualKeyCode.CONTROL, VirtualKeyCode.TAB);
                case DefaultAction.PrevTab:
                    return new InvokeItem(new[] { VirtualKeyCode.CONTROL, VirtualKeyCode.SHIFT }, VirtualKeyCode.TAB);
                case DefaultAction.ShowCharms:
                    return new InvokeItem(VirtualKeyCode.LWIN, VirtualKeyCode.VK_C);
                case DefaultAction.GoToDesktop:
                    return new InvokeItem(VirtualKeyCode.LWIN, VirtualKeyCode.VK_D);
                case DefaultAction.ShowMetroSearchApps:
                    return new InvokeItem(VirtualKeyCode.LWIN, VirtualKeyCode.VK_Q);
                case DefaultAction.ShowMetroSearchSettings:
                    return new InvokeItem(VirtualKeyCode.LWIN, VirtualKeyCode.VK_W);
                case DefaultAction.ShowMetroSearchFiles:
                    return new InvokeItem(VirtualKeyCode.LWIN, VirtualKeyCode.VK_F);
                case DefaultAction.ShowMetroSettingsSidebar:
                    return new InvokeItem(VirtualKeyCode.LWIN, VirtualKeyCode.VK_I);
                case DefaultAction.ShowMetroSharingSidebar:
                    return new InvokeItem(VirtualKeyCode.LWIN, VirtualKeyCode.VK_H);
                case DefaultAction.ShowMetroDevicesSidebar:
                    return new InvokeItem(VirtualKeyCode.LWIN, VirtualKeyCode.VK_K);
                case DefaultAction.SnapMetroAppToRight:
                    return new InvokeItem(VirtualKeyCode.LWIN, VirtualKeyCode.OEM_PERIOD);
                case DefaultAction.SnapMetroAppToLeft:
                    holdKeys = new List<VirtualKeyCode>();
                    holdKeys.Add(VirtualKeyCode.SHIFT);
                    holdKeys.Add(VirtualKeyCode.LWIN);
                    return new InvokeItem(holdKeys, VirtualKeyCode.OEM_PERIOD);
                case DefaultAction.SnapWindowToRight:
                    return new InvokeItem(VirtualKeyCode.LWIN, VirtualKeyCode.RIGHT);
                case DefaultAction.SnapWindowToLeft:
                    return new InvokeItem(VirtualKeyCode.LWIN, VirtualKeyCode.LEFT);
                case DefaultAction.MaximizeWindow:
                    return new InvokeItem(VirtualKeyCode.LWIN, VirtualKeyCode.UP);
                case DefaultAction.MinimizeWindow:
                    return new InvokeItem(VirtualKeyCode.LWIN, VirtualKeyCode.DOWN);
                case DefaultAction.LockWindows:
                    return new InvokeItem(VirtualKeyCode.LWIN, VirtualKeyCode.VK_L);
                case DefaultAction.OpenExplorer:
                    return new InvokeItem(VirtualKeyCode.LWIN, VirtualKeyCode.VK_E);
                case DefaultAction.OpenRun:
                    return new InvokeItem(VirtualKeyCode.LWIN, VirtualKeyCode.VK_R);
                case DefaultAction.StartMenu:
                    return new InvokeItem(VirtualKeyCode.LWIN);
                case DefaultAction.CloseWindow:
                    return new InvokeItem(VirtualKeyCode.MENU, VirtualKeyCode.F4);
                case DefaultAction.ShowMetroApps:
                    holdKeys = new List<VirtualKeyCode>();
                    holdKeys.Add(VirtualKeyCode.LWIN);
                    holdKeys.Add(VirtualKeyCode.CONTROL);
                    holdKeys.Add(VirtualKeyCode.SHIFT);
                    return new InvokeItem(holdKeys, VirtualKeyCode.TAB);
                case DefaultAction.ShowMetroAppSettings:
                    return new InvokeItem(VirtualKeyCode.LWIN, VirtualKeyCode.VK_Z);
                case DefaultAction.ShowProgramList:
                    holdKeys = new List<VirtualKeyCode>();
                    holdKeys.Add(VirtualKeyCode.MENU);
                    holdKeys.Add(VirtualKeyCode.CONTROL);
                    holdKeys.Add(VirtualKeyCode.SHIFT);
                    return new InvokeItem(holdKeys, VirtualKeyCode.TAB);
                case DefaultAction.SwitchToLastWindow:
                    return new InvokeItem(VirtualKeyCode.MENU, VirtualKeyCode.TAB);
                case DefaultAction.SwitchToLastMetroWindow:
                    return new InvokeItem(VirtualKeyCode.LWIN, VirtualKeyCode.TAB);
                case DefaultAction.PageUp:
                    return new InvokeItem(VirtualKeyCode.PRIOR);
                case DefaultAction.PageDown:
                    return new InvokeItem(VirtualKeyCode.NEXT);
                case DefaultAction.ExplorerNewFolder:
                    holdKeys = new List<VirtualKeyCode>();
                    holdKeys.Add(VirtualKeyCode.CONTROL);
                    holdKeys.Add(VirtualKeyCode.SHIFT);
                    return new InvokeItem(holdKeys, VirtualKeyCode.VK_N);
                case DefaultAction.ExplorerFolderLevelUp:
                    return new InvokeItem(VirtualKeyCode.MENU, VirtualKeyCode.UP);
                case DefaultAction.ExplorerTogglePreviewPane:
                    return new InvokeItem(VirtualKeyCode.MENU, VirtualKeyCode.VK_P);
                case DefaultAction.ExplorerToggleDetailPane:
                    holdKeys = new List<VirtualKeyCode>();
                    holdKeys.Add(VirtualKeyCode.MENU);
                    holdKeys.Add(VirtualKeyCode.SHIFT);
                    return new InvokeItem(holdKeys, VirtualKeyCode.VK_P);
                case DefaultAction.ExplorerToggleRibbon:
                    return new InvokeItem(VirtualKeyCode.CONTROL, VirtualKeyCode.F1);

                    
                default:
                    return null;
            }
        }
        public static Dictionary<string, DefaultAction> getDefaultActions()
        {
            var defaultActions = new Dictionary<string, DefaultAction>();
            defaultActions.Add("No action", DefaultAction.NoAction);
            defaultActions.Add("Mouse left click", DefaultAction.LeftClick);
            defaultActions.Add("Mouse middle click", DefaultAction.MiddleClick);
            defaultActions.Add("Mouse right click", DefaultAction.RightClick);
            defaultActions.Add("Left key", DefaultAction.Left);
            defaultActions.Add("Right key", DefaultAction.Right);
            defaultActions.Add("Next tab (Ctrl+Tab)", DefaultAction.NextTab);
            defaultActions.Add("Previous tab (Ctrl+Shift+Tab)", DefaultAction.PrevTab);
            defaultActions.Add("Scroll to top (Home)", DefaultAction.ScrollToTop);
            defaultActions.Add("Scroll to bottom (End)", DefaultAction.ScrollToBottom);
            defaultActions.Add("Scroll page up (Page Up)", DefaultAction.PageUp);
            defaultActions.Add("Scroll page down (Page Down)", DefaultAction.PageDown);
            defaultActions.Add("Show Charms bar (Win+C)", DefaultAction.ShowCharms);
            defaultActions.Add("Show open Metro apps (Win+Ctrl+Shift+Tab)", DefaultAction.ShowMetroApps);
            defaultActions.Add("Instant search for apps / list of installed apps (Win+Q)", DefaultAction.ShowMetroSearchApps);
            defaultActions.Add("Instant search for settings (Win+W)", DefaultAction.ShowMetroSearchSettings);
            defaultActions.Add("Instant search for files (Win+F)", DefaultAction.ShowMetroSearchFiles);
            defaultActions.Add("Settings sidebar (Win+I)", DefaultAction.ShowMetroSettingsSidebar);
            defaultActions.Add("Sharing sidebar (Win+H)", DefaultAction.ShowMetroSharingSidebar);
            defaultActions.Add("Devices sidebar (Win+K)", DefaultAction.ShowMetroDevicesSidebar);
            defaultActions.Add("Snap Metro app to the left (Win+Shift+.)", DefaultAction.SnapMetroAppToLeft);
            defaultActions.Add("Snap Metro app to the right (Win+.)", DefaultAction.SnapMetroAppToRight);
            defaultActions.Add("Snap window to the left (Win+Left)", DefaultAction.SnapWindowToLeft);
            defaultActions.Add("Snap window to the right (Win+Right)", DefaultAction.SnapWindowToRight);
            defaultActions.Add("Maximize current window (Win+Up)", DefaultAction.MaximizeWindow);
            defaultActions.Add("Minimize or restore current window (Win+Down)", DefaultAction.MinimizeWindow);
            defaultActions.Add("Lock Windows (Win+L)", DefaultAction.LockWindows);
            defaultActions.Add("Open run dialog (Win+L)", DefaultAction.OpenRun);
            defaultActions.Add("Show start menu (Win)", DefaultAction.StartMenu);
            defaultActions.Add("Close current app (Alt+F4)", DefaultAction.CloseWindow);

            defaultActions.Add("Show app bar in Metro apps (Win+Z)", DefaultAction.ShowMetroAppSettings);
            //defaultActions.Add("Show open programs (Alt+Ctrl+Shift+Tab)", DefaultAction.ShowProgramList);
            defaultActions.Add("Go to desktop (Win+D)", DefaultAction.GoToDesktop);
            defaultActions.Add("Switch to last Metro app (Win+Tab)", DefaultAction.SwitchToLastMetroWindow);
            defaultActions.Add("Switch to last window (Alt+Tab)", DefaultAction.SwitchToLastWindow);

            
            defaultActions.Add("Open Windows Explorer (Win+E)", DefaultAction.OpenExplorer);
            defaultActions.Add("Create new folder in Explorer (Ctrl+Shift+N)", DefaultAction.ExplorerNewFolder);
            defaultActions.Add("Go folder a level up in Explorer (Alt+Up)", DefaultAction.ExplorerFolderLevelUp);
            defaultActions.Add("Toggle preview pane in Explorer (Alt+P)", DefaultAction.ExplorerTogglePreviewPane);
            defaultActions.Add("Toggle detail pane in Explorer (Alt+Shift+P)", DefaultAction.ExplorerToggleDetailPane);
            defaultActions.Add("Toggle ribbon menu in Explorer (Ctrl+F1)", DefaultAction.ExplorerToggleRibbon);




            return defaultActions;
        }
    }
}
