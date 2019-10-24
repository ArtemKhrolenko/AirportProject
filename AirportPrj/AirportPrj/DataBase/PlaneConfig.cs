using System;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;
using AirportPrj.Model;

namespace AirportPrj.DataBase
{
    class PlaneConfig : EntityTypeConfiguration<Plane>
    {
        public PlaneConfig()
        {
            HasKey(plane => plane.PlaneID);
            //Property(plane => plane.PlaneID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(plane => plane.Manufacturer).IsRequired().HasMaxLength(50);
            Property(plane => plane.Model).IsRequired().HasMaxLength(50);
            Property(plane => plane.FlightID).IsRequired();
            
            
            ToTable("Plane");

        }
    }
}
