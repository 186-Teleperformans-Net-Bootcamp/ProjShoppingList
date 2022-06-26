using Application.Common.Models;
using Application.Common.Models.Identity;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IIdentityService
    {
        Task<(Result, string Token)> LoginAsync(LoginModel loginModel);
        Task<Result> RegisterAsync(RegisterModel registerModel, string role = UserRoles.User);
        Task<Result> RegisterAdminAsync(RegisterModel registerModel, string role = UserRoles.Admin);
    }
}
