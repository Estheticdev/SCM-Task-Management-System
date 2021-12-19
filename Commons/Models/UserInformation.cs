using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commons.Models
{
    public class UserInformation
    {
        public int User_ID { get; set; }
        public int UserType_ID { get; set; }
        public string UserTypeName { get; set; }
        public int MemberID { get; set; }
        public string MemberName { get; set; }
        public string User_Name { get; set; }
        public Boolean Super_Admin { get; set; }
        public string SuperAdmin { get; set; }
        public Boolean Active { get; set; }
        public string Status { get; set; }
        public long Clinic_Code { get; set; }
        public DateTime Created_Date { get; set; }
        public int Created_By { get; set; }
        public DateTime Modified_Date { get; set; }
        public int Modified_By { get; set; }
    }
}
