using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commons.Models
{
    public class SetupFormData
    {
        public int ID { get; set; }
        public int ServiceID { get; set; }
        public string Service { get; set; }
        public string Name { get; set; }
        public string Active { get; set; }
    }
}
