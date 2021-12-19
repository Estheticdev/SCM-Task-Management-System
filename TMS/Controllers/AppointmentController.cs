using BusinessAccessLayer.BAL;
using Commons.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TMS.Controllers
{
    public class AppointmentController : Controller
    {
        // GET: Appointment
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult BookAppointment()
        {
            return View();
        }

        public ActionResult FindRegularPatient()
        {
            return View();
        }

        public ActionResult SearchAppointment()
        {
            return View();
        }

        public ActionResult ViewAppointment()
        {
            return View();
        }

        [HttpGet]
        public ActionResult FindRegularPatientData(string Name, string CNIC, string Contact, string Email)
        {
            try
            {
                BAL BusinessAccessLayer = new BAL();
                List<RegularPatientData> lst = BusinessAccessLayer.FindRegularPatient(Name, CNIC, Contact, Email);
                return Json(lst, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult FindAppointment(string Name, string CNIC, string Contact, string Email, string Doctor, string AppointmentDate, string Day, string CreatedDate)
        {
            try
            {
                BAL BusinessAccessLayer = new BAL();
                List<SearchAppointment> lst = BusinessAccessLayer.FindAppointment(Name, CNIC, Contact, Email, Doctor, AppointmentDate, Day, CreatedDate);
                return Json(lst, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult SaveAppointments(long Patient_ID, int Patient_Type, string Full_Name, string Contact, string CNIC, string Email, DateTime DOB, int BloodGroup, int City, string Address, string Discription, int ServiceID, int DoctorID, int DayID, DateTime AppointmentDate, int ScheduleID, int DiseaseID, string Note)
        {
            try
            {
                BAL BusinessAccessLayer = new BAL();
                BusinessAccessLayer.SaveAppointments(Patient_ID, Patient_Type, Full_Name, Contact, CNIC, Email, DOB, BloodGroup, City, Address, Discription, DoctorID, AppointmentDate, ServiceID, DayID, ScheduleID, DiseaseID, Note, Convert.ToInt32(Session["UserID"]));
                return Json("Success", JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult DeleteAppointment(int Appointment_ID)
        {
            try
            {
                BAL BusinessAccessLayer = new BAL();
                BusinessAccessLayer.DeleteAppointment(Appointment_ID, Convert.ToInt32(Session["UserID"]));
                return Json("Success", JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
            }
        }
    }
}