using HiWeb.Interface;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HiWeb.Services
{

    public class AppLogger : Interface.ILogger
    {
        Logger logger = LogManager.GetLogger("HiWeb");

        public void LogMessage(string message)
        {
            logger.Log(LogLevel.Info, message);
        }
    }
}