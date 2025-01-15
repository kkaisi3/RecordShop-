using Microsoft.EntityFrameworkCore;
using RecordShop.Data;
using RecordShop.Services;

namespace RecordShop.Model
{
    public interface IAlbumRepository
    {
        List<Album> GetAllAlbums();
        Album GetAlbumById(int id);
      
    }
    public class AlbumRepository : IAlbumRepository
    {
        private readonly RecordShopDbContext _context;

        public AlbumRepository(RecordShopDbContext context)
        {
            _context = context;
        }

        public List<Album> GetAllAlbums()
        {
            return _context.Albums.Include(a => a.Artist).ToList();
        }

        public Album GetAlbumById(int id)
        {
            return GetAllAlbums().FirstOrDefault(a => a.Id == id);
        }
    }
}
