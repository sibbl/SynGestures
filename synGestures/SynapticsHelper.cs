using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SYNCTRLLib;
using System.Drawing;
using System.Windows.Forms;
using synGestures.Properties;
using System.Runtime.InteropServices;
using synGestures.Config;
using SYNCOMLib;

namespace synGestures
{
    public delegate bool SynapticsAction(ActionType type);
    public class SynapticsHelper
    {
        public Configuration config;

        private SynAPICtrl synAPI;
        private SynDeviceCtrl synTouchPad;

        private int devHandle = -1;

        private bool isDeviceTapLocked = false;
        private bool synTapState = false;
        private int tapMaxNof = 0;
        private int tapLastNof = 0;
        private Point tapTouchPos;
        private Point tapFirstTouchPos;
        private int tapStartTime = 0;
        private int tapTouchTime = 0;
        private bool tapDone = false;

        private int scrollTouchTime = 0;
        private Point scrollTouchPos;
        private bool IsPadAcquired = true;
        private ScrollDirection scrollDir;
        private bool scrollNotEdgeX = false;
        private bool scrollNotEdgeY = false;
        private int scrollLastXDelta = 0;
        private int scrollLastYDelta = 0;
        private bool swipeDone = true;
        private int swipeXDelta = 0;
        private int swipeYDelta = 0;
        private int scrollBufferX = 0;
        private int scrollBufferY = 0;

        //properties:
        //private int tapMaxDistance = 50;
        private bool scrollLinearEdgeX = true;
        private bool scrollLinearEdgeY = true;
        private bool scrollLinearX = true;
        private bool scrollLinearY = true;
        
        int ylo = 0;
        int yhi = 0;
        int xlo = 0;
        int xhi = 0;
        int xlorim = 0;
        int xhirim = 0;
        int ylorim = 0;
        int yhirim = 0;
        int xmin = 0;
        int xmax = 0;
        int ymin = 0;
        int ymax = 0;

        public event SynapticsAction actionEvent;
        protected virtual bool OnActionEvent(ActionType type)
        {
            return actionEvent(type);
        }


