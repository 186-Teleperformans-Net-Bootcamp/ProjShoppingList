﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Repositories.ShopListRepo
{
    public interface IShopListWriteRepository : IWriteRepository<ShopList>
    {
        bool AddProductToListAsync(string id,Product product);
        bool AddRangeProductToListAsync(string id,List<Product> products);
    }
}
