namespace TMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Bank_Information
    {
        [Key]
        public int Bank_ID { get; set; }

        [StringLength(50)]
        public string Bank_Name { get; set; }

        [StringLength(50)]
        public string Acronym { get; set; }

        [StringLength(50)]
        public string Branch_Code { get; set; }

        [StringLength(50)]
        public string Website { get; set; }

        [StringLength(50)]
        public string Phone_Number { get; set; }

        [StringLength(500)]
        public string Address { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Created_Date { get; set; }

        public int? Created_By { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Modified_Date { get; set; }

        public int? Modified_By { get; set; }

        public bool? Active { get; set; }
    }
}
