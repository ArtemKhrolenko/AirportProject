using AirportPrj.Model;
using System;
using System.Data.Entity.Validation;
using System.Windows;

namespace AirportPrj.DataBase
{
    // Статический класс начальной инициализации БД
    public static class InitDB
    {
        public static bool IsRebuid;

        internal static void Fill(AirportContext Context)
        {
            #region Инициализация типов авиасуден
            var planes = new[]
{
                new Plane {PlaneID = "00001", FlightID = "empty", Manufacturer = "Boeing", Model = "737", BusinessSeatsNumbers = 10, FirstClassSeatsNumbers = 20, TotalSeatsNumbers = 144},
                new Plane {PlaneID = "00002", FlightID = "empty", Manufacturer = "AirBus", Model = "A380", BusinessSeatsNumbers = 5, FirstClassSeatsNumbers = 15, TotalSeatsNumbers = 150}
            };
            Context.Planes.AddRange(planes);
            #endregion


            #region Инициализация авиасообщений
            ArrivalFlight[] arrivalFlights = new ArrivalFlight[]
            {
                new ArrivalFlight("KC 406") {FlightID = "KC 406", Time = new DateTime(1995, 9, 2), CityName = "Алматы", AirCompany = "Air Astana", Terminal = "A", GateID = "A1", FlightStatus = FlightStatus.Arrived, PlaneID = "00001"},
                new ArrivalFlight("PQ 7119") {FlightID = "PQ 7119", Time = new DateTime(1996, 9, 2), CityName = "Шарм-Эль-Шейх", AirCompany = "Sky Up Airlines", Terminal = "B", GateID = "A2", FlightStatus = FlightStatus.Canceled, PlaneID = "00002"},
                new ArrivalFlight("LO 8312") {FlightID = "LO 8312", Time = new DateTime(1997, 9, 2), CityName = "Таллинн", AirCompany = "LOT Polish Airlines", Terminal = "C", GateID = "A3", FlightStatus = FlightStatus.ChekIn, PlaneID = "00001"},
                new ArrivalFlight("PS 5673") {FlightID = "PS 5673", Time = new DateTime(1998, 9, 2), CityName = "Мюнхен", AirCompany = "Ukraine International Airlines", Terminal = "D", GateID = "B1", FlightStatus = FlightStatus.Delayed, PlaneID = "00002"},
                new ArrivalFlight("LH 2545") {FlightID = "LH 2545", Time = new DateTime(1999, 9, 2), CityName = "Афины", AirCompany = "Lufthansa", Terminal = "A", GateID = "B2", FlightStatus = FlightStatus.DepartedAt, PlaneID = "00001"},
                new ArrivalFlight("LH 2544") {FlightID = "LH 2544", Time = new DateTime(1985, 9, 2), CityName = "Франкфурт", AirCompany = "Air Astana", Terminal = "B", GateID = "B3", FlightStatus = FlightStatus.ExpectedAt, PlaneID = "00002"},
                new ArrivalFlight("QU 4440") {FlightID = "QU 4440", Time = new DateTime(2000, 9, 2), CityName = "Цюрих", AirCompany = "LOT Polish Airlines", Terminal = "C", GateID = "C1", FlightStatus = FlightStatus.GateClosed, PlaneID = "00001"},
                new ArrivalFlight("PS 354") {FlightID = "PS 354", Time = new DateTime(2001, 9, 2), CityName = "Киев", AirCompany = "Azur Air Ukraine", Terminal = "D", GateID = "C2", FlightStatus = FlightStatus.InFlight, PlaneID = "00002"},
                new ArrivalFlight("LH 1494") {FlightID = "LH 1494", Time = new DateTime(2002, 9, 2), CityName = "Минск", AirCompany = "Lufthansa", Terminal = "A", GateID = "D1", FlightStatus = FlightStatus.Unknown, PlaneID = "00001"},
            };
            Context.ArrivalFlight.AddRange(arrivalFlights);

            var departurelFlights = new[]
{
                new DepartureFlight("KC 407") {FlightID = "KC 407", Time = new DateTime(1995, 9, 2), CityName = "Алматы", AirCompany = "Air Astana", Terminal = "A", GateID = "A1", FlightStatus = FlightStatus.Arrived, PlaneID = "00001"},
                new DepartureFlight("PQ 7120") {FlightID = "PQ 7120", Time = new DateTime(1996, 9, 2), CityName = "Шарм-Эль-Шейх", AirCompany = "Sky Up Airlines", Terminal = "B", GateID = "A2", FlightStatus = FlightStatus.Canceled, PlaneID = "00002"},
                new DepartureFlight("LO 8313") {FlightID = "LO 8313", Time = new DateTime(1997, 9, 2), CityName = "Таллинн", AirCompany = "LOT Polish Airlines", Terminal = "C", GateID = "A3", FlightStatus = FlightStatus.ChekIn, PlaneID = "00001"},
                new DepartureFlight("PS 5674") {FlightID = "PS 5674", Time = new DateTime(1998, 9, 2), CityName = "Мюнхен", AirCompany = "Ukraine International Airlines", Terminal = "D", GateID = "B1", FlightStatus = FlightStatus.Delayed, PlaneID = "00002"},
                new DepartureFlight("LH 2445") {FlightID = "LH 2445", Time = new DateTime(1999, 9, 2), CityName = "Афины", AirCompany = "Lufthansa", Terminal = "A", GateID = "B2", FlightStatus = FlightStatus.DepartedAt, PlaneID = "00001"},
                new DepartureFlight("LH 2444") {FlightID = "LH 2444", Time = new DateTime(1985, 9, 2), CityName = "Франкфурт", AirCompany = "Air Astana", Terminal = "B", GateID = "B3", FlightStatus = FlightStatus.ExpectedAt, PlaneID = "00002"},
                new DepartureFlight("QU 4441") {FlightID = "QU 4441", Time = new DateTime(2000, 9, 2), CityName = "Цюрих", AirCompany = "LOT Polish Airlines", Terminal = "C", GateID = "C1", FlightStatus = FlightStatus.GateClosed, PlaneID = "00001"},
                new DepartureFlight("PS 355") {FlightID = "PS 355", Time = new DateTime(2001, 9, 2), CityName = "Киев", AirCompany = "Azur Air Ukraine", Terminal = "D", GateID = "C2", FlightStatus = FlightStatus.InFlight, PlaneID = "00002"},
                new DepartureFlight("LH 1495") {FlightID = "LH 1495", Time = new DateTime(2002, 9, 2), CityName = "Минск", AirCompany = "Lufthansa", Terminal = "A", GateID = "D1", FlightStatus = FlightStatus.Unknown, PlaneID = "00001"},
                new DepartureFlight("PS 473") {FlightID = "PS 473", Time = new DateTime(1999, 9, 2), CityName = "Брюсель", AirCompany = "Azur Air Ukraine", Terminal = "B", GateID = "D2", FlightStatus = FlightStatus.Arrived, PlaneID = "00002"}
            };
            Context.DepartureFlight.AddRange(departurelFlights);
            #endregion

            #region Инициализация билетов
            var tickets = new[]
{
                new Ticket {TicketNumb = "01001", Price = 34.8M},
                new Ticket {TicketNumb = "01002", Price = 44.1M},
                new Ticket {TicketNumb = "01003", Price = 22.5M},
                new Ticket {TicketNumb = "01004", Price = 13.0M},
                new Ticket {TicketNumb = "01005", Price = 67.9M},
                new Ticket {TicketNumb = "01006", Price = 47.5M},
                new Ticket {TicketNumb = "01007", Price = 25.6M},
                new Ticket {TicketNumb = "01008", Price = 36.7M},
                new Ticket {TicketNumb = "01009", Price = 47.8M},
                new Ticket {TicketNumb = "01010", Price = 58.9M}
            };
            Context.Tickets.AddRange(tickets);
            #endregion

            #region Инициализация пасажиров
            var passengers = new[]
            {
                new Passenger {FirstName = "Mohammed", LastName = "Woodham", Nationality = "Afghan", Passport = "CH 123456", DateOfBirth = new DateTime(1995, 9, 2), Sex = Sex.Male, PassClass = PassClass.Business, FlightID = "KC 406", TicketNumb = "01001"},
                new Passenger {FirstName = "Porter", LastName = "Hilger", Nationality = "Belgian", Passport = "QW 132447", DateOfBirth = new DateTime(1996, 9, 2), Sex = Sex.Male, PassClass = PassClass.Economy, FlightID = "KC 406", TicketNumb = "01002"},
                new Passenger {FirstName = "Chad", LastName = "Heyer", Nationality = "Brazilian", Passport = "DF 345678", DateOfBirth = new DateTime(1997, 9, 2), Sex = Sex.Male, PassClass = PassClass.Business, FlightID = "KC 406", TicketNumb = "01003"},
                new Passenger {FirstName = "Fidel", LastName = "Dorsey", Nationality = "Chinese", Passport = "JK 135286", DateOfBirth = new DateTime(1998, 9, 2), Sex = Sex.Male, PassClass = PassClass.Economy, FlightID = "KC 406", TicketNumb = "01004"},
                new Passenger {FirstName = "Faustino", LastName = "Sweatt", Nationality = "Cuban", Passport = "PQ 102938", DateOfBirth = new DateTime(1999, 9, 2), Sex = Sex.Male, PassClass = PassClass.Business, FlightID = "KC 406", TicketNumb = "01005"},

                new Passenger {FirstName = "Alexandra", LastName = "Barrientez", Nationality = "Ethiopian", Passport = "AS 416587", DateOfBirth = new DateTime(1985, 9, 2), Sex = Sex.Female, PassClass = PassClass.Economy, FlightID = "KC 406", TicketNumb = "01006"},
                new Passenger {FirstName = "Bari", LastName = "Lazar", Nationality = "Iranian", Passport = "DG 764556", DateOfBirth = new DateTime(2000, 9, 2), Sex = Sex.Female, PassClass = PassClass.Business, FlightID = "KC 406", TicketNumb = "01007"},
                new Passenger {FirstName = "Awilda", LastName = "Marson", Nationality = "Nambian", Passport = "JH 653076", DateOfBirth = new DateTime(2001, 9, 2), Sex = Sex.Female, PassClass = PassClass.Economy, FlightID = "KC 406", TicketNumb = "01008"},
                new Passenger {FirstName = "Patrica", LastName = "Blackledge", Nationality = "Serbian", Passport = "MN 852700", DateOfBirth = new DateTime(2002, 9, 2), Sex = Sex.Female, PassClass = PassClass.Business, FlightID = "KC 406", TicketNumb = "01009"},
                new Passenger {FirstName = "Ellie", LastName = "Baumer", Nationality = "Ukranian", Passport = "CX 336629", DateOfBirth = new DateTime(1999, 9, 2), Sex = Sex.Female, PassClass = PassClass.Economy, FlightID = "KC 406", TicketNumb = "01010"}
            };
            Context.Passengers.AddRange(passengers);
            #endregion

            // отлавливаем ошибку сохранения в БД
            try
            {
                Context.SaveChanges(); // сохраняем все изменения в БД
            }
            catch (DbEntityValidationException ex)
            {
                string lg = "";
                foreach (DbEntityValidationResult validationError in ex.EntityValidationErrors)
                {
                    lg = "Object: " + validationError.Entry.Entity.ToString();
                    lg += " ";
                        foreach (DbValidationError err in validationError.ValidationErrors)
                        {
                            lg += err.ErrorMessage + "";
                        }
                }
                MessageBox.Show(lg);
            }
            IsRebuid = false;       // сбрасываем флаг - пока не используется
        }
    }
}
