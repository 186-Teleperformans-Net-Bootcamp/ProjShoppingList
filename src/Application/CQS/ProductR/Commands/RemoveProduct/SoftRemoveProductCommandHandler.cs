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
    public class SoftRemoveProductCommandHandler : IRequestHandler<SoftRemoveProductCommandRequest, CommandResponse>
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
        public async Task<CommandResponse> Handle(SoftRemoveProductCommandRequest request, CancellationToken cancellationToken)
        {
            var removed = _mapper.Map<Product>(request);
            var result = await _unitOfWork.ProductWriteRepository.SoftRemoveAsync(removed);
            if (result)
            {
                return new CommandResponse { IsSuccess = true };
            }
            return new CommandResponse { IsSuccess = false };
        }
    }
}
