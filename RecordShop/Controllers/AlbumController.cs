using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecordShop.Services;
namespace RecordShop.Controllers
{
    [Route("api/[controller]")]
    public class AlbumController : ControllerBase
    {
        private readonly IAlbumService _albumService;
        

        public AlbumController(IAlbumService albumService)
        {
            _albumService = albumService;
        }

        [HttpGet]
        public IActionResult GetAllAlbums()
        {
            var albums = _albumService.GetAllAlbums();
                return Ok(albums);
        }

        [HttpGet]
        public IActionResult GetAlbumById(int id)
        {
            var albums = _albumService.GetAlbumById(id);
            return Ok(albums);
        }
    }

}
