using TMS.Models;
using BusinessAccessLayer.BAL;
using Commons;
using Commons.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TMS.Controllers
{
    public class ClinicController : Controller
    {
        Models.commonModal _dbContext;
        Int64 clinicCode = Convert.ToInt64(Commons.Constants.ClinicCode);
        public ClinicController()
        {
            _dbContext = new Models.commonModal();
        }

        public ActionResult AddEditClinic()
        {
            if (Session["userName"] != null)
            {
                BAL accessLayer = new BAL();
            ViewBag.Parimary = accessLayer.GetPrimary();
            ViewBag.Status = accessLayer.GetStatus();
            ViewBag.Client = accessLayer.Client();
            ViewBag.ProjectType = accessLayer.ProjectType();
            return View();
        }
            else
            {
                return RedirectToAction("LoginUser", "Login", new { userName = "" });
            }
        }

        public ActionResult ClinicDetails()
        {
            if (Session["userName"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("LoginUser", "Login", new { userName = "" });
            }

        }

        public ActionResult ViewClinic()
        {
            if (Session["userName"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("LoginUser", "Login", new { userName = "" });
            }

        }

        [HttpGet]
        public ActionResult GetClinicDetail()
        {
            
            var lstuser = _dbContext.Clinic_Information.Where(s => s.Clinic_Code == clinicCode).ToList();
            return Json(lstuser, JsonRequestBehavior.AllowGet);
        }



        [HttpGet]
        public ActionResult GetClinicDetailByID(int RecordNumber)//activity sheet get data
        {
            BAL aL = new BAL();
            var data = aL.GetActivitySheetDataByRecordNumber(RecordNumber);
            var lstData = data.ToList<tbl_current_months>();
            return Json(lstData, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult AddClinicIndformation([Bind(Exclude = "Clinic_ID")] Clinic_Information clinic)
        {
            try
            {
                clinic.Clinic_Code = Convert.ToInt64(Commons.Constants.ClinicCode);

                if (ModelState.IsValid)
                {
                    if (System.Web.HttpContext.Current.Request.Files.AllKeys.Any())
                    {
                        foreach (string file in System.Web.HttpContext.Current.Request.Files)
                        {
                            string fileName = string.Empty;
                            try
                            {
                                HttpPostedFile hpf = System.Web.HttpContext.Current.Request.Files[file] as HttpPostedFile;

                            }
                            catch (Exception ex)
                            {
                                CustomLogging.LogMessage("Exception: " + ex.ToString() + Environment.NewLine + "Stack Trace: " + ex.StackTrace + Environment.NewLine + "Message: " + ex.Message, LogType.Error);
                            }
                        }
                    }

                    clinic.Created_Date = DateTime.Now;
                    clinic.Created_By = Convert.ToInt32(Session["UserID"]);
                    _dbContext.Clinic_Information.Add(clinic);
                    _dbContext.SaveChanges();

                    this.SaveClinicTimeSlabs(clinic.Time_Start, clinic.Time_End);
                }

                return Json(clinic, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                CustomLogging.LogMessage("Exception: " + ex.ToString() + Environment.NewLine + "Stack Trace: " + ex.StackTrace + Environment.NewLine + "Message: " + ex.Message, LogType.Error);
                return Json(clinic, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult UpdateClinicIndformation(Clinic_Information clinic)
        {
            try
            {
                clinic.Clinic_Code = Convert.ToInt64(Commons.Constants.ClinicCode);

                if (ModelState.IsValid)
                {
                    clinic.Modified_Date = DateTime.Now;
                    clinic.Modified_By = Convert.ToInt32(Session["UserID"]);
                    _dbContext.Entry(clinic).State = EntityState.Modified;
                    _dbContext.SaveChanges();

                    this.SaveClinicTimeSlabs(clinic.Time_Start, clinic.Time_End);
                }
                return Json("Success", JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {
                CustomLogging.LogMessage("Exception: " + ex.ToString() + Environment.NewLine + "Stack Trace: " + ex.StackTrace + Environment.NewLine + "Message: " + ex.Message, LogType.Error);
                return Json("Error", JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        //public ActionResult Saveupdateactivitysheet(tbl_current_months activity)
        public ActionResult Saveupdateactivitysheet(string RecordNumber, string Content_Type, string ProjectName, string Pro_Rel_Pat_number, string Plan_Codefreeze, string plan_shipment, string shipped, string jira_issue, string optimization, string actual_build, string actual_codefreeze, string actual_shipment, string build_machine, string client, string comments, string created, string itemtype, string path, string internal_cr, string uat_issue, string gaps, string fault, string modification, string datacorrection, string enhacement, string others, string total_category_hd, string crittical, string minor, string moderate, string total_priory_hd, string time_planned_code_freeze, string time_actual_code_freeze, string time_planned_shipment, string time_actual_shipment, string primary_name, string secondary_name, string status, string effor_hours) //Qasim Save Activity sheet data
        {
            try
            {
                 
                //activity.RecordNumber = Convert.ToInt64(Commons.Constants.ClinicCode);

                if (ModelState.IsValid)
                {
                    BAL BusinessAccessLayer = new BAL();
                    //BusinessAccessLayer.Saveupdateactivitysheet(activity);
                    BusinessAccessLayer.Saveupdateactivitysheet(RecordNumber, Content_Type, ProjectName, Pro_Rel_Pat_number, Plan_Codefreeze, plan_shipment, shipped, jira_issue, optimization, actual_build, actual_codefreeze, actual_shipment, build_machine, client, comments, created, itemtype, path, internal_cr, uat_issue, gaps, fault, modification, datacorrection, enhacement, others, total_category_hd, crittical, minor, moderate, total_priory_hd, time_planned_code_freeze, time_actual_code_freeze, time_planned_shipment, time_actual_shipment, primary_name, secondary_name, status, effor_hours);
                }

                return Json("Success", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                CustomLogging.LogMessage("Exception: " + ex.ToString() + Environment.NewLine + "Stack Trace: " + ex.StackTrace + Environment.NewLine + "Message: " + ex.Message, LogType.Error);
                return Json("Error", JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult DeleteClinic(int ClinicID)
        {
            try
            {
                var clinic = _dbContext.Clinic_Information.ToList().Find(x => x.Clinic_ID == ClinicID && x.Clinic_Code == clinicCode);
                if (clinic != null)
                {
                    _dbContext.Clinic_Information.Remove(clinic);
                    _dbContext.SaveChanges();
                }

                return Json("Deleted", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                CustomLogging.LogMessage("Exception: " + ex.ToString() + Environment.NewLine + "Stack Trace: " + ex.StackTrace + Environment.NewLine + "Message: " + ex.Message, LogType.Error);
                return Json("Error", JsonRequestBehavior.AllowGet);
            } 
        }

        [HttpGet]
        //public ActionResult GetClinicData(int clinicID) 
        //{
        //    try
        //    {
        //        BAL BusinessAccessLayer = new BAL();
        //        List<ClinicData> lst = BusinessAccessLayer.GetClinicData(clinicID);
        //        return Json(lst, JsonRequestBehavior.AllowGet);
        //    }
        //    catch (Exception ex)
        //    {
        //        CustomLogging.LogMessage("Exception: " + ex.ToString() + Environment.NewLine + "Stack Trace: " + ex.StackTrace + Environment.NewLine + "Message: " + ex.Message, LogType.Error);
        //        return Json("Error", JsonRequestBehavior.AllowGet);
        //    }
        //}
        public ActionResult GetActivitySheetData(int RecordNumber) // modified by qasim for View activity data
        {
            try
            {
                BAL BusinessAccessLayer = new BAL();
                List<ClinicData> lst = BusinessAccessLayer.GetActivitySheetData(RecordNumber);
                return Json(lst, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                CustomLogging.LogMessage("Exception: " + ex.ToString() + Environment.NewLine + "Stack Trace: " + ex.StackTrace + Environment.NewLine + "Message: " + ex.Message, LogType.Error);
                return Json("Error", JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public JsonResult GetCurrentMonth() //Qasim Mahmood
        {
            try
            {
                BAL BusinessAccessLayer = new BAL();
                //List<CurrentData> lst = BusinessAccessLayer.GetCurrentDataData();
                //return Json(lst, JsonRequestBehavior.AllowGet);
                var jsonResult = Json(BusinessAccessLayer.GetCurrentDataData(), JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;
                return jsonResult;
            }
            catch (Exception ex)
            {
                CustomLogging.LogMessage("Exception: " + ex.ToString() + Environment.NewLine + "Stack Trace: " + ex.StackTrace + Environment.NewLine + "Message: " + ex.Message, LogType.Error);
                return Json("Error", JsonRequestBehavior.AllowGet);
            }
        }

        public void SaveClinicTimeSlabs(string timeStart, string timeEnd)
        {
            try
            {
                var times = new List<TimeSlot>();
                double interval = 30;
                DateTime startTime = DateTime.Parse(timeStart.Replace('.',':'));
                DateTime endTime = DateTime.Parse(timeEnd.Replace('.', ':'));

                if (endTime < startTime)
                {
                    endTime = endTime.AddDays(1);
                }
                for (var ts = startTime; ts <= endTime; ts = ts.AddMinutes(interval))
                {
                    TimeSlot t = new TimeSlot();
                    t.Time = ts.TimeOfDay.ToString("T");
                    times.Add(t);
                }

                BAL BusinessAccessLayer = new BAL();
                BusinessAccessLayer.SaveClinicTimeSlabs(times, "1");
            }
            catch(Exception ex)
            {
                CustomLogging.LogMessage("Exception: " + ex.ToString() + Environment.NewLine + "Stack Trace: " + ex.StackTrace + Environment.NewLine + "Message: " + ex.Message, LogType.Error);
            }
        }
    }
}
