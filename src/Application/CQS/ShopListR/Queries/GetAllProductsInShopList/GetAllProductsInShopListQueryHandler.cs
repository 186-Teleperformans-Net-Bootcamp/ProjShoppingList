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
        public Task<List<GetAllProductsInShopListQueryResponse>> Handle(GetAllProductsInShopListQueryRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
