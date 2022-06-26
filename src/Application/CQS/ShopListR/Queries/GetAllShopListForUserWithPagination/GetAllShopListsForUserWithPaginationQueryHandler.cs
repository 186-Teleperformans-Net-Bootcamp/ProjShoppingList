using Application.Common.Interfaces;
using Application.Common.Models;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQS.ShopListR.Queries.GetAllShopListForUserWithPagination
{
    public class GetAllShopListsForUserWithPaginationQueryHandler : IRequestHandler<GetAllShopListsForUserWithPaginationQueryRequest, PaginatedList<GetAllShopListsForUserWithPaginationQueryResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public GetAllShopListsForUserWithPaginationQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<PaginatedList<GetAllShopListsForUserWithPaginationQueryResponse>> Handle(GetAllShopListsForUserWithPaginationQueryRequest request, CancellationToken cancellationToken)
        {
            var mapped = await _unitOfWork
                .ShopListReadRepository
                .GetAllWithPaginationAsync(request.UserId,
                new PaginatedParameters { PageNumber = request.PageNumber, PageSize = request.PageSize }
                );
            var result = _mapper.Map<List<GetAllShopListsForUserWithPaginationQueryResponse>>(mapped);
            return new PaginatedList<GetAllShopListsForUserWithPaginationQueryResponse>(result, result.Count, request.PageNumber, request.PageSize);
        }
    }
}
