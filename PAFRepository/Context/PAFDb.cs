using System;
using System.Collections;
using System.Data.Entity;
using Entities;

namespace PAFRepository.Context
{
    public class PAFDb : DbContext, IEnumerable
    {
        public PAFDb(String connectionString)
            : base(connectionString)
        {

        }

        public virtual DbSet<DeliveryPoint> DeliveryPoints { get; set; }
        public virtual DbSet<Locality> Localities { get; set; }
        public virtual DbSet<ThoroughFare> ThoroughFares { get; set; }
        public virtual DbSet<WelshDeliveryPoint> WelshDeliveryPoints { get; set; }
        public virtual DbSet<WelshLocality> WelshLocalities { get; set; }
        public virtual DbSet<WelshThoroughFare> WelshThoroughFares { get; set; }
        public virtual DbSet<FatalAddressLog> FatalAddressLogs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DeliveryPoint>()
                .Property(e => e.Outcode)
                .IsUnicode(false);

            modelBuilder.Entity<DeliveryPoint>()
                .Property(e => e.Incode)
                .IsUnicode(false);

            modelBuilder.Entity<DeliveryPoint>()
                .Property(e => e.PostCodeType)
                .IsUnicode(false);

            modelBuilder.Entity<DeliveryPoint>()
                .Property(e => e.Sequence)
                .IsUnicode(false);

            modelBuilder.Entity<DeliveryPoint>()
                .Property(e => e.DPS)
                .IsUnicode(false);

            modelBuilder.Entity<DeliveryPoint>()
                .Property(e => e.BuildingName)
                .IsUnicode(false);

            modelBuilder.Entity<DeliveryPoint>()
                .Property(e => e.SubBuildingName)
                .IsUnicode(false);

            modelBuilder.Entity<DeliveryPoint>()
                .Property(e => e.OrganisationName)
                .IsUnicode(false);

            modelBuilder.Entity<DeliveryPoint>()
                .Property(e => e.DepartmentName)
                .IsUnicode(false);

            modelBuilder.Entity<DeliveryPoint>()
                .Property(e => e.POBoxNumber)
                .IsUnicode(false);

            modelBuilder.Entity<DeliveryPoint>()
                .Property(e => e.NoOfHouseholds)
                .IsUnicode(false);

            modelBuilder.Entity<DeliveryPoint>()
                .Property(e => e.SmallUserOrganisation)
                .IsUnicode(false);

            modelBuilder.Entity<Locality>()
                .Property(e => e.Outcode)
                .IsUnicode(false);

            modelBuilder.Entity<Locality>()
                .Property(e => e.Incode)
                .IsUnicode(false);

            modelBuilder.Entity<Locality>()
                .Property(e => e.PostCodeType)
                .IsUnicode(false);

            modelBuilder.Entity<Locality>()
                .Property(e => e.PostTown)
                .IsUnicode(false);

            modelBuilder.Entity<Locality>()
                .Property(e => e.DepLocality)
                .IsUnicode(false);

            modelBuilder.Entity<Locality>()
                .Property(e => e.DoubleDepLocality)
                .IsUnicode(false);

            modelBuilder.Entity<Locality>()
                .Property(e => e.PostTownTidy)
                .IsUnicode(false);

            modelBuilder.Entity<Locality>()
                .Property(e => e.DepLocalityTidy)
                .IsUnicode(false);

            modelBuilder.Entity<ThoroughFare>()
                .Property(e => e.Outcode)
                .IsUnicode(false);

            modelBuilder.Entity<ThoroughFare>()
                .Property(e => e.Incode)
                .IsUnicode(false);

            modelBuilder.Entity<ThoroughFare>()
                .Property(e => e.PostCodeType)
                .IsUnicode(false);

            modelBuilder.Entity<ThoroughFare>()
                .Property(e => e.Sequence)
                .IsUnicode(false);

            modelBuilder.Entity<ThoroughFare>()
                .Property(e => e.ThoroughFareName)
                .IsUnicode(false);

            modelBuilder.Entity<ThoroughFare>()
                .Property(e => e.ThoroughFareDescriptor)
                .IsUnicode(false);

            modelBuilder.Entity<ThoroughFare>()
                .Property(e => e.DepThoroughFareName)
                .IsUnicode(false);

            modelBuilder.Entity<ThoroughFare>()
                .Property(e => e.DepThoroughFareDescriptor)
                .IsUnicode(false);

