using Application.Common.Models;
using Application.Common.Repositories.ProductRepo;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductWriteRepository _productWriteRepository;

        public ProductsController(IProductWriteRepository productWriteRepository)
        {
            _productWriteRepository = productWriteRepository;
        }
        [HttpPost]
        public async Task<IActionResult> AddAsync(Product product)
        {
            var result= await _productWriteRepository.AddAsync(product);
            return Ok(result);
        }
    }
}
