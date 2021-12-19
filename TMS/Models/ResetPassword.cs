namespace TMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ResetPassword")]
    public partial class ResetPassword
    {
        [Key]
        public int Request_ID { get; set; }

        public string UserName { get; set; }

        public string User_email { get; set; }

        public string Token { get; set; }

        public DateTime? Date_Stamp { get; set; }

        public DateTime? Expiry_Date { get; set; }

        public bool? isPasswordChanged { get; set; }

        public DateTime? Change_Date_Stamp { get; set; }

        [StringLength(50)]
        public string Request_Status { get; set; }
    }
}
