using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commons.Models
{
    public class SearchAppointment
    {
        public long Appointment_ID { get; set; }
        public string Doctor_Name { get; set; }
        public string Patient_Type { get; set; }
        public string Patient_Name { get; set; }
        public string CNIC { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
        public string Service { get; set; }
        public string Disease_Name { get; set; }
        public DateTime Appointment_Date { get; set; }
        public string Day { get; set; }
        public string Time { get; set; }
        public string Note { get; set; }
        public string Status { get; set; }
        public DateTime Created_Date { get; set; }
        public string Created_By { get; set; }
        public string AppointmentTakenTimeStamp { get; set; }
        public string AppointmentProcessedTimeStamp { get; set; }
    }
}
