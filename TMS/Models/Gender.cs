namespace TMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Gender")]
    public partial class Gender
    {
        [Key]
        public int Gender_ID { get; set; }

        [StringLength(15)]
        public string Gender_Name { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Created_Date { get; set; }

        public int? Created_By { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Modified_Date { get; set; }

        public int? Modified_By { get; set; }

        public bool? Active { get; set; }
    }
}
