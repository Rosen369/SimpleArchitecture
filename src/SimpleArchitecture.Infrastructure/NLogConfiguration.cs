using NLog;
using NLog.Config;
using NLog.Targets;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleArchitecture.Infrastructure
{
    public class NLogConfiguration
    {
        public static LoggingConfiguration Config()
        {
            var res = new LoggingConfiguration();

            var logfile = new FileTarget("logfile")
            {
                Layout = @"${date:format=HH\:mm\:ss} ${logger} ${level} ${message} ${exception}",
                FileName = "${basedir}/${shortdate}.log"
            };

            var logconsole = new ColoredConsoleTarget("logconsole")
            {
                Layout = @"${date:format=HH\:mm\:ss} ${logger} ${level} ${message} ${exception}"
            };

            res.AddRule(LogLevel.Info, LogLevel.Fatal, logconsole);
            res.AddRule(LogLevel.Debug, LogLevel.Fatal, logfile);

            return res;
        }
    }
}
