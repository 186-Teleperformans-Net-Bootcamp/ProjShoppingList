using Application.Common.Interfaces;
using Application.Common.Models;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQS.ProductR.Queries
{
    public class GetAllProductsWithPaginationQueryHandler : IRequestHandler<GetAllProductsWithPaginationQueryRequest, List<GetAllProductsQueryResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public GetAllProductsWithPaginationQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        /// <summary>
        /// Automapper not support PaginatedList mapping, this extension only supports collection structures in visual studio content
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<List<GetAllProductsQueryResponse>> Handle(GetAllProductsWithPaginationQueryRequest request, CancellationToken cancellationToken)
        {
            var mapped = await _unitOfWork
                .ProductReadRepository
                .GetAllWithPaginationAsync(
                new PaginatedParameters { PageNumber = request.PageNumber, PageSize = request.PageSize }
                );
            var result = _mapper.Map<List<GetAllProductsQueryResponse>>(mapped);
            return result;
        }
    }
}
