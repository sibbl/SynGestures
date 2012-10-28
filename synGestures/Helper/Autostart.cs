using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;
using System.Reflection;

namespace synGestures.Helper
{
    class Autostart
    {
        private const string RUN_LOCATION = @"Software\Microsoft\Windows\CurrentVersion\Run";

        public static void SetAutoStart()
        {
            SetAutoStart("synGestures", Assembly.GetExecutingAssembly().Location);
        }
        public static bool IsAutoStartEnabled()
        {
            return IsAutoStartEnabled("synGestures", Assembly.GetExecutingAssembly().Location);
        }
        public static void UnSetAutoStart()
        {
            UnSetAutoStart("synGestures");
        }

        public static void SetAutoStart(string keyName, string assemblyLocation)
        {
            RegistryKey key = Registry.CurrentUser.CreateSubKey(RUN_LOCATION);
            key.SetValue(keyName, assemblyLocation);
        }

        public static bool IsAutoStartEnabled(string keyName, string assemblyLocation)
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(RUN_LOCATION);
            if (key == null)
                return false;

            string value = (string)key.GetValue(keyName);
            if (value == null)
                return false;

            return (value == assemblyLocation);
        }

        public static void UnSetAutoStart(string keyName)
        {
            RegistryKey key = Registry.CurrentUser.CreateSubKey(RUN_LOCATION);
            key.DeleteValue(keyName);
        }
    }
}
