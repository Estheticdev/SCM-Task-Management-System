using TMS.Models;
using BusinessAccessLayer.BAL;
using Commons;
using Commons.Configuration;
using Commons.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TMS.Controllers
{
    public class AdminController : BaseController
    {
        Models.commonModal _dbContext;
        Int64 clinicCode = Convert.ToInt64(Commons.Constants.ClinicCode);
        public AdminController()
        {
            _dbContext = new commonModal();
        }
        // GET: Admin
        public ActionResult Administrator()
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

        public ActionResult ViewGeneralData()
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

        public ActionResult BankInformation()
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

        public ActionResult AppointmentTimes()
        {
            //if (Session["userName"] != null)
            //{
            //    return View();
            //}
            //else
            //{
            //    return RedirectToAction("LoginUser", "Login", new { userName = "" });
            //}
            return View();
        }

        public ActionResult CreateUser()
        {
            //if (Session["userName"] != null)
            //{
            //    return View();
            //}
            //else
            //{
            //    return RedirectToAction("LoginUser", "Login", new { userName = "" });
            //}
            return View();
        }

        public ActionResult StaffInformation()
        {
            //if (Session["userName"] != null)
            //{
            //    return View();
            //}
            //else
            //{
            //    return RedirectToAction("LoginUser", "Login", new { userName = "" });
            //}
            return View();
        }

        [HttpGet]
        public ActionResult GetBankInformation()
        {
            try
            {
                var lstuser = _dbContext.Bank_Information.Where(s => s.Bank_ID != 0).ToList();
                return Json(lstuser, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                CustomLogging.LogMessage("Exception: " + ex.ToString() + Environment.NewLine + "Stack Trace: " + ex.StackTrace + Environment.NewLine + "Message: " + ex.Message, LogType.Error);
                return Json("Error", JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult SaveAppointmentTimeSlots(List<AppointmentTimeSlots> Arr)
        {
            try
            {
                BAL BusinessAccessLayer = new BAL();
                BusinessAccessLayer.SaveAppointmentTimeSlots(Arr, Convert.ToString(Session["UserID"]));
                return Json("Success", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                CustomLogging.LogMessage("Exception: " + ex.ToString() + Environment.NewLine + "Stack Trace: " + ex.StackTrace + Environment.NewLine + "Message: " + ex.Message, LogType.Error);
                return Json("Error", JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult GetAppointmentTimeSlots()
        {
            try
            {
                BAL BusinessAccessLayer = new BAL();
                List<AppointmentTime> lst = BusinessAccessLayer.GetAppointmentTimeSlots();
                return Json(lst, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                CustomLogging.LogMessage("Exception: " + ex.ToString() + Environment.NewLine + "Stack Trace: " + ex.StackTrace + Environment.NewLine + "Message: " + ex.Message, LogType.Error);
                return Json("Error", JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult AddBankInformation([Bind(Exclude = "Bank_ID")] Bank_Information bank)
        {
            try
            {
                bank.Created_Date = DateTime.Now;
                bank.Created_By = Convert.ToInt32(Session["UserID"]);
                if (ModelState.IsValid)
                {
                    _dbContext.Bank_Information.Add(bank);
                    _dbContext.SaveChanges();
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
        public ActionResult UpdateBankInformation(Bank_Information bank)
        {
            try
            {
                bank.Modified_Date = DateTime.Now;
                bank.Modified_By = Convert.ToInt32(Session["UserID"]);

                if (ModelState.IsValid)
                {
                    _dbContext.Entry(bank).State = EntityState.Modified;
                    _dbContext.SaveChanges();
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
        public ActionResult SaveSetupFormData(int FieldID, string ddlField, string FieldText, bool Active, string Type)
        {
            try
            {
                BAL BusinessAccessLayer = new BAL();
                BusinessAccessLayer.SaveSetupFormData(FieldID, ddlField, FieldText, Active, Type, Convert.ToString(Session["UserID"]));
                return Json("Success", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                CustomLogging.LogMessage("Exception: " + ex.ToString() + Environment.NewLine + "Stack Trace: " + ex.StackTrace + Environment.NewLine + "Message: " + ex.Message, LogType.Error);
                return Json("Error", JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult GetSetupFormData(string Type)
        {
            try
            {
                BAL BusinessAccessLayer = new BAL();
                List<SetupFormData> lst  = BusinessAccessLayer.GetSetupFormData(Type);
                return Json(lst, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                CustomLogging.LogMessage("Exception: " + ex.ToString() + Environment.NewLine + "Stack Trace: " + ex.StackTrace + Environment.NewLine + "Message: " + ex.Message, LogType.Error);
                return Json("Error", JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult DeleteSetupFormData(int ID, string Type)
        {
            try
            {
                BAL BusinessAccessLayer = new BAL();
                BusinessAccessLayer.DeleteSetupFormData(ID, Type, Convert.ToString(Session["UserID"]));
                return Json("Deleted", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                CustomLogging.LogMessage("Exception: " + ex.ToString() + Environment.NewLine + "Stack Trace: " + ex.StackTrace + Environment.NewLine + "Message: " + ex.Message, LogType.Error);
                return Json("Error", JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult SaveStaffInformation([Bind(Exclude = "Staff_ID")] Staff_Information staff)
        {
            try
            {
                staff.ClinicCode = Convert.ToInt64(Commons.Constants.ClinicCode);
                staff.Created_Date = DateTime.Now;
                staff.Active = true;
                staff.Created_By = Convert.ToInt32(Session["UserID"]);
                if (ModelState.IsValid)
                {
                    _dbContext.Staff_Information.Add(staff);
                    _dbContext.SaveChanges();
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
        public ActionResult UpdateStaffInformation(Staff_Information staff)
        {
            try
            {
                staff.ClinicCode = Convert.ToInt64(Commons.Constants.ClinicCode);
                if (ModelState.IsValid)
                {
                    _dbContext.Entry(staff).State = EntityState.Modified;
                    _dbContext.SaveChanges();
                }
                return Json("Success", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                CustomLogging.LogMessage("Exception: " + ex.ToString() + Environment.NewLine + "Stack Trace: " + ex.StackTrace + Environment.NewLine + "Message: " + ex.Message, LogType.Error);
                return Json("Error", JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult GetStaffInformation()
        {
            try
            {
                BAL BusinessAccessLayer = new BAL();
                List<StaffInformation> lst = BusinessAccessLayer.GetStaffInformation();
                return Json(lst, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                CustomLogging.LogMessage("Exception: " + ex.ToString() + Environment.NewLine + "Stack Trace: " + ex.StackTrace + Environment.NewLine + "Message: " + ex.Message, LogType.Error);
                return Json("Error", JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult DeleteStaffInformation(int ID)
        {
            try
            {
                BAL BusinessAccessLayer = new BAL();
                BusinessAccessLayer.DeleteStaffInformation(ID, Convert.ToInt32(Session["UserID"]));
                return Json("Deleted", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                CustomLogging.LogMessage("Exception: " + ex.ToString() + Environment.NewLine + "Stack Trace: " + ex.StackTrace + Environment.NewLine + "Message: " + ex.Message, LogType.Error);
                return Json("Error", JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult SaveUser([Bind(Exclude = "User_ID")] CreateUser user)
        {
            try
            {
                user.Clinic_Code = Convert.ToInt64(Commons.Constants.ClinicCode);
                user.Created_Date = DateTime.Now;
                user.Created_By = Convert.ToInt32(Session["UserID"]);
                user.Password = SecurityManager.Encrypt(user.Password);
                if (ModelState.IsValid)
                {
                    _dbContext.CreateUsers.Add(user);
                    _dbContext.SaveChanges();
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
        public ActionResult UpdateUser(CreateUser user)
        {
            try
            {
                user.Clinic_Code = Convert.ToInt64(Commons.Constants.ClinicCode);
                user.Modified_Date = DateTime.Now;
                user.Modified_By = Convert.ToInt32(Session["UserID"]);
                if (!string.IsNullOrEmpty(user.Password))
                {
                    user.Password = SecurityManager.Encrypt(user.Password);
                }

                if (ModelState.IsValid)
                {
                    BAL BusinessAccessLayer = new BAL();
                    BusinessAccessLayer.UpdateUser(user.User_ID, user.UserType, user.Staff_ID , user.Doctor_ID, user.User_Name, user.Password, user.Super_Admin, user.Active, user.Modified_Date, user.Modified_By, user.Clinic_Code);
                }

                return Json("Success", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                CustomLogging.LogMessage("Exception: " + ex.ToString() + Environment.NewLine + "Stack Trace: " + ex.StackTrace + Environment.NewLine + "Message: " + ex.Message, LogType.Error);
                return Json("Error", JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult GetUserInformation()
        {
            try
            {
                BAL BusinessAccessLayer = new BAL();
                List<UserInformation> lst = BusinessAccessLayer.GetUserInformation();
                return Json(lst, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                CustomLogging.LogMessage("Exception: " + ex.ToString() + Environment.NewLine + "Stack Trace: " + ex.StackTrace + Environment.NewLine + "Message: " + ex.Message, LogType.Error);
                return Json("Error", JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult DeleteUserInformation(int ID)
        {
            try
            {
                BAL BusinessAccessLayer = new BAL();
                BusinessAccessLayer.DeleteUserInformation(ID, Convert.ToInt32(Session["UserID"]));
                return Json("Deleted", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                CustomLogging.LogMessage("Exception: " + ex.ToString() + Environment.NewLine + "Stack Trace: " + ex.StackTrace + Environment.NewLine + "Message: " + ex.Message, LogType.Error);
                return Json("Error", JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult CheckMember(int MemberType, int MemberID)
        {
            try
            {
                BAL BusinessAccessLayer = new BAL();
                string msg = BusinessAccessLayer.CheckMember(MemberType, MemberID);
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                CustomLogging.LogMessage("Exception: " + ex.ToString() + Environment.NewLine + "Stack Trace: " + ex.StackTrace + Environment.NewLine + "Message: " + ex.Message, LogType.Error);
                return Json("Error", JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult CheckUserName(string UserName)
        {
            try
            {
                BAL BusinessAccessLayer = new BAL();
                string msg = BusinessAccessLayer.CheckUserName(UserName);
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                CustomLogging.LogMessage("Exception: " + ex.ToString() + Environment.NewLine + "Stack Trace: " + ex.StackTrace + Environment.NewLine + "Message: " + ex.Message, LogType.Error);
                return Json("Error", JsonRequestBehavior.AllowGet);
            }
        }
    }
}