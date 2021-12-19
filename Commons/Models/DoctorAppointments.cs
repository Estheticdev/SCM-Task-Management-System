using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commons.Models
{
    public class DoctorAppointments
    {
        public long Appointment_ID { get; set; }
        public string Patient_Type { get; set; }
        public string Patient_Name { get; set; }
        public string Service_Name { get; set; }
        public string Disease_Name { get; set; }
        public DateTime Appointment_Date { get; set; }
        public string Day { get; set; }
        public string Time { get; set; }
        public string Note { get; set; }
        public string Status { get; set; }
        public decimal Fee { get; set; }
        public DateTime Created_Date { get; set; }
        public string Created_By { get; set; }
    }
}
