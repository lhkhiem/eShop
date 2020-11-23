using eShop.ViewModels.Common;
using eShop.ViewModels.System.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShop.AdminApp.Services
{
    public interface IUserApiClient
    {
        Task<string> Authenticate(LoginRequest request);
        Task<PagedResult<UserVm>> GetUsersPagings(GetUserPagingRequest request);
        Task<bool> RegisterUser(RegisterRequest registerRequest);
    }
}