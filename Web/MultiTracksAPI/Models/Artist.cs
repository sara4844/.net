using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTracksAPI.Models
{
    public class Artist
    {
        public int ArtistID { get; set; }
        public string Biography { get; set; }
        public DateTime DateCreation { get; set; }
        public string HeroURL { get; set; }
        public string ImageURL { get; set; }
        public string Title { get; set; }
                
        public Artist() { }
        public Artist(Artist other)
        {
            this.ArtistID = other.ArtistID;
            this.Biography = other.Biography;
            this.DateCreation = other.DateCreation;
            this.HeroURL = other.HeroURL;
            this.ImageURL = other.ImageURL;
            this.Title = other.Title;
        }
    }
}
