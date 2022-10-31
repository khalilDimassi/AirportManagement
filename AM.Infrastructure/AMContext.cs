using AM.ApplicationCore.Domain;
using AM.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;

namespace AM.Infrastructure
{
    public class AMContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;
                                        Initial Catalog=AirportManagementDB;
                                        Integrated Security=true");
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<Plane> Planes { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<Traveller> Travellers { get; set; }
        public DbSet<Staff> Staff { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.ApplyConfiguration(new PlaneConfiguration());
            mb.ApplyConfiguration(new FlightConfiguration());
            mb.ApplyConfiguration(new PassengerConfiguration());
            mb.ApplyConfiguration(new ticketConfiguration());

            mb.Entity<Staff>().ToTable("Staff");
            mb.Entity<Traveller>().ToTable("Traveller");
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder mcb)
        {
            mcb.Properties<DateTime>().HaveColumnType("date");
        }
    }
}
