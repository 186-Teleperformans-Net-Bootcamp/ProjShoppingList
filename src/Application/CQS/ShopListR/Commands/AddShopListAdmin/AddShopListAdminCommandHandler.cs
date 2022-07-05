using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Entities.AdminEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQS.ShopListR.Commands.AddShopListAdmin
{
    public class AddShopListAdminCommandHandler : IRequestHandler<AddShopListAdminCommandRequest, CommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public AddShopListAdminCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CommandResponse> Handle(AddShopListAdminCommandRequest request, CancellationToken cancellationToken)
        {
            var mapped = _mapper.Map<CompletedList>(request);
            var result=await _unitOfWork.ShopListWriteRepository.AddShopListAdminAsync(mapped);
            if (result)
            {
                return new CommandResponse { IsSuccess = true };
            }
            return new CommandResponse { IsSuccess = false };
        }
    }
}
