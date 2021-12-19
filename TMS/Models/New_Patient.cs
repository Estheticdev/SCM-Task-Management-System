namespace TMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class New_Patient
    {
        [Key]
        public long New_Patient_ID { get; set; }

        [StringLength(50)]
        public string Full_Name { get; set; }

        public DateTime? DOB { get; set; }

        [StringLength(13)]
        public string Contact { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        public int? Blood_Group_ID { get; set; }

        [StringLength(15)]
        public string CNIC { get; set; }

        public int? City_ID { get; set; }

        [StringLength(500)]
        public string Discription { get; set; }

        [StringLength(500)]
        public string Address { get; set; }

        public DateTime? Created_Date { get; set; }

        public long? Created_By { get; set; }

        public DateTime? Modified_Date { get; set; }

        public long? Modified_By { get; set; }

        public long? Clinic_Code { get; set; }

        public int? Request_Type { get; set; }
    }
}
