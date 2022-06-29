using Application.Common.Models;
using Application.Common.Repositories.ProductRepo;
using Application.CQS.ProductR.Commands.AddProductToShopList;
using Application.CQS.ProductR.Commands.BuyAllProducts;
using Application.CQS.ProductR.Commands.BuyProduct;
using Application.CQS.ProductR.Commands.RemoveProduct;
using Application.CQS.ProductR.Commands.UpdateProduct;
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
        //Queries
        [HttpGet]
        public async Task<ActionResult<PaginatedList<GetAllProductsInShopListQueryResponse>>> GetAllProductsInShopListAsync([FromQuery] GetAllProductsInShopListQueryRequest request)
        {
            var result=await _mediator.Send(request);
            Response.Headers.Add("X-Pagination", System.Text.Json.JsonSerializer.Serialize(request));
            if (result.Count > -1)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        //Commands
        [HttpPost("{id}")]
        public async Task<IActionResult> AddAsync(string shopListId,AddProductToShopListCommandRequest request)
        {
            if (shopListId!=request.ShopListId)
            {
                return BadRequest();
            }
            var result=await _mediator.Send(request);
            if (result.IsSuccess)
            {
                return StatusCode(201);
            }
            return BadRequest(result.Error);                
        }

        [HttpPut("updating_{id}")]
        public async Task<IActionResult> UpdateAsync(string id,UpdateProductCommandRequest request)
        {
            if (id!=request.Id)
            {
                return BadRequest();
            }
            var result = await _mediator.Send(request);
            if (result.IsSuccess)
            {
                return Ok();
            }
            else return BadRequest();
        }

        [HttpPut("removing_{id}")]
        public async Task<IActionResult> SoftRemoveAsync(string id,SoftRemoveProductCommandRequest request)
        {
            if (id!=request.Id)
            {
                return BadRequest();
            }
            var result=await _mediator.Send(request);
            if (result.IsSuccess)
            {
                return Ok();
            }
            return BadRequest();
        }
        [HttpPut("buying_{id}")]
        public async Task<IActionResult> BuyProductAsync(string id, BuyProductCommandRequest request)
        {
            if (id != request.Id)
            {
                return BadRequest();
            }
            var result = await _mediator.Send(request);
            if (result.IsSuccess)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut("allBuying_{shopListId}")]
        public async Task<IActionResult> BuyAllProductsAsync(string shopListId, BuyAllProductsCommandRequest request)
        {
            if (shopListId != request.ShopListId)
            {
                return BadRequest();
            }
            var result = await _mediator.Send(request);
            if (result.IsSuccess)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
