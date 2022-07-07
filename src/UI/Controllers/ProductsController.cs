using Application.Common.Models;
using Application.Common.Repositories.ProductRepo;
using Application.CQS.ProductR.Commands.AddProductToShopList;
using Application.CQS.ProductR.Commands.BuyAllProducts;
using Application.CQS.ProductR.Commands.BuyProduct;
using Application.CQS.ProductR.Commands.RemoveProduct;
using Application.CQS.ProductR.Commands.UpdateProduct;
using Application.CQS.ProductR.Queries;
using Domain.Entities;
using Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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
        //<ActionResult<PaginatedList<GetAllProductsInShopListQueryResponse>>>
        [Authorize(Roles = UserRoles.User)]
        [HttpGet("{shopListId}")]
        public async Task<IActionResult> GetAllProductsInShopListAsync(string shopListId, [FromQuery]GetAllProductsInShopListQueryRequest request)
        {
            if (shopListId!=request.ShopListId)
            {
                return BadRequest();
            }
            var result=await _mediator.Send(request);
            Response.Headers.Add("X-Pagination", System.Text.Json.JsonSerializer.Serialize(request));
            if (result.Count > -1)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        //Commands
        [Authorize(Roles = UserRoles.User)]
        [HttpPost("{shopListId}")]
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

        [Authorize(Roles = UserRoles.User)]
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
            else return BadRequest(result.Error);
        }
        [Authorize(Roles = UserRoles.User)]
        [HttpPatch("removing_{id}")]
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
            return BadRequest(result.Error);
        }
        [Authorize(Roles = UserRoles.User)]
        [HttpPatch("buying_{id}")]
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
        [Authorize(Roles = UserRoles.User)]
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
