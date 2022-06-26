using Application.CQS.CategoryR.Commands.AddCategory;
using Application.CQS.CategoryR.Commands.RemoveCategory;
using Application.CQS.CategoryR.Commands.UpdateCategory;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mapping
{
    public class CategoryProfile:Profile
    {
        public CategoryProfile()
        {
            CreateMap<AddCategoryCommandRequest, Category>().ReverseMap();
            CreateMap<UpdateCategoryCommandRequest, Category>().ReverseMap();
            CreateMap<RemoveCategoryCommandRequest, Category>().ReverseMap();
        }
    }
}
