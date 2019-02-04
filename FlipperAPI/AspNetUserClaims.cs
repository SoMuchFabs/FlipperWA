namespace FlipperAPI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ITS_GROUP2.ASPNETUSERCLAIMS")]
    public partial class ASPNETUSERCLAIMS
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [Required]
        [StringLength(128)]
        public string USERID { get; set; }

        [StringLength(256)]
        public string CLAIMTYPE { get; set; }

        [StringLength(256)]
        public string CLAIMVALUE { get; set; }
    }
}
