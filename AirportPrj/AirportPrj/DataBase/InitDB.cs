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
                new Plane {PlaneID = "00001", FlightID = "empty", Manufacturer = "Boeing", Model = "737", BusinessSeatsNumbers = 10, FirstClassSeatsNumbers = 20, TotalSeatsNumbers = 100},
                new Plane {PlaneID = "00002", FlightID = "empty", Manufacturer = "AirBus", Model = "A380", BusinessSeatsNumbers = 5, FirstClassSeatsNumbers = 15, TotalSeatsNumbers = 150}
            };
            Context.Planes.AddRange(planes);
            #endregion

            #region Инициализация пасажиров
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
            #endregion

            #region Инициализация билетов
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
            #endregion

            #region Инициализация авиасообщений
            ArrivalFlight[] arrivalFlights = new ArrivalFlight[]
            {
                new ArrivalFlight("KC 406") {FlightID = "KC 406", Time = new DateTime(1995, 9, 2), CityName = "Алматы", AirCompany = "Air Astana", Terminal = "A", GateID = "A1", FlightStatus = FlightStatus.Arrived, Plane = planes[0]},
                new ArrivalFlight("PQ 7119") {FlightID = "PQ 7119", Time = new DateTime(1996, 9, 2), CityName = "Шарм-Эль-Шейх", AirCompany = "Sky Up Airlines", Terminal = "B", GateID = "A2", FlightStatus = FlightStatus.Canceled, Plane = planes[1]},
                new ArrivalFlight("LO 8312") {FlightID = "LO 8312", Time = new DateTime(1997, 9, 2), CityName = "Таллинн", AirCompany = "LOT Polish Airlines", Terminal = "C", GateID = "A3", FlightStatus = FlightStatus.ChekIn, Plane = planes[0]},
                new ArrivalFlight("PS 5673") {FlightID = "PS 5673", Time = new DateTime(1998, 9, 2), CityName = "Мюнхен", AirCompany = "Ukraine International Airlines", Terminal = "D", GateID = "B1", FlightStatus = FlightStatus.Delayed, Plane = planes[1]},
                new ArrivalFlight("LH 2545") {FlightID = "LH 2545", Time = new DateTime(1999, 9, 2), CityName = "Афины", AirCompany = "Lufthansa", Terminal = "A", GateID = "B2", FlightStatus = FlightStatus.DepartedAt, Plane = planes[0]},
                new ArrivalFlight("LH 2544") {FlightID = "LH 2544", Time = new DateTime(1985, 9, 2), CityName = "Франкфурт", AirCompany = "Air Astana", Terminal = "B", GateID = "B3", FlightStatus = FlightStatus.ExpectedAt, Plane = planes[1]},
                new ArrivalFlight("QU 4440") {FlightID = "QU 4440", Time = new DateTime(2000, 9, 2), CityName = "Цюрих", AirCompany = "LOT Polish Airlines", Terminal = "C", GateID = "C1", FlightStatus = FlightStatus.GateClosed, Plane = planes[0]},
                new ArrivalFlight("PS 354") {FlightID = "PS 354", Time = new DateTime(2001, 9, 2), CityName = "Киев", AirCompany = "Azur Air Ukraine", Terminal = "D", GateID = "C2", FlightStatus = FlightStatus.InFlight, Plane = planes[1]},
                new ArrivalFlight("LH 1494") {FlightID = "LH 1494", Time = new DateTime(2002, 9, 2), CityName = "Минск", AirCompany = "Lufthansa", Terminal = "A", GateID = "D1", FlightStatus = FlightStatus.Unknown, Plane = planes[0]},
                new ArrivalFlight("PS 472") {FlightID = "PS 472", Time = new DateTime(1999, 9, 2), CityName = "Брюсель", AirCompany = "Azur Air Ukraine", Terminal = "B", GateID = "D2", FlightStatus = FlightStatus.Arrived, Plane = planes[1]}
            };
            Context.ArrivalFlight.AddRange(arrivalFlights);

            var departurelFlights = new[]
{
                new DepartureFlight("KC 407") {FlightID = "KC 407", Time = new DateTime(1995, 9, 2), CityName = "Алматы", AirCompany = "Air Astana", Terminal = "A", GateID = "A1", FlightStatus = FlightStatus.Arrived, Plane = planes[1]},
                new DepartureFlight("PQ 7120") {FlightID = "PQ 7120", Time = new DateTime(1996, 9, 2), CityName = "Шарм-Эль-Шейх", AirCompany = "Sky Up Airlines", Terminal = "B", GateID = "A2", FlightStatus = FlightStatus.Canceled, Plane = planes[0]},
                new DepartureFlight("LO 8313") {FlightID = "LO 8313", Time = new DateTime(1997, 9, 2), CityName = "Таллинн", AirCompany = "LOT Polish Airlines", Terminal = "C", GateID = "A3", FlightStatus = FlightStatus.ChekIn, Plane = planes[1]},
                new DepartureFlight("PS 5674") {FlightID = "PS 5674", Time = new DateTime(1998, 9, 2), CityName = "Мюнхен", AirCompany = "Ukraine International Airlines", Terminal = "D", GateID = "B1", FlightStatus = FlightStatus.Delayed, Plane = planes[0]},
                new DepartureFlight("LH 2445") {FlightID = "LH 2445", Time = new DateTime(1999, 9, 2), CityName = "Афины", AirCompany = "Lufthansa", Terminal = "A", GateID = "B2", FlightStatus = FlightStatus.DepartedAt, Plane = planes[1]},
                new DepartureFlight("LH 2444") {FlightID = "LH 2444", Time = new DateTime(1985, 9, 2), CityName = "Франкфурт", AirCompany = "Air Astana", Terminal = "B", GateID = "B3", FlightStatus = FlightStatus.ExpectedAt, Plane = planes[0]},
                new DepartureFlight("QU 4441") {FlightID = "QU 4441", Time = new DateTime(2000, 9, 2), CityName = "Цюрих", AirCompany = "LOT Polish Airlines", Terminal = "C", GateID = "C1", FlightStatus = FlightStatus.GateClosed, Plane = planes[1]},
                new DepartureFlight("PS 355") {FlightID = "PS 355", Time = new DateTime(2001, 9, 2), CityName = "Киев", AirCompany = "Azur Air Ukraine", Terminal = "D", GateID = "C2", FlightStatus = FlightStatus.InFlight, Plane = planes[0]},
                new DepartureFlight("LH 1495") {FlightID = "LH 1495", Time = new DateTime(2002, 9, 2), CityName = "Минск", AirCompany = "Lufthansa", Terminal = "A", GateID = "D1", FlightStatus = FlightStatus.Unknown, Plane = planes[1]},
                new DepartureFlight("PS 473") {FlightID = "PS 473", Time = new DateTime(1999, 9, 2), CityName = "Брюсель", AirCompany = "Azur Air Ukraine", Terminal = "B", GateID = "D2", FlightStatus = FlightStatus.Arrived, Plane = planes[0]}
            };
            Context.DepartureFlight.AddRange(departurelFlights);
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




            //Context.SaveChanges();  // сохраняем все изменения в БД
            IsRebuid = false;       // сбрасываем флаг - пока не используется
        }
    }
}
