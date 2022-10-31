using AM.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Infrastructure.Configurations
{
    internal class PassengerConfiguration: IEntityTypeConfiguration<Passenger>
    {
       public void Configure(EntityTypeBuilder<Passenger> builder)
        {
            builder.OwnsOne(p => p.FullName, s => {
                s.Property(f => f.FirstName).HasColumnName("PssFirstName").HasMaxLength(30);
                s.Property(l => l.LastName).HasColumnName("PassLastName").IsRequired();
            });

            //builder.HasDiscriminator<string>("IsTraveller").HasValue<Passenger>("0").HasValue<Traveller>("1").HasValue<Staff>("2");
        }
    }
}
