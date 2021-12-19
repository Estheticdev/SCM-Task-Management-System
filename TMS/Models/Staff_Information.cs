namespace TMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Staff_Information
    {
        [Key]
        public int Staff_ID { get; set; }

        [StringLength(50)]
        public string First_Name { get; set; }

        [StringLength(50)]
        public string Middle_Name { get; set; }

        [StringLength(50)]
        public string Last_Name { get; set; }

        public int? Gender { get; set; }

        public int? Marital_Status { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(50)]
        public string CNIC_No { get; set; }

        [StringLength(50)]
        public string Cell_No { get; set; }

        [StringLength(150)]
        public string Address { get; set; }

        public DateTime? Created_Date { get; set; }

        public int? Created_By { get; set; }

        public DateTime? Modified_Date { get; set; }

        public int? Modified_By { get; set; }

        public bool? Active { get; set; }

        public long? ClinicCode { get; set; }
    }
}
