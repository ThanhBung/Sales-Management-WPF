using SE1611_Group3_A2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE1611_Group3_A2.Controller
{
    internal class ArtistController
    {
        MusicStoreContext context = new MusicStoreContext();
        public List<Artist> GetAllArtist()
        {
            return context.Artists.ToList();
        }
        public Artist GetArtistByArtistId(int artistId)
        {
            return context.Artists.FirstOrDefault(x => x.ArtistId == artistId);
        }
    }
}
