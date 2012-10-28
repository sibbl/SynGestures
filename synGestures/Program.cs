using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Collections;
using System.Text;
using System.Threading;
using System.Diagnostics;


namespace synGestures
{

    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool createdNew = true;
            using (Mutex mutex = new Mutex(true, "synGesturesApp", out createdNew))
            {
                if (createdNew) {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    var mainClass = new synGesturesClass();
                    Application.ApplicationExit += new EventHandler(mainClass.tray_exit);
                    Application.Run();
                }
                else
                {
                    Process current = Process.GetCurrentProcess();
                    foreach (Process process in Process.GetProcessesByName(current.ProcessName))
                    {
                        if (process.Id != current.Id)
                        {
                            NativeMethods.SetForegroundWindow(process.MainWindowHandle);
                            break;
                        }
                    }
                }
            }
        }
    }
}
