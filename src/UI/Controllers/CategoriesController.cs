using Application.Common.Repositories.CategoryRepo;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryWriteRepository _categoryWriteRepository;

        public CategoriesController(ICategoryWriteRepository categoryWriteRepository)
        {
            _categoryWriteRepository = categoryWriteRepository;
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(Category category)
        {
            var result = await _categoryWriteRepository.AddAsync(category);
            return Ok(result);
        }
    }
}
