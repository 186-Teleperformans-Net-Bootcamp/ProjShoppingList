using Application.Common.Repositories.CategoryRepo;
using Application.CQS.CategoryR.Commands.AddCategory;
using Application.CQS.CategoryR.Commands.UpdateCategory;
using Application.CQS.CategoryR.Queries.GetAllCategories;
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
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        //[Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> GetAllCategoriesAsync([FromQuery] GetAllCategoriesQueryRequest request)
        {
            var result = await _mediator.Send(request);
            if (result.Count > -1)
            {
                return Ok(result);
            }
            return NoContent();
        }


        [HttpPost]
        //[Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> AddAsync(AddCategoryCommandRequest request)
        {
            var result = await _mediator.Send(request);
            if (result.IsSuccess)
            {
                return StatusCode(201);
            }
            return BadRequest(result.Error);
        }
        [HttpPut("{id}")]
        //[Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> UpdateAsync(string id, UpdateCategoryCommandRequest request)
        {
            if (id != request.Id)
            {
                return BadRequest();
            }
            var result = await _mediator.Send(request);
            if (result.IsSuccess)
            {
                return StatusCode(201);
            }
            return BadRequest(result.Error);
        }
    }
}
