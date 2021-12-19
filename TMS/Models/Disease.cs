namespace TMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Disease")]
    public partial class Disease
    {
        [Key]
        public int Disease_ID { get; set; }

        public int? Speciality { get; set; }

        [StringLength(30)]
        public string Disease_Name { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Created_Date { get; set; }

        public int? Created_By { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Modified_Date { get; set; }

        public int? Modified_By { get; set; }

        public bool? Active { get; set; }
    }
}
