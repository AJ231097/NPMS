﻿using Microsoft.Extensions.Logging;
using System;
using System.Globalization;
using System.IO;

namespace NPMS.Utils
{
    public class FileLogger : ILogger
    {
        private string filePath;
        private static object _lock = new object();

        public FileLogger(string path)
        {
            filePath = path;
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (formatter != null)
            {
                lock (_lock)
                {
                    string fullFilePath = Path.Combine(filePath, "log_" + DateTime.UtcNow.ToString("yyyy-MM-dd") + ".txt");
                    var n = Environment.NewLine;
                    string exc = string.Empty;
                    if (exception != null)
                    {
                        exc = $"{n}{exception.GetType()}: {exception.Message}{n}{exception.StackTrace}{n}";
                    }
                    string message = $"{DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ", CultureInfo.InvariantCulture)} [{logLevel}]: ";
                    message += $"{formatter(state, exception)}{n}{exc}";
                    File.AppendAllText(fullFilePath, message);
                }
            }
        }
    }
}