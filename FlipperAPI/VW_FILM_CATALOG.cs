namespace FlipperAPI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ITS_GROUP2.VW_FILM_CATALOG")]
    public partial class VW_FILM_CATALOG
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(100)]
        public string NOME { get; set; }

        [Key]
        [Column(Order = 1)]
        public DateTime RILASCIATO { get; set; }

        [StringLength(500)]
        public string TRAMA { get; set; }

        [StringLength(4000)]
        public string ATTORI { get; set; }

        [StringLength(4000)]
        public string CATEGORIA { get; set; }
    }
}
