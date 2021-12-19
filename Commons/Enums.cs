using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commons
{
    public partial class Enums
    {
        public enum ScreenID
        {
            AddEditClinic = 1001,
            ClinicDetail = 1003,
            ViewClinic = 1002,
            DoctorSchdule = 1005,
            Administrator = 1006,
            RegularPatientDetails = 1007,
            ViewPatient = 1008,
            AddEditDoctor = 1009,
            ViewGeneralData = 1010,
            BookAppointment = 1011,
            FindRegularPatient = 1012,
            SearchAppointment = 1013,
            ViewAppointment = 1014,
            DoctorCalendar = 1015,
            ProcessAppointment = 1015,
            DoctorDetail = 1016,
            ViewDoctor = 1017,
            CreateUser = 1018,
            StaffInformation = 1019,
            LoginUser = 1020
        }
    }

    public enum LogType
    {
        /// <summary>
        /// Unknown type.
        /// </summary>
        Unknown,

        /// <summary>
        /// Info.
        /// </summary>
        Info,

        /// <summary>
        /// Error.
        /// </summary>
        Error,

        /// <summary>
        /// Debug.
        /// </summary>
        Debug,

        /// <summary>
        /// Warning.
        /// </summary>
        Warn,

        /// <summary>
        /// Fatal.
        /// </summary>
        Fatal
    }
}
