﻿using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirportPrj.Model;

namespace AirportPrj.DataBase
{
    class AirportContext : DbContext
    {
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<ArrivalFlight> ArrivalFlight { get; set; }
        public DbSet<DepartureFlight> DepartureFlight { get; set; }

        public AirportContext(string connectionString = "AirportPrj.Properties.Settings.AirportDBConnectionString")
            : base(connectionString)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new PassengerConfig());
            modelBuilder.Configurations.Add(new ArrivalFlightConfig());
            modelBuilder.Configurations.Add(new DepartureFlightConfig());
        }
    }
}
