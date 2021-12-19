using Commons.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Commons
{
    [Serializable]
    public class SessionManagement
    {
        public static string UserName
        {
            set
            {
                HttpContext.Current.Session["userName"] = value;
            }
            get
            {
                if (HttpContext.Current.Session["userName"] != null)
                    return HttpContext.Current.Session["userName"].ToString();
                else
                    return string.Empty;
            }
        }

        public static UserConfiguration UserConfigurations
        {
            set
            {
                HttpContext.Current.Session["UserConfig"] = value;
                HttpContext.Current.Session["UserNameTemp"] = value.UserInfo.User_Name;
            }
            get
            {
                if (HttpContext.Current.Session["UserConfig"] != null)
                    return (UserConfiguration)HttpContext.Current.Session["UserConfig"];
                else
                    return null;

            }
        }

        public static string ErrorMessage
        {
            set
            {
                HttpContext.Current.Session["UserError"] = value;
            }
            get
            {
                if (HttpContext.Current.Session["UserError"] != null)
                    return HttpContext.Current.Session["UserError"].ToString();
                else
                    return string.Empty;
            }
        }
    }
}
