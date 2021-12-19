namespace TMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Clinic_Information
    {
        [Key]
        public long Clinic_ID { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Acronym { get; set; }

        [StringLength(50)]
        public string NTN_Number { get; set; }

        [StringLength(13)]
        public string Contact { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(50)]
        public string Website { get; set; }

        public int? Time_Start_ID { get; set; }

        [StringLength(50)]
        public string Time_Start { get; set; }

        public int? Time_End_ID { get; set; }

        [StringLength(50)]
        public string Time_End { get; set; }

        public int? Closing_Day { get; set; }

        public int? Country { get; set; }

        public int? State { get; set; }

        public int? City { get; set; }

        [StringLength(150)]
        public string Address { get; set; }

        [StringLength(255)]
        public string Discription { get; set; }

        [StringLength(255)]
        public string Logo { get; set; }

        public DateTime? Created_Date { get; set; }

        public long? Created_By { get; set; }

        public DateTime? Modified_Date { get; set; }

        public long? Modified_By { get; set; }

        public long? Clinic_Code { get; set; }
    }
}
