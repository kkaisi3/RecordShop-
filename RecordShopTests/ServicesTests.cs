using FluentAssertions;
using Moq;
using RecordShop.Data;
using RecordShop.Model;
using RecordShop.Services;

namespace RecordShopTests
{
    public class Tests
    {
        private Mock<IAlbumRepository> _albumRepositoryMock;
        private AlbumService _albumService;

        [SetUp]
        public void Setup()
        {
            _albumRepositoryMock = new Mock<IAlbumRepository>();
            _albumService = new(_albumRepositoryMock.Object);
        }


        [Test]
        public void etAllAlbums_ReturnListOfAlbums()
        {
            // Arrange
            var albums = new List<Album>
        {
            new Album { Id = 1, Title = "Madvillainy" },
            new Album { Id = 2, Title = "Abbey Road" }
        };
            _albumRepositoryMock.Setup(repo => repo.GetAllAlbums()).Returns(albums);

            // Act
            var result = _albumService.GetAllAlbums();

            // Assert
            result.Should().BeEquivalentTo(albums);
        }

        [Test]
        public void GetAlbumById_ReturnCorrectAlbum()
        {
            // Arrange
            var album = new Album { Id = 1, Title = "Madvillainy" };
            _albumRepositoryMock.Setup(repo => repo.GetAlbumById(1)).Returns(album);

            // Act
            var result = _albumService.GetAlbumById(1);

            // Assert
            result.Should().BeEquivalentTo(album);
        }
    }
}