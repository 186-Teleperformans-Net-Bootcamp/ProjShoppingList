using Application.Common.Interfaces;
using Application.Common.Models.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IIdentityService _identityService;

        public AccountsController(IIdentityService identityService)
        {
            _identityService = identityService;
        }
        [HttpPost("Register")]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterModel user)
        {
            var result = await _identityService.RegisterAsync(user);
            if (result.Succeeded)
            {
                return Created("~api/Accounts", user);
            }
            else if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }
            else
            {
                return StatusCode(501);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginModel user)
        {
            var result = await _identityService.LoginAsync(user);
            if (result.Item1.Succeeded)
            {
                Response.Headers.Add("JWT:", result.Token);
                return Ok();
            }
            else
            {
                return BadRequest(result.Item1.Errors);
            }
        }

        [HttpPost("Register-Admin")]
        public async Task<IActionResult> RegisterAdmin([FromBody] RegisterModel user)
        {
            var result = await _identityService.RegisterAdminAsync(user);
            if (result.Succeeded)
            {
                return Created("~api/Accounts", user);
            }
            else if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }
            else
            {
                return StatusCode(501);
            }
        }
    }
}
