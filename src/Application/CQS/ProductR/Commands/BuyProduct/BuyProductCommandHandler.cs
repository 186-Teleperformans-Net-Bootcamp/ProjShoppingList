using Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQS.ProductR.Commands.BuyProduct
{
    public class BuyProductCommandHandler : IRequestHandler<BuyProductCommandRequest, CommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public BuyProductCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CommandResponse> Handle(BuyProductCommandRequest request, CancellationToken cancellationToken)
        {
            var result = _unitOfWork.ProductShopListWriteRepository.BuyProductInShopList(request.Id);
            if (result)
            {
                return new CommandResponse { IsSuccess = true };
            }
            return new CommandResponse { IsSuccess = false };
        }
    }
}
