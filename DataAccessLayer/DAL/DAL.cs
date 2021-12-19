using System;
using System.Collections.Generic;
using System.Data;
using Commons;
using Commons.Models;

namespace DataAccessLayer.DAL
{
    public class DAL
    {
        public List<DropDownData> GetDropDownData(DataTable dataTable, Dictionary<string, string> dictionarys)
        {
            try
            {
                dbHelper db = new dbHelper();
                DataSet ds = db.GetDataByValueInDataSet(Proc.GetDropDownData, "Param", dataTable, dictionarys);
                return ds.Tables[0].ToList<DropDownData>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ClinicData> GetActivitySheetData(Dictionary<string, string> dictionary)
        {
            try
            {
                dbHelper db = new dbHelper();
                DataSet ds = db.GetDataByValueInDataSet(Proc.GetcurrentmonthDatabyRecordNUmber, dictionary);
                return ds.Tables[0].ToList<ClinicData>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<CurrentData> GetcurrentmonthData() //qasim mahmood
        {
            try
            {
                dbHelper db = new dbHelper();
                DataSet ds = db.GetAllData(Proc.GetcurrentmonthData);
                return ds.Tables[0].ToList<CurrentData>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SaveDoctorSchdule(DataTable dataTable, Dictionary<string, string> dictionary)
        {
            try
            {
                dbHelper db = new dbHelper();
                db.SaveChanges(Proc.SaveDoctorSchedule, "doctorSchedule", dataTable, dictionary);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<DoctorScheduleData> GetDoctorScheduleData(Dictionary<string, string> dictionary)
        {
            try
            {
                dbHelper db = new dbHelper();
                DataSet ds = db.GetDataByValueInDataSet(Proc.GetDoctorScheduleData, dictionary);
                return ds.Tables[0].ToList<DoctorScheduleData>();
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
                dbHelper db = new dbHelper();
                DataSet ds = db.GetAllData(Proc.GetRegularPatientData);
                return ds.Tables[0].ToList<RegularPatientData>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<RegularPatientData> GetRegularPatientDataByID(Dictionary<string, string> dictionary)
        {
            try
            {
                dbHelper db = new dbHelper();
                DataSet ds = db.GetDataByValueInDataSet(Proc.GetRegularPatientDataByID, dictionary);
                return ds.Tables[0].ToList<RegularPatientData>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SaveClinicTimeSlabs(DataTable dataTable, Dictionary<string, string> dictionary)
        {
            try
            {
                dbHelper db = new dbHelper();
                db.SaveChanges(Proc.SaveClinicTimeSlabs, "timeSlabs", dataTable, dictionary);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SaveAppointmentTimeSlots(DataTable dataTable, Dictionary<string, string> dictionary)
        {
            try
            {
                dbHelper db = new dbHelper();
                db.SaveChanges(Proc.SaveAppointmentTimeSlots, "timeSlots", dataTable, dictionary);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<AppointmentTime> GetAppointmentTimeSlots(Dictionary<string, string> dictionary)
        {
            try
            {
                dbHelper db = new dbHelper();
                DataSet ds = db.GetDataByValueInDataSet(Proc.GetAppointmentTimeSlots, dictionary);
                return ds.Tables[0].ToList<AppointmentTime>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Saveupdateactivitysheet(Dictionary<string, string> dictionary)
        {
            try
            {
                dbHelper db = new dbHelper();
                db.SaveChanges(Proc.Saveupdateactivitysheet, dictionary);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SetupFormData> GetSetupFormData(Dictionary<string, string> dictionary)
        {
            try
            {
                dbHelper db = new dbHelper();
                DataSet ds = db.GetDataByValueInDataSet(Proc.GetSetupFormData, dictionary);
                return ds.Tables[0].ToList<SetupFormData>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteSetupFormData(Dictionary<string, string> dictionary)
        {
            try
            {
                dbHelper db = new dbHelper();
                db.DeleteRecords(Proc.DeleteSetupFormData, dictionary);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<RegularPatientData> FindRegularPatient(Dictionary<string, string> dictionary)
        {
            try
            {
                dbHelper db = new dbHelper();
                DataSet ds = db.GetDataByValueInDataSet(Proc.FindRegularPatient, dictionary);
                return ds.Tables[0].ToList<RegularPatientData>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SearchAppointment> FindAppointment(Dictionary<string, string> dictionary)
        {
            try
            {
                dbHelper db = new dbHelper();
                DataSet ds = db.GetDataByValueInDataSet(Proc.GetAppointments, dictionary);
                return ds.Tables[0].ToList<SearchAppointment>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SaveAppointments(Dictionary<string, string> dictionary)
        {
            try
            {
                dbHelper db = new dbHelper();
                db.SaveChanges(Proc.SaveAppointments, dictionary);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteAppointment(Dictionary<string, string> dictionary)
        {
            try
            {
                dbHelper db = new dbHelper();
                db.DeleteRecords(Proc.DeleteAppointment, dictionary);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<AppointmentCalendar> GetAppointmentsCalendar(Dictionary<string, string> dictionary)
        {
            try
            {
                dbHelper db = new dbHelper();
                DataSet ds = db.GetDataByValueInDataSet(Proc.GetAppointmentsCalendar, dictionary);
                return ds.Tables[0].ToList<AppointmentCalendar>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<DoctorAppointments> GetAppointmentsForProcess(Dictionary<string, string> dictionary)
        {
            try
            {
                dbHelper db = new dbHelper();
                DataSet ds = db.GetDataByValueInDataSet(Proc.GetAppointmentsForProcess, dictionary);
                return ds.Tables[0].ToList<DoctorAppointments>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ProcessAppointments(Dictionary<string, string> dictionary)
        {
            try
            {
                dbHelper db = new dbHelper();
                db.SaveChanges(Proc.ProcessAppointments, dictionary);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<DoctorData> GetDoctorDetail(Dictionary<string, string> dictionary)
        {
            try
            {
                dbHelper db = new dbHelper();
                DataSet ds = db.GetDataByValueInDataSet(Proc.GetDoctorInformationData, dictionary);
                return ds.Tables[0].ToList<DoctorData>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<StaffInformation> GetStaffInformation(Dictionary<string, string> dictionary)
        {
            try
            {
                dbHelper db = new dbHelper();
                DataSet ds = db.GetDataByValueInDataSet(Proc.GetStaffInformation, dictionary);
                return ds.Tables[0].ToList<StaffInformation>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteStaffInformation(Dictionary<string, string> dictionary)
        {
            try
            {
                dbHelper db = new dbHelper();
                db.DeleteRecords(Proc.DeleteStaffInformation, dictionary);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateUser(Dictionary<string, string> dictionary)
        {
            try
            {
                dbHelper db = new dbHelper();
                db.SaveChanges(Proc.UpdateUser, dictionary);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<UserInformation> GetUserInformation(Dictionary<string, string> dictionary)
        {
            try
            {
                dbHelper db = new dbHelper();
                DataSet ds = db.GetDataByValueInDataSet(Proc.GetUserInformation, dictionary);
                return ds.Tables[0].ToList<UserInformation>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteUserInformation(Dictionary<string, string> dictionary)
        {
            try
            {
                dbHelper db = new dbHelper();
                db.DeleteRecords(Proc.DeleteUserInformation, dictionary);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public UserConfiguration GetLoginInformation(Dictionary<string, string> dictionary)
        {
            try
            {
                dbHelper db = new dbHelper();
                DataSet ds = db.GetDataByValueInDataSet(Proc.LoginUser, dictionary);
                LoginInformation lg = ClassHelper.Table.ToClass<LoginInformation>(ds.Tables[0]);
                UserConfiguration UserConfig = new UserConfiguration();
                UserConfig.UserInfo = lg;
                return UserConfig;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public LoginUser GetUserEmail(Dictionary<string, string> dictionary)
        {
            try
            {
                dbHelper db = new dbHelper();
                DataTable dt = db.GetDataByValueInDataTable(Proc.GetUserEmail, dictionary);
                LoginUser user = new LoginUser();

                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        user.UserID = Convert.ToInt32(dt.Rows[0]["UserID"]);
                        user.FullName = dt.Rows[0]["FullName"].ToString();
                        user.Email = dt.Rows[0]["Email"].ToString();
                    }
                }

                return user;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public EmailTemplate GetEmailTemplate(Dictionary<string, string> dictionary)
        {
            try
            {
                dbHelper db = new dbHelper();
                DataTable dt = db.GetDataByValueInDataTable(Proc.GetEmailTemplate, dictionary);
                EmailTemplate template = new EmailTemplate();

                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        template.TemplateID = Convert.ToInt32(dt.Rows[0]["TemplateID"]);
                        template.Template_Name = dt.Rows[0]["Template_Name"].ToString();
                        template.Email_Subject = dt.Rows[0]["Email_Subject"].ToString();
                        template.Email_Body = dt.Rows[0]["Email_Body"].ToString();
                        template.Active = Convert.ToBoolean(dt.Rows[0]["Active"]);
                        template.Clinic_Code = Convert.ToInt64(dt.Rows[0]["Clinic_Code"]);
                    }
                }

                return template;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Boolean TokenValidated(Dictionary<string, string> dictionary)
        {
            try
            {
                dbHelper db = new dbHelper();
                DataTable dt = db.GetDataByValueInDataTable(Proc.ValidateToken, dictionary);
                bool validated = false;

                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        validated = Convert.ToBoolean(dt.Rows[0]["Valid"]);
                    }
                }

                return validated;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ResetPasswordAfterForgotten(Dictionary<string, string> dictionary)
        {
            try
            {
                dbHelper db = new dbHelper();
                db.SaveChanges(Proc.ResetPasswordAfterForgotten, dictionary);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteDoctor(Dictionary<string, string> dictionary)
        {
            try
            {
                dbHelper db = new dbHelper();
                db.DeleteRecords(Proc.DeleteDoctor, dictionary);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeletePatient(Dictionary<string, string> dictionary)
        {
            try
            {
                dbHelper db = new dbHelper();
                db.DeleteRecords(Proc.DeletePatient, dictionary);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetActivitySheetDataByRecordNumber(Dictionary<string, string> dictionary)
        {
            try
            {
                dbHelper db = new dbHelper();
                return db.GetDataByValueInDataTable(Proc.GetcurrentmonthDatabyRecordNUmber, dictionary);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable CheckMember(Dictionary<string, string> dictionary)
        {
            try
            {
                dbHelper db = new dbHelper();
                return db.GetDataByValueInDataTable(Proc.CheckUserAlreadyCreated, dictionary);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable CheckUserName(Dictionary<string, string> dictionary)
        {
            try
            {
                dbHelper db = new dbHelper();
                return db.GetDataByValueInDataTable(Proc.CheckUserNameAlreadyExist, dictionary);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<DropDownData> GetPrimary()
        {
            dbHelper db = new dbHelper();
            var dt =  db.GetData(Proc.sp_getpriamryname);
            return dt.ToList<DropDownData>();
        }
        public List<DropDownData> GetStatus()
        {
            dbHelper db = new dbHelper();
            var dt = db.GetData(Proc.Get_ReleaseStatus);
            return dt.ToList<DropDownData>();
        }
        public List<DropDownData> ProjectType()
        {
            dbHelper db = new dbHelper();
            var dt = db.GetData(Proc.Get_ProjectType);
            return dt.ToList<DropDownData>();
        }
        public List<DropDownData> Client()
        {
            dbHelper db = new dbHelper();
            var dt = db.GetData(Proc.Get_Client);
            return dt.ToList<DropDownData>();
        }

    }
}