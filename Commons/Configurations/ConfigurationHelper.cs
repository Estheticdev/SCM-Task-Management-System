using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commons.Configuration
{
    class ConfigurationHelper
    {
        public static readonly string ClinicCode = ConfigurationManager.AppSettings["ClinicCode"].ToString();
        public static readonly string SMTPServer = ConfigurationManager.AppSettings["SMTPServer"] ?? string.Empty;
        public static readonly string SMTPUser = ConfigurationManager.AppSettings["SMTPUserName"] ?? string.Empty;
        public static readonly string SMTPPassword = SecurityManager.Decrypt(ConfigurationManager.AppSettings["SMTPPassword"] ?? string.Empty);
        public static readonly string SMTPPort = ConfigurationManager.AppSettings["SMTPPort"] ?? string.Empty;
        public static readonly string eMailSubject = ConfigurationManager.AppSettings["eMailSubject"] ?? string.Empty;
        public static readonly string eMailTo = ConfigurationManager.AppSettings["eMailTo"] ?? string.Empty;
        public static readonly string eMailCC = ConfigurationManager.AppSettings["eMailCC"] ?? string.Empty;
        public static readonly string eMailFrom = ConfigurationManager.AppSettings["eMailFrom"] ?? string.Empty;
        public static readonly string SSL = ConfigurationManager.AppSettings["EnableSSL"] ?? string.Empty;
    }
}
