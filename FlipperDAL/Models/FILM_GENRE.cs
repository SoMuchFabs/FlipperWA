namespace FlipperDAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ITS_GROUP2.FILM_GENRE")]
    public partial class FILM_GENRE
    {
        [Key,Column(Order =0)]
        public decimal ID_FILM { get; set; }
        [Key,Column(Order =1)]
        public decimal ID_GENRE { get; set; }

        public virtual FILMS FILMS { get; set; }

        public virtual GENRES GENRES { get; set; }
    }
}
