namespace FlipperAPI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ITS_GROUP2.FILM_ACTOR")]
    public partial class FILM_ACTOR
    {
        [Key]
        public decimal ID_FILM_ACTOR { get; set; }

        public decimal ID_FILM { get; set; }

        public decimal ID_ACTOR { get; set; }

        public virtual ACTORS ACTORS { get; set; }

        public virtual FILMS FILMS { get; set; }
    }
}
