using EventsAPI.Models;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Diagnostics;
using System.Diagnostics.Metrics;

namespace EventsAPI
{
    public class EventsDbContext : DbContext 
    {
        public DbSet<Events> Events { get; set; }

        public EventsDbContext()
        {
        }

        public EventsDbContext(DbContextOptions<EventsDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=EventsDB;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Events Table
            modelBuilder.Entity<Events>(c =>
            {
                c.HasKey(e => e.id);
                c.Property(e => e.id).ValueGeneratedOnAdd();
                c.Property(e => e.title);
                c.Property(e => e.EventDate);
                c.Property(e => e.description);
                c.Property(e => e.notes);
            });

        }

    }
}
