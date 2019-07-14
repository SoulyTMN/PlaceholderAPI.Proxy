using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlaceholderAPI.Proxy.Interfaces
{
    public interface IUsersService
    {
        Task<List<User>> GetUsersAsync();
        Task<User> GetUserAsync(int id);

    }
}
