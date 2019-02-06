namespace FlipperAPI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ITS_GROUP2.SEATS")]
    public partial class SEATS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SEATS()
        {
            RESERVATIONS = new HashSet<RESERVATIONS>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal ID_SEAT { get; set; }

        [Required]
        [StringLength(2)]
        public string CODE { get; set; }

        public decimal ID_THEATER { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RESERVATIONS> RESERVATIONS { get; set; }

        public virtual THEATERS THEATERS { get; set; }
    }
}
