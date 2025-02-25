using Microsoft.EntityFrameworkCore;
using RecordShop.Data;
using RecordShop.Services;

namespace RecordShop.Model
{
    public interface IAlbumRepository
    {
        public Task<List<Album>> GetAllAlbums();
        Task<Album> GetAlbumById(int id);

        Task<Album> CreateAlbum(Album album);
        Task UpdateAlbum(Album album);

        Task DeleteAlbum(int id);
    }
    public class AlbumRepository : IAlbumRepository
    {
        private readonly RecordShopDbContext _context;

        public AlbumRepository(RecordShopDbContext context)
        {
            _context = context;
        }

        public async Task<List<Album>> GetAllAlbums()
        {
            return await _context.Albums.Include(a => a.Artist).ToListAsync();
        }

          public async Task<Album> GetAlbumById(int id)
        {
            return await _context.Albums.Include(a => a.Artist).FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<Album> CreateAlbum(Album album)
        {
           _context.Albums.Add(album);
            await _context.SaveChangesAsync();
            return album;
        }

        public async Task UpdateAlbum(Album album)
        {
            var existingAlbum = await _context.Albums.FindAsync(album.Id);

            existingAlbum.Title = album.Title;
            existingAlbum.ReleaseDate = album.ReleaseDate;


            await _context.SaveChangesAsync();
        }

        public async Task DeleteAlbum(int id)
        {
            var album = await _context.Albums.FindAsync(id); 
            if (album != null)
            {
                _context.Albums.Remove(album); 
               await _context.SaveChangesAsync(); 
            }
        }
    }
}
