using System;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using System.Linq;


namespace synGestures
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            bool createdNew;
            using (new Mutex(true, "synGesturesApp", out createdNew))
            {
                if (createdNew) {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    var mainClass = new SynGesturesLogic();
                    Application.ApplicationExit += mainClass.tray_exit;
                    Application.Run();
                }
                else
                {
                    var current = Process.GetCurrentProcess();
                    foreach (var process in Process.GetProcessesByName(current.ProcessName).Where(process => process.Id != current.Id))
                    {
                        NativeMethods.SetForegroundWindow(process.MainWindowHandle);
                        break;
                    }
                }
            }
        }
    }
}
