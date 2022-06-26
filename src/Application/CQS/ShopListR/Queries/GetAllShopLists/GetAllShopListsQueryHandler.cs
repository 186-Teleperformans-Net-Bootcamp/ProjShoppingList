using Application.Common.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQS.ShopListR.Queries.GetAllShopLists
{
    public class GetAllShopListsQueryHandler : IRequestHandler<GetAllShopListsQueryRequest, List<GetAllShopListsQueryResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public GetAllShopListsQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<GetAllShopListsQueryResponse>> Handle(GetAllShopListsQueryRequest request, CancellationToken cancellationToken)
        {
            var cachedList= await _unitOfWork.ShopListReadRepository.GetAllCacheAsync("allLists");
            var mappedList=_mapper.Map<List<GetAllShopListsQueryResponse>>(cachedList);
            return mappedList;
        }
    }
}
