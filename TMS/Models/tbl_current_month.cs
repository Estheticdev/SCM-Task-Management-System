namespace TMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tbl_current_month")]
    public class tbl_current_months
    {
       
        public int RecordNumber { get; set; }
        public string Content_Type { get; set; }        
        public string ProjectName { get; set; }        
        public string Pro_Rel_Pat_number { get; set; }        
        [Column(TypeName = "date")]
        public DateTime? Plan_Codefreeze { get; set; }        
        [Column(TypeName = "date")]
        public DateTime? plan_shipment { get; set; }        
        public string shipped { get; set; }        
        public string jira_issue { get; set; }        
        public string optimization { get; set; }        
        public int actual_build { get; set; }        
        [Column(TypeName = "date")]
        public DateTime? actual_codefreeze { get; set; }        
        [Column(TypeName = "date")]
        public DateTime? actual_shipment { get; set; }        
        public string build_machine { get; set; }        
        public string client { get; set; }        
        public string comments { get; set; }
        
        [Column(TypeName = "date")]
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
