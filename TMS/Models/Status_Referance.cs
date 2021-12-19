namespace TMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Status_Referance
    {
        [Key]
        public int Ref_ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Reference_Code { get; set; }

        [Required]
        [StringLength(100)]
        public string Reference_ID { get; set; }

        [StringLength(500)]
        public string Reference_Desc { get; set; }

        public int? Sort_Order { get; set; }

        public bool Active { get; set; }
    }
}
