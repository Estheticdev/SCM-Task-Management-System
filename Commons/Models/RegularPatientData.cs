using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commons.Models
{
    public class RegularPatientData
    {
        public long Patient_ID { get; set; }
        public string Patient_Name { get; set; }
        public DateTime DOB { get; set; }
        public int Blood_Group_ID { get; set; }
        public string Blood_Group_Name { get; set; }
        public string CNIC { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
        public int City_ID { get; set; }
        public string City_Name { get; set; }
        public string Discription { get; set; }
        public string Address { get; set; }
        public DateTime Created_Date { get; set; }
        public string Created_By { get; set; }
        public DateTime Modified_Date { get; set; }
        public string Modified_By { get; set; }
    }
}
