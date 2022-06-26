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
        private readonly IUnitOfWork _unitOfWork;

        public GetAllProductsInShopListQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<GetAllProductsInShopListQueryResponse>> Handle(GetAllProductsInShopListQueryRequest request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.ProductShopListReadRepository.GetAllByShopListIdAsync(request.ShopListId);
            var list = new List<GetAllProductsInShopListQueryResponse>();
            foreach (var item in result)
            {
                var product = await _unitOfWork.ProductReadRepository.GetByIdAsync(item.ProductId);
                var response = new GetAllProductsInShopListQueryResponse();
                response.Amount = item.Amount;
                response.Name = product.Name;
                list.Add(response);
            }
            return list;
        }
    }
}
