using Application.Common.Interfaces;
using Application.Common.Models;
using Application.Common.Models.Identity;
using Domain.Consts.Messages.Identity;
using Domain.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Identity
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IConfiguration _configuration;
        public IdentityService(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }

        
        public async Task<(Result, string Token)> LoginAsync(LoginModel loginModel)
        {
            var user = await _userManager.FindByEmailAsync(loginModel.Email);
            if (user != null && await _userManager.CheckPasswordAsync(user, loginModel.Password))
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
                };
                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }
                var token = GetToken(authClaims);

                return (Result.Success(), token.ToString());
            }
            else return (Result.Failure(new string[] { IdentityMessages.EmailOrPasswordInvalid }), "");
        }

        public async Task<Result> RegisterAdminAsync(RegisterModel registerModel, UserRoles role = UserRoles.Admin)
        {
            var userExist = await _userManager.FindByEmailAsync(registerModel.Email);

            if (userExist == null)
            {
                AppUser user = new()
                {
                    FirstName = registerModel.FirstName,
                    LastName = registerModel.LastName,
                    Email = registerModel.Email,
                    UserName = $"{registerModel.FirstName} {registerModel.LastName}",
                    BirthDate = registerModel.BirthDate
                };
                var result = await _userManager.CreateAsync(user, registerModel.Password);

                if (result.Succeeded)
                {
                    await CreateRole(role);
                    await _userManager.AddToRoleAsync(user, role.ToString());
                    return Result.Success();
                }
                return Result.Failure(new string[] { });


            }
            else return Result.Failure(new string[] { IdentityMessages.ExistEmail });
        }

        public async Task<Result> RegisterAsync(RegisterModel registerModel, UserRoles role = UserRoles.User)
        {
            var userExists = await _userManager.FindByEmailAsync(registerModel.Email);
            if (userExists == null)
            {
                AppUser user = new()
                {
                    FirstName = registerModel.FirstName,
                    LastName = registerModel.LastName,
                    Email = registerModel.Email,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = $"{registerModel.FirstName} {registerModel.LastName}",
                    BirthDate = registerModel.BirthDate
                };
                var result = await _userManager.CreateAsync(user, registerModel.Password);
                if (result.Succeeded)
                {
                    await CreateRole(role);
                    await _userManager.AddToRoleAsync(user, role.ToString());
                    return Result.Success();
                }
                else
                {
                    string errors = System.Text.Json.JsonSerializer.Serialize(result.Errors);
                    return Result.Failure(new string[] { errors });
                }
            }
            else return Result.Failure(new string[] { IdentityMessages.ExistEmail });
        }

        private async Task CreateRole(UserRoles role)
        {
            string strRole = role.ToString();
            bool roleControl = await _roleManager.RoleExistsAsync(strRole);
            if (!roleControl)
            {
                await _roleManager.CreateAsync(new AppRole { Name = strRole });
            }
        }
        private JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );
            return token;
        }
    }
}
