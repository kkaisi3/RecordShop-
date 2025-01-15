using RecordShop.Data;
using RecordShop.Services;

namespace RecordShop.Model
{
    public interface IAlbumRepository
    {
        List<Album> GetAllAlbums();
      
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
            return _context.Albums.ToList();
        }
    }
}
