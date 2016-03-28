using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace synGestures
{
    public class Logger : IDisposable
    {
        private readonly StreamWriter _sw;

        public Logger()
        {
            var a = Assembly.GetEntryAssembly();
            var loggerPath = Path.Combine(Path.GetDirectoryName(a.Location), "synGestures.log");
            _sw = new StreamWriter(loggerPath, true);
        }

        public void Log(string text)
        {
#if DEBUG
            Console.WriteLine(string.Format("[{0}] {1}", DateTime.Now, text));
#endif
            _sw.WriteLine(string.Format("[{0}] {1}", DateTime.Now, text));
            _sw.Flush();
        }

        public void LogDebug(string text)
        {
#if DEBUG
            _sw.WriteLine(string.Format("[{0}] [debug] {1}", DateTime.Now, text));
            _sw.Flush();
#endif
        }

        public void LogError(string text)
        {
            _sw.WriteLine(string.Format("[{0}] [error] {1}", DateTime.Now, text));
            _sw.Flush();
        }

        public void LogFatal(string text)
        {
            _sw.WriteLine(string.Format("[{0}] [fatal] {1}", DateTime.Now, text));
            _sw.Flush();
        }

        #region IDisposable Members

        public void Dispose()
        {
            _sw.Flush();
            _sw.Close();
            _sw.Dispose();
        }

        #endregion
    }
}