            modelBuilder.Entity<ThoroughFare>()
                .Property(e => e.ThoroughFareNameTidy)
                .IsUnicode(false);

            modelBuilder.Entity<ThoroughFare>()
                .Property(e => e.DepThoroughFareNameTidy)
                .IsUnicode(false);

            modelBuilder.Entity<WelshDeliveryPoint>()
                .Property(e => e.Outcode)
                .IsUnicode(false);

            modelBuilder.Entity<WelshDeliveryPoint>()
                .Property(e => e.Incode)
                .IsUnicode(false);

            modelBuilder.Entity<WelshDeliveryPoint>()
                .Property(e => e.PostCodeType)
                .IsUnicode(false);

            modelBuilder.Entity<WelshDeliveryPoint>()
                .Property(e => e.Sequence)
                .IsUnicode(false);

            modelBuilder.Entity<WelshDeliveryPoint>()
                .Property(e => e.DPS)
                .IsUnicode(false);

            modelBuilder.Entity<WelshDeliveryPoint>()
                .Property(e => e.BuildingName)
                .IsUnicode(false);

            modelBuilder.Entity<WelshDeliveryPoint>()
                .Property(e => e.SubBuildingName)
                .IsUnicode(false);

            modelBuilder.Entity<WelshDeliveryPoint>()
                .Property(e => e.OrganisationName)
                .IsUnicode(false);

            modelBuilder.Entity<WelshDeliveryPoint>()
                .Property(e => e.DepartmentName)
                .IsUnicode(false);

            modelBuilder.Entity<WelshDeliveryPoint>()
                .Property(e => e.POBoxNumber)
                .IsUnicode(false);

            modelBuilder.Entity<WelshDeliveryPoint>()
                .Property(e => e.NoOfHouseholds)
                .IsUnicode(false);

            modelBuilder.Entity<WelshDeliveryPoint>()
                .Property(e => e.SmallUserOrganisation)
                .IsUnicode(false);

            modelBuilder.Entity<WelshLocality>()
                .Property(e => e.Outcode)
                .IsUnicode(false);

            modelBuilder.Entity<WelshLocality>()
                .Property(e => e.Incode)
                .IsUnicode(false);

            modelBuilder.Entity<WelshLocality>()
                .Property(e => e.PostCodeType)
                .IsUnicode(false);

            modelBuilder.Entity<WelshLocality>()
                .Property(e => e.PostTown)
                .IsUnicode(false);

            modelBuilder.Entity<WelshLocality>()
                .Property(e => e.DepLocality)
                .IsUnicode(false);

            modelBuilder.Entity<WelshLocality>()
                .Property(e => e.DoubleDepLocality)
                .IsUnicode(false);

            modelBuilder.Entity<WelshLocality>()
                .Property(e => e.PostTownTidy)
                .IsUnicode(false);

            modelBuilder.Entity<WelshLocality>()
                .Property(e => e.DepLocalityTidy)
                .IsUnicode(false);

            modelBuilder.Entity<WelshThoroughFare>()
                .Property(e => e.Outcode)
                .IsUnicode(false);

            modelBuilder.Entity<WelshThoroughFare>()
                .Property(e => e.Incode)
                .IsUnicode(false);

            modelBuilder.Entity<WelshThoroughFare>()
                .Property(e => e.PostCodeType)
                .IsUnicode(false);

            modelBuilder.Entity<WelshThoroughFare>()
                .Property(e => e.Sequence)
                .IsUnicode(false);

            modelBuilder.Entity<WelshThoroughFare>()
                .Property(e => e.ThoroughFareName)
                .IsUnicode(false);

            modelBuilder.Entity<WelshThoroughFare>()
                .Property(e => e.ThoroughFareDescriptor)
                .IsUnicode(false);

            modelBuilder.Entity<WelshThoroughFare>()
                .Property(e => e.DepThoroughFareName)
                .IsUnicode(false);

            modelBuilder.Entity<WelshThoroughFare>()
                .Property(e => e.DepThoroughFareDescriptor)
                .IsUnicode(false);

            modelBuilder.Entity<WelshThoroughFare>()
                .Property(e => e.ThoroughFareNameTidy)
                .IsUnicode(false);

            modelBuilder.Entity<WelshThoroughFare>()
                .Property(e => e.DepThoroughFareNameTidy)
                .IsUnicode(false);

            modelBuilder.Entity<FatalAddressLog>()
                .Property(e => e.Address)
                .IsUnicode(false);
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
