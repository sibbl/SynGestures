using System;
using Microsoft.Win32;
using System.Windows.Forms;
using synGestures.Properties;
using System.Reflection;
using System.IO;
using synGestures.Config;
using synGestures.Helper;

namespace synGestures
{
    class SynGesturesLogic : IDisposable
    {
        private readonly ContextMenu _menu;
        private readonly NotifyIcon _icn;
        private readonly InvokeActionManager _actions;
        private readonly SynapticsHelper _synapticsHelper;

        private frmSettings _settingsWindow;
        private bool _settingsOpen;

        private readonly string _configPath;
        private Configuration _config;

        public void tray_settings(object sender, EventArgs e)
        {
            if (_settingsOpen)
            {
                try
                {
                    _settingsWindow.Focus();
                }
                catch (Exception)
                {
                    //ignore
                }
                return;
            }
            using (_settingsWindow = new frmSettings())
            {
                _settingsOpen = true;
                _settingsWindow.actionManager = _actions;
                var tempConfig = _config.Clone();
                _settingsWindow.config = _config;
                var dlgResult = _settingsWindow.ShowDialog();
                if (dlgResult == DialogResult.OK)
                {
                    _config = _settingsWindow.config;
                    if (_settingsWindow.startWithWindows)
                    {
                        if (!Autostart.IsAutoStartEnabled()) Autostart.SetAutoStart();
                    }
                    else
                    {
                        if (Autostart.IsAutoStartEnabled()) Autostart.UnSetAutoStart();
                    }
                    _config.Save(_configPath);
                    _actions.LoadConfig(_config);
                }
                else
                {
                    _config = tempConfig;
                    _synapticsHelper.Config = tempConfig;
                    _actions.LoadConfig(_config);
                }
                _settingsWindow.Close();
                _settingsOpen = false;
            }
        }
        public void tray_exit(object sender, EventArgs e)
        {
            _icn.Visible = false;
            Application.Exit();
        }
        private bool ExecuteAction(ActionType type)
        {
            return _actions.Execute(type);
        }
        public SynGesturesLogic()
        {
            var a = Assembly.GetEntryAssembly();
            _configPath = Path.Combine(Path.GetDirectoryName(a.Location), "synGesturesData.xml");
            _config = Configuration.Load(_configPath);

            _actions = new InvokeActionManager(_config);

            _synapticsHelper = new SynapticsHelper(_config);
            if (!_synapticsHelper.Init())
            {
                Application.Exit();
            }
            _synapticsHelper.ActionEvent += ExecuteAction;

            _menu = new ContextMenu();
            _menu.MenuItems.Add("Settings", new EventHandler(tray_settings));
            _menu.MenuItems.Add("-");
            _menu.MenuItems.Add("Exit", new EventHandler(tray_exit));
            _icn = new NotifyIcon
            {
                Visible = true,
                ContextMenu = _menu,
                Icon = Resources.tray,
                Text = "SynGestures"
            };
            //icn.MouseClick += new MouseEventHandler(icn_click);

            SystemEvents.PowerModeChanged += SystemEvents_PowerModeChanged;
        }
        private void SystemEvents_PowerModeChanged(object sender, PowerModeChangedEventArgs e)
        {
            if (e.Mode == PowerModes.Resume)
            {
                _synapticsHelper.Resume();
            }
        }
        public void Dispose()
        {
            _icn.Visible = false;
        }
    }
}
