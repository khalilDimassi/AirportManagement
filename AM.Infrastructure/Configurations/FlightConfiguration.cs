using AM.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace AM.Infrastructure.Configurations
{
    public class FlightConfiguration : IEntityTypeConfiguration<Flight>
    {
        public void Configure(EntityTypeBuilder<Flight> builder)
        {
            builder.HasMany(f => f.Passengers)
                   .WithMany(p => p.Flights)
                   .UsingEntity(pf => pf.ToTable("Reservation"));

            builder.HasOne(f => f.Plane)
                   .WithMany(p => p.Flights)
                   .HasForeignKey(f => f.PlaneId)
                   .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
