using Application.Common.Interfaces;
using Application.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQS.ShopListR.Queries.GetAllShopListsAdmin
{
    public class GetAllShopListsAdminQueryHandler : IRequestHandler<GetAllShopListsAdminQueryRequest, PaginatedList<GetAllShopListsAdminQueryResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public Task<PaginatedList<GetAllShopListsAdminQueryResponse>> Handle(GetAllShopListsAdminQueryRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
