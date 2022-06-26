using Application.Common.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQS.ShopListR.Queries.GetAllProductsInShopList
{
    public class GetAllProductsInShopListQueryHandler : IRequestHandler<GetAllProductsInShopListQueryRequest, List<GetAllProductsInShopListQueryResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public async Task<List<GetAllProductsInShopListQueryResponse>> Handle(GetAllProductsInShopListQueryRequest request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.ProductShopListReadRepository.GetAllByShopListIdAsync(request.Id);
            var list = new List<GetAllProductsInShopListQueryResponse>();
            foreach (var item in result)
            {
                var response = new GetAllProductsInShopListQueryResponse();
                item.Amount = response.Amount;
                item.Product.Name = response.Name;
                list.Add(response);
            }
            return list;
        }
    }
}
