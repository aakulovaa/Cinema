using Cinema.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection.Emit;
using System.Web;

namespace Cinema.DAL
{
    public class CinemaContext : DbContext
    {
        public CinemaContext() : base("CinemaContext")
        {
        }

        public DbSet<CashRegister> CashRegisters { get; set; } 
        public DbSet<Hall> Halls { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<People> Peoples { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<TicketSold> TicketSolds { get; set; }

        protected override void OnModelCreating(DbModelBuilder optionsBuilder)
        {
            //// CashRegister has many TicketSolds
            ///
            //optionsBuilder.Entity<CashRegister>()
            //.HasMany(cr => cr.TicketSolds)
            //.WithRequired(ts => ts.CashRegister)
            //.HasForeignKey(ts => ts.CashRegisterId)
            //.WillCascadeOnDelete(true);

            optionsBuilder.Entity<TicketSold>()
           .HasRequired(s => s.CashRegister)
           .WithMany(m => m.TicketSolds)
           .HasForeignKey(s => s.CashRegisterId)
           .WillCascadeOnDelete(true);


            // Session has one Movie
            optionsBuilder.Entity<Session>()
            .HasRequired(s => s.Movie)
            .WithMany(m => m.Sessions)
            .HasForeignKey(s => s.MovieId)
            .WillCascadeOnDelete(true);


            // Session has one Hall
            optionsBuilder.Entity<Session>()
            .HasRequired(s => s.Hall)
            .WithMany(h => h.Sessions)
            .HasForeignKey(s => s.HallId)
            .WillCascadeOnDelete(true);


            // Session has many TicketSolds

            //optionsBuilder.Entity<Session>()
            //.HasMany(s => s.TicketSolds)
            //.WithRequired(ts => ts.Session)
            //.HasForeignKey(ts => ts.SessionId)
            //.WillCascadeOnDelete(true);

            optionsBuilder.Entity<TicketSold>()
           .HasRequired(s => s.Session)
           .WithMany(m => m.TicketSolds)
           .HasForeignKey(s => s.SessionId)
           .WillCascadeOnDelete(true);


            // Session has many Peoples

            optionsBuilder.Entity<Session>()
                .HasMany<People>(s => s.Peoples)
                .WithMany(s => s.Sessions)
                .Map(cs =>
                {
                    cs.MapLeftKey("SessionId");
                    cs.MapRightKey("PeopleId");
                    cs.ToTable("PeopleSession");
                });


            // TicketSold has one People
            optionsBuilder.Entity<TicketSold>()
            .HasRequired(ts => ts.People)
            .WithRequiredPrincipal(p => p.TicketSold);
        }
    }

}