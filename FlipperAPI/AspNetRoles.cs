namespace FlipperAPI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ITS_GROUP2.ASPNETROLES")]
    public partial class ASPNETROLES
    {
        public string ID { get; set; }

        [Required]
        [StringLength(256)]
        public string NAME { get; set; }
    }
}
