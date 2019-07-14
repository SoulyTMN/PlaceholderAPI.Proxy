using PlaceholderAPI.Proxy.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlaceholderAPI.Proxy.Services
{
    public class AlbumsService : IAlbumsService
    {
        private readonly IAlbumsClient _httpClient;

        public AlbumsService(IAlbumsClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Album>> GetAlbumsAsync(int? userId)
        {
            List<Album> albums = 
                userId == null 
                ? await _httpClient.GetAlbumsAsync() 
                : await _httpClient.GetAlbumByUserIdAsync(userId ?? 0);
            return albums;
        }

        public async Task<Album> GetAlbumAsync(int id)
        {
            var album = await _httpClient.GetAlbumAsync(id);
            return album;
        }
    }
}
