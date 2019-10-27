using AirportPrj.Model;
using System;

namespace AirportPrj.DataBase
{
    public static class InitDB
    {
        public static bool IsRebuid;

        internal static void Fill(AirportContext Context)
        {
            var planes = new[]
            {
                new Plane {PlaneID = "AB",  Manufacturer = "Boeing", Model = "737"},
                new Plane {PlaneID = "AC",  Manufacturer = "AirBus", Model = "A380"}
            };


            var passengers = new[]
            {
                new Passenger {FirstName = "Mohammed", LastName = "Woodham", Nationality = "Afghan", Passport = "CH 123456", DateOfBirth = new DateTime(1995, 9, 2), Sex = Sex.Male, PassClass = PassClass.Business, FlightID = "1"},
                new Passenger {FirstName = "Porter", LastName = "Hilger", Nationality = "Belgian", Passport = "QW 132447", DateOfBirth = new DateTime(1996, 9, 2), Sex = Sex.Male, PassClass = PassClass.Economy, FlightID = "2"},
                new Passenger {FirstName = "Chad", LastName = "Heyer", Nationality = "Brazilian", Passport = "DF 345678", DateOfBirth = new DateTime(1997, 9, 2), Sex = Sex.Male, PassClass = PassClass.Business, FlightID = "3"},
                new Passenger {FirstName = "Fidel", LastName = "Dorsey", Nationality = "Chinese", Passport = "JK 135286", DateOfBirth = new DateTime(1998, 9, 2), Sex = Sex.Male, PassClass = PassClass.Economy, FlightID = "4"},
                new Passenger {FirstName = "Faustino", LastName = "Sweatt", Nationality = "Cuban", Passport = "PQ 102938", DateOfBirth = new DateTime(1999, 9, 2), Sex = Sex.Male, PassClass = PassClass.Business, FlightID = "5"},

                new Passenger {FirstName = "Alexandra", LastName = "Barrientez", Nationality = "Ethiopian", Passport = "AS 416587", DateOfBirth = new DateTime(1985, 9, 2), Sex = Sex.Female, PassClass = PassClass.Economy, FlightID = "6"},
                new Passenger {FirstName = "Bari", LastName = "Lazar", Nationality = "Iranian", Passport = "DG 764556", DateOfBirth = new DateTime(2000, 9, 2), Sex = Sex.Female, PassClass = PassClass.Business, FlightID = "7"},
                new Passenger {FirstName = "Awilda", LastName = "Marson", Nationality = "Nambian", Passport = "JH 653076", DateOfBirth = new DateTime(2001, 9, 2), Sex = Sex.Female, PassClass = PassClass.Economy, FlightID = "8"},
                new Passenger {FirstName = "Patrica", LastName = "Blackledge", Nationality = "Serbian", Passport = "MN 852700", DateOfBirth = new DateTime(2002, 9, 2), Sex = Sex.Female, PassClass = PassClass.Business, FlightID = "9"},
                new Passenger {FirstName = "Ellie", LastName = "Baumer", Nationality = "Ukranian", Passport = "CX 336629", DateOfBirth = new DateTime(1999, 9, 2), Sex = Sex.Female, PassClass = PassClass.Economy, FlightID = "10"}
            };
            Context.Passengers.AddRange(passengers);

            var tickets = new[]
{
                new Ticket {TicketNumb = passengers[0].FlightID, FlightID=passengers[0].FlightID, Price = 34.8M},
                new Ticket {TicketNumb = passengers[1].FlightID, FlightID="23333", Price = 44.1M},
                new Ticket {TicketNumb = passengers[2].FlightID, FlightID=passengers[2].FlightID, Price = 22.5M},
                new Ticket {TicketNumb = passengers[3].FlightID, FlightID=passengers[3].FlightID, Price = 13.0M},
                new Ticket {TicketNumb = passengers[4].FlightID, FlightID=passengers[4].FlightID, Price = 67.9M},
                new Ticket {TicketNumb = passengers[5].FlightID, FlightID=passengers[5].FlightID, Price = 47.5M},
                new Ticket {TicketNumb = passengers[6].FlightID, FlightID=passengers[6].FlightID, Price = 25.6M},
                new Ticket {TicketNumb = passengers[7].FlightID, FlightID=passengers[7].FlightID, Price = 36.7M},
                new Ticket {TicketNumb = passengers[8].FlightID, FlightID=passengers[8].FlightID, Price = 47.8M},
                new Ticket {TicketNumb = passengers[9].FlightID,FlightID=passengers[9].FlightID, Price = 58.9M}
            };
            Context.Tickets.AddRange(tickets);

            var arrivalFlights = new[]
{
                //new ArrivalFlight {FlightID = "KC 406", PlaneID = "AB", Time = new DateTime(1995, 9, 2), CityName = "Алматы", AirCompany = "Air Astana", Terminal = "A", GateID = "A1", FlightStatus = FlightStatus.Arrived},
                new ArrivalFlight {FlightID = "PQ 7119", Time = new DateTime(1996, 9, 2), CityName = "Шарм-Эль-Шейх", AirCompany = "Sky Up Airlines", Terminal = "B", GateID = "A2", FlightStatus = FlightStatus.Canceled, Plane = planes[1]},
                //new ArrivalFlight {FlightID = "LO 8312", Time = new DateTime(1997, 9, 2), CityName = "Таллинн", AirCompany = "LOT Polish Airlines", Terminal = "C", GateID = "A3", FlightStatus = FlightStatus.ChekIn},
                //new ArrivalFlight {FlightID = "PS 5673", Time = new DateTime(1998, 9, 2), CityName = "Мюнхен", AirCompany = "Ukraine International Airlines", Terminal = "D", GateID = "B1", FlightStatus = FlightStatus.Delayed},
                //new ArrivalFlight {FlightID = "LH 2545", Time = new DateTime(1999, 9, 2), CityName = "Афины", AirCompany = "Lufthansa", Terminal = "A", GateID = "B2", FlightStatus = FlightStatus.DepartedAt},
                //new ArrivalFlight {FlightID = "LH 2544", Time = new DateTime(1985, 9, 2), CityName = "Франкфурт", AirCompany = "Air Astana", Terminal = "B", GateID = "B3", FlightStatus = FlightStatus.ExpectedAt},
                //new ArrivalFlight {FlightID = "QU 4440", Time = new DateTime(2000, 9, 2), CityName = "Цюрих", AirCompany = "LOT Polish Airlines", Terminal = "C", GateID = "C1", FlightStatus = FlightStatus.GateClosed},
                //new ArrivalFlight {FlightID = "PS 354", Time = new DateTime(2001, 9, 2), CityName = "Киев", AirCompany = "Azur Air Ukraine", Terminal = "D", GateID = "C2", FlightStatus = FlightStatus.InFlight},
                //new ArrivalFlight {FlightID = "LH 1494", Time = new DateTime(2002, 9, 2), CityName = "Минск", AirCompany = "Lufthansa", Terminal = "A", GateID = "D1", FlightStatus = FlightStatus.Unknown},
                //new ArrivalFlight {FlightID = "PS 472", Time = new DateTime(1999, 9, 2), CityName = "Брюсель", AirCompany = "Azur Air Ukraine", Terminal = "B", GateID = "D2", FlightStatus = FlightStatus.Arrived}
            };
            Context.ArrivalFlight.AddRange(arrivalFlights);

            var departurelFlights = new[]
{
                new DepartureFlight {FlightID = "11111", Time = new DateTime(1995, 9, 2), CityName = "Алматы", AirCompany = "Air Astana", Terminal = "A", GateID = "A1", FlightStatus = FlightStatus.Arrived, Plane = planes[0]},
                //new DepartureFlight {FlightID = "22222",  PlaneID = "AC", Time = new DateTime(1996, 9, 2), CityName = "Шарм-Эль-Шейх", AirCompany = "Sky Up Airlines", Terminal = "B", GateID = "A2", FlightStatus = FlightStatus.Canceled},
                //new DepartureFlight {FlightID = "33333", Time = new DateTime(1997, 9, 2), CityName = "Таллинн", AirCompany = "LOT Polish Airlines", Terminal = "C", GateID = "A3", FlightStatus = FlightStatus.ChekIn},
                //new DepartureFlight {FlightID = "44444", Time = new DateTime(1998, 9, 2), CityName = "Мюнхен", AirCompany = "Ukraine International Airlines", Terminal = "D", GateID = "B1", FlightStatus = FlightStatus.Delayed},
                //new DepartureFlight {FlightID = "55555", Time = new DateTime(1999, 9, 2), CityName = "Афины", AirCompany = "Lufthansa", Terminal = "A", GateID = "B2", FlightStatus = FlightStatus.DepartedAt},
                //new DepartureFlight {FlightID = "LH 2444", Time = new DateTime(1985, 9, 2), CityName = "Франкфурт", AirCompany = "Air Astana", Terminal = "B", GateID = "B3", FlightStatus = FlightStatus.ExpectedAt},
                //new DepartureFlight {FlightID = "QU 4441", Time = new DateTime(2000, 9, 2), CityName = "Цюрих", AirCompany = "LOT Polish Airlines", Terminal = "C", GateID = "C1", FlightStatus = FlightStatus.GateClosed},
                //new DepartureFlight {FlightID = "PS 355", Time = new DateTime(2001, 9, 2), CityName = "Киев", AirCompany = "Azur Air Ukraine", Terminal = "D", GateID = "C2", FlightStatus = FlightStatus.InFlight},
                //new DepartureFlight {FlightID = "LH 1495", Time = new DateTime(2002, 9, 2), CityName = "Минск", AirCompany = "Lufthansa", Terminal = "A", GateID = "D1", FlightStatus = FlightStatus.Unknown},
                //new DepartureFlight {FlightID = "PS 473", Time = new DateTime(1999, 9, 2), CityName = "Брюсель", AirCompany = "Azur Air Ukraine", Terminal = "B", GateID = "D2", FlightStatus = FlightStatus.Arrived}
            };

            




            Context.DepartureFlight.AddRange(departurelFlights);

            Context.SaveChanges();
            IsRebuid = false; // сбрасываем флаг
        }
    }
}
