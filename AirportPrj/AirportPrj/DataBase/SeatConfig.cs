using System;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;
using AirportPrj.Model;

namespace AirportPrj.DataBase
{
    class SeatConfig : EntityTypeConfiguration<Seat>
    {
        public SeatConfig()
        {
            //HasKey(seat => seat.Number);

            //Property(seat => seat.Number).IsRequired().HasMaxLength(50);            
            
            //ToTable("Seat");

        }
    }
}
