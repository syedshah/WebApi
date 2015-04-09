namespace Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DeliveryPoint")]
    public partial class DeliveryPoint
    {
        [Key]
        public int DeliveryPointID { get; set; }

        [StringLength(4)]
        public String Outcode { get; set; }

        [StringLength(3)]
        public String Incode { get; set; }

        [StringLength(1)]
        public String PostCodeType { get; set; }

        [StringLength(1)]
        public String Sequence { get; set; }

        [StringLength(2)]
        public String DPS { get; set; }

        public short? BuildingNumber { get; set; }

        [StringLength(50)]
        public String BuildingName { get; set; }

        [StringLength(30)]
        public String SubBuildingName { get; set; }

        [StringLength(60)]
        public String OrganisationName { get; set; }

        [StringLength(60)]
        public String DepartmentName { get; set; }

        [StringLength(14)]
        public String POBoxNumber { get; set; }

        [StringLength(4)]
        public String NoOfHouseholds { get; set; }

        [StringLength(1)]
        public String SmallUserOrganisation { get; set; }

        public int? AddressKey { get; set; }

        public int? OrganisationKey { get; set; }

    }
}
