using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PlaceholderAPI.Proxy.Extensions;
using PlaceholderAPI.Proxy.Interfaces;

namespace PlaceholderAPI.Proxy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumsController : ControllerBase
    {
        private readonly IAlbumsService _albumsService;
        private readonly ILogger<AlbumsController> _logger;

        public AlbumsController(IAlbumsService albumsService, ILogger<AlbumsController> logger)
        {
            _albumsService = albumsService;
            _logger = logger;
        }

        // GET api/albums
        // GET api/albums?userId=5
        [HttpGet]
        public async Task<ActionResult<List<Album>>> GetAsync([FromQuery] int? userId)
        {
            try
            {
                _logger.WithLogContext().Error($"Error while getting albums");
                var albums = await _albumsService.GetAlbumsAsync(userId);
                return Ok(albums);
            }
            catch (Exception ex)
            {
                _logger.WithLogContext().Error($"Error while getting albums: {ex}");
                return StatusCode(500, "Internal server error");
            }
        }

        // GET api/albums/2
        [HttpGet("{id}")]
        public async Task<ActionResult<Album>> GetAsync(int id)
        {
            try
            {
                var album = await _albumsService.GetAlbumAsync(id);
                return Ok(album);
            }
            catch (Exception ex)
            {
                _logger.WithLogContext().Error($"Error while getting album: {ex}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
