using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class Song
    {
        public int AlbumID { get; set; }
        public int ArtistID { get; set; }
        public decimal Bpm { get; set; }
        public bool Chart { get; set; }
        public bool CustomMix { get; set; }
        public DateTime DateCreation { get; set; }
        public bool MultiTracks { get; set; }
        public bool Patches { get; set; }
        public bool ProPresenter { get; set; }
        public bool RehearsalMix { get; set; }
        public int SongID { get; set; }
        public bool SongSpecificPatches { get; set; }
        public string TimeSignature { get; set; }
        public string Title { get; set; }

        public Song() { }
        public Song(Song other)
        {
            this.AlbumID = other.AlbumID;
            this.ArtistID = other.ArtistID;
            this.Bpm = other.Bpm;
            this.Chart = other.Chart;
            this.CustomMix = other.CustomMix;
            this.DateCreation = other.DateCreation;
            this.MultiTracks = other.MultiTracks;
            this.Patches = other.Patches;
            this.ProPresenter = other.ProPresenter;
            this.RehearsalMix = other.RehearsalMix;
            this.SongID = other.SongID;
            this.SongSpecificPatches = other.SongSpecificPatches;
            this.TimeSignature = other.TimeSignature;
            this.Title = other.Title;
        }
    }
}
