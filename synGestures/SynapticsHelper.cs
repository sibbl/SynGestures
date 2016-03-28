using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using Microsoft.Win32;
using synGestures.Config;
using synGestures.Properties;
using SYNCTRLLib;

namespace synGestures
{
    public delegate bool SynapticsAction(ActionType type);
    public class SynapticsHelper
    {
        private Configuration _config;

        public Configuration Config
        {
            set { _config = value; }
        }

        private SynAPICtrl _synApi;
        private SynDeviceCtrl _synTouchPad;

        private Logger _log;

        private int _devHandle = -1;

        private bool _isDeviceTapLocked;
        private bool _synTapState;
        private int _tapMaxNof;
        private int _tapLastNof;
        private Point _tapTouchPos;
        private Point _tapFirstTouchPos;
        private int _tapStartTime;
        private int _tapTouchTime;
        private bool _tapDone;

        private int _scrollTouchTime;
        private Point _scrollTouchPos;
        private bool _isPadAcquired = true;
        private ScrollDirection _scrollDir;
        private bool _scrollNotEdgeX;
        private bool _scrollNotEdgeY;
        private int _scrollLastXDelta;
        private int _scrollLastYDelta;
        private bool _swipeDone = true;
        private int _swipeXDelta;
        private int _swipeYDelta;
        private int _scrollBufferX;
        private int _scrollBufferY;

        //properties:
        //private int tapMaxDistance = 50;
        private bool _scrollLinearEdgeX = true;
        private bool _scrollLinearEdgeY = true;
        private bool _scrollLinearX = true;
        private bool _scrollLinearY = true;
        
        private int _ylo;
        private int _yhi;
        private int _xlo;
        private int _xhi;
        private int _xlorim;
        private int _xhirim;
        private int _ylorim;
        private int _yhirim;
        private int _xmin;
        private int _xmax;
        private int _ymin;
        private int _ymax;

        public event SynapticsAction ActionEvent;
        protected virtual bool OnActionEvent(ActionType type)
        {
            try
            {
                return ActionEvent != null && ActionEvent(type);
            }
            catch (Exception exception)
            {
                _log.Log("OnActionEvent: " + exception.Message);
                return false;
            }
        }


