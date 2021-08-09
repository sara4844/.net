using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiTracksAPI.Dto
{
    public class ArtistParameter
    {
        public int ArtistID { get; set; }
        public string Biography { get; set; }
        public DateTime DateCreation { get; set; }
        public string HeroURL { get; set; }
        public string ImageURL { get; set; }
        public string Title { get; set; }
    }
}
