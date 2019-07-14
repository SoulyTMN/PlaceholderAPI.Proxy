using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlaceholderAPI.Proxy.Interfaces
{
    public interface IAlbumsClient
    {
        [Get("/albums")]
        Task<List<Album>> GetAlbumsAsync();

        [Get("/albums?userId={userId}")]
        Task<List<Album>> GetAlbumByUserIdAsync(int userId);

        [Get("/albums/{id}")]
        Task<Album> GetAlbumAsync(int id);
    }

    public class Album
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
    }
}
