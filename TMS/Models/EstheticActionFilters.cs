using Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.WebPages;

namespace TMS.Models
{
    public class EstheticActionFilters: ActionFilterAttribute, IExceptionFilter
    {
        [ValidateAntiForgeryToken()]
        [ValidateInput(true)]
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //if (filterContext == null)
            //{
            //    throw new ArgumentNullException(nameof(filterContext));
            //}

            string IdentityProviderURL = System.Configuration.ConfigurationManager.AppSettings["IdentityProviderURL"].ToString();
            try
            {
                //UrlHelper helper = new UrlHelper(filterContext.RequestContext);
                bool isLocalUrl = true;
                if (filterContext.HttpContext.Request.Url != null)
                {
                    isLocalUrl = this.IsUrlLocalToHost(filterContext.HttpContext.Request, filterContext.HttpContext.Request.Url.AbsoluteUri); //helper.IsLocalUrl(filterContext.HttpContext.Request.Url.AbsoluteUri);
                    if (filterContext.HttpContext.Request.Url.ToString() != SanitizeUrl(filterContext.HttpContext.Request.Url.ToString()))
                    {
                        isLocalUrl = false;
                    }
                }
                if (!isLocalUrl)
                {
                    RouteValueDictionary redirectTargetDictionary = new RouteValueDictionary();
                    filterContext.Result = new RedirectToRouteResult(redirectTargetDictionary);
                    redirectTargetDictionary.Add("error", "Open Redirect Attack Detected - You are not authorized to view this page. Please contact VLR administrator.");
                    filterContext.Result = new RedirectResult(IdentityProviderURL + "?error=Open Redirect Attack Detected - You are not authorized to view this page. Please contact VLR administrator.");
                    return;
                }
            }
            catch (Exception ex)
            {
                CustomLogging.LogMessage(ex.ToString(), LogType.Error);
            }
        }

        [ValidateAntiForgeryToken()]
        public virtual void OnException(ExceptionContext filterContext)
        {
            //if (filterContext == null)
            //{
            //    throw new ArgumentNullException(nameof(filterContext));
            //}

            ExceptionHandler.HandleException("VLRActionFilter-OnException", filterContext.Exception);

            RouteValueDictionary redirectTargetDictionary = new RouteValueDictionary();
            redirectTargetDictionary.Add("action", "Index");
            redirectTargetDictionary.Add("controller", "Error");

            if (Constants.ShowErrorDetial == true)
                SessionManagement.ErrorMessage = filterContext.Exception.ToString();

            filterContext.Result = new RedirectToRouteResult(redirectTargetDictionary);

            filterContext.ExceptionHandled = true;


        }

        public string SanitizeUrl(string url)
        {
            string regularExpression = Constants.SanitizeURLRegex;
            regularExpression = (!string.IsNullOrEmpty(regularExpression) ? regularExpression : @"[^-A-Za-z0-9+&@#\/%?=~_|!:,.;\(\)– ] ");
            Regex rgx = new Regex(regularExpression);
            string result = rgx.Replace(url, "");
            return result;
        }

        public bool IsUrlLocalToHost(HttpRequestBase request, string url)
        {
            if (url.IsEmpty())
            {
                return false;
            }

            Uri absoluteUri;
            if (Uri.TryCreate(url, UriKind.Absolute, out absoluteUri))
            {
                return String.Equals(request.Url.Host, absoluteUri.Host,
                            StringComparison.OrdinalIgnoreCase);
            }
            else
            {
                bool isLocal = !url.StartsWith("http:", StringComparison.OrdinalIgnoreCase)
                    && !url.StartsWith("https:", StringComparison.OrdinalIgnoreCase)
                    && Uri.IsWellFormedUriString(url, UriKind.Relative);
                return isLocal;
            }
        }
    }
}