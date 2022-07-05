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

namespace Application.CQS.ShopListR.Queries.GetAllUserShopListsByCategory
{
    public class GetAllUsersShopListsByCategoryQueryHandler : IRequestHandler<GetAllUsersShopListsByCategoryQueryRequest, PaginatedList<GetAllUsersShopListsByCategoryQueryResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public GetAllUsersShopListsByCategoryQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<PaginatedList<GetAllUsersShopListsByCategoryQueryResponse>> Handle(GetAllUsersShopListsByCategoryQueryRequest request, CancellationToken cancellationToken)
        {
            var mapped = await _unitOfWork
                .ShopListReadRepository
                .GetAllShopListsByUserIdAsync(request.UserId,
                new PaginatedParameters { PageNumber = request.PageNumber, PageSize = request.PageSize }
                );
            var mappedList = _mapper.Map<List<ShopListDto>>(mapped);
            var result = _unitOfWork.ShopListReadRepository.ConvertToResponse("ByCategory",mappedList);
            return new PaginatedList<GetAllUsersShopListsByCategoryQueryResponse>(result, result.Count, request.PageNumber, request.PageSize);
        }
    }
}
