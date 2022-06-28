using Application.Common.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQS.ProductR.Commands.BuyAllProducts
{
    public class BuyAllProductCommandHandler : IRequestHandler<BuyAllProductsCommandRequest, CommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public BuyAllProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CommandResponse> Handle(BuyAllProductsCommandRequest request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.ProductWriteRepository.BuyAllProductsByShopListIdAsync(request.ShopListId);
            if (result)
            {
                return new CommandResponse { IsSuccess = true };
            }
            return new CommandResponse { IsSuccess = false, Error = "Products not found" };
        }
    }
}
