using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Moq;
using RecordShop.Controllers;
using RecordShop.Data;
using RecordShop.Model;
using RecordShop.Services;

namespace RecordShopTests
{
    internal class ControllersTests
    {
        private Mock<IAlbumService> _albumServiceMock;
        private AlbumController _albumController;

        [SetUp]     
        public void SetUp()
        {
            _albumServiceMock = new Mock<IAlbumService>();
            _albumController = new(_albumServiceMock.Object);
        }
        [Test]
        public void GetAllAlbums_ReturnListOfAlbums()
        {
            //Arange
            List<Album> albums = [new Album() { Id = 1, Title = "Madvillainy" }, new Album() { Id = 2, Title = "Abbey road" }];
            _albumServiceMock.Setup(s => s.GetAllAlbums()).Returns(albums);

            // Act
            var result = _albumController.GetAllAlbums() as OkObjectResult;

            // Assert
            var listOfAlbums = result.Value as List<Album>;
            listOfAlbums.Should().BeEquivalentTo(albums); 
        }

        [Test]
        public void GetAlbumById_ReturnCorrectAlbum()
        {
            //Arange
            Album album = new Album() { Id = 1, Title = "Madvillainy" };
            _albumServiceMock.Setup(s => s.GetAlbumById(1)).Returns(album);

            // Act
            var result = _albumController.GetAlbumById(1) as OkObjectResult;

            // Assert


            var returnedAlbum = result.Value as Album;
            returnedAlbum.Should().BeEquivalentTo(album);

        }
        [Test]
        public void CreateAlbum_Return()
        {
            // Arrange
            var albumToPost = new Album { Id = 1, Title = "Madvillainy", ArtistId = 1 };
            var postedAlbum = new Album { Id = 1, Title = "Madvillainy", ArtistId = 1 };

            _albumServiceMock.Setup(s => s.CreateAlbum(albumToPost)).Returns(postedAlbum);

            var albumController = new AlbumController(_albumServiceMock.Object);

            // Act
            var result = albumController.CreateAlbum(albumToPost) as CreatedAtActionResult;

            // Assert
            result.Should().NotBeNull();
            result.StatusCode.Should().Be(201);
            result.Value.Should().BeEquivalentTo(postedAlbum);
            result.RouteValues["id"].Should().Be(postedAlbum.Id);
        }

        [Test]
        public void UpdateAlbum_ShouldReturnOkResult_WithUpdatedAlbum()
        {
            // Arrange
            var albumId = 1; // Simulate path variable
            var updatedAlbum = new Album
            {
                Id = albumId,
                Title = "Title1",
                ReleaseDate = new DateTime(2001, 1, 1)
            };

            // Mock Setup for void method
            _albumServiceMock
                .Setup(s => s.UpdateAlbum(It.Is<Album>(a => a.Id == albumId && a.Title == "Title1")))
                .Callback<Album>(album =>
                {
                    album.Id.Should().Be(albumId);
                    album.Title.Should().Be("Title1");
                });

            // Act
            var result = _albumController.UpdateAlbum(albumId, updatedAlbum) as OkObjectResult;

            // Assert
            result.Should().NotBeNull();
            result.StatusCode.Should().Be(200); 
            result.Value.Should().BeOfType<Album>();

            var returnedAlbum = result.Value as Album;
            returnedAlbum.Should().NotBeNull();
            //ignore properties not changed
            returnedAlbum.Should().BeEquivalentTo(updatedAlbum, options => options.ExcludingMissingMembers());

            _albumServiceMock.Verify(service => service.UpdateAlbum(It.Is<Album>(a => a.Id == albumId)), Times.Once);
        }
        [Test]
        public void DeleteAlbum_NotFoundWhenDeleted()
        {
            // Arrange
            var albumId = 1;
            _albumServiceMock.Setup(service => service.DeleteAlbum(albumId));

            // Act
            var result = _albumController.DeleteAlbum(albumId); 

            // Assert
            result.Should().BeOfType<NoContentResult>(); 
            _albumServiceMock.Verify(service => service.DeleteAlbum(albumId), Times.Once); 
        }

    }
}
