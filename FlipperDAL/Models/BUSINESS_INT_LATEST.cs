namespace FlipperDAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ITS_GROUP2.BUSINESS_INT_LATEST")]
    public partial class BUSINESS_INT_LATEST
    {
        [Key]
        [StringLength(100)]
        public string NAME { get; set; }

        public decimal? TOTAL_RESERVATIONS { get; set; }

        [StringLength(81)]
        public string REDUCTED_REGULAR_RATIO { get; set; }
    }
}
