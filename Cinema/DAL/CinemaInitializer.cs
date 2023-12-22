using Cinema.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cinema.DAL
{
    public class CinemaInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<CinemaContext>
    {
        protected override void Seed(CinemaContext context)
        {
            var movies = new List<Movie>
            {
                new Movie { MovieName = "Seven Psychopats", YearRelease = 2012, Director = "Martin McDonagh" },
                new Movie { MovieName = "Desperation Road", YearRelease = 2023, Director = "Nadine Crocker" },
                new Movie { MovieName = "Дух Байкала", YearRelease = 2023, Director = "Андрей Кравчук" },
                new Movie { MovieName = "Императрицы", YearRelease = 2023, Director = "Михаил Расходников" },
                new Movie { MovieName = "Accuseds", YearRelease = 2023, Director = "Phil Barantini" },
            };
            movies.ForEach(s => context.Movies.Add(s));
            context.SaveChanges();
            var cashRegisters = new List<CashRegister>
            {
                new CashRegister { StartWorking = new DateTime(2023,12,23,08, 00, 00), EndWorking = new DateTime(2023, 12, 23, 22, 00, 00), Employee = "Patricia Jensen" },
                new CashRegister { StartWorking = new DateTime(2023, 12, 23, 10, 00, 00), EndWorking = new DateTime(2023, 12, 23, 20, 00, 00), Employee = "Stephanie Barnes" },
                new CashRegister { StartWorking = new DateTime(2023, 12, 23, 12, 00, 00), EndWorking = new DateTime(2023, 12, 23, 23, 00, 00), Employee =  "Walter Garcia" },
                new CashRegister { StartWorking = new DateTime(2023, 12, 23, 11, 00, 00), EndWorking = new DateTime(2023, 12, 23, 22, 00, 00), Employee = "Ann Love" },
                new CashRegister { StartWorking = new DateTime(2023, 12, 23, 09, 00, 00), EndWorking = new DateTime(2023, 12, 23, 21, 00, 00), Employee = "Pauline Harris" },

            };
            cashRegisters.ForEach(s => context.CashRegisters.Add(s));
            context.SaveChanges();
            var halls = new List<Hall>
            {
                new Hall { Amount = 500, ScreenSize = 88, HallSize = 450 },
                new Hall { Amount = 200, ScreenSize = 60, HallSize = 370 },
                new Hall { Amount = 130, ScreenSize = 40, HallSize = 230 },
                new Hall { Amount = 350, ScreenSize = 70, HallSize = 400 },
                new Hall { Amount = 140, ScreenSize = 20, HallSize = 100 },

            };
            halls.ForEach(s => context.Halls.Add(s));
            context.SaveChanges();
            var sessions = new List<Session>
            {
                new Session { StartDateTime = new DateTime(2023, 11, 06, 12, 00, 00), MovieId = 2, HallId = 1 },
                new Session { StartDateTime = new DateTime(2023, 11, 06, 15, 00, 00), MovieId = 1, HallId = 4 },
                new Session { StartDateTime = new DateTime(2023, 11, 06, 15, 00, 00), MovieId = 3, HallId = 3 },
                new Session { StartDateTime =  new DateTime(2023, 11, 06, 20, 00, 00), MovieId = 5, HallId = 4 },
                new Session { StartDateTime =  new DateTime(2023, 11, 06, 21, 00, 00), MovieId = 4, HallId = 1 },

            };
            sessions.ForEach(s => context.Sessions.Add(s));
            context.SaveChanges();
            var ticketSolds = new List<TicketSold>
            {
                new TicketSold { SessionId = 1, PeopleId = 1, Cost = 730, PlaceNumber = 13, CashRegisterId = 2 },
                new TicketSold { SessionId = 2, PeopleId = 2, Cost = 450, PlaceNumber = 18, CashRegisterId = 1 },
                new TicketSold { SessionId = 3, PeopleId = 3, Cost = 450, PlaceNumber = 17, CashRegisterId = 1 },
                new TicketSold { SessionId = 4, PeopleId = 4, Cost = 1100, PlaceNumber = 56, CashRegisterId = 5 },
                new TicketSold { SessionId = 5, PeopleId = 5, Cost = 780, PlaceNumber = 22, CashRegisterId = 3 },

            };
            ticketSolds.ForEach(s => context.TicketSolds.Add(s));
            context.SaveChanges();
            var peoples = new List<People>
            {
                new People { FirstName = "Даниил", LastName = "Николаев" },
                new People { FirstName ="Кирилл", LastName = "Громов" },
                new People { FirstName = "Амина", LastName = "Смирнова" },
                new People { FirstName = "Ксения", LastName = "Рябинина" },
                new People { FirstName = "Роман", LastName = "Маслов" },

            };
            peoples.ForEach(s => context.Peoples.Add(s));
            context.SaveChanges();
            
        }
    }
}