using Microsoft.AspNetCore.Mvc;
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
    }
}
