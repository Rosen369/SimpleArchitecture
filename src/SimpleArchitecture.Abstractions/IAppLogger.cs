using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleArchitecture.Abstractions
{
    public interface IAppLogger<T>
    {
        void Debug(object message);

        void Debug(string message, Exception exception);

        void Info(object message);

        void Info(string message, Exception exception);

        void Error(object message);

        void Error(string message, Exception exception);

        void Fatal(object message);

        void Fatal(string message, Exception exception);

        void Warn(object message);

        void Warn(string message, Exception exception);
    }
}
