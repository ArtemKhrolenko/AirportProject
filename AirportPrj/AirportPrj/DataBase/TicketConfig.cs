using System;
using System.Data.Entity.ModelConfiguration;
using AirportPrj.Model;

namespace AirportPrj.DataBase
{
    class TicketConfig : EntityTypeConfiguration<Ticket>
    {
        public TicketConfig()
        {
            HasKey(ticket => ticket.TicketNumb);
            Property(ticket => ticket.TicketNumb).IsRequired().HasMaxLength(50);
            Property(ticket => ticket.FlightID).IsRequired();
            Property(ticket => ticket.Price).IsRequired();

            ToTable("Ticket");
        }
    }
}