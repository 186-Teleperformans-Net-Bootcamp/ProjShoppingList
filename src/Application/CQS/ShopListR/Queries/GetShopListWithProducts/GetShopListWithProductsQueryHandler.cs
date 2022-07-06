using Application.Common.Interfaces;
using Application.DTOs;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQS.ShopListR.Queries.GetShopListWithProducts
{
    public class GetShopListWithProductsQueryHandler : IRequestHandler<GetShopListWithProductsQueryRequest, GetShopListWithProductsQueryResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetShopListWithProductsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<GetShopListWithProductsQueryResponse> Handle(GetShopListWithProductsQueryRequest request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.ShopListReadRepository.GetAllWithProductsAsync(predicate: s => s.Id == request.ShopListId, includeProperties: s => s.Products);
            IList<ProductDto> productList = new List<ProductDto>();
            foreach (var product in result.Products)
            {
                var productDto = _mapper.Map<ProductDto>(product);
                productList.Add(productDto);
            }
            if (result != null)
            {
                return new GetShopListWithProductsQueryResponse
                {
                    Category = _unitOfWork.CategoryReadRepository.GetWhereAsync(condition: c => c.Id == result.CategoryId).Result.Name.ToString(),
                    Products = productList,
                    Title = result.Title
                };
            }
            return null;
        }
    }
}
