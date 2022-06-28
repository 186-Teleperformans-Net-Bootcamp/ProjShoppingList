using Application.CQS.ShopListR.Commands.AddShopList;
using Application.CQS.ShopListR.Commands.RemoveShopList;
using Application.CQS.ShopListR.Commands.UpdateShopList;
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
            CreateMap<RemoveShopListCommandRequest, ShopList>().ReverseMap();
            CreateMap<UpdateShopListCommandRequest, ShopList>().ReverseMap();
            //Queries
        }
    }
}
