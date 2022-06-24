using Application.CQS.ShopListR.Commands.AddProductToShopList;
using Application.CQS.ShopListR.Commands.RemoveProductFromShopList;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mapping
{
    public class ProductShopListProfile:Profile
    {
        public ProductShopListProfile()
        {
            CreateMap<AddProductToShopListCommandRequest,ProductShopList>().ReverseMap();
            CreateMap<RemoveProductFromShopListCommandRequest,ProductShopList>().ReverseMap();
        }
    }
}