        public SynapticsHelper(Configuration config)
        {
            _config = config;
        }
        public void Resume()
        {
            //this is necessery after coming back from standby/hibernation
            _log.LogDebug("resuming...");
            _synApi = new SynAPICtrl();
            _synTouchPad = new SynDeviceCtrl();
            _synApi.Initialize();
            _synApi.Activate();
            
            _devHandle = _synApi.FindDevice(
                SynConnectionType.SE_ConnectionAny,
                SynDeviceType.SE_DeviceTouchPad,
                -1);
            if (_devHandle < 0)
            {
                //I know, this should be async...
                Thread.Sleep(500);
                Resume();
                return;
            }
            _synTouchPad.Select(_devHandle);
            _synTouchPad.Activate();
            _synTouchPad.OnPacket += OnPacket;
            ReadDeviceProperties();
        }
        public bool Init()
        {
            _log = new Logger();
            try
            {
                _log.LogDebug("Create SynAPI");
                _synApi = new SynAPICtrl();
                _log.LogDebug("Create SynDeviceCtrl");
                _synTouchPad = new SynDeviceCtrl();


                _log.LogDebug("Init SynAPI");
                _synApi.Initialize();
                _synApi.Activate();

                _log.LogDebug("Find Synaptics Device");
                _devHandle = _synApi.FindDevice(
                    SynConnectionType.SE_ConnectionAny,
                    SynDeviceType.SE_DeviceTouchPad,
                    -1);
                _synTouchPad.Select(_devHandle);

                _synTouchPad.Activate();
                _log.LogDebug("Create OnPacketEventHandler");
                _synTouchPad.OnPacket += OnPacket;

            }
            catch (Exception ex)
            {
                _log.LogDebug("Error on init: " + ex.InnerException.Message);
                MessageBox.Show(
                    Resources.error_startup_no_driver_found,
                    Resources.error_msg_title,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                Application.Exit();
                return false;
            }

            if (_devHandle < 0)
            {
                _log.LogDebug("No device handle found");
                MessageBox.Show(Resources.error_startup_no_device_found,
                                Resources.error_msg_title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
                return false;
            }
            _log.LogDebug("Device handle found: "+_devHandle);

            //check if the touchpad has support for multiple fingers
            var multi = _synTouchPad.GetLongProperty(SynDeviceProperty.SP_IsMultiFingerCapable);
            if (multi < 0)
            {
                //HKLM "System\\CurrentControlSet\\Services\\SynTP\\Parameters" -> CapabilitiesMask must be 0xFFFFFFFF
                var parampath = @"System\CurrentControlSet\Services\SynTP\Parameters";
                var key = Registry.LocalMachine.CreateSubKey(parampath);
                key.SetValue("CapabilitiesMask", 0xFFFFFFFF);
                MessageBox.Show("Multiple finger support was missing. We made some changes to the registry.\n\nTry running SynGestures again or reboot your computer and try again then.",
                                Resources.error_msg_title, MessageBoxButtons.OK, MessageBoxIcon.Information);

                Application.Exit();
                return false;
            }
            ReadDeviceProperties();

            return true;
        }
        private void CheckTappingProperty()
        {
            var tapEnabled = _synTouchPad.GetLongProperty(SynDeviceProperty.SP_IsTapEnabled);
            if (tapEnabled == 0) _synTouchPad.SetLongProperty(SynDeviceProperty.SP_IsTapEnabled, 1);

            /*
            var dragEnabled = _synTouchPad.GetLongProperty(SYNCTRLLib.SynDeviceProperty.SP_IsDragEnabled);
            if (dragEnabled == 0) _synTouchPad.SetLongProperty(SYNCTRLLib.SynDeviceProperty.SP_IsDragEnabled, 1);

            var cornerTapEnabled = _synTouchPad.GetLongProperty(SYNCTRLLib.SynDeviceProperty.SP_IsCornerTapEnabled);
            if (cornerTapEnabled == 1) _synTouchPad.SetLongProperty(SYNCTRLLib.SynDeviceProperty.SP_IsCornerTapEnabled, 0);
            */
        }
        private void ReadDeviceProperties()
        {
            _ylo = _synTouchPad.GetLongProperty(SynDeviceProperty.SP_YLoBorder);
            _yhi = _synTouchPad.GetLongProperty(SynDeviceProperty.SP_YHiBorder);
            _xlo = _synTouchPad.GetLongProperty(SynDeviceProperty.SP_XLoBorder);
            _xhi = _synTouchPad.GetLongProperty(SynDeviceProperty.SP_XHiBorder);
            _xlorim = _synTouchPad.GetLongProperty(SynDeviceProperty.SP_XLoRim);
            _xhirim = _synTouchPad.GetLongProperty(SynDeviceProperty.SP_XHiRim);
            _ylorim = _synTouchPad.GetLongProperty(SynDeviceProperty.SP_YLoRim);
            _yhirim = _synTouchPad.GetLongProperty(SynDeviceProperty.SP_YHiRim);
            _xmin = _synTouchPad.GetLongProperty(SynDeviceProperty.SP_XLoSensor);
            _xmax = _synTouchPad.GetLongProperty(SynDeviceProperty.SP_XHiSensor);
            _ymin = _synTouchPad.GetLongProperty(SynDeviceProperty.SP_YLoSensor);
            _ymax = _synTouchPad.GetLongProperty(SynDeviceProperty.SP_YHiSensor);

            _log.LogDebug("ylo=" + _ylo);
            _log.LogDebug("yhi=" + _yhi);
            _log.LogDebug("xlo=" + _xlo);
            _log.LogDebug("xhi=" + _xhi);
            _log.LogDebug("xlorim=" + _xlorim);
            _log.LogDebug("xhirim=" + _xhirim);
            _log.LogDebug("ylorim=" + _ylorim);
            _log.LogDebug("yhirim=" + _yhirim);
            _log.LogDebug("xmin=" + _xmin);
            _log.LogDebug("xmax=" + _xmax);
            _log.LogDebug("ymin=" + _ymin);
            _log.LogDebug("ymax=" + _ymax);

            CheckTappingProperty();

        }
        private void LockDeviceTap(bool dolock)
        {
            if (dolock != _isDeviceTapLocked)
            {
                if (dolock)
                {
                    var gest = _synTouchPad.GetLongProperty(SynDeviceProperty.SP_Gestures);
                    if ((gest & (int)SynGestures.SF_GestureTap) != 0)
                    {
                        _synTouchPad.SetLongProperty(SynDeviceProperty.SP_Gestures,
                                                    gest & ~(int)SynGestures.SF_GestureTap);
                        ;
                        _synTapState = true;
                    }
                    else _synTapState = false;
                }
                else
                {
                    var gest = _synTouchPad.GetLongProperty(SynDeviceProperty.SP_Gestures);
                    if (_synTapState) gest |= (int)SynGestures.SF_GestureTap;
                    else gest &= ~(int)SynGestures.SF_GestureTap;
                    _synTouchPad.SetLongProperty(SynDeviceProperty.SP_Gestures,
                                                gest & ~(int)SynGestures.SF_GestureTap);
                }
                _isDeviceTapLocked = dolock;
            }
        }
        public void AcquirePad(bool acquire)
        {
            /*
            if (acquire && !_isPadAcquired)
            {
                try
                {
                    _synTouchPad.Acquire(0);
                }
                catch
                {
                    //ignore
                }
            }
            else if (!acquire && _isPadAcquired)
            {
                _synTouchPad.Unacquire();
            }
            */
            _isPadAcquired = acquire;
        }
        public int GetDistance(Point a, Point b)
        {
            var result = 0;
            var part1 = Math.Pow((b.X - a.X), 2);
            var part2 = Math.Pow((b.Y - a.Y), 2);
            var underRadical = part1 + part2;
            result = (int)Math.Sqrt(underRadical);
            return result;
        }
        private void OnPacket()
        {
            var packet = new SynPacketCtrl();
            _synTouchPad.LoadPacket(packet);

            CheckTappingProperty();
            
            var nof = packet.GetLongProperty(SynPacketProperty.SP_ExtraFingerState) & 3;
            var fstate = packet.GetLongProperty(SynPacketProperty.SP_FingerState);
            var xd = packet.GetLongProperty(SynPacketProperty.SP_XDelta);
            var yd = packet.GetLongProperty(SynPacketProperty.SP_YDelta);
            var y = packet.GetLongProperty(SynPacketProperty.SP_Y);
            var x = packet.GetLongProperty(SynPacketProperty.SP_X);

            _log.LogDebug("got packet");
            _log.LogDebug("nof=" + nof);
            _log.LogDebug("fstate=" + fstate);
            _log.LogDebug("xd=" + xd);
            _log.LogDebug("yd=" + yd);
            _log.LogDebug("x=" + x);
            _log.LogDebug("y=" + y);

            if (nof > _tapMaxNof) _tapMaxNof = nof; 
            //handle tapping
            if (nof > _tapLastNof) // on press
            {
                _tapDone = false;
                if (nof >= 2) //on press of more than one finger
                {
                    _tapStartTime = packet.GetLongProperty(SynPacketProperty.SP_TimeStamp);
                    

                    LockDeviceTap(true);
                }
                if (_tapLastNof == 0) //first touch
                {
                    _tapTouchTime = packet.GetLongProperty(SynPacketProperty.SP_TimeStamp);
                    NativeMethods.GetCursorPos(ref _tapTouchPos);
                    _tapFirstTouchPos = new Point(x, y);
                }
            }
            else if (nof < _tapLastNof) // on release
            {
                if (nof == 0)
                {
                    _tapDone = false;
                    _tapMaxNof = 0;
                }
                if (_tapLastNof >= 1 && !_tapDone)
                {
                    var ok = false;
                    var tstamp = packet.GetLongProperty(SynPacketProperty.SP_TimeStamp);
                    if (tstamp - _tapTouchTime < _config.SwipeBorderSpeedMs &&
                        (_tapFirstTouchPos.X > (_xmax - _config.SwipeBorderStartInsetX) || 
                         _tapFirstTouchPos.X < (_xmin + _config.SwipeBorderStartInsetX) || 
                         _tapFirstTouchPos.Y > (_ymax - _config.SwipeBorderStartInsetY) || 
                         _tapFirstTouchPos.Y < (_xmin + _config.SwipeBorderStartInsetY)))
                    {
                        _log.LogDebug("first touch: " + _tapFirstTouchPos.X + "/" + _tapFirstTouchPos.Y);
                        _log.LogDebug("current touch: " + x + "/" + y);
                        if (_tapFirstTouchPos.X > (_xmax - _config.SwipeBorderStartInsetX) && x < _tapFirstTouchPos.X - _config.SwipeBorderInsetX)
                        {
                            _log.LogDebug("swipe border right");
                            ok = OnActionEvent(ActionType.SwipeBorderRight);
                            NativeMethods.SetCursorPos(_tapTouchPos.X, _tapTouchPos.Y);
                        }
                        else if (_tapFirstTouchPos.X < (_xmin + _config.SwipeBorderStartInsetX) && x > _tapFirstTouchPos.X + _config.SwipeBorderInsetX)
                        {
                            _log.LogDebug("swipe border left");
                            ok = OnActionEvent(ActionType.SwipeBorderLeft);
                            NativeMethods.SetCursorPos(_tapTouchPos.X, _tapTouchPos.Y);
                        }
                        else if (_tapFirstTouchPos.Y > (_ymax - _config.SwipeBorderStartInsetY) && y < _tapFirstTouchPos.Y - _config.SwipeBorderInsetY)
                        {
                            _log.LogDebug("swipe border top");
                            ok = OnActionEvent(ActionType.SwipeBorderTop);
                            NativeMethods.SetCursorPos(_tapTouchPos.X, _tapTouchPos.Y);
                        }
                        else if (_tapFirstTouchPos.Y < (_ymin + _config.SwipeBorderStartInsetY) && y > _tapFirstTouchPos.Y + _config.SwipeBorderInsetY)
                        {
                            _log.LogDebug("swipe border bottom");
                            ok = OnActionEvent(ActionType.SwipeBorderBottom);
                            NativeMethods.SetCursorPos(_tapTouchPos.X, _tapTouchPos.Y);
                        }
                    }else if (tstamp - _tapTouchTime < _config.TapMaxMsBetween &&
                        Math.Abs(_tapFirstTouchPos.X - x) < _config.TapMaxDistance &&
                        Math.Abs(_tapFirstTouchPos.Y - y) < _config.TapMaxDistance) //time between now and first touch < _config
                    {
                        if (_tapLastNof == 1 && _tapMaxNof <= 1) ok = OnActionEvent(ActionType.MouseTapOne);
                        else if (_tapLastNof == 2 && _tapMaxNof <= 2) ok = OnActionEvent(ActionType.MouseTapTwo);
                        else if (_tapLastNof == 3 && _tapMaxNof <= 3) ok = OnActionEvent(ActionType.MouseTapThree);
                    }
                    else if (tstamp - _tapTouchTime > _config.MouseTapsLongMs && !_tapDone)
                    {
                        if(Math.Abs(_tapFirstTouchPos.X - x) < _config.MouseTapsLongMovingArea &&
                            Math.Abs(_tapFirstTouchPos.Y - y) < _config.MouseTapsLongMovingArea)
                        {
                            if (_tapLastNof == 1 && _tapMaxNof <= 1) ok = OnActionEvent(ActionType.MouseTapOneLong);
                            else if (_tapLastNof == 2 && _tapMaxNof <= 2) ok = OnActionEvent(ActionType.MouseTapTwoLong);
                            else if (_tapLastNof == 3 && _tapMaxNof <= 3) ok = OnActionEvent(ActionType.MouseTapThreeLong);
                        }
                    }
                    #region old code
                    /*
                    if (tstamp - tapTouchTime < _config.TapMaxMsBetween) //time between now and first touch < _config
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
                        tstamp - tapTouchTime >= _config.TapMaxMsBetween && //time between now and first touch > _config
                        tstamp - tapStartTime < _config.TapMaxMsBetween) //time between now and last touch < _config
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
                    else if (tapLastNof == 1 && tstamp - tapTouchTime > _config.MouseTapOneLongMs)
                    {
                        //compare end point to start point
                        Point releasePoint = tapTouchPos;
                        NativeMethods.GetCursorPos(ref releasePoint);
                        //only catch difference of 100 (px?)
                        if (Math.Abs(releasePoint.X - tapTouchPos.X) < _config.MouseTapOneLongMovingArea && Math.Abs(releasePoint.Y - tapTouchPos.Y) < _config.MouseTapOneLongMovingArea)
                        {
                            ok = OnActionEvent(ActionType.MouseTapOneLong);
                        }
                    }
                    */
#endregion
                    //if there is an action, move cursor back to start position where the action has been performed
                    if (ok)
                    {
                        _tapDone = true;
                        //NativeMethods.SetCursorPos(tapTouchPos.X, tapTouchPos.Y);
                        //tapStartTime -= _config.TapMaxMsBetween;
                    }
                    _tapStartTime -= _config.TapMaxMsBetween;
                    _tapLastNof = nof;
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
            _tapLastNof = nof;


            //handle scrolling
            if ((fstate & (int)SynFingerFlags.SF_FingerPresent) != 0)
            {
                if (_scrollTouchTime == 0)
                {
                    NativeMethods.GetCursorPos(ref _scrollTouchPos);
                    _scrollTouchTime = packet.GetLongProperty(SynPacketProperty.SP_TimeStamp);
                }
                if (nof == 2)
                {
                    if (_isPadAcquired && _scrollLinearEdgeY && (_scrollDir == ScrollDirection.Up || _scrollDir == ScrollDirection.Down))
                    {
                        if (_ylo <= y && y <= _yhi) _scrollNotEdgeY = true;
                        else if (_scrollNotEdgeY && ((y < _ylo && _scrollLastYDelta < 0) ||
                            (y > _yhi && _scrollLastYDelta > 0)))
                        {
                            DoScroll(_scrollLastXDelta, _scrollLastYDelta);
                            return;
                        }
                    }
                    if (_isPadAcquired && _scrollLinearEdgeX && (_scrollDir == ScrollDirection.Left || _scrollDir == ScrollDirection.Right))
                    {
                        if (_xlo <= x && x <= _xhi) _scrollNotEdgeX = true;
                        else if (_scrollNotEdgeX && ((x < _xlo && _scrollLastXDelta < 0) ||
                            (x > _xhi && _scrollLastXDelta > 0)))
                        {
                            DoScroll(_scrollLastXDelta, _scrollLastYDelta);
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
                    if ((fstate & (int)SynFingerFlags.SF_FingerMotion) != 0)
                    {

                        if (!_isPadAcquired)
                        {
                            _swipeDone = false; //start left/right swipe

                            AcquirePad(true);
                            var tstamp = packet.GetLongProperty(SynPacketProperty.SP_TimeStamp);
                            if (tstamp - _scrollTouchTime < 1000)
                            {
                                NativeMethods.SetCursorPos(_scrollTouchPos.X, _scrollTouchPos.Y);
                            }
                        }
                        if (_isPadAcquired)
                        {
                            _swipeXDelta += xd;
                            _swipeYDelta += yd;
                            if (_swipeXDelta < -1 * _config.SwipeTwoMovementXDirection && Math.Abs(_swipeYDelta) < _config.SwipeTwoMovementXOrthogonal)
                            {  //left
                                _scrollDir = ScrollDirection.Left;
                                if (!_swipeDone) OnActionEvent(ActionType.SwipeTwoLeft);
                                _swipeDone = true;
                            }
                            else if (_swipeXDelta > _config.SwipeTwoMovementXDirection && Math.Abs(_swipeYDelta) < _config.SwipeTwoMovementXOrthogonal)
                            {  //right
                                _scrollDir = ScrollDirection.Right;
                                if (!_swipeDone) OnActionEvent(ActionType.SwipeTwoRight);
                                _swipeDone = true;
                            }
                            else if (Math.Abs(_swipeXDelta) < _config.SwipeTwoMovementYDirection && _swipeYDelta < -1 * _config.SwipeTwoMovementYOrthogonal)
                            { //down
                                _swipeDone = true;
                                _scrollDir = ScrollDirection.Down;
                            }
                            else if (Math.Abs(_swipeXDelta) < _config.SwipeTwoMovementYDirection && _swipeYDelta > _config.SwipeTwoMovementYOrthogonal)
                            { //up
                                _swipeDone = true;
                                _scrollDir = ScrollDirection.Up;
                            }
                            _scrollLastXDelta = xd;
                            _scrollLastYDelta = yd;
                            if (_scrollDir != ScrollDirection.None)
                            {
                                DoScroll(xd, yd);
                            }
                        }
                    }
                }
                else if (nof == 3)
                {
                    if ((fstate & (int)SynFingerFlags.SF_FingerMotion) != 0)
                    {
                        if (!_isPadAcquired)
                        {
                            AcquirePad(true);
                            _swipeDone = false;
                        }
                        if (_isPadAcquired && !_swipeDone)
                        {

                            _swipeXDelta += xd;
                            _swipeYDelta += yd;
                            if (_swipeXDelta < -1 * _config.SwipeThreeMovementXDirection && Math.Abs(_swipeYDelta) < _config.SwipeThreeMovementXOrthogonal)
                            {  //left
                                _swipeDone = true;
                                OnActionEvent(ActionType.SwipeThreeLeft);
                            }
                            else if (_swipeXDelta > _config.SwipeThreeMovementXDirection && Math.Abs(_swipeYDelta) < _config.SwipeThreeMovementXOrthogonal)
                            {  //right
                                _swipeDone = true;
                                OnActionEvent(ActionType.SwipeThreeRight);
                            }
                            else if (Math.Abs(_swipeXDelta) < _config.SwipeThreeMovementYOrthogonal && _swipeYDelta < -1 * _config.SwipeThreeMovementYDirection)
                            { //down
                                _swipeDone = true;
                                OnActionEvent(ActionType.SwipeThreeDown);
                            }
                            else if (Math.Abs(_swipeXDelta) < _config.SwipeThreeMovementYOrthogonal && _swipeYDelta > _config.SwipeThreeMovementYDirection)
                            {  //up
                                _swipeDone = true;
                                OnActionEvent(ActionType.SwipeThreeUp);
                            }
                        }
                    }
                }
                else
                {
                    _scrollLastXDelta = _scrollLastYDelta = 0;
                    _swipeXDelta = _swipeYDelta = 0;
                    _swipeDone = false;
                    _scrollDir = ScrollDirection.None;
                    AcquirePad(false);
                    _scrollBufferX = _scrollBufferY = 0;
                    _scrollNotEdgeX = _scrollNotEdgeY = false;
                }
            }
            else
            {
                _scrollTouchTime = 0;
                _scrollLastXDelta = _scrollLastYDelta = 0;
                _swipeXDelta = _swipeYDelta = 0;
                _swipeDone = false;
                _scrollDir = ScrollDirection.None;
                AcquirePad(false);
                _scrollBufferX = _scrollBufferY = 0;
                _scrollNotEdgeX = _scrollNotEdgeY = false;
            }
        }
        private bool DoScroll(int dx, int dy)
        {
            var isHorizontal = (_scrollDir == ScrollDirection.Left || _scrollDir == ScrollDirection.Right);
            if (!_scrollLinearX && isHorizontal) return false;
            if (!_scrollLinearY && !isHorizontal) return false;

            int d, dd = isHorizontal ? dx : dy;

            if (Math.Abs(dy) > 800 || Math.Abs(dx) > 800)
                return false;

            // scrollSpeed
            dd = dd * _config.ScrollSpeed / 100;

            // scrollAcc
            if (_config.ScrollAccelerationEnabled)
            {
                d = dd * dd / _config.ScrollAcceleration;
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

            d = _config.ScrollReverse ? d * -1 : d;

            if (d != 0)
            {
                var i = new NativeMethods.INPUT[1];

                i[0].type = NativeMethods.INPUT_MOUSE;
                i[0].mi.dwFlags = isHorizontal ? NativeMethods.MOUSEEVENTF_HWHEEL : NativeMethods.MOUSEEVENTF_WHEEL;
                i[0].mi.mouseData = d;

                NativeMethods.SendInput(1, i, Marshal.SizeOf(typeof(NativeMethods.INPUT)));


            }

            return true;
        }
    }
}
