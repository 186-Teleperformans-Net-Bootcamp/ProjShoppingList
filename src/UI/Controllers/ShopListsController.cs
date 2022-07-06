using Application.Common.Models;
using Application.CQS.ShopListR.Commands.AddShopList;
using Application.CQS.ShopListR.Commands.CompleteShopList;
using Application.CQS.ShopListR.Commands.RemoveShopList;
using Application.CQS.ShopListR.Commands.UpdateShopList;
using Application.CQS.ShopListR.Queries.GetAllShopListForUserWithPagination;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Domain.Enums;
using Application.CQS.ProductR.Queries;
using Application.CQS.ShopListR.Queries.GetAllUserShopListsByCategory;
using Application.CQS.ShopListR.Commands.AddShopListAdmin;
using Application.CQS.ShopListR.Queries.GetShopListWithProducts;

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
        [HttpGet("GetAllUsersShopListsByCategory_{categoryId}/{userId}")]
        public async Task<IActionResult> GetAllShopListByCategoryIdAsync(string categoryId, string userId, [FromQuery] GetAllUsersShopListsByCategoryQueryRequest request)
        {
            if (userId != request.UserId || categoryId != request.CategoryId)
            {
                return BadRequest();
            }
            var result = await _mediator.Send(request);
            Response.Headers.Add("X-Pagination", System.Text.Json.JsonSerializer.Serialize(request));
            return Ok(result);
        }

        [HttpGet("GetShopListWithProductsAsync_{shopListId}")]
        public async Task<IActionResult> GetShopListWithProductsAsync(string shopListId, [FromQuery] GetShopListWithProductsQueryRequest request)
        {
            if (shopListId != request.ShopListId)
            {
                return BadRequest();
            }
            var result = await _mediator.Send(request);
            //Response.Headers.Add("X-Pagination", System.Text.Json.JsonSerializer.Serialize(request));
            return Ok(result);
        }

        //[Authorize(Roles = UserRoles.Admin)]
        [HttpGet("GetAllShopListByUserId_{userId}")]
        public async Task<IActionResult> GetAllShopListByUserIdAsync(string userId, [FromQuery] GetAllShopListsQueryRequest request)
        {
            if (userId != request.UserId)
            {
                return BadRequest();
            }
            var result = await _mediator.Send(request);
            Response.Headers.Add("X-Pagination", System.Text.Json.JsonSerializer.Serialize(request));
            return Ok(result);
        }
        //[Authorize(Roles = UserRoles.User)]
        [HttpGet("GetAllProductsInShopList_{shopListId}")]
        public async Task<IActionResult> GetAllProductsByShopListId(string shopListId, [FromQuery] GetAllProductsInShopListQueryRequest request)
        {
            if (shopListId != request.ShopListId)
            {
                return BadRequest();
            }
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        //Commands

        //[Authorize(Roles = UserRoles.User)]
        [HttpPost("adding")]
        public async Task<IActionResult> AddAsync(AddShopListCommandRequest request)
        {
            var result = await _mediator.Send(request);
            if (result.IsSuccess)
            {
                return StatusCode(201);
            }
            return BadRequest(result.Error);
        }
        [HttpPost("adding-admin")]
        public async Task<IActionResult> AddAdminAsync(AddShopListAdminCommandRequest request)
        {
            var result = await _mediator.Send(request);
            if (result.IsSuccess)
            {
                return StatusCode(201);
            }
            return BadRequest(result.Error);
        }
        //[Authorize(Roles = UserRoles.User)]
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
        //[Authorize(Roles = UserRoles.User)]
        [HttpPatch("completing_{id}")]
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
        //[Authorize(Roles = UserRoles.User)]
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
