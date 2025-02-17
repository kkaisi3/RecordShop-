﻿using RecordShop.Data;
using RecordShop.Model;

namespace RecordShop.Services
{
    public interface IAlbumService
    {
        List<Album> GetAllAlbums();
        Album GetAlbumById(int id);

        Album CreateAlbum(Album album);

        void UpdateAlbum(Album album);

        void DeleteAlbum(int id);

    }
    public class AlbumService : IAlbumService
    {
        private readonly IAlbumRepository _albumRepository;

        public AlbumService(IAlbumRepository albumRepository)
        {
            _albumRepository = albumRepository;
        }

        public List<Album> GetAllAlbums()
        {
            return _albumRepository.GetAllAlbums();
        }

        public Album GetAlbumById(int id)
        {
            return _albumRepository.GetAlbumById(id);
        }

        public Album CreateAlbum(Album album)
        {
            return _albumRepository.CreateAlbum(album);
        }

        public void UpdateAlbum(Album album)
        {
            _albumRepository.UpdateAlbum(album);
        }

        public void DeleteAlbum(int id)
        {
            _albumRepository.DeleteAlbum(id);
        }

     
    }
}
