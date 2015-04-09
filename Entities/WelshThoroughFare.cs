namespace Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("WelshThoroughFare")]
    public partial class WelshThoroughFare
    {
        [Key]
        public int WelshThoroughFareID { get; set; }

        [StringLength(4)]
        public string Outcode { get; set; }

        [StringLength(3)]
        public string Incode { get; set; }

        [StringLength(1)]
        public string PostCodeType { get; set; }

        [StringLength(1)]
        public string Sequence { get; set; }

        [StringLength(60)]
        public string ThoroughFareName { get; set; }

        [StringLength(20)]
        public string ThoroughFareDescriptor { get; set; }

        [StringLength(60)]
        public string DepThoroughFareName { get; set; }

        [StringLength(20)]
        public string DepThoroughFareDescriptor { get; set; }

        [StringLength(60)]
        public string ThoroughFareNameTidy { get; set; }

        [StringLength(65)]
        public string DepThoroughFareNameTidy { get; set; }

    }
}
