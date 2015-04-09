namespace Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("WelshLocality")]
    public partial class WelshLocality
    {
        [Key]
        public int WelshLocalityID { get; set; }

        [StringLength(4)]
        public String Outcode { get; set; }

        [StringLength(3)]
        public String Incode { get; set; }

        [StringLength(1)]
        public String PostCodeType { get; set; }

        [StringLength(30)]
        public String PostTown { get; set; }

        [StringLength(35)]
        public String DepLocality { get; set; }

        [StringLength(35)]
        public String DoubleDepLocality { get; set; }

        [StringLength(30)]
        public String PostTownTidy { get; set; }

        [StringLength(35)]
        public String DepLocalityTidy { get; set; }

    }
}
