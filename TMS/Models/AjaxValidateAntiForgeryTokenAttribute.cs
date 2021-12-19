using System;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Net;
using System.Configuration;
using Commons;

namespace TMS.Models
{
    [AttributeUsage(validOn:AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class AjaxValidateAntiForgeryTokenAttribute : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            try
            {
                var request = filterContext.HttpContext.Request;
                if (ValidateReferrer(request))
                {
                    if (request.HttpMethod == WebRequestMethods.Http.Post)
                    {
                        if (filterContext.HttpContext.Request.IsAjaxRequest()) // if it is ajax request.
                        {
                            this.ValidateRequestHeader(filterContext.HttpContext.Request); // run the validation.
                        }
                        else
                        {
                            AntiForgery.Validate();
                        }
                    }
                    else if (request.HttpMethod == WebRequestMethods.Http.Get)
                    {
                        this.ValidateRequestQuery(filterContext.HttpContext.Request); // run the validation.
                    }
                    
                }
                else
                { 
                    string validReferrer = string.Empty;
                    if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["ReferrerURL"]))
                    {
                        validReferrer = ConfigurationManager.AppSettings["ReferrerURL"];
                    }
                    string msg = "Invalid Referrer: " + validReferrer;
                    if (request.UrlReferrer != null)
                    {
                        msg += " It should be: " + request.UrlReferrer.Host.ToString();
                    }
                    throw new Exception(msg);
                }


            }
            catch (Exception ex)
            {
                var request = filterContext.HttpContext.Request;
                CustomLogging.LogMessage("Error while loading request " + request.Url.ToString(), LogType.Error);
                CustomLogging.LogMessage(ex.ToString(), LogType.Error);
                //throw new HttpAntiForgeryException("Anti forgery token not found");
                var response = filterContext.HttpContext.Response;
                response.StatusCode = (int)HttpStatusCode.NotFound;
                try
                {
                    response.AddHeader("CustomHeader", "RedirectToLogin");
                    response.Redirect("~/Login/LoginUser?error=Your session has been expired. Please log in again.");
                }
                catch (Exception ex1s)
                {
                    CustomLogging.LogMessage(ex1s.ToString(), LogType.Error);

                    throw;
                }
            }
        }

        private void ValidateRequestHeader(HttpRequestBase request)
        {
            string cookieToken = string.Empty;
            string formToken = string.Empty;
            string tokenValue = request.Headers["RequestVerificationToken"]; // read the header key and validate the tokens.
            if (!string.IsNullOrEmpty(tokenValue))
            {
                string[] tokens = tokenValue.Split(':');
                if (tokens.Length == 2)
                {
                    cookieToken = tokens[0].Trim();
                    formToken = tokens[1].Trim();
                }
            }
            //CustomLogging.LogMessage("Token: " + tokenValue, LogType.Info);

            AntiForgery.Validate(cookieToken, formToken); // this validates the request token.
        }

        private void ValidateRequestQuery(HttpRequestBase request)
        {
            string cookieToken = string.Empty;
            string formToken = string.Empty;
            string tokenValue = request.QueryString["RequestVerificationToken"]; // read the header key and validate the tokens.
            if (!string.IsNullOrEmpty(tokenValue))
            {
                string[] tokens = tokenValue.Split(':');
                if (tokens.Length == 2)
                {
                    cookieToken = tokens[0].Trim();
                    formToken = tokens[1].Trim();
                }
            }

            //CustomLogging.LogMessage(request.FilePath, LogType.Error);
            if (!IsAllowedURL(request.FilePath))
            {
                AntiForgery.Validate(cookieToken, formToken); // this validates the request token.
            }
        }

        private bool IsAllowedURL(string url)
        {
            string urls=string.Empty;
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["AllowedPages"]))
            {
                urls = ConfigurationManager.AppSettings["AllowedPages"];
            }
            if (urls.Contains(url))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        private bool ValidateReferrer(HttpRequestBase request)
        {
            //return true;
            string validReferrer = string.Empty;
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["ReferrerURL"]))
            {
                validReferrer = ConfigurationManager.AppSettings["ReferrerURL"];
            }

            //CustomLogging.LogMessage("HOST: " + (request.UrlReferrer == null ? "" : request.UrlReferrer.Host), LogType.Info);
            //CustomLogging.LogMessage("ReferrerURL: " + validReferrer, LogType.Info);

            if (request.Url != null && ((request.UrlReferrer != null && request.UrlReferrer.Host == validReferrer) || IsAllowedURL(request.FilePath)))
            {
                return true;
            }
            return false;
        }
    }
}
