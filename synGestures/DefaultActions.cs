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
                case DefaultAction.ShowCharms:
                    return new InvokeItem(VirtualKeyCode.LWIN,VirtualKeyCode.VK_C);
                case DefaultAction.ShowMetroApps:
                    return new InvokeItem(new[] { VirtualKeyCode.LWIN, VirtualKeyCode.CONTROL, VirtualKeyCode.SHIFT }, VirtualKeyCode.TAB);
                case DefaultAction.ShowMetroAppSettings:
                    return new InvokeItem(VirtualKeyCode.LWIN, VirtualKeyCode.VK_Z);
                case DefaultAction.ShowProgramList:
                    return new InvokeItem(new[] { VirtualKeyCode.MENU, VirtualKeyCode.CONTROL, VirtualKeyCode.SHIFT }, VirtualKeyCode.TAB);
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
            defaultActions.Add("Scroll to top", DefaultAction.ScrollToTop);
            defaultActions.Add("Show Charms bar", DefaultAction.ShowCharms);
            defaultActions.Add("Show open Metro apps", DefaultAction.ShowMetroApps);
            defaultActions.Add("Show Metro app settings", DefaultAction.ShowMetroAppSettings);
            defaultActions.Add("Show open programs", DefaultAction.ShowProgramList);

            return defaultActions;
        }
    }
}
