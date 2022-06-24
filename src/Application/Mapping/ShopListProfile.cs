using Application.CQS.ShopListR.Commands.AddShopList;
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
    public class ShopListProfile : Profile
    {
        public ShopListProfile()
        {
            CreateMap<AddShopListCommandRequest, ShopList>().ReverseMap();
        }
    }
}
