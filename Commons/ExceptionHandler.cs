using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;

namespace Commons
{
    public class ExceptionHandler
    {
        public static void HandleException(string pageName, Int32 messageCode, System.Exception ex, Page page)
        {
            try
            {
                if (ex is Exception)
                {
                    StringBuilder str = new StringBuilder("");
                    str.Append(ex.Message.ToString());
                    str.Append(System.Environment.NewLine);
                    if (ex.InnerException != null)
                    {
                        str.Append(" InnerException: ");
                        str.Append(ex.InnerException.ToString());
                        str.Append(System.Environment.NewLine);
                    }
                    str.Append(" StackTrace: ");
                    str.Append(ex.StackTrace.ToString());

                    CustomLogging.LogMessage(str.ToString(), LogType.Error);

                }
            }
            catch (Exception exp)
            {
                LogToEventViewer(exp.StackTrace.ToString());
            }
        }

        public static void HandleException(string pageName, string businessMessage, System.Exception ex, Page page)
        {
            try
            {
                if (ex is Exception)
                {
                    StringBuilder str = new StringBuilder("");
                    str.Append(ex.Message.ToString());
                    str.Append(System.Environment.NewLine);
                    if (ex.InnerException != null)
                    {
                        str.Append(" InnerException: ");
                        str.Append(ex.InnerException.ToString());
                        str.Append(System.Environment.NewLine);
                    }
                    str.Append(" StackTrace: ");
                    str.Append(ex.StackTrace.ToString());

                    //LogCentral.Current.WriteLog(pageName, ex, LogType.Error);
                    CustomLogging.LogMessage(str.ToString(), LogType.Error);
                }
            }
            catch (Exception exp)
            {
                LogToEventViewer(exp.StackTrace.ToString());
            }
        }

        public static void HandleException(string pageName, System.Exception ex)
        {
            try
            {
               if (ex is Exception)
                {
                    StringBuilder str = new StringBuilder("");
                    str.Append(ex.Message.ToString());
                    str.Append(System.Environment.NewLine);
                    if (ex.InnerException != null)
                    {
                        str.Append("InnerException: ");
                        str.Append(ex.InnerException.ToString());
                        str.Append(System.Environment.NewLine);
                    }
                    str.Append(" StackTrace: ");
                    str.Append(ex.StackTrace.ToString());
                    //LogCentral.Current.WriteLog(pageName, ex, LogType.Error);
                    CustomLogging.LogMessage(str.ToString(), LogType.Error);
                }
            }
            catch (Exception exp)
            {
                LogToEventViewer(exp.StackTrace.ToString());

            }
        }

        public static void LogMessage(string pageName, String message)
        {
            try
            {

                CustomLogging.LogMessage(message, LogType.Error);

            }
            catch (Exception ex)
            {
                LogToEventViewer(ex.StackTrace.ToString());
            }
        }
        public static void LogMessage(String message, LogType lg)
        {
            try
            {

                CustomLogging.LogMessage(message, lg);

            }
            catch (Exception ex)
            {
                LogToEventViewer(ex.StackTrace.ToString());
            }
        }
        public static void HandleException(System.Exception ex)
        {
            try
            {
               if (ex is Exception)
                {
                    StringBuilder str = new StringBuilder("");
                    str.Append(ex.Message.ToString());
                    str.Append(System.Environment.NewLine);
                    if (ex.InnerException != null)
                    {
                        str.Append(" InnerException: ");
                        str.Append(ex.InnerException.ToString());
                        str.Append(System.Environment.NewLine);
                    }
                    str.Append(" StackTrace: ");
                    str.Append(ex.StackTrace.ToString());

                    //LogCentral.Current.WriteLog(ex, LogType.Error);
                    CustomLogging.LogMessage(str.ToString(), LogType.Error);

                }
            }
            catch (Exception exp)
            {
                LogToEventViewer(exp.StackTrace.ToString());

            }
        }

        private static void LogToEventViewer(string msg)
        {

            try
            {
                System.Diagnostics.EventLog.WriteEntry("EstheticDevelopers Suite", msg);
            }
            catch (Exception)
            {

                // TODO
                // Handle security access issue
            }

        }
    }
}
