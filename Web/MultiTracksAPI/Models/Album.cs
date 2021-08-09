using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTracksAPI.Models
{
    public class Album
    {
        public int AlbumID { get; set; }
        public int ArtistID { get; set; }
        public DateTime DateCreation { get; set; }
        public string ImageURL { get; set; }
        public Dictionary<int, Song> Songs { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }

        public Album() { }
        public Album(Album other)
        {
            this.AlbumID = other.AlbumID;
            this.ArtistID = other.ArtistID;
            this.DateCreation = other.DateCreation;
            this.ImageURL = other.ImageURL;
            if (other.Songs != null) this.Songs = new Dictionary<int, Song>(other.Songs);  
            this.Title = other.Title;
            this.Year = other.Year;
        }
    }
}
