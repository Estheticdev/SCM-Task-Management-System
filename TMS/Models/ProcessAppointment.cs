namespace TMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProcessAppointment")]
    public partial class ProcessAppointment
    {
        [Key]
        public int Process_ID { get; set; }

        public int? Doctor_ID { get; set; }

        public int? Appointment_ID { get; set; }

        public decimal? Amount_Recieved { get; set; }

        [StringLength(8000)]
        public string Prescription { get; set; }

        public DateTime? Processed_Date { get; set; }

        public int? Processed_By { get; set; }

        public long? Clinic_Code { get; set; }
    }
}
