using Application.CQS.ShopListR.Commands.AddShopList;
using Application.CQS.ShopListR.Commands.AddShopListAdmin;
using Application.CQS.ShopListR.Commands.RemoveShopList;
using Application.CQS.ShopListR.Commands.UpdateShopList;
using Application.DTOs;
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
            //Commands
            CreateMap<AddShopListCommandRequest, ShopList>().ReverseMap();
            CreateMap<AddShopListAdminCommandRequest, ShopList>().ReverseMap();
            CreateMap<RemoveShopListCommandRequest, ShopList>().ReverseMap();
            CreateMap<UpdateShopListCommandRequest, ShopList>().ReverseMap();
            //Queries
            CreateMap<ShopList, ShopListDto>().ReverseMap();

        }
    }
}
