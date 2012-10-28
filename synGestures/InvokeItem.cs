using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WindowsInput;
using System.Runtime.InteropServices;
using System.Drawing;

namespace synGestures
{
    public class InvokeItem
    {
        
        enum Type { Unknown, Mouse, Keyboard };

        const String DEFAULT_NAME = "Custom action";

        public bool invokeKeyPress;
        public List<VirtualKeyCode> keysHold;
        public VirtualKeyCode keyPress;

        public bool invokeMousePress;
        public List<MouseKeyCode> mouseButtonsDown;

        public InvokeItem()
        {
            invokeKeyPress = false;
            invokeMousePress = false;
        }
        public InvokeItem(VirtualKeyCode _keyPress)
        {
            invokeKeyPress = true;
            invokeMousePress = false;
            keysHold = new List<VirtualKeyCode>();
            keyPress = _keyPress;
        }
        public InvokeItem(VirtualKeyCode _keyHold, VirtualKeyCode _keyPress)
        {
            invokeKeyPress = true;
            invokeMousePress = false;
            keysHold = new List<VirtualKeyCode>(new[] { _keyHold });
            keyPress = _keyPress;
        }
        public InvokeItem(IEnumerable<VirtualKeyCode> _keysHold, VirtualKeyCode _keyPress)
        {
            invokeKeyPress = true;
            invokeMousePress = false;
            keysHold = new List<VirtualKeyCode>(_keysHold);
            keyPress = _keyPress;
        }
        public InvokeItem(MouseKeyCode _mouseButtonDown)
        {
            invokeKeyPress = false;
            invokeMousePress = true;
            mouseButtonsDown = new List<MouseKeyCode>(new[] { _mouseButtonDown });
        }
        public InvokeItem(IEnumerable<MouseKeyCode> _mouseButtonsDown)
        {
            invokeKeyPress = false;
            invokeMousePress = true;
            mouseButtonsDown = new List<MouseKeyCode>(_mouseButtonsDown);
        }
        public void Execute()
        {
            if (invokeKeyPress)
            {
                if (keyPress == VirtualKeyCode.NONAME) return;
                if (keysHold == null || keysHold.Count == 0)
                    InputSimulator.SimulateKeyPress(keyPress);
                else
                    InputSimulator.SimulateModifiedKeyStroke(keysHold, keyPress);
            }
            else if (invokeMousePress)
            {
                if (mouseButtonsDown == null || mouseButtonsDown.Count == 0) return;
                uint inputCount = (uint)(mouseButtonsDown.Count * 2);
                var i = new NativeMethods.INPUT[inputCount];
                var k = 0;

                foreach (var mouseEvent in mouseButtonsDown)
                {
                    int mouseIdDown = NativeMethods.MOUSEEVENTF_LEFTDOWN;
                    int mouseIdUp = NativeMethods.MOUSEEVENTF_LEFTUP;
                    if (mouseEvent == MouseKeyCode.Middle)
                    {
                        mouseIdDown = NativeMethods.MOUSEEVENTF_MIDDLEDOWN;
                        mouseIdUp = NativeMethods.MOUSEEVENTF_MIDDLEUP;
                    }
                    else if (mouseEvent == MouseKeyCode.Right)
                    {
                        mouseIdDown = NativeMethods.MOUSEEVENTF_RIGHTDOWN;
                        mouseIdUp = NativeMethods.MOUSEEVENTF_RIGHTUP;
                    }
                    i[k].type = NativeMethods.INPUT_MOUSE;
                    i[k].mi.dwFlags = mouseIdDown;
                    k++;
                    i[k].type = NativeMethods.INPUT_MOUSE;
                    i[k].mi.dwFlags = mouseIdUp;
                    k++;
                }

                NativeMethods.SendInput(inputCount, i, Marshal.SizeOf(typeof(NativeMethods.INPUT)));
            }
        }
    }
}
