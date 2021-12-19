using TMS.Models;
using Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TMS.Controllers
{
    [EstheticActionFilters]
    [AjaxValidateAntiForgeryTokenAttribute]
    public class BaseController : AsyncController
    {
        public static bool Is_Authorized(string MenuName, string ActionName)
        {

            bool result = false;
            //if (SessionManagement.UserConfigurations.ScreenActions.Where(p => p.Action_Name.ToLower() == ActionName.ToLower() && p.Menu_Name.ToLower() == MenuName.ToLower()).ToList().Count > 0)
            //    return true;

            return result;

        }
        public JsonResult GetJSONObject(bool isSuccess, string jsonStr)
        {
            JsonResult DataJson = new JsonResult
            {
                Data = new { success = isSuccess, error = jsonStr },
                JsonRequestBehavior = JsonRequestBehavior.AllowGet

            };

            return DataJson;
        }
        public static bool Is_Authorized(string MenuName)
        {

            bool result = false;
            //if (SessionManagement.UserConfigurations.ScreenMenus.Where(p => p.Menu_Name.ToLower() == MenuName.ToLower()).ToList().Count > 0)
            //    return true;

            return result;

        }

        //public static ViewBagErrors HandleViewError(Enums.ErrorMessageType errorType, Exception ex, RouteData routeData)
        //{
        //    var controllerName = routeData.Values["controller"];
        //    var actionName = routeData.Values["action"];
        //    string pageInfo = "ControllerName: " + controllerName + " , ActionName: " + actionName;
        //    ExceptionHandler.HandleException(pageInfo, ex);

        //    ViewBagErrors vbr = new ViewBagErrors();
        //    vbr.ErrorMsg = ex.Message;
        //    vbr.HasError = true;
        //    vbr.ErrorType = errorType.ToString();
        //    return vbr;
        //}
        //public static ViewBagErrors HandleViewError(Enums.ErrorMessageType errorType, string Msg, RouteData routeData)
        //{
        //    var controllerName = routeData.Values["controller"];
        //    var actionName = routeData.Values["action"];
        //    string pageInfo = "ControllerName: " + controllerName + " , ActionName: " + actionName;
        //    ExceptionHandler.LogMessage(pageInfo, Msg);

        //    ViewBagErrors vbr = new ViewBagErrors();
        //    vbr.ErrorMsg = Msg;
        //    vbr.HasError = true;
        //    vbr.ErrorType = errorType.ToString();
        //    return vbr;
        //}
        //public static ViewBagErrors HandleViewError(Enums.ErrorMessageType errorType, string Msg)
        //{

        //    ViewBagErrors vbr = new ViewBagErrors();
        //    vbr.ErrorMsg = Msg;
        //    vbr.HasError = true;
        //    vbr.ErrorType = errorType.ToString();
        //    return vbr;
        //}

        //public static HistoryDataFilter GetHistoryView(ScreenConfiguration sc)
        //{


        //    VLRUtility.GetHistoryFieldData(ref sc);
        //    return SessionManagement.GetHistoryDataFilter(sc.Id.ToString());
        //}
    }
}