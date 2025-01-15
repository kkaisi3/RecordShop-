using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecordShop.Services;
namespace RecordShop.Controllers
{
    [Route("api/[controller]")]
    public class AlbumController : ControllerBase
    {
        private readonly IAlbumService _albumService;
        private readonly RecordShopDbContext _context;

        //public AlbumController(IAlbumService albumService)
        //{
        //    _albumService = albumService;
        //}
        public AlbumController(RecordShopDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllAlbums()
        {
            var albums = _context.Albums.Include(a => a.Artist).ToList();
                return Ok(albums);
        }
    }

}
