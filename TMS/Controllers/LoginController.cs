using BusinessAccessLayer.BAL;
using Commons.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Commons.Configuration;
using TMS.Models;
using Commons;

namespace AMS.Controllers
{
    public class LoginController : Controller
    {
        TMS.Models.commonModal _dbContext;
        
        public LoginController()
        {
            _dbContext = new TMS.Models.commonModal();
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LoginUser()
        {
            return View();
        }

        public ActionResult ForgetPassword()
        {
            return View();
        }

        public ActionResult ResetPassword()
        {
            return View();
        }

        [HttpGet]
        public ActionResult LoginAuthentication(string userName, string password)
        {
            try
            {
               // string encryptedPassword = SecurityManager.Encrypt(password);
                BAL BusinessAccessLayer = new BAL();
                UserConfiguration UserConfig = BusinessAccessLayer.GetLoginInformation(userName, password);
                if (UserConfig != null)
                {
                    Session["userName"] = UserConfig.UserInfo.empcode;
                    Session["password"] = UserConfig.UserInfo.employeepassword;
                    Session["name"] = UserConfig.UserInfo.User_Name;
                    //Session["UserType"] = UserConfig.UserInfo.UserType_ID;
                    //Session["DoctorID"] = UserConfig.UserInfo.Doctor_ID;
                    //Session["DoctorName"] = UserConfig.UserInfo.DoctorName;
                    //Session["DoctorAbbr"] = UserConfig.UserInfo.DoctorAbbr;
                    //Session["StaffID"] = UserConfig.UserInfo.Staff_ID;
                    //Session["StaffName"] = UserConfig.UserInfo.StaffName;
                    //Session["StaffAbbr"] = UserConfig.UserInfo.StaffAbbr;
                    //Session["SuperAdmin"] = UserConfig.UserInfo.SuperAdmin;

                    SessionManagement.UserConfigurations = UserConfig;
                    string newUrl = Url.Content("~/Dashboard/Dashboard") + "?RequestVerificationToken=" + Utility.TokenHeaderValue();

                    CustomLogging.LogMessage("User Name " + UserConfig.UserInfo.User_Name.ToString() + " Logged in System. UserType Id: " + UserConfig.UserInfo.empcode, LogType.Info);
                    return Json(newUrl, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    CustomLogging.LogMessage("No User Found against the user name " + userName , LogType.Info);
                    return Json("Error", JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                CustomLogging.LogMessage("Exception: " + ex.ToString() + Environment.NewLine + "Stack Trace: " + ex.StackTrace + Environment.NewLine + "Message: " + ex.Message, LogType.Error);
                return Json("Error", JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult LogOut()
        {
            CustomLogging.LogMessage(Session["userName"] + " logged out.", LogType.Info);
            System.Web.Security.FormsAuthentication.SignOut();
            Session.Abandon();
            Session.Clear();
            Session.RemoveAll(); // it will clear the session at the end of request
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult SendEmail(string userName)
        {
            try
            {
                BAL BusinessAccessLayer = new BAL();
                ResetPassword resetpassword = new ResetPassword();
                LoginUser user = BusinessAccessLayer.GetUserEmail(userName);
                EmailTemplate template = BusinessAccessLayer.GetEmailTemplate("ForgotPassword");

                string host = Request.Url.Authority;
                string scheme = Request.Url.Scheme;
                string token = Guid.NewGuid().ToString();
                string url = scheme + "://" + host + "/Login/ResetPassword?token=" + token;

                template.Email_Body = template.Email_Body.Replace("@Name", user.FullName);
                template.Email_Body = template.Email_Body.Replace("@Regards", "Medical Center");  
                template.Email_Body = template.Email_Body.Replace("@Link", url);
                bool emailSent = SMTPMailer.SendMail(user.Email, template.Email_Subject, template.Email_Body);

                if (emailSent)
                {
                    DateTime PgTime = DateTime.Now;
                    resetpassword.UserName = userName;
                    resetpassword.User_email = user.Email;
                    resetpassword.Token = token;
                    resetpassword.Date_Stamp = DateTime.Now;
                    resetpassword.Expiry_Date = DateTime.Now.Add(TimeSpan.FromMinutes(10));
                    resetpassword.isPasswordChanged = false;
                    resetpassword.Request_Status = "Email Sent";
                    _dbContext.ResetPasswords.Add(resetpassword);
                    _dbContext.SaveChanges();

                    CustomLogging.LogMessage("Forgot Email sent to this user " + userName + " on " + user.Email, LogType.Info);
                    return Json("Success", JsonRequestBehavior.AllowGet);
                }
                else
                {
                    CustomLogging.LogMessage("something went wrong with smtp while sending email to " + userName + " on " + user.Email, LogType.Info);
                    return Json("Error", JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                CustomLogging.LogMessage("Exception: " + ex.ToString() + Environment.NewLine + "Stack Trace: " + ex.StackTrace + Environment.NewLine + "Message: " + ex.Message, LogType.Error);
                return Json("Error", JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult ResetPasswordAfterForgotten(string token, string password)
        {
            try
            {
                BAL BusinessAccessLayer = new BAL();
                if (BusinessAccessLayer.TokenValidated(token))
                {
                    string encryptedPassword = SecurityManager.Encrypt(password);
                    BusinessAccessLayer.ResetPasswordAfterForgotten(token, encryptedPassword);
                    CustomLogging.LogMessage("Pass has been reset against this " + token, LogType.Info);
                    return Json("Success", JsonRequestBehavior.AllowGet);
                }
                else
                {
                    CustomLogging.LogMessage("Time Expire to change the password against this " + token, LogType.Info);
                    return Json("Error", JsonRequestBehavior.AllowGet);
                }

            }
            catch(Exception ex)
            {
                CustomLogging.LogMessage("Exception: " + ex.ToString() + Environment.NewLine + "Stack Trace: " + ex.StackTrace + Environment.NewLine + "Message: " + ex.Message, LogType.Error);
                return Json("Error", JsonRequestBehavior.AllowGet);
            }
        }
    }
}