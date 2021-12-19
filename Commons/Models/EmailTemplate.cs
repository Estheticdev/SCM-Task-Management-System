using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commons.Models
{
    public class EmailTemplate
    {
        public int TemplateID { get; set; }
        public string Template_Name { get; set; }
        public string Email_Subject { get; set; }
        public string Email_Body { get; set; }
        public bool Active { get; set; }
        public long Clinic_Code { get; set; }
    }
}
