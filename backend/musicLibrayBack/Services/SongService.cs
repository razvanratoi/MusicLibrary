using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using musicLibrayBack.Models;
using musicLibrayBack.Repositories;

namespace musicLibrayBack.Services;
    public class SongService
    {
        private readonly SongRepository _songRepository;
        private readonly AlbumRepository _albumRepository;

        public SongService(SongRepository songRepository, AlbumRepository albumRepository)
        {
            _songRepository = songRepository;
            _albumRepository = albumRepository;
        }

        public async Task<IEnumerable<Song>> GetSongsAsync()
        {
            return await _songRepository.GetAllAsync();
        }

        public async Task<IEnumerable<Song>> GetSongsByAlbumIdAsync(Guid albumId)
        {
            return await _songRepository.GetSongsByAlbumIdAsync(albumId);
        }

        public async Task<Song> GetSongByIdAsync(Guid songId)
        {
            return await _songRepository.GetByIdAsync(songId);
        }

        public async Task AddSongAsync(Song song)
        {
            var album = await _albumRepository.GetByIdAsync(song.AlbumId);
            if (album == null)
            {
                throw new ArgumentException("Invalid AlbumId");
            }

            song.Id = Guid.NewGuid();
            await _songRepository.AddAsync(song);
        }

        public async Task UpdateSongAsync(Song song)
        {
            var album = await _albumRepository.GetByIdAsync(song.AlbumId);
            if (album == null)
            {
                throw new ArgumentException("Invalid AlbumId");
            }

            await _songRepository.UpdateAsync(song);
        }

        public async Task DeleteSongAsync(Guid songId)
        {
            await _songRepository.DeleteAsync(songId);
        }
    }
