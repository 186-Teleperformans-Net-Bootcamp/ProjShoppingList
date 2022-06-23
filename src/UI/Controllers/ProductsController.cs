using Application.Common.Repositories.ProductRepo;
using Application.CQS.ProductR.Commands.CreateProduct;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(AddProductCommandRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }
    }
}
