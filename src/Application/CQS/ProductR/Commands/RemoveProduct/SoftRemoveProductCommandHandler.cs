using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQS.ProductR.Commands.RemoveProduct
{
    public class SoftRemoveProductCommandHandler : IRequestHandler<RemoveProductCommandRequest, CommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public SoftRemoveProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        /// <summary>
        /// If any basket contains product, we should remove this records firstly.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<CommandResponse> Handle(RemoveProductCommandRequest request, CancellationToken cancellationToken)
        {
            var removed = _mapper.Map<Product>(request);
            _ = await _unitOfWork.ProductShopListWriteRepository.SoftRemoveByProductIdAsync(request.Id);
            var result=await _unitOfWork.ProductWriteRepository.SoftRemoveAsync(removed);
            if (result)
            {
                return new CommandResponse { IsSuccess = true };
            }
            else return new CommandResponse { IsSuccess = false };
        }
    }
}
