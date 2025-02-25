using RecordShop.Data;
using RecordShop.Model;

namespace RecordShop.Services
{
    public interface IAlbumService
    {
        Task <List<Album>> GetAllAlbums();
        Task<Album> GetAlbumById(int id);

        Task <Album> CreateAlbum(Album album);

        Task UpdateAlbum(Album album);

        Task DeleteAlbum(int id);

    }
    public class AlbumService : IAlbumService
    {
        private readonly IAlbumRepository _albumRepository;

        public AlbumService(IAlbumRepository albumRepository)
        {
            _albumRepository = albumRepository;
        }

        public async Task<List<Album>> GetAllAlbums()
        {
            return await _albumRepository.GetAllAlbums();
        }

        public async Task<Album> GetAlbumById(int id)
        {
            return await _albumRepository.GetAlbumById(id);
        }

        public async Task<Album> CreateAlbum(Album album)
        {
            return await _albumRepository.CreateAlbum(album);
        }

        public async Task UpdateAlbum(Album album)
        {
            await _albumRepository.UpdateAlbum(album);
        }

        public async Task DeleteAlbum(int id)
        {
           await _albumRepository.DeleteAlbum(id);
        }

     
    }
}
