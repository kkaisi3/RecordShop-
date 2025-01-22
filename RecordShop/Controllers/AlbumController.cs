using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecordShop.Data;
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

        [HttpGet("id")]
        public IActionResult GetAlbumById(int id)
        {
            var albums = _albumService.GetAlbumById(id);
            return Ok(albums);
        }

        [HttpPost]
        public IActionResult CreateAlbum([FromBody] Album album)
        {

            var createdAlbum = _albumService.CreateAlbum(album);

            return CreatedAtAction("GetAlbumById", new { id = createdAlbum.Id }, createdAlbum);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAlbum(int id, [FromBody] Album album)
        {
            if (id != album.Id)
            {
                return BadRequest("Album ID mismatch.");
            }
            _albumService.UpdateAlbum(album);
            return Ok(album);

        }
        [HttpDelete("{id}")]
        public IActionResult DeleteAlbum(int id)
        {
            _albumService.DeleteAlbum(id);
            return NoContent(); 
        }
    }

}
