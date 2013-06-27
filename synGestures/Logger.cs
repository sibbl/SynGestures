﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace synGestures
{
    public class Logger : IDisposable
    {
        private StreamWriter sw;

        public Logger()
        {
            Assembly a = Assembly.GetEntryAssembly();
            var loggerPath = Path.Combine(Path.GetDirectoryName(a.Location), "synGestures.log");
            sw = new StreamWriter(loggerPath, true);
        }

        public void Log(string text)
        {
#if DEBUG
            Console.WriteLine(string.Format("[{0}] {1}", DateTime.Now, text));
#endif
            sw.WriteLine(string.Format("[{0}] {1}", DateTime.Now, text));
            sw.Flush();
        }

        public void LogDebug(string text)
        {
#if DEBUG
            sw.WriteLine(string.Format("[{0}] [debug] {1}", DateTime.Now, text));
            sw.Flush();
#endif
        }

        public void LogError(string text)
        {
            sw.WriteLine(string.Format("[{0}] [error] {1}", DateTime.Now, text));
            sw.Flush();
        }

        public void LogFatal(string text)
        {
            sw.WriteLine(string.Format("[{0}] [fatal] {1}", DateTime.Now, text));
            sw.Flush();
        }

        #region IDisposable Members

        public void Dispose()
        {
            sw.Flush();
            sw.Close();
            sw.Dispose();
        }

        #endregion
    }
}
