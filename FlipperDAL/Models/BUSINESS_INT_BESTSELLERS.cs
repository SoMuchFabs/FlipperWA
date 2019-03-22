namespace FlipperDAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ITS_GROUP2.BUSINESS_INT_BESTSELLERS")]
    public partial class BUSINESS_INT_BESTSELLERS
    {
        [Key]
        [StringLength(100)]
        public string NAME { get; set; }

        public decimal? TOTAL_SCREENINGS { get; set; }

        public decimal? TOTAL_EARNINGS { get; set; }

        public decimal? AVERAGE_EARNINGS { get; set; }
    }
}
