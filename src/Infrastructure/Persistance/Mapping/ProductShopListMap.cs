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
    public class ProductShopListMap : IEntityTypeConfiguration<ProductShopList>
    {
        public void Configure(EntityTypeBuilder<ProductShopList> builder)
        {
            throw new NotImplementedException();
        }
    }
}
