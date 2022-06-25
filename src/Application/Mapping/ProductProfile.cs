using Application.Common.Models;
using Application.CQS.ProductR.Commands.AddProduct;
using Application.CQS.ProductR.Commands.RemoveProduct;
using Application.CQS.ProductR.Commands.UpdateProduct;
using Application.CQS.ProductR.Queries;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mapping
{
    public class ProductProfile:Profile
    {
        public ProductProfile()
        {
            //Command
            CreateMap<AddProductCommandRequest, Product>().ReverseMap();
            CreateMap<RemoveProductCommandRequest,Product>().ReverseMap(); 
            CreateMap<UpdateProductCommandRequest, Product>().ReverseMap();
            //Query
            CreateMap<Product,GetAllProductsQueryResponse>().ReverseMap();
        }
    }
}
