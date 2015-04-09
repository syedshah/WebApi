namespace Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ThoroughFare")]
    public partial class ThoroughFare
    {
        [Key]
        public int ThoroughFareID { get; set; }

        [StringLength(4)]
        public String Outcode { get; set; }

        [StringLength(3)]
        public String Incode { get; set; }

        [StringLength(1)]
        public String PostCodeType { get; set; }

        [StringLength(1)]
        public String Sequence { get; set; }

        [StringLength(60)]
        public String ThoroughFareName { get; set; }

        [StringLength(20)]
        public String ThoroughFareDescriptor { get; set; }

        [StringLength(60)]
        public String DepThoroughFareName { get; set; }

        [StringLength(20)]
        public String DepThoroughFareDescriptor { get; set; }

        [StringLength(60)]
        public String ThoroughFareNameTidy { get; set; }

        [StringLength(65)]
        public String DepThoroughFareNameTidy { get; set; }
        
    }
}
