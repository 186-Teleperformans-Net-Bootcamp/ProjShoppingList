using Application.Common.Interfaces;
using Application.Common.Models;
using Application.DTOs;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQS.ShopListR.Queries.GetAllShopListForUserWithPagination
{
    public class GetAllShopListsQueryHandler : IRequestHandler<GetAllShopListsQueryRequest, PaginatedList<GetAllShopListsQueryResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public GetAllShopListsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<PaginatedList<GetAllShopListsQueryResponse>> Handle(GetAllShopListsQueryRequest request, CancellationToken cancellationToken)
        {
            var mapped = await _unitOfWork
                .ShopListReadRepository
                .GetAllShopListsByUserIdAsync(request.UserId,
                new PaginatedParameters { PageNumber = request.PageNumber, PageSize = request.PageSize }
                );
            var mappedList = _mapper.Map<List<ShopListDto>>(mapped);
            var result=_unitOfWork.ShopListReadRepository.ConvertToResponse(mappedList);
            return new PaginatedList<GetAllShopListsQueryResponse>(result, result.Count, request.PageNumber, request.PageSize);
        }
    }
}
