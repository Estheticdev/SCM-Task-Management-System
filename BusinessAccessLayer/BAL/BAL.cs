using Commons;
using Commons.Models;
using DataAccessLayer.DAL;
using System;
using System.Collections.Generic;
using System.Data;

namespace BusinessAccessLayer.BAL
{
    public class BAL
    {
        public List<DropDownData> GetDropDownData(List<DropDownData> param, string DropDown)
        {
            try
            {
                DAL DataAccessLayer = new DAL();
                return DataAccessLayer.GetDropDownData(Utility.GetDropDownParameters(param), Utility.GetParameters("DropDown", DropDown));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public UserConfiguration GetLoginInformation(string UserName, string Password)
        {
            try
            {
                DAL DataAccessLayer = new DAL();
                return DataAccessLayer.GetLoginInformation(Utility.GetParameters("Employeecode,employeePassword", UserName + "," + Password));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<ClinicData> GetActivitySheetData(int RecordNumber)
        {
            try
            {
                DAL DataAccessLayer = new DAL();
                return DataAccessLayer.GetActivitySheetData(Utility.GetParameters("RecordNumber", RecordNumber.ToString()));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<CurrentData> GetCurrentDataData() //Qasim MAhmood
        {
            try
            {
                DAL DataAccessLayer = new DAL();
                return DataAccessLayer.GetcurrentmonthData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SaveDoctorSchdule(List<DoctorSchedule> Arr, string userID)
        {
            try
            {
                DAL DataAccessLayer = new DAL();
                DataAccessLayer.SaveDoctorSchdule(Utility.ToDataTable(Arr), Utility.GetParameters("ClinicCode,UserID", Constants.ClinicCode + ',' + userID));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<DoctorScheduleData> GetDoctorScheduleData(int Doctor_ID)
        {
            try
            {
                DAL DataAccessLayer = new DAL();
                return DataAccessLayer.GetDoctorScheduleData(Utility.GetParameters("Doctor_ID,Clinic_Code", Doctor_ID.ToString() + ',' + Constants.ClinicCode));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<RegularPatientData> GetRegularPatientDataByID(int PatientID)
        {
            try
            {
                DAL DataAccessLayer = new DAL();
                return DataAccessLayer.GetRegularPatientDataByID(Utility.GetParameters("Patient_ID", PatientID.ToString()));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<RegularPatientData> GetRegularPatientData()
        {
            try
            {
                DAL DataAccessLayer = new DAL();
                return DataAccessLayer.GetRegularPatientData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SaveClinicTimeSlabs(List<TimeSlot> lstStr, string userID)
        {
          var TimeSlabs =  Utility.ToDataTable(lstStr);

            try
            {
                DAL DataAccessLayer = new DAL();
                DataAccessLayer.SaveClinicTimeSlabs(Utility.ToDataTable(lstStr), Utility.GetParameters("UserID,ClinicCode", userID + ',' + Constants.ClinicCode));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SaveAppointmentTimeSlots(List<AppointmentTimeSlots> lst, string userID)
        {
            try
            {
                DAL DataAccessLayer = new DAL();
                DataAccessLayer.SaveAppointmentTimeSlots(Utility.ToDataTable(lst), Utility.GetParameters("ClinicCode,UserID", Constants.ClinicCode + ',' + userID));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<AppointmentTime> GetAppointmentTimeSlots()
        {
            try
            {
                DAL DataAccessLayer = new DAL();
                return DataAccessLayer.GetAppointmentTimeSlots(Utility.GetParameters("Clinic_Code", Constants.ClinicCode));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SaveSetupFormData(int FieldID, string ddlField, string FieldText, bool Active, string Type, string userID)
        {
            //try
            //{
            //    DAL DataAccessLayer = new DAL();
            //    DataAccessLayer.SaveSetupFormData(Utility.GetParameters("FieldID,ddlField,FieldText,Active,Type,UserID", FieldID.ToString() + ',' + ddlField + ',' + FieldText + ',' + Active.ToString() + ',' + Type + ',' + userID));
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
        } //Qasim

        //public void Saveupdateactivitysheet(tbl_current_months activity)
        public void Saveupdateactivitysheet(string RecordNumber, string Content_Type, string ProjectName, string Pro_Rel_Pat_number, string Plan_Codefreeze, string plan_shipment, string shipped, string jira_issue, string optimization, string actual_build, string actual_codefreeze, string actual_shipment, string build_machine, string client, string comments, string created, string itemtype, string path, string internal_cr, string uat_issue, string gaps, string fault, string modification, string datacorrection, string enhacement, string others, string total_category_hd, string crittical, string minor, string moderate, string total_priory_hd, string time_planned_code_freeze, string time_actual_code_freeze, string time_planned_shipment, string time_actual_shipment, string primary_name, string secondary_name, string status, string effor_hours)
        {
            try
            {
                DAL DataAccessLayer = new DAL();
                DataAccessLayer.Saveupdateactivitysheet(Utility.GetParameters("RecordNumber, Content_Type, ProjectName, Pro_Rel_Pat_number, Plan_Codefreeze, plan_shipment,  shipped,  jira_issue, optimization, actual_build, actual_codefreeze, actual_shipment, build_machine, client,  comments,  created,  itemtype, path, internal_cr, uat_issue, gaps, fault, modification, datacorrection, enhacement, others,  total_category_hd, crittical, minor, moderate, total_priory_hd, time_planned_code_freeze, time_actual_code_freeze, time_planned_shipment, time_actual_shipment, primary_name, secondary_name, status, effor_hours", RecordNumber+','+ Content_Type + ',' + ProjectName + ',' + Pro_Rel_Pat_number + ',' +Plan_Codefreeze+ ',' +plan_shipment+ ',' +shipped+ ',' +jira_issue+ ',' +optimization+ ',' +actual_build+ ',' +actual_codefreeze+ ',' +actual_shipment+ ',' +build_machine+ ',' +client+ ',' +comments+ ',' +created+ ',' +itemtype+ ',' +path+ ',' + internal_cr + ',' + uat_issue + ',' + gaps + ',' + fault + ',' + modification + ',' + datacorrection + ',' + enhacement + ',' + others + ',' + total_category_hd + ',' + crittical + ',' + minor + ',' + moderate + ',' + total_priory_hd + ',' + time_planned_code_freeze + ',' + time_actual_code_freeze + ',' + time_planned_shipment + ',' + time_actual_shipment + ',' + primary_name + ',' + secondary_name + ',' + status + ',' + effor_hours));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SetupFormData> GetSetupFormData(string Type)
        {
            try
            {
                DAL DataAccessLayer = new DAL();
                return DataAccessLayer.GetSetupFormData(Utility.GetParameters("Type", Type));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteSetupFormData(int ID, string Type, string UserID)
        {
            try
            {
                DAL DataAccessLayer = new DAL();
                DataAccessLayer.DeleteSetupFormData(Utility.GetParameters("ID,Type,UserID", ID + "," + Type + "," + UserID));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<RegularPatientData> FindRegularPatient(string Name, string CNIC, string Contact, string Email)
        {
            try
            {
                DAL DataAccessLayer = new DAL();
                return DataAccessLayer.FindRegularPatient(Utility.GetParameters("ClinicCode,Name,Contact,CNIC,Email", Constants.ClinicCode + "," + Name + "," + Contact + "," + CNIC + "," + Email));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SearchAppointment> FindAppointment(string Name, string CNIC, string Contact, string Email, string Doctor, string AppointmentDate, string Day, string CreatedDate)
        {
            try
            {
                DAL DataAccessLayer = new DAL();
                return DataAccessLayer.FindAppointment(Utility.GetParameters("ClinicCode,PatientName,Contact,CNIC,Email,Doctor_ID,AppointmentDate,Day,CreatedDate", Constants.ClinicCode + "," + Name + "," + Contact + "," + CNIC + "," + Email + "," + Doctor + "," + AppointmentDate + "," + Day + "," + CreatedDate));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SaveAppointments(long Patient_ID, int Patient_Type, string Full_Name, string Contact, string CNIC, string Email, DateTime DOB, int BloodGroup, int City, string Address, string Discription, int DoctorID, DateTime AppointmentDate, int ServiceID, int DayID, int ScheduleID, int DiseaseID, string Note, int UserID)
        {
            try
            {
                DAL DataAccessLayer = new DAL();
                DataAccessLayer.SaveAppointments(Utility.GetParameters("Patient_ID,Full_Name,Contact,CNIC,Email,DOB,BloodGroup,City,Address,Discription,ServiceID,DoctorID,AppointmentDate,DayID,ScheduleID,DiseaseID,Note,UserID,ClinicCode,PatiendType ", Patient_ID + "," + Full_Name + "," + Contact + "," + CNIC + "," + Email + "," + DOB + "," + BloodGroup + "," + City + "," + Address + "," + Discription + "," + ServiceID + "," + DoctorID + "," + AppointmentDate + "," + DayID + "," + ScheduleID + "," + DiseaseID + "," + Note + "," + UserID + "," + Constants.ClinicCode + "," + Patient_Type));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteAppointment(int Appointment_ID, int UserID)
        {
            try
            {
                DAL DataAccessLayer = new DAL();
                DataAccessLayer.DeleteAppointment(Utility.GetParameters("Appointment_ID,UserID,ClinicCode", Appointment_ID + "," + UserID + "," + Constants.ClinicCode));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<AppointmentCalendar> GetAppointmentsCalendar(int Doctor)
        {
            try
            {
                DAL DataAccessLayer = new DAL();
                return DataAccessLayer.GetAppointmentsCalendar(Utility.GetParameters("ClinicCode,Doctor_ID", Constants.ClinicCode + "," + Doctor));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<DoctorAppointments> GetAppointmentsForProcess(int Doctor)
        {
            try
            {
                DAL DataAccessLayer = new DAL();
                return DataAccessLayer.GetAppointmentsForProcess(Utility.GetParameters("ClinicCode,Doctor_ID", Constants.ClinicCode + "," + Doctor));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateUser(int user_ID, int? userType, int? staff_ID, int? doctor_ID, string user_Name, string password, bool? super_Admin, bool? active, DateTime? modified_Date, int? modified_By, long? clinic_Code)
        {
            try
            {
                DAL DataAccessLayer = new DAL();
                DataAccessLayer.UpdateUser(Utility.GetParameters("User_ID,UserType,Staff_ID,Doctor_ID,UserName,Password,Super_Admin,Active,Modified_Date,Modified_By,Clinic_Code", user_ID + "," + userType + "," + staff_ID + "," + doctor_ID + "," + user_Name + "," + password + "," + super_Admin + "," + active + "," + modified_Date + "," + modified_By + "," + Constants.ClinicCode));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ProcessAppointments(int AppointmentID, decimal RecievedAmount, string Prescription, int userID)
        {
            try
            {
                DAL DataAccessLayer = new DAL();
                DataAccessLayer.ProcessAppointments(Utility.GetParameters("DoctorID,AppointmentID,RecievedAmount,Prescription,UserID,ClinicCode", userID + "," + AppointmentID + "," + RecievedAmount + "," + Prescription + "," + userID + "," + Constants.ClinicCode));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<DoctorData> GetDoctorDetail()
        {
            try
            {
                DAL DataAccessLayer = new DAL();
                return DataAccessLayer.GetDoctorDetail(Utility.GetParameters("ClinicCode", Constants.ClinicCode));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<StaffInformation> GetStaffInformation()
        {
            try
            {
                DAL DataAccessLayer = new DAL();
                return DataAccessLayer.GetStaffInformation(Utility.GetParameters("Clinic_Code", Constants.ClinicCode));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteStaffInformation(int Staff_ID, int UserID)
        {
            try
            {
                DAL DataAccessLayer = new DAL();
                DataAccessLayer.DeleteStaffInformation(Utility.GetParameters("Staff_ID,UserID,ClinicCode", Staff_ID.ToString() + "," + UserID.ToString() + "," + Constants.ClinicCode));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<UserInformation> GetUserInformation()
        {
            try
            {
                DAL DataAccessLayer = new DAL();
                return DataAccessLayer.GetUserInformation(Utility.GetParameters("Clinic_Code", Constants.ClinicCode));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteUserInformation(int User_ID, int Deleted_By)
        {
            try
            {
                DAL DataAccessLayer = new DAL();
                DataAccessLayer.DeleteUserInformation(Utility.GetParameters("User_ID,Deleted_By,ClinicCode", User_ID.ToString() + "," + Deleted_By.ToString() + "," + Constants.ClinicCode));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public UserConfiguration GetLoginInformation(string UserName, string Password)
        //{
        //    try
        //    {
        //        DAL DataAccessLayer = new DAL();
        //        return DataAccessLayer.GetLoginInformation(Utility.GetParameters("UserName,Password,Clinic_Code", UserName + "," + Password + "," + Constants.ClinicCode));
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public LoginUser GetUserEmail(string UserName)
        {
            try
            {
                DAL DataAccessLayer = new DAL();
                return DataAccessLayer.GetUserEmail(Utility.GetParameters("UserName,Clinic_Code", UserName + "," + Constants.ClinicCode));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public EmailTemplate GetEmailTemplate(string templateName)
        {
            try
            {
                DAL DataAccessLayer = new DAL();
                return DataAccessLayer.GetEmailTemplate(Utility.GetParameters("TemplateName,Clinic_Code", templateName + "," + Constants.ClinicCode));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Boolean TokenValidated(string Token)
        {
            try
            {
                DAL DataAccessLayer = new DAL();
                return DataAccessLayer.TokenValidated(Utility.GetParameters("token", Token));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ResetPasswordAfterForgotten(string Token, string Password)
        {
            try
            {
                DAL DataAccessLayer = new DAL();
                DataAccessLayer.ResetPasswordAfterForgotten(Utility.GetParameters("token,password", Token + "," + Password));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteDoctor(string DoctorID, string UserID)
        {
            try
            {
                DAL DataAccessLayer = new DAL();
                DataAccessLayer.DeleteDoctor(Utility.GetParameters("Doctor_ID,User_ID,ClinicCode", DoctorID + "," + UserID + "," + Constants.ClinicCode));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetActivitySheetDataByRecordNumber(int RecordNumber)
        {
            try
            {
                DAL DataAccessLayer = new DAL();
                return DataAccessLayer.GetActivitySheetDataByRecordNumber(Utility.GetParameters("RecordNumber", RecordNumber.ToString()));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeletePatient(string PatientID, string UserID)
        {
            try
            {
                DAL DataAccessLayer = new DAL();
                DataAccessLayer.DeletePatient(Utility.GetParameters("Patient_ID,User_ID,ClinicCode", PatientID + "," + UserID + "," + Constants.ClinicCode));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string CheckMember(int MemberType, int MemberID)
        {
            try
            {
                string msg = "NotExist";
                DAL DataAccessLayer = new DAL();
                DataTable dt = DataAccessLayer.CheckMember(Utility.GetParameters("MemberType,MemberID,ClinicCode", MemberType.ToString() + "," + MemberID.ToString() + "," + Constants.ClinicCode));
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        msg = "Exist";
                    }
                }

                return msg;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string CheckUserName(string UserName)
        {
            try
            {
                string msg = "NotExist";
                DAL DataAccessLayer = new DAL();
                DataTable dt = DataAccessLayer.CheckUserName(Utility.GetParameters("UserName,ClinicCode", UserName.ToString() + "," + Constants.ClinicCode));
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        msg = "Exist";
                    }
                }

                return msg;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<DropDownData> GetPrimary()
        {
            try
            {
                DAL dal = new DAL();
                return dal.GetPrimary();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<DropDownData> GetStatus()
        {
            try
            {
                DAL dal = new DAL();
                return dal.GetStatus();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<DropDownData> ProjectType()
        {
            try
            {
                DAL dal = new DAL();
                return dal.ProjectType();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<DropDownData> Client()
        {
            try
            {
                DAL dal = new DAL();
                return dal.Client();
            }
            catch (Exception)
            {

                throw;
            }
        }



    }
}