        public SynapticsHelper(Configuration _config)
        {
            config = _config;
        }
        public void Resume()
        {
            synAPI = new SynAPICtrl();
            synTouchPad = new SynDeviceCtrl();
            synTouchPad.OnPacket += new _ISynDeviceCtrlEvents_OnPacketEventHandler(onPacket);
            synAPI.Initialize();
            
            devHandle = synAPI.FindDevice(
                SYNCTRLLib.SynConnectionType.SE_ConnectionAny,
                SYNCTRLLib.SynDeviceType.SE_DeviceTouchPad,
                -1);
            if (devHandle < 0)
            {
                System.Threading.Thread.Sleep(500);
                Resume();
                return;
            }
            synTouchPad.Select(devHandle);
            ReadDeviceProperties();
        }
        public bool Init()
        {

            try
            {
                synAPI = new SynAPICtrl();
                synTouchPad = new SynDeviceCtrl();

                synTouchPad.OnPacket += new _ISynDeviceCtrlEvents_OnPacketEventHandler(onPacket);

                synAPI.Initialize();

                devHandle = synAPI.FindDevice(
                    SYNCTRLLib.SynConnectionType.SE_ConnectionAny,
                    SYNCTRLLib.SynDeviceType.SE_DeviceTouchPad,
                    -1);

            }
            catch (Exception)
            {
                MessageBox.Show(
                    Resources.error_startup_no_driver_found,
                    Resources.error_msg_title,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                Application.Exit();
                return false;
            }

            if (devHandle < 0)
            {
                MessageBox.Show(Resources.error_startup_no_device_found,
                                Resources.error_msg_title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
                return false;
            }

            synTouchPad.Select(devHandle);
            //synTouchPad.CreatePacket(ref _synPacket);

            int multi = synTouchPad.GetLongProperty(SYNCTRLLib.SynDeviceProperty.SP_IsMultiFingerCapable);
            if (multi < 0)
            {
                //HKLM "System\\CurrentControlSet\\Services\\SynTP\\Parameters" -> CapabilitiesMask must be 0xFFFFFFFF
                //TODO: do different checks here
                MessageBox.Show("multiple finger support is missing!",
                                Resources.error_msg_title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            ReadDeviceProperties();

            return true;
        }
        private void CheckTappingProperty()
        {
            var tapEnabled = synTouchPad.GetLongProperty(SYNCTRLLib.SynDeviceProperty.SP_IsTapEnabled);
            if (tapEnabled == 0) synTouchPad.SetLongProperty(SYNCTRLLib.SynDeviceProperty.SP_IsTapEnabled, 1);

            /*
            var dragEnabled = synTouchPad.GetLongProperty(SYNCTRLLib.SynDeviceProperty.SP_IsDragEnabled);
            if (dragEnabled == 0) synTouchPad.SetLongProperty(SYNCTRLLib.SynDeviceProperty.SP_IsDragEnabled, 1);

            var cornerTapEnabled = synTouchPad.GetLongProperty(SYNCTRLLib.SynDeviceProperty.SP_IsCornerTapEnabled);
            if (cornerTapEnabled == 1) synTouchPad.SetLongProperty(SYNCTRLLib.SynDeviceProperty.SP_IsCornerTapEnabled, 0);
            */
        }
        private void ReadDeviceProperties()
        {
            ylo = synTouchPad.GetLongProperty(SYNCTRLLib.SynDeviceProperty.SP_YLoBorder);
            yhi = synTouchPad.GetLongProperty(SYNCTRLLib.SynDeviceProperty.SP_YHiBorder);
            xlo = synTouchPad.GetLongProperty(SYNCTRLLib.SynDeviceProperty.SP_XLoBorder);
            xhi = synTouchPad.GetLongProperty(SYNCTRLLib.SynDeviceProperty.SP_XHiBorder);
            xlorim = synTouchPad.GetLongProperty(SYNCTRLLib.SynDeviceProperty.SP_XLoRim);
            xhirim = synTouchPad.GetLongProperty(SYNCTRLLib.SynDeviceProperty.SP_XHiRim);
            ylorim = synTouchPad.GetLongProperty(SYNCTRLLib.SynDeviceProperty.SP_YLoRim);
            yhirim = synTouchPad.GetLongProperty(SYNCTRLLib.SynDeviceProperty.SP_YHiRim);
            xmin = synTouchPad.GetLongProperty(SYNCTRLLib.SynDeviceProperty.SP_XLoSensor);
            xmax = synTouchPad.GetLongProperty(SYNCTRLLib.SynDeviceProperty.SP_XHiSensor);
            ymin = synTouchPad.GetLongProperty(SYNCTRLLib.SynDeviceProperty.SP_YLoSensor);
            ymax = synTouchPad.GetLongProperty(SYNCTRLLib.SynDeviceProperty.SP_YHiSensor);

            CheckTappingProperty();

        }
        private void LockDeviceTap(bool dolock)
        {
            if (dolock != isDeviceTapLocked)
            {
                if (dolock)
                {
                    int gest = synTouchPad.GetLongProperty(SYNCTRLLib.SynDeviceProperty.SP_Gestures);
                    if ((gest & (int)SYNCTRLLib.SynGestures.SF_GestureTap) != 0)
                    {
                        synTouchPad.SetLongProperty(SYNCTRLLib.SynDeviceProperty.SP_Gestures,
                                                    gest & ~(int)SYNCTRLLib.SynGestures.SF_GestureTap);
                        ;
                        synTapState = true;
                    }
                    else synTapState = false;
                }
                else
                {
                    int gest = synTouchPad.GetLongProperty(SYNCTRLLib.SynDeviceProperty.SP_Gestures);
                    if (synTapState) gest |= (int)SYNCTRLLib.SynGestures.SF_GestureTap;
                    else gest &= ~(int)SYNCTRLLib.SynGestures.SF_GestureTap;
                    synTouchPad.SetLongProperty(SYNCTRLLib.SynDeviceProperty.SP_Gestures,
                                                gest & ~(int)SYNCTRLLib.SynGestures.SF_GestureTap);
                }
                isDeviceTapLocked = dolock;
            }
        }
        public void AcquirePad(bool acquire)
        {
            //return;
            if (acquire && !IsPadAcquired)
            {
                try
                {
                    //synTouchPad.Acquire(0);
                }
                catch
                {
                }
            }
            else if (!acquire && IsPadAcquired)
            {
                //synTouchPad.Unacquire();
            }
            IsPadAcquired = acquire;
        }
        public int GetDistance(Point a, Point b)
        {
            int result = 0;
            double part1 = Math.Pow((b.X - a.X), 2);
            double part2 = Math.Pow((b.Y - a.Y), 2);
            double underRadical = part1 + part2;
            result = (int)Math.Sqrt(underRadical);
            return result;
        }
        private void onPacket()
        {
            var packet = new SynPacketCtrl();
            synTouchPad.LoadPacket(packet);

            CheckTappingProperty();
            
            int nof = packet.GetLongProperty(SYNCTRLLib.SynPacketProperty.SP_ExtraFingerState) & 3;
            int fstate = packet.GetLongProperty(SYNCTRLLib.SynPacketProperty.SP_FingerState);
            int xd = packet.GetLongProperty(SYNCTRLLib.SynPacketProperty.SP_XDelta);
            int yd = packet.GetLongProperty(SYNCTRLLib.SynPacketProperty.SP_YDelta);
            int y = packet.GetLongProperty(SYNCTRLLib.SynPacketProperty.SP_Y);
            int x = packet.GetLongProperty(SYNCTRLLib.SynPacketProperty.SP_X);


            if (nof > tapMaxNof) tapMaxNof = nof; 
            //handle tapping
            if (nof > tapLastNof) // on press
            {
                tapDone = false;
                if (nof >= 2) //on press of more than one finger
                {
                    tapStartTime = packet.GetLongProperty(SYNCTRLLib.SynPacketProperty.SP_TimeStamp);
                    

                    LockDeviceTap(true);
                }
                if (tapLastNof == 0) //first touch
                {
                    tapTouchTime = packet.GetLongProperty(SYNCTRLLib.SynPacketProperty.SP_TimeStamp);
                    NativeMethods.GetCursorPos(ref tapTouchPos);
                    tapFirstTouchPos = new Point(x, y);
                }
            }
            else if (nof < tapLastNof) // on release
            {
                if (nof == 0)
                {
                    tapDone = false;
                    tapMaxNof = 0;
                }
                if (tapLastNof >= 1 && !tapDone)
                {
                    bool ok = false;
                    int tstamp = packet.GetLongProperty(SYNCTRLLib.SynPacketProperty.SP_TimeStamp);
                    if (tstamp - tapTouchTime < config.SwipeBorderSpeedMs &&
                        (tapFirstTouchPos.X > (xmax - config.SwipeBorderStartInsetX) || 
                         tapFirstTouchPos.X < (xmin + config.SwipeBorderStartInsetX) || 
                         tapFirstTouchPos.Y > (ymax - config.SwipeBorderStartInsetY) || 
                         tapFirstTouchPos.Y < (xmin + config.SwipeBorderStartInsetY)))
                    {
                        if (tapFirstTouchPos.X > (xmax - config.SwipeBorderStartInsetX) && x < tapFirstTouchPos.X - config.SwipeBorderInsetX)
                        {
                            ok = OnActionEvent(ActionType.SwipeBorderRight);
                            NativeMethods.SetCursorPos(tapTouchPos.X, tapTouchPos.Y);
                        }
                        else if (tapFirstTouchPos.X < (xmin + config.SwipeBorderStartInsetX) && x > tapFirstTouchPos.X + config.SwipeBorderInsetX)
                        {
                            ok = OnActionEvent(ActionType.SwipeBorderLeft);
                            NativeMethods.SetCursorPos(tapTouchPos.X, tapTouchPos.Y);
                        }
                        else if (tapFirstTouchPos.Y > (ymax - config.SwipeBorderStartInsetY) && y < tapFirstTouchPos.Y - config.SwipeBorderInsetY)
                        {
                            ok = OnActionEvent(ActionType.SwipeBorderTop);
                            NativeMethods.SetCursorPos(tapTouchPos.X, tapTouchPos.Y);
                        }
                        else if (tapFirstTouchPos.Y < (ymin + config.SwipeBorderStartInsetY) && y > tapFirstTouchPos.Y + config.SwipeBorderInsetY)
                        {
                            ok = OnActionEvent(ActionType.SwipeBorderBottom);
                            NativeMethods.SetCursorPos(tapTouchPos.X, tapTouchPos.Y);
                        }
                    }else if (tstamp - tapTouchTime < config.TapMaxMsBetween &&
                        Math.Abs(tapFirstTouchPos.X - x) < config.TapMaxDistance &&
                        Math.Abs(tapFirstTouchPos.Y - y) < config.TapMaxDistance) //time between now and first touch < config
                    {
                        if (tapLastNof == 1 && tapMaxNof <= 1) ok = OnActionEvent(ActionType.MouseTapOne);
                        else if (tapLastNof == 2 && tapMaxNof <= 2) ok = OnActionEvent(ActionType.MouseTapTwo);
                        else if (tapLastNof == 3 && tapMaxNof <= 3) ok = OnActionEvent(ActionType.MouseTapThree);
                    }
                    else if (tstamp - tapTouchTime > config.MouseTapsLongMs && !tapDone)
                    {
                        //Point releasePoint = tapTouchPos;
                        //NativeMethods.GetCursorPos(ref releasePoint);
                        //if (Math.Abs(releasePoint.X - tapTouchPos.X) < config.MouseTapsLongMovingArea && Math.Abs(releasePoint.Y - tapTouchPos.Y) < config.MouseTapsLongMovingArea)
                        if(Math.Abs(tapFirstTouchPos.X - x) < config.MouseTapsLongMovingArea &&
                            Math.Abs(tapFirstTouchPos.Y - y) < config.MouseTapsLongMovingArea)
                        {
                            if (tapLastNof == 1 && tapMaxNof <= 1) ok = OnActionEvent(ActionType.MouseTapOneLong);
                            else if (tapLastNof == 2 && tapMaxNof <= 2) ok = OnActionEvent(ActionType.MouseTapTwoLong);
                            else if (tapLastNof == 3 && tapMaxNof <= 3) ok = OnActionEvent(ActionType.MouseTapThreeLong);
                        }
                    }
                    #region old code
                    /*
                    if (tstamp - tapTouchTime < config.TapMaxMsBetween) //time between now and first touch < config
                    {
                        if (tapLastNof == 1)
                        {
                            ok = OnActionEvent(ActionType.MouseTapOne);
                        }
                        else if (tapLastNof == 2)
                        {
                            ok = OnActionEvent(ActionType.MouseTapTwo);
                        }
                        else if (tapLastNof == 3) {
                            ok = OnActionEvent(ActionType.MouseTapThree);
                        }
                    }
                    else if (
                        tstamp - tapTouchTime >= config.TapMaxMsBetween && //time between now and first touch > config
                        tstamp - tapStartTime < config.TapMaxMsBetween) //time between now and last touch < config
                    {
                        if (tapLastNof == 2)
                        {
                            ok = OnActionEvent(ActionType.MouseTapOneOne);
                        }
                        else if (tapLastNof == 3)
                        {
                            ok = OnActionEvent(ActionType.MouseTapTwoOne);
                        }
                        //if only one touch has been recognized and time is longer than xyz ms, check if long press
                    }
                    else if (tapLastNof == 1 && tstamp - tapTouchTime > config.MouseTapOneLongMs)
                    {
                        //compare end point to start point
                        Point releasePoint = tapTouchPos;
                        NativeMethods.GetCursorPos(ref releasePoint);
                        //only catch difference of 100 (px?)
                        if (Math.Abs(releasePoint.X - tapTouchPos.X) < config.MouseTapOneLongMovingArea && Math.Abs(releasePoint.Y - tapTouchPos.Y) < config.MouseTapOneLongMovingArea)
                        {
                            ok = OnActionEvent(ActionType.MouseTapOneLong);
                        }
                    }
                    */
#endregion
                    //if there is an action, move cursor back to start position where the action has been performed
                    if (ok)
                    {
                        tapDone = true;
                        //NativeMethods.SetCursorPos(tapTouchPos.X, tapTouchPos.Y);
                        //tapStartTime -= config.TapMaxMsBetween;
                    }
                    tapStartTime -= config.TapMaxMsBetween;
                    tapLastNof = nof;
                    return;

                }

            }
            /*
            if (isDeviceTapLocked)
            {
                if (Math.Abs(xd) < 800) tapDistance += Math.Abs(xd);
                if (Math.Abs(yd) < 800) tapDistance += Math.Abs(yd);
                if ((fstate & (int)SYNCTRLLib.SynFingerFlags.SF_FingerPresent) == 0)
                    LockDeviceTap(false);
            }
            */
            tapLastNof = nof;


            //handle scrolling
            if ((fstate & (int)SYNCTRLLib.SynFingerFlags.SF_FingerPresent) != 0)
            {
                if (scrollTouchTime == 0)
                {
                    NativeMethods.GetCursorPos(ref scrollTouchPos);
                    scrollTouchTime = packet.GetLongProperty(SYNCTRLLib.SynPacketProperty.SP_TimeStamp);
                }
                if (nof == 2)
                {
                    if (IsPadAcquired && scrollLinearEdgeY && (scrollDir == ScrollDirection.Up || scrollDir == ScrollDirection.Down))
                    {
                        if (ylo <= y && y <= yhi) scrollNotEdgeY = true;
                        else if (scrollNotEdgeY && ((y < ylo && scrollLastYDelta < 0) ||
                            (y > yhi && scrollLastYDelta > 0)))
                        {
                            DoScroll(scrollLastXDelta, scrollLastYDelta);
                            return;
                        }
                    }
                    if (IsPadAcquired && scrollLinearEdgeX && (scrollDir == ScrollDirection.Left || scrollDir == ScrollDirection.Right))
                    {
                        if (xlo <= x && x <= xhi) scrollNotEdgeX = true;
                        else if (scrollNotEdgeX && ((x < xlo && scrollLastXDelta < 0) ||
                            (x > xhi && scrollLastXDelta > 0)))
                        {
                            DoScroll(scrollLastXDelta, scrollLastYDelta);
                            return;
                        }
                        /*
                        if (ylo <= y && x <= yhi) scrollNotEdgeY = true;
                        else if (scrollNotEdgeY && ((y < ylo && scrollLastYDelta < 0) ||
                            (y > yhi && scrollLastYDelta > 0)))
                        {
                            DoScroll(scrollLastXDelta, scrollLastYDelta);
                            return;
                        }
                        */
                    }
                    if ((fstate & (int)SYNCTRLLib.SynFingerFlags.SF_FingerMotion) != 0)
                    {

                        if (!IsPadAcquired)
                        {
                            swipeDone = false; //start left/right swipe

                            AcquirePad(true);
                            int tstamp = packet.GetLongProperty(SYNCTRLLib.SynPacketProperty.SP_TimeStamp);
                            if (tstamp - scrollTouchTime < 1000)
                            {
                                NativeMethods.SetCursorPos(scrollTouchPos.X, scrollTouchPos.Y);
                            }
                        }
                        if (IsPadAcquired)
                        {
                            swipeXDelta += xd;
                            swipeYDelta += yd;
                            if (swipeXDelta < -1 * config.SwipeTwoMovementXDirection && Math.Abs(swipeYDelta) < config.SwipeTwoMovementXOrthogonal)
                            {  //links
                                scrollDir = ScrollDirection.Left;
                                if (!swipeDone) OnActionEvent(ActionType.SwipeTwoLeft);
                                swipeDone = true;
                            }
                            else if (swipeXDelta > config.SwipeTwoMovementXDirection && Math.Abs(swipeYDelta) < config.SwipeTwoMovementXOrthogonal)
                            {  //rechts
                                scrollDir = ScrollDirection.Right;
                                if (!swipeDone) OnActionEvent(ActionType.SwipeTwoRight);
                                swipeDone = true;
                            }
                            else if (Math.Abs(swipeXDelta) < config.SwipeTwoMovementYDirection && swipeYDelta < -1 * config.SwipeTwoMovementYOrthogonal)
                            { //runter
                                swipeDone = true;
                                scrollDir = ScrollDirection.Down;
                            }
                            else if (Math.Abs(swipeXDelta) < config.SwipeTwoMovementYDirection && swipeYDelta > config.SwipeTwoMovementYOrthogonal)
                            { //hoch
                                swipeDone = true;
                                scrollDir = ScrollDirection.Up;
                            }
                            scrollLastXDelta = xd;
                            scrollLastYDelta = yd;
                            if (scrollDir != ScrollDirection.None)
                            {
                                DoScroll(xd, yd);
                            }
                        }
                    }
                }
                else if (nof == 3)
                {
                    if ((fstate & (int)SYNCTRLLib.SynFingerFlags.SF_FingerMotion) != 0)
                    {
                        if (!IsPadAcquired)
                        {
                            AcquirePad(true);
                            swipeDone = false;
                        }
                        if (IsPadAcquired && !swipeDone)
                        {

                            swipeXDelta += xd;
                            swipeYDelta += yd;
                            if (swipeXDelta < -1 * config.SwipeThreeMovementXDirection && Math.Abs(swipeYDelta) < config.SwipeThreeMovementXOrthogonal)
                            {  //links
                                swipeDone = true;
                                OnActionEvent(ActionType.SwipeThreeLeft);
                            }
                            else if (swipeXDelta > config.SwipeThreeMovementXDirection && Math.Abs(swipeYDelta) < config.SwipeThreeMovementXOrthogonal)
                            {  //rechts
                                swipeDone = true;
                                OnActionEvent(ActionType.SwipeThreeRight);
                            }
                            else if (Math.Abs(swipeXDelta) < config.SwipeThreeMovementYOrthogonal && swipeYDelta < -1 * config.SwipeThreeMovementYDirection)
                            { //runter
                                swipeDone = true;
                                OnActionEvent(ActionType.SwipeThreeDown);
                            }
                            else if (Math.Abs(swipeXDelta) < config.SwipeThreeMovementYOrthogonal && swipeYDelta > config.SwipeThreeMovementYDirection)
                            {  //hoch
                                swipeDone = true;
                                OnActionEvent(ActionType.SwipeThreeUp);
                            }
                        }
                    }
                }
                else
                {
                    scrollLastXDelta = scrollLastYDelta = 0;
                    swipeXDelta = swipeYDelta = 0;
                    swipeDone = false;
                    scrollDir = ScrollDirection.None;
                    AcquirePad(false);
                    scrollBufferX = scrollBufferY = 0;
                    scrollNotEdgeX = scrollNotEdgeY = false;
                }
            }
            else
            {
                scrollTouchTime = 0;
                scrollLastXDelta = scrollLastYDelta = 0;
                swipeXDelta = swipeYDelta = 0;
                swipeDone = false;
                scrollDir = ScrollDirection.None;
                AcquirePad(false);
                scrollBufferX = scrollBufferY = 0;
                scrollNotEdgeX = scrollNotEdgeY = false;
            }
        }
        private bool DoScroll(int dx, int dy)
        {
            //Console.WriteLine("scroll " + dx + "/" + dy);
            bool isHorizontal = (scrollDir == ScrollDirection.Left || scrollDir == ScrollDirection.Right);
            if (!scrollLinearX && isHorizontal) return false;
            if (!scrollLinearY && !isHorizontal) return false;

            int d, dd = isHorizontal ? dx : dy;

            if (Math.Abs(dy) > 800 || Math.Abs(dx) > 800)
                return false;

            // scrollSpeed
            dd = dd * config.ScrollSpeed / 100;

            // scrollAcc
            if (config.ScrollAccelerationEnabled)
            {
                d = dd * dd / config.ScrollAcceleration;
                if (d < 4)
                    d = 4;
                if (dd < 0)
                    d = -d;
            }
            else d = dd;

            /* old mode
            if (scrollMode == 0)
            {
                // compatibility mode
                if (isHorizontal) scrollBufferX += d;
                else scrollBufferY += d;
                d = isHorizontal ? scrollBufferX : scrollBufferY - isHorizontal ? scrollBufferX : scrollBufferY % WHEEL_DELTA;
            }
             * */

            d = config.ScrollReverse ? d * -1 : d;

            if (d != 0)
            {
                NativeMethods.INPUT[] i = new NativeMethods.INPUT[1];

                i[0].type = NativeMethods.INPUT_MOUSE;
                i[0].mi.dwFlags = isHorizontal ? NativeMethods.MOUSEEVENTF_HWHEEL : NativeMethods.MOUSEEVENTF_WHEEL;
                i[0].mi.mouseData = d;

                NativeMethods.SendInput(1, i, Marshal.SizeOf(typeof(NativeMethods.INPUT)));


            }

            return true;
        }
    }
}
