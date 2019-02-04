namespace FlipperAPI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ITS_GROUP2.FILMS")]
    public partial class FILMS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FILMS()
        {
            FILM_ACTOR = new HashSet<FILM_ACTOR>();
            FILM_GENRE = new HashSet<FILM_GENRE>();
            SCREENINGS = new HashSet<SCREENINGS>();
        }

        [Key]
        public decimal ID_FILM { get; set; }

        [Required]
        [StringLength(100)]
        public string NAME { get; set; }

        public DateTime RELEASE_DATE { get; set; }

        [StringLength(500)]
        public string PLOT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FILM_ACTOR> FILM_ACTOR { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FILM_GENRE> FILM_GENRE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SCREENINGS> SCREENINGS { get; set; }
    }
}
