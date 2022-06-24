using Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQS.ProductR.Commands.BuyAllProducts
{
    public class BuyAllProductsCommandHandler : IRequestHandler<BuyAllProductsCommandRequest, CommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public BuyAllProductsCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CommandResponse> Handle(BuyAllProductsCommandRequest request, CancellationToken cancellationToken)
        {
            var result = _unitOfWork.ProductShopListWriteRepository.BuyAllProductInShopList(request.ShopListId);
            if (result)
            {
                return new CommandResponse { IsSuccess = true };
            }
            return new CommandResponse { IsSuccess = false };
        }
    }
}
