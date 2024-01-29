using SE1611_Group3_A2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE1611_Group3_A2.Controller
{
    internal class AlbumController
    {
        MusicStoreContext context = new MusicStoreContext();
        public List<Album> GetAllAlbums()
        {
            return context.Albums.ToList();
        }

        public Album GetAlbumByAlbumId(int albumId)
        {
            return context.Albums.FirstOrDefault(x => x.AlbumId == albumId);
        }
        public List<Album> GetAlbumsByGenreId(int genreId)
        {
            return context.Albums.Where(x => x.GenreId == genreId).ToList();
        }

        public List<Album> GetAlbumsByLimitOffet(int page, int genreId)
        {
            // select all
            if (genreId == 0)
            {
                return context.Albums.OrderBy(x => x.AlbumId).Skip(page * 4).Take(4).ToList();
            }
            // select genre
            else
            {
                return context.Albums.OrderBy(x => x.AlbumId).Where(x => x.GenreId == genreId).Skip(page * 4).Take(4).ToList();
            }
        }
        public void AddAlbum(Album album)
        {
            context.Albums.Add(album);
            context.SaveChanges();
        }
        public void RemoveAlbum(Album album)
        {
            context.Albums.Remove(album);
            context.SaveChanges();
        }
        public void UpdateAlbum(Album album)
        {
            Album newAlbum = context.Albums.FirstOrDefault(x => x.AlbumId == album.AlbumId);
            newAlbum.GenreId = album.GenreId;
            newAlbum.ArtistId = album.ArtistId;
            newAlbum.Title = album.Title;
            newAlbum.Price = album.Price;
            newAlbum.AlbumUrl = album.AlbumUrl;
            context.SaveChanges();
        }
    }
}
