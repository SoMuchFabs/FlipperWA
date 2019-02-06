namespace FlipperAPI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ITS_GROUP2.SCREENINGS")]
    public partial class SCREENINGS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SCREENINGS()
        {
            RESERVATIONS = new HashSet<RESERVATIONS>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal ID_SCREENING { get; set; }

        public decimal ID_FILM { get; set; }

        public DateTime SCREENING_DATE { get; set; }

        public decimal? PRICE { get; set; }

        public byte? REDUCTION_PCT { get; set; }

        public decimal? REDUCTED_PRICE { get; set; }

        public decimal ID_THEATER { get; set; }

        public virtual FILMS FILMS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RESERVATIONS> RESERVATIONS { get; set; }

        public virtual THEATERS THEATERS { get; set; }
    }
}
