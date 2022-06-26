using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistance.Mapping
{
    public class ShopListMap : IEntityTypeConfiguration<ShopList>
    {
        public void Configure(EntityTypeBuilder<ShopList> builder)
        {
            builder.Property(p=>p.IsCompleted).IsRequired().HasDefaultValue(false);
            builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Description).IsRequired().HasMaxLength(400);
            builder.Property(p => p.Type).IsRequired().HasMaxLength(200);

            //User Fk
        }
    }
}
