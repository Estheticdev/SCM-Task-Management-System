namespace TMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Doctor_Information
    {
        [Key]
        public int Doctor_ID { get; set; }

        [StringLength(50)]
        public string First_Name { get; set; }

        [StringLength(50)]
        public string Middle_Name { get; set; }

        [StringLength(50)]
        public string Last_Name { get; set; }

        public DateTime? DOB { get; set; }

        public int? Gender_Id { get; set; }

        public int? Marital_Status { get; set; }

        [StringLength(50)]
        public string PMDC_No { get; set; }

        [StringLength(50)]
        public string CNIC_No { get; set; }

        [StringLength(50)]
        public string Cell_No { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(50)]
        public string Home_Ph_No { get; set; }

        public int? Speciality { get; set; }

        public int? Country { get; set; }

        public int? State { get; set; }

        public int? City { get; set; }

        [StringLength(500)]
        public string Postal_Address { get; set; }

        public int? Bank_ID { get; set; }

        [StringLength(50)]
        public string Account_Information { get; set; }

        public decimal? Fee { get; set; }

        [StringLength(1000)]
        public string Discription { get; set; }

        public DateTime? Created_Date { get; set; }

        public int? Created_By { get; set; }

        public DateTime? Modified_Date { get; set; }

        public int? Modified_By { get; set; }

        public bool? Active { get; set; }

        public long? Clinic_Code { get; set; }
    }
}
