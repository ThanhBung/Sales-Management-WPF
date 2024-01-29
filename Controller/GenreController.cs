using SE1611_Group3_A2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE1611_Group3_A2.Controller
{
    internal class GenreController
    {
        MusicStoreContext context = new MusicStoreContext();
        public List<Genre> GetAllGenre()
        {
            return context.Genres.ToList();
        }
        public Genre GetGenreByGenreId(int genreId)
        {
            return context.Genres.FirstOrDefault(x => x.GenreId == genreId);
        }

    }
}
