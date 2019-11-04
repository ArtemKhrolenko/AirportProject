using System;
using System.Data.Entity.ModelConfiguration;
using AirportPrj.Model;

namespace AirportPrj.DataBase
{
    public class DepartureFlightConfig : EntityTypeConfiguration<DepartureFlight>
    {
        public DepartureFlightConfig()
        {
            HasKey(flight => flight.FlightID);
            Property(flight => flight.FlightID).IsRequired().HasMaxLength(50);
            Property(flight => flight.Time).HasColumnType("date").IsOptional();
            Property(flight => flight.CityName).IsRequired().HasMaxLength(50);
            Property(flight => flight.AirCompany).IsRequired().HasMaxLength(50);
            Property(flight => flight.Terminal).IsRequired().HasMaxLength(2);
            Property(flight => flight.GateID).IsRequired().HasMaxLength(50);
            Property(flight => flight.FlightStatus).IsRequired();
            Property(flight => flight.PlaneID).IsRequired();

            ToTable("DepartureFlight");
        }
    }
}
