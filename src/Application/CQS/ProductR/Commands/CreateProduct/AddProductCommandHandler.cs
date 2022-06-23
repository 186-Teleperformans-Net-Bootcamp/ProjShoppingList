using Application.Common.Repositories.ProductRepo;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.CQS.ProductR.Commands.CreateProduct
{
    public class AddProductCommandHandler : IRequestHandler<AddProductCommandRequest, AddProductCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProductWriteRepository _productWriteRepository;

        public AddProductCommandHandler(IProductWriteRepository productWriteRepository, IMapper mapper)
        {
            _productWriteRepository = productWriteRepository;
            _mapper = mapper;
        }

        public async Task<AddProductCommandResponse> Handle(AddProductCommandRequest request, CancellationToken cancellationToken)
        {
            var addedProduct = _mapper.Map<Product>(request);
            var result=await _productWriteRepository.AddAsync(addedProduct);
            if (result)
            {
                return new AddProductCommandResponse { IsSuccess = true };
            }
            else return new AddProductCommandResponse { IsSuccess = false };
        }
    }
}
