namespace TMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Email_Templates
    {
        [Key]
        public int TemplateID { get; set; }

        [StringLength(50)]
        public string Template_Name { get; set; }

        [StringLength(100)]
        public string Email_Subject { get; set; }

        [StringLength(500)]
        public string Email_Body { get; set; }

        public bool? Active { get; set; }

        public long? Clinic_Code { get; set; }
    }
}
