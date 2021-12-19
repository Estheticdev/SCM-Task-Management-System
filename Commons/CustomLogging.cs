using Commons;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commons
{
    public static class CustomLogging
    {

        public static void LogMessage(string message, LogType logType)
        {
            log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            try
            {
                switch (logType)
                {
                    case LogType.Debug:
                        log.Debug(message);
                        break;
                    case LogType.Info:
                        log.Info(message);
                        break;
                    case LogType.Error:
                        log.Error(message);
                        break;
                    case LogType.Warn:
                        log.Warn(message);
                        break;
                    case LogType.Fatal:
                        log.Fatal(message);
                        break;
                    default:
                        break;
                }
            }
            catch
            {
                throw new ApplicationException("Some went wrong while longing");
            }
        }
    }
}
