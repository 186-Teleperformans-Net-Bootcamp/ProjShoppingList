using Application.Common.Repositories.CategoryRepo;
using Application.CQS.CategoryR.Commands.AddCategory;
using Application.CQS.CategoryR.Commands.RemoveCategory;
using Application.CQS.CategoryR.Commands.UpdateCategory;
using Application.CQS.CategoryR.Queries.GetAllCategories;
using Domain.Entities;
using MediatR;
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
        public async Task<ActionResult<List<GetAllCategoriesQueryResponse>>> GetAllCategoriesAsync([FromQuery]GetAllCategoriesQueryRequest request)
        {
            var result = await _mediator.Send(request);
            if (result.Count>-1)
            {
                return Ok(result);
            }
            return NoContent();
        }


        [HttpPost]
        public async Task<IActionResult> AddAsync(AddCategoryCommandRequest request)
        {
            var result = await _mediator.Send(request);
            if (result.IsSuccess)
            {
                return StatusCode(201);
            }
            return BadRequest(result.Errors);
        }
        [HttpPut("{id}")]
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
            return BadRequest(result.Errors);
        }


        [HttpPut("removing_id")]
        public async Task<IActionResult> SoftRemoveAsync(string id, RemoveCategoryCommandRequest request)
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
    }
}
