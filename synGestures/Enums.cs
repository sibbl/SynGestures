using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace synGestures
{
    public enum MouseKeyCode { Left, Middle, Right }
    public enum ActionType
    {
        MouseTapOne,
        MouseTapOneLong,
        MouseTapTwo,
        MouseTapTwoLong,
        MouseTapThree,
        MouseTapThreeLong,
        SwipeTwoLeft,
        SwipeTwoRight,
        SwipeThreeUp,
        SwipeThreeRight,
        SwipeThreeDown,
        SwipeThreeLeft,
        SwipeBorderTop,
        SwipeBorderRight,
        SwipeBorderBottom,
        SwipeBorderLeft
    }
    public enum ScrollDirection { None, Up, Down, Left, Right }
    public enum DefaultAction
    {
        NoAction,
        LeftClick,
        MiddleClick,
        RightClick,
        ShowMetroApps,
        ShowMetroAppSettings,
        ShowProgramList,
        ShowCharms,
        ScrollToTop,
    }
}
