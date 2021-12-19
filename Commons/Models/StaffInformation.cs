using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commons.Models
{
    public class StaffInformation
    {
        public int Staff_ID { get; set; }
        public string First_Name { get; set; }
        public string Middle_Name { get; set; }
        public string Last_Name { get; set; }
        public string Full_Name { get; set; }
        public int Gender { get; set; }
        public string Gender_Name { get; set; }
        public int Marital_Status { get; set; }
        public string Marital_Status_Name { get; set; }
        public string CNIC_No { get; set; }
        public string Cell_No { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Active { get; set; }
        public string ClinicCode { get; set; }
    }
}
