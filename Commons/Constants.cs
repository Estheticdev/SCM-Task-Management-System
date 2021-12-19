using Commons.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commons
{
    public static class Constants
    {
        public static string ClinicCode = ConfigurationHelper.ClinicCode;

        public static string SanitizeURLRegex
        {
            get
            {
                try
                {
                    string sURLRegex = ConfigurationManager.AppSettings["SanitizeURLRegex"];
                    if (!string.IsNullOrEmpty(sURLRegex))
                        return sURLRegex;
                    else
                        return "";
                }
                catch (Exception)
                {
                    return "";
                }
            }
        }

        public static bool ShowErrorDetial
        {
            get
            {
                try
                {
                    if (ConfigurationManager.AppSettings["ShowErrorDetial"] != null)
                        return Convert.ToBoolean(ConfigurationManager.AppSettings["ShowErrorDetial"]);
                    else
                        return false;
                }
                catch (Exception)
                {

                    return false;
                }
            }
        }

        public static string GetEndpoints(string Key)
        {
            return ConfigurationManager.AppSettings[Key].ToString();
        }
    }
}
