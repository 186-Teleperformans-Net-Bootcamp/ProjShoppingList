using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQS.ShopListR.Commands.CompleteShopList
{
    public class CompleteShopListCommandHandler : IRequestHandler<CompleteShopListCommandRequest, CommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CompleteShopListCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CommandResponse> Handle(CompleteShopListCommandRequest request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.ShopListWriteRepository.CompleteAsync(request.Id);
            if (result)
            {
                return new CommandResponse { IsSuccess = true };
            }
            else return new CommandResponse { IsSuccess = false };
        }
    }
}
