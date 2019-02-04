namespace FlipperAPI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ITS_GROUP2.ASPNETUSERS")]
    public partial class ASPNETUSERS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ASPNETUSERS()
        {
            RESERVATIONS = new HashSet<RESERVATIONS>();
        }

        public string ID { get; set; }

        [StringLength(256)]
        public string EMAIL { get; set; }

        public bool EMAILCONFIRMED { get; set; }

        [StringLength(256)]
        public string PASSWORDHASH { get; set; }

        [StringLength(256)]
        public string SECURITYSTAMP { get; set; }

        [StringLength(256)]
        public string PHONENUMBER { get; set; }

        public bool PHONENUMBERCONFIRMED { get; set; }

        public bool TWOFACTORENABLED { get; set; }

        public DateTime? LOCKOUTENDDATEUTC { get; set; }

        public bool LOCKOUTENABLED { get; set; }

        public int ACCESSFAILEDCOUNT { get; set; }

        [Required]
        [StringLength(256)]
        public string USERNAME { get; set; }

        [StringLength(100)]
        public string NAME { get; set; }

        [StringLength(100)]
        public string SURNAME { get; set; }

        public DateTime? REGISTRATION_DATE { get; set; }

        public DateTime? LAST_ACCESS { get; set; }

        public decimal? FIDELITY_POINTS { get; set; }

        public bool? IS_ACTIVE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RESERVATIONS> RESERVATIONS { get; set; }
    }
}
