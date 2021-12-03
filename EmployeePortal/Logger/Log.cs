using System;
using System.IO;
using System.Text;

namespace Logger
{
    /// <summary>
    /// Represent a log using Singleton Design Pattern.
    /// </summary>
    /// <remarks>sealed keyword is to prevent inheritance.</remarks>
    public sealed class Log : ILog
    {
        /// <summary>
        /// Lazy instantiation. Multi-thread safe.
        /// </summary>
        private static readonly Lazy<Log> instance = new Lazy<Log>(() => new Log());
        private Log()
        {
        }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        public static Log GetInstance
        {
            get { return instance.Value; }
        }

        /// <summary>
        /// Log exception message.
        /// </summary>
        /// <param name="message">Message.</param>
        public void LogException(string message)
        {
            string fileName = $"Exception_{DateTime.Today.ToString("yyyy-MM-dd")}.log";
            string logFilePath = $@"{AppDomain.CurrentDomain.BaseDirectory}\{fileName}";
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.ff"));
            sb.AppendLine(message);
            using(StreamWriter writer = new StreamWriter(logFilePath, true))
            {
                writer.Write(sb.ToString());
                writer.Flush();
            }
        }
    }
}