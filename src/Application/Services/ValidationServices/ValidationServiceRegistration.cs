using Application.CQS.CategoryR.Commands.AddCategory;
using Application.CQS.CategoryR.Commands.UpdateCategory;
using Application.CQS.ProductR.Commands.AddProductToShopList;
using Application.CQS.ProductR.Commands.BuyAllProducts;
using Application.CQS.ProductR.Commands.BuyProduct;
using Application.CQS.ProductR.Commands.RemoveProduct;
using Application.CQS.ProductR.Commands.UpdateProduct;
using Application.CQS.ShopListR.Commands.AddShopList;
using Application.CQS.ShopListR.Commands.CompleteShopList;
using Application.CQS.ShopListR.Commands.RemoveShopList;
using Application.CQS.ShopListR.Commands.UpdateShopList;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.ValidationServices
{
    public static class ValidationServiceRegistration
    {
        public static void AddValidationServices(this IServiceCollection services)
        {
            services.AddControllers().AddFluentValidation();
            services.AddTransient<IValidator<AddCategoryCommandRequest>, AddCategoryCommandValidator>();
            services.AddTransient<IValidator<UpdateCategoryCommandRequest>, UpdateCategoryCommandValidator>();
            services.AddTransient<IValidator<AddProductToShopListCommandRequest>, AddProductToShopListCommandValidator>();
            services.AddTransient<IValidator<AddProductToShopListCommandRequest>, AddProductToShopListCommandValidator>();
            services.AddTransient<IValidator<BuyAllProductsCommandRequest>, BuyAllProductsCommandValidator>();
            services.AddTransient<IValidator<BuyProductCommandRequest>, BuyProductCommandValidator>();
            services.AddTransient<IValidator<SoftRemoveProductCommandRequest>, SoftRemoveProductCommandValidator>();
            services.AddTransient<IValidator<UpdateProductCommandRequest>, UpdateProductCommandValidator>();
            services.AddTransient<IValidator<AddShopListCommandRequest>, AddShopListCommandValidator>();
            services.AddTransient<IValidator<CompleteShopListCommandRequest>, CompleteShopListCommandValidator>();
            services.AddTransient<IValidator<RemoveShopListCommandRequest>, RemoveShopListCommandValidator>();
            services.AddTransient<IValidator<UpdateShopListCommandRequest>, UpdateShopListCommandValidator>();
        }
    }
}
