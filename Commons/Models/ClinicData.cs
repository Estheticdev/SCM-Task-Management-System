using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commons.Models
{
    public class ClinicData
    {
        public long Clinic_ID { get; set; }
        public string Name { get; set; }
        public string Acronym { get; set; }
        public string NTN_Number { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string Country_Name { get; set; }
        public string City_Name { get; set; }
        public string State_Name { get; set; }
        public string Address { get; set; }
        public string Discription { get; set; }
        public string Logo { get; set; }
        public string Created_By { get; set; }
        public DateTime Created_Date { get; set; }
        public string Modified_By { get; set; }
        public DateTime Modified_Date { get; set; }
    }
}
