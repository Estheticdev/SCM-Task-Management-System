using BusinessAccessLayer.BAL;
using Commons;
using Commons.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace TMS.Controllers
{
    public class CommonController : BaseController
    {
        // GET: Common
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetDropDownData(List<DropDownData> param, string DropDown)
        {
            try
            {
                BAL BusinessAccessLayer = new BAL();
                List<DropDownData> lst = BusinessAccessLayer.GetDropDownData(param, DropDown);
                return Json(lst, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                CustomLogging.LogMessage("Exception: " + ex.ToString() + Environment.NewLine + "Stack Trace: " + ex.StackTrace + Environment.NewLine + "Message: " + ex.Message, LogType.Error);
                return Json("Error", JsonRequestBehavior.AllowGet);
            }
        }
    }
}