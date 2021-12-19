namespace TMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CreateUser")]
    public partial class CreateUser
    {
        [Key]
        public int User_ID { get; set; }

        public int? UserType { get; set; }

        public int? Staff_ID { get; set; }

        public int? Doctor_ID { get; set; }

        [StringLength(50)]
        public string User_Name { get; set; }

        [StringLength(50)]
        public string Password { get; set; }

        public bool? Super_Admin { get; set; }

        public bool? Active { get; set; }

        public DateTime? Created_Date { get; set; }

        public int? Created_By { get; set; }

        public DateTime? Modified_Date { get; set; }

        public int? Modified_By { get; set; }

        public long? Clinic_Code { get; set; }
    }
}
