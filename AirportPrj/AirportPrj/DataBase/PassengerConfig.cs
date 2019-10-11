using System;
using System.Data.Entity.ModelConfiguration;
using AirportPrj.Model;

namespace AirportPrj.DataBase
{
    class PassengerConfig : EntityTypeConfiguration<Passenger>
    {
        public PassengerConfig()
        {
            HasKey(passenger => passenger.Passport);
            Property(passenger => passenger.FirstName).IsRequired().HasMaxLength(50);
            Property(passenger => passenger.LastName).IsRequired().HasMaxLength(50);
            Property(passenger => passenger.Nationality).IsRequired().HasMaxLength(50);
            Property(passenger => passenger.Passport).IsRequired().HasMaxLength(50);
            Property(passenger => passenger.DateOfBirth).HasColumnType("date").IsOptional();
            Property(passenger => passenger.Sex).IsRequired();
            Property(passenger => passenger.PassClass).IsRequired();
            Property(passenger => passenger.FlightID).IsRequired();

            ToTable("Passenger");
        }
    }
}
