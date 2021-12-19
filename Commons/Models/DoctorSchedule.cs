using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commons.Models
{
    public class DoctorSchedule
    {
        public int Schedule_ID { get; set; }
        public int Doctor_ID { get; set; }
        public string Doctor { get; set; }
        public int Day_ID { get; set; }
        public string Day { get; set; }
        public int Time_ID { get; set; }
        public string Time { get; set; }
    }
}
