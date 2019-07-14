using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PlaceholderAPI.Proxy.Extensions;
using PlaceholderAPI.Proxy.Interfaces;

namespace PlaceholderAPI.Proxy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;
        private readonly ILogger<UsersController> _logger;
        public UsersController(IUsersService usersService, ILogger<UsersController> logger)
        {
            _usersService = usersService;
            _logger = logger;
        }

        // GET api/users
        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAsync()
        {
            try
            {
                var users = await _usersService.GetUsersAsync();
                return Ok(users);
            }
            catch (Exception ex)
            {
                _logger.WithLogContext().Error($"Error while getting users: {ex}");
                return StatusCode(500, "Internal server error");
            }
        }

        // GET api/users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetAsync(int id)
        {
            try
            {
                var user = await _usersService.GetUserAsync(id);
                return Ok(user);
            }
            catch (Exception ex)
            {
                _logger.WithLogContext().Error($"Error while getting user: {ex}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
