using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commons
{
    public static class Proc
    {
        public const string GetClinicData  = "[dbo].[GetClinicData]";
        public const string GetDropDownData = "[dbo].[GetDropDownData]";
        public const string SaveDoctorSchedule = "[dbo].[SaveDoctorSchedule]";
        public const string GetDoctorScheduleData = "[dbo].[GetDoctorScheduleData]";
        public const string GetRegularPatientData = "[dbo].[GetRegularPatientData]";
        public const string GetRegularPatientDataByID = "[dbo].[GetRegularPatientDataByID]";
        public const string SaveClinicTimeSlabs = "[dbo].[SaveClinicTimeSlabs]";
        public const string SaveAppointmentTimeSlots = "[dbo].[SaveAppointmentTimeSlots]";
        public const string GetAppointmentTimeSlots = "[dbo].[GetAppointmentTimeSlots]";
        public const string SaveSetupFormData = "[dbo].[SaveSetupFormData]";
        public const string GetSetupFormData = "[dbo].[GetSetupFormData]";
        public const string DeleteSetupFormData = "[dbo].[DeleteSetupFormData]";
        public const string FindRegularPatient = "[dbo].[FindRegularPatient]";
        public const string SaveAppointments = "[dbo].[SaveAppointments]";
        public const string GetAppointments = "[dbo].[GetAppointments]";
        public const string DeleteAppointment = "[dbo].[DeleteAppointment]";
        public const string GetAppointmentsCalendar = "[dbo].[GetAppointmentsCalendar]";
        public const string GetAppointmentsForProcess = "[dbo].[GetAppointmentsForProcess]";
        public const string ProcessAppointments = "[dbo].[ProcessAppointments]";
        public const string GetDoctorInformationData = "[dbo].[GetDoctorInformationData]";
        public const string GetStaffInformation = "[dbo].[GetStaffInformation]";
        public const string DeleteStaffInformation = "[dbo].[DeleteStaffInformation]";
        public const string GetUserInformation = "[dbo].[GetUserInformation]";
        public const string UpdateUser = "[dbo].[UpdateUser]";
        public const string DeleteUserInformation = "[dbo].[DeleteUserInformation]";
        public const string LoginUser = "[dbo].[LoginUser]";
        public const string GetUserEmail = "[dbo].[GetUserEmail]";
        public const string GetEmailTemplate = "[dbo].[GetEmailTemplate]";
        public const string ValidateToken = "[dbo].[ValidateToken]";
        public const string ResetPasswordAfterForgotten = "[dbo].[ResetPasswordAfterForgotten]";
        public const string DeleteDoctor = "[dbo].[DeleteDoctor]";
        public const string DeletePatient = "[dbo].[DeletePatient]";
        public const string CheckUserAlreadyCreated = "[dbo].[CheckUserAlreadyCreated]";
        public const string CheckUserNameAlreadyExist = "[dbo].[CheckUserNameAlreadyExist]";
        public const string GetcurrentmonthData = "[dbo].[GetcurrentMonthData]";
        public const string sp_getpriamryname = "[dbo].[sp_getpriamryname]";
        public const string Get_ReleaseStatus = "[dbo].[Get_ReleaseStatus]";
        public const string Get_ProjectType = "[dbo].[Get_ProjectType]";
        public const string Get_Client = "[dbo].[Get_Client]";
        public const string Saveupdateactivitysheet = "[dbo].[ActivitySheetData]";
        public const string GetcurrentmonthDatabyRecordNUmber = "[dbo].[GetcurrentmonthDatabyRecordNUmber]";
    }
}
