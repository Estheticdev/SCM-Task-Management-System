namespace TMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Appointment
    {
        [Key]
        public long Appointment_ID { get; set; }

        public long? Clinic_Code { get; set; }

        public int? Doctor_ID { get; set; }

        public int? Patient_Type { get; set; }

        public long? Patient_ID { get; set; }

        public int? Service_ID { get; set; }

        public DateTime? Appointment_Date { get; set; }

        public int? Day_ID { get; set; }

        public int? Time_ID { get; set; }

        public int? Disease_ID { get; set; }

        [Required]
        [StringLength(500)]
        public string Note { get; set; }

        public int? Status { get; set; }

        public DateTime? Created_Date { get; set; }

        public int? Created_By { get; set; }

        public DateTime? Modified_Date { get; set; }

        public int? Modified_By { get; set; }

        public DateTime? Processed_Date { get; set; }

        public int? Processed_By { get; set; }

        public bool? Active { get; set; }
    }
}
