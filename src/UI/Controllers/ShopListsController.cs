using Application.Common.Models;
using Application.CQS.ShopListR.Commands.AddProductToShopList;
using Application.CQS.ShopListR.Commands.AddShopList;
using Application.CQS.ShopListR.Commands.CompleteShopList;
using Application.CQS.ShopListR.Commands.RemoveProductFromShopList;
using Application.CQS.ShopListR.Commands.RemoveShopList;
using Application.CQS.ShopListR.Commands.UpdateShopList;
using Application.CQS.ShopListR.Queries.GetAllProductsInShopList;
using Application.CQS.ShopListR.Queries.GetAllShopListForUserWithPagination;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Domain.Enums;
using Application.CQS.ShopListR.Queries.GetAllShopLists;

namespace UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopListsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ShopListsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        //Queries
        [HttpGet("all")]
        public async Task<IActionResult> GetAllAsync([FromQuery]GetAllShopListsQueryRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }
        [Authorize(Roles = UserRoles.Admin)]
        [HttpGet("GetAllShopListByUserId_{userId}")]
        public async Task<ActionResult<PaginatedList<GetAllShopListsForUserWithPaginationQueryResponse>>> GetAllShopListByUserIdAsync(string userId,[FromQuery]GetAllShopListsForUserWithPaginationQueryRequest request)
        {
            if (userId!=request.UserId)
            {
                return BadRequest();
            }
            var result=await _mediator.Send(request);
            Response.Headers.Add("X-Pagination", System.Text.Json.JsonSerializer.Serialize(request));
            return result;
        }
        [Authorize(Roles = UserRoles.User)]
        [HttpGet("GetAllProductsInShopList_{shopListId}")]
        public async Task<IActionResult> GetAllProductsShopListId(string shopListId, [FromQuery]GetAllProductsInShopListQueryRequest request)
        {
            if (shopListId!=request.ShopListId)
            {
                return BadRequest();
            }
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        //Commands
        [Authorize(Roles = UserRoles.User)]
        [HttpPut("{id}")]
        public async Task<IActionResult> RemoveProductFromShopListAsync(string id, RemoveProductFromShopListCommandRequest request)
        {
            if (id!=request.Id)
            {
                return BadRequest();
            }
            var result=await _mediator.Send(request);
            if (result.IsSuccess)
            {
                return NoContent();
            }
            return BadRequest(result.Errors);
        }

        [Authorize(Roles = UserRoles.User)]
        [HttpPost("{shopListId},{productId}")]
        public async Task<IActionResult> AddProductToShopListAsync(string shopListId, string productId, AddProductToShopListCommandRequest request)
        {
            if (shopListId!=request.ShopListId || productId!=request.ProductId)
            {
                return BadRequest();
            }
            var result = await _mediator.Send(request);
            if (result.IsSuccess)
            {
                return StatusCode(201);
            }
            return BadRequest(result.Errors);
        }
        [Authorize(Roles = UserRoles.User)]
        [HttpPost]
        public async Task<IActionResult> AddAsync(AddShopListCommandRequest request)
        {
            var result = await _mediator.Send(request);
            if (result.IsSuccess)
            {
                return StatusCode(201);
            }
            return BadRequest(result.Errors);
        }
        [Authorize(Roles = UserRoles.User)]
        [HttpPut("updating_{id}")]
        public async Task<IActionResult> UpdateAsync(string id, UpdateShopListCommandRequest request)
        {
            if (id != request.Id)
            {
                return BadRequest();
            }
            await _mediator.Send(request);
            return StatusCode(204);
        }
        [Authorize(Roles = UserRoles.User)]
        [HttpPatch("{id}")]
        public async Task<IActionResult> CompleteAsync(string id, CompleteShopListCommandRequest request)
        {
            if (id != request.Id)
            {
                return BadRequest();
            }
            await _mediator.Send(request);
            return StatusCode(204);
        }
        // SoftRemove
        [Authorize(Roles = UserRoles.User)]
        [HttpPut("removing_{id}")]
        public async Task<IActionResult> RemoveAsync(string id, RemoveShopListCommandRequest request)
        {
            if (id != request.Id)
            {
                return BadRequest();
            }
            await _mediator.Send(request);
            return StatusCode(204);
        }
    }
}
