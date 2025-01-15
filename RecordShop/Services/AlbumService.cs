using RecordShop.Data;
using RecordShop.Model;

namespace RecordShop.Services
{
    public interface IAlbumService
    {
     List<Album> GetAllAlbums();
    }
    public class AlbumService : IAlbumService
    {
        private readonly IAlbumRepository _albumRepository;

        public AlbumService(IAlbumRepository albumRepository)
        {
            _albumRepository = albumRepository;
        }

        public List<Album> GetAllAlbums()
        {
            return _albumRepository.GetAllAlbums();
        }
    }
}
