using PlaceholderAPI.Proxy.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlaceholderAPI.Proxy.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUsersClient _httpClient;

        public UsersService(IUsersClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<User>> GetUsersAsync()
        {
            var users = await _httpClient.GetUsersAsync();
            return users;
        }

        public async Task<User> GetUserAsync(int id)
        {
            var user = await _httpClient.GetUserAsync(id);
            return user;
        }
    }
}
