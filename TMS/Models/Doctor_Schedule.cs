namespace TMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Doctor_Schedule
    {
        [Key]
        public int Schedule_ID { get; set; }

        public int? Doctor_ID { get; set; }

        public int? Day_ID { get; set; }

        public int? Time_ID { get; set; }

        public int? Created_By { get; set; }

        public DateTime? Created_Date { get; set; }

        public int? Modified_By { get; set; }

        public DateTime? Modified_Date { get; set; }

        public bool? Active { get; set; }

        public long? Clinic_Code { get; set; }
    }
}
