using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;
using System.Windows.Forms;
using synGestures.Properties;
using System.Reflection;
using System.Xml.Serialization;
using System.IO;
using synGestures.Config;
using synGestures.Helper;
using WindowsInput;

namespace synGestures
{
    class synGesturesClass : IDisposable
    {
        private ContextMenu menu;
        private NotifyIcon icn;
        private InvokeActionManager actions;
        private SynapticsHelper synapticsHelper;

        private frmSettings settingsWindow = null;
        private bool settingsOpen = false;

        private string configPath;
        private Configuration config;

        public void tray_settings(object sender, EventArgs e)
        {
            if (settingsOpen)
            {
                try
                {
                    settingsWindow.Focus();
                }catch(Exception) {};
                return;
            }
            using (settingsWindow = new frmSettings())
            {
                settingsOpen = true;
                settingsWindow.actionManager = actions;
                var tempConfig = config.Clone();
                settingsWindow.config = config;
                var dlgResult = settingsWindow.ShowDialog();
                if (dlgResult == DialogResult.OK)
                {
                    config = settingsWindow.config;
                    if (settingsWindow.startWithWindows)
                    {
                        if (!Autostart.IsAutoStartEnabled()) Autostart.SetAutoStart();
                    }
                    else
                    {
                        if (Autostart.IsAutoStartEnabled()) Autostart.UnSetAutoStart();
                    }
                    config.Save(configPath);
                    actions.loadConfig(config);
                }
                else
                {
                    config = tempConfig;
                    synapticsHelper.config = tempConfig;
                    actions.loadConfig(config);
                }
                settingsWindow.Close();
                settingsOpen = false;
            }
        }
        public void tray_exit(object sender, EventArgs e)
        {
            icn.Visible = false;
            Application.Exit();
            return;
        }
        private bool ExecuteAction(ActionType type)
        {
            return actions.execute(type);
        }
        public synGesturesClass()
        {
            Assembly a = Assembly.GetEntryAssembly();
            configPath = Path.Combine(Path.GetDirectoryName(a.Location), "data.xml");
            config = Configuration.Load(configPath);

            actions = new InvokeActionManager(config);

            synapticsHelper = new SynapticsHelper(config);
            if (!synapticsHelper.Init())
            {
                Application.Exit();
                Environment.Exit(1);
                return;
            }
            synapticsHelper.actionEvent += ExecuteAction;

            menu = new ContextMenu();
            menu.MenuItems.Add("Settings", new EventHandler(tray_settings));
            menu.MenuItems.Add("-");
            menu.MenuItems.Add("Exit", new EventHandler(tray_exit));
            icn = new NotifyIcon
            {
                Visible = true,
                ContextMenu = menu,
                Icon = Resources.tray,
                Text = "SynGestures"
            };
            //icn.MouseClick += new MouseEventHandler(icn_click);

            SystemEvents.PowerModeChanged += new PowerModeChangedEventHandler(SystemEvents_PowerModeChanged);

            //synTouchPad.SetSynchronousNotification();
        }
        private void SystemEvents_PowerModeChanged(object sender, PowerModeChangedEventArgs e)
        {
            if (e.Mode == PowerModes.Resume)
            {
                synapticsHelper.Resume();
            }
        }
        public void Dispose()
        {
            icn.Visible = false;
        }
    }
}
