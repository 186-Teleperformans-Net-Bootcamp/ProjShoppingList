using Application.Common.Models;
using Application.Common.Repositories.ProductRepo;
using Application.CQS.ProductR.Commands.AddProduct;
using Application.CQS.ProductR.Queries;
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
        [HttpGet]
        public async Task<ActionResult<List<GetAllProductsQueryResponse>>> GetAllProductsWithPaginationAsync([FromQuery] GetAllProductsWithPaginationQueryRequest request)
        {
            var result=await _mediator.Send(request);
            if (result.Count > -1)
            {
                return Ok(result);
            }
            else return BadRequest();
        }
        [HttpPost]
        public async Task<IActionResult> AddAsync(AddProductCommandRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }
    }
}
