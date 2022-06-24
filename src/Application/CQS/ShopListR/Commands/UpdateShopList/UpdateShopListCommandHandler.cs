using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQS.ShopListR.Commands.UpdateShopList
{
    public class UpdateShopListCommandHandler : IRequestHandler<UpdateShopListCommandRequest, CommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateShopListCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CommandResponse> Handle(UpdateShopListCommandRequest request, CancellationToken cancellationToken)
        {
            var updated = _mapper.Map<ShopList>(request);
            var result = await _unitOfWork.ShopListWriteRepository.UpdateAsync(updated);
            if (result)
            {
                return new CommandResponse { IsSuccess = true };
            }
            else return new CommandResponse { IsSuccess = false };
        }
    }
}
