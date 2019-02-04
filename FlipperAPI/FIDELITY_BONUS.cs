namespace FlipperAPI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ITS_GROUP2.FIDELITY_BONUS")]
    public partial class FIDELITY_BONUS
    {
        [Key]
        public decimal ID_FIDELITY_BONUS { get; set; }

        [Required]
        [StringLength(100)]
        public string NAME { get; set; }

        [StringLength(500)]
        public string DESCRIPTION { get; set; }

        public decimal COST { get; set; }
    }
}
