using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlaceholderAPI.Proxy.Interfaces
{
    public interface IAlbumsService
    {
        Task<List<Album>> GetAlbumsAsync(int? userId);
        Task<Album> GetAlbumAsync(int id);
    }
}
