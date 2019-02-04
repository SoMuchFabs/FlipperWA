namespace FlipperAPI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ITS_GROUP2.ASPNETUSERROLES")]
    public partial class ASPNETUSERROLES
    {
        [Key]
        [Column(Order = 0)]
        public string USERID { get; set; }

        [Key]
        [Column(Order = 1)]
        public string ROLEID { get; set; }
    }
}
