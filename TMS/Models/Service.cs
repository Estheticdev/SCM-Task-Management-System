namespace TMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Service")]
    public partial class Service
    {
        [Key]
        public int Service_ID { get; set; }

        [StringLength(50)]
        public string Service_Name { get; set; }

        public bool? Active { get; set; }

        public DateTime? Created_Date { get; set; }

        public long? Created_By { get; set; }

        public DateTime? Modified_Date { get; set; }

        public long? Modified_By { get; set; }

        public long? Clinic_Code { get; set; }
    }
}
