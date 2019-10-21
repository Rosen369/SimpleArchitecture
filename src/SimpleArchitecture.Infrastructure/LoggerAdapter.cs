using NLog;
using SimpleArchitecture.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleArchitecture.Infrastructure
{
    public class LoggerAdapter<T> : IAppLogger<T>
    {
        private readonly ILogger _logger;

        public LoggerAdapter()
        {
            _logger = LogManager.GetLogger(typeof(T).Name);
        }

        public void Debug(object message)
        {
            _logger.Debug(message);
        }

        public void Debug(string message, Exception exception)
        {
            _logger.Debug(exception, message);
        }

        public void Info(object message)
        {
            _logger.Info(message);
        }

        public void Info(string message, Exception exception)
        {
            _logger.Info(exception, message);
        }

        public void Error(object message)
        {
            _logger.Error(message);
        }

        public void Error(string message, Exception exception)
        {
            _logger.Error(exception, message);
        }


        public void Fatal(object message)
        {
            _logger.Fatal(message);
        }

        public void Fatal(string message, Exception exception)
        {
            _logger.Fatal(exception, message);
        }


        public void Warn(object message)
        {
            _logger.Warn(message);
        }

        public void Warn(string message, Exception exception)
        {
            _logger.Warn(exception, message);
        }
    }
}
