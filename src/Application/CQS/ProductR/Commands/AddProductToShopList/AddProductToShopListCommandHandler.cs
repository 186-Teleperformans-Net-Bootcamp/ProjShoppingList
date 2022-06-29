using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQS.ProductR.Commands.AddProductToShopList
{
    public class AddProductToShopListCommandHandler : IRequestHandler<AddProductToShopListCommandRequest, CommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public AddProductToShopListCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CommandResponse> Handle(AddProductToShopListCommandRequest request, CancellationToken cancellationToken)
        {
            var mapped = _mapper.Map<Product>(request);
            var result = await _unitOfWork.ProductWriteRepository.AddAsync(mapped);
            if (result)
            {
                return new CommandResponse { IsSuccess = true };
            }
            return new CommandResponse { IsSuccess = false, Error = "Model is not valid" };
        }
    }
}
