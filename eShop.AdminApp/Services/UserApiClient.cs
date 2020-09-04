using eShop.ViewModels.Common;
using eShop.ViewModels.System.Users;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace eShop.AdminApp.Services
{
    public class UserApiClient : IUserApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public UserApiClient(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }

        public async Task<string> Authenticate(LoginRequest request)
        {
            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("https://localhost:5001");
            var response = await client.PostAsync("/api/users/authenticate", httpContent);
            var token = await response.Content.ReadAsStringAsync();
            return token;
        }

        Task<string> IUserApiClient.Authenticate(LoginRequest request)
        {
            throw new NotImplementedException();
        }

        Task<PagedResult<UserVm>> IUserApiClient.GetUsersPagings(GetUserPagingRequest request)
        {
            throw new NotImplementedException();
        }

        Task<bool> IUserApiClient.RegisterUser(RegisterRequest registerRequest)
        {
            throw new NotImplementedException();
        }
    }
}