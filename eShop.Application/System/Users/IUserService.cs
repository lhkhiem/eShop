using eShop.ViewModels.Common;
using eShop.ViewModels.System.Users;
using System;
using System.Threading.Tasks;

namespace eShop.Application.System.Users
{
    public interface IUserService
    {
        //Task<ApiResult<string>> Authencate(LoginRequest request);
        Task<LoginRespone> Authencate(LoginRequest request);

        Task<ApiResult<bool>> Register(RegisterRequest request);

        Task<ApiResult<PagedResult<UserVm>>> GetUsersPaging(GetUserPagingRequest request);

        Task<ApiResult<bool>> Update(Guid id, UserUpdateRequest request);

        Task<ApiResult<UserVm>> GetById(Guid id);
    }
}