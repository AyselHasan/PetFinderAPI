using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetFinder.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetFinder.Data.Configurations
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(25);
            builder.Property(x => x.Surname).HasMaxLength(25);
            builder.Property(x => x.Email).HasMaxLength(100);
            builder.Property(x => x.UserName).HasMaxLength(25);
            builder.Property(x => x.IsCreated).HasDefaultValue(DateTime.UtcNow.AddHours(4));
            builder.Property(x => x.IsModified).HasDefaultValue(DateTime.UtcNow.AddHours(4));

        }
    }
}

