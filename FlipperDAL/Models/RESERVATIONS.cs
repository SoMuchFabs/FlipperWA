namespace FlipperDAL
{
    using FlipperDAL.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;


    [Table("ITS_GROUP2.RESERVATIONS")]
    public partial class RESERVATIONS
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal ID_RESERVATION { get; set; }

        public decimal ID_SCREENING { get; set; }

        public DateTime? RESERVATION_DATE { get; set; }

        public decimal ID_SEAT { get; set; }

        public bool IS_REDUCED { get; set; }

        [Required]
        [StringLength(128)]
        public string ID_USER { get; set; }

        public virtual ApplicationUser APPLICATIONUSER { get; set; }

        public virtual SEATS SEATS { get; set; }

        public virtual SCREENINGS SCREENINGS { get; set; }
    }
}
