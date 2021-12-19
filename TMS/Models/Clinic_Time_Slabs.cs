namespace TMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Clinic_Time_Slabs
    {
        [Key]
        public int Cline_Time_ID { get; set; }

        [Column("Clinic_Time_Slabs")]
        [StringLength(50)]
        public string Clinic_Time_Slabs1 { get; set; }

        public long? Clinic_Code { get; set; }

        public DateTime? Created_Date { get; set; }

        public int? Created_By { get; set; }

        public DateTime? Modified_Date { get; set; }

        public int? Modified_By { get; set; }

        public bool? Active { get; set; }
    }
}
