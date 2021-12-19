using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commons.Models
{
    public class DoctorData
    {
        public int Doctor_ID { get; set; }
        public string Doctor_Name { get; set; }
        public DateTime DOB { get; set; }
        public string Gender_Name { get; set; }
        public string Marital_Status_Name { get; set; }
        public string PMDC_No { get; set; }
        public string CNIC_No { get; set; }
        public string Cell_No { get; set; }
        public string Email { get; set; }
        public string Home_Ph_No { get; set; }
        public string Speciality_Name { get; set; }
        public string Country_Name { get; set; }
        public string State_Name { get; set; }
        public string City_Name { get; set; }
        public string Address { get; set; }
        public string Discription { get; set; }
        public string Bank_Name { get; set; }
        public string Account_Information { get; set; }
        public decimal Fee { get; set; }
        public bool Active { get; set; }
        public long Clinic_Code { get; set; }
        public DateTime Created_Date { get; set; }
        public string Created_By { get; set; }
        public DateTime Modified_Date { get; set; }
        public string Modified_By { get; set; }
    }
}
