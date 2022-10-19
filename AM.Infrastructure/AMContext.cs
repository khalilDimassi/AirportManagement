using AM.ApplicationCore.Domain;
using EntityFramework.Exceptions.SqlServer;
using Microsoft.EntityFrameworkCore;

namespace AM.Infrastucture
{
    internal class AMContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source = (localdb)\mssqllocaldb; 
                                          Initial Catalog  = AirportManagementDB;
                                          Integrated Security = true;");
            optionsBuilder.UseExceptionProcessor();
            base.OnConfiguring(optionsBuilder);
        }

        public int Myprop { get; set; }
        public DbSet<Plane> SetDbPlane { get; set; }
        public DbSet<Flight> SetDbFlight { get; set; }
        public DbSet<Passenger> SetDbPassenger { get; set; }
        public DbSet<Staff> SetDbStaff { get; set; }
        public DbSet<Traveller> SetDbTraveller { get; set; }

    }
}
