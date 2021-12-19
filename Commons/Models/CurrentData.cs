using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commons.Models
{
    public class CurrentData
    {
       
        public int RecordNumber { get; set; }

        public string Content_Type { get; set; }

        public string ProjectName { get; set; }

        public string Pro_Rel_Pat_number { get; set; }
        
        public DateTime? Plan_Codefreeze { get; set; }

        public DateTime? plan_shipment { get; set; }

        public string shipped { get; set; }

        public string jira_issue { get; set; }

        public string optimization { get; set; }

        public int actual_build { get; set; }

        public DateTime? actual_codefreeze { get; set; }
      
        public DateTime? actual_shipment { get; set; }

        public string build_machine { get; set; }

        public string client { get; set; }

        public string comments { get; set; }
        
        public DateTime? created { get; set; }

        public string itemtype { get; set; }

        public string path { get; set; }

        public int internal_cr { get; set; }
        public int uat_issue { get; set; }
        public int gaps { get; set; }
        public int fault { get; set; }
        public int modification { get; set; }
        public int datacorrection { get; set; }
        public int enhacement { get; set; }
        public int others { get; set; }
        public int total_category_hd { get; set; }
        public int crittical { get; set; }
        public int minor { get; set; }
        public int moderate { get; set; }
        public int total_priory_hd { get; set; }
        public string time_planned_code_freeze { get; set; }
        public string time_actual_code_freeze { get; set; }
        public string time_planned_shipment { get; set; }
        public string time_actual_shipment { get; set; }
        public string primary_name { get; set; }
        public string secondary_name { get; set; }
        public string status { get; set; }
        public string effor_hours { get; set; }


    }
}
