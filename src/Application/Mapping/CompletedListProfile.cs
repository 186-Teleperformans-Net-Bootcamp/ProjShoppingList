using Application.CQS.ShopListR.Commands.AddShopListAdmin;
using AutoMapper;
using Domain.Entities.AdminEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mapping
{
    public class CompletedListProfile : Profile
    {
        public CompletedListProfile()
        {
            CreateMap<AddShopListAdminCommandRequest, CompletedList>().ReverseMap();
        }
    }
}
