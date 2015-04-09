namespace Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FatalAddressLog")]
    public partial class FatalAddressLog
    {
        [Key]
        [Column(Order = 0)]
        public int ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(4000)]
        public String Address { get; set; }

        [Key]
        [Column(Order = 2)]
        public DateTime DateTime { get; set; }
    }
}
