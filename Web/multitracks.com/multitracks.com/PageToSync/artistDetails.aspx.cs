using DataAccess;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PageToSync_artistDetails : System.Web.UI.Page
{
    protected Artist Artist;
    protected Dictionary<int, Album> Albums;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            // Retrieve artistID parameter
            int artistID = Convert.ToInt32(Request.QueryString["artistID"]);
            Artist = new Artist();
            Albums = new Dictionary<int, Album>();
            Dictionary<int, Song> songs = new Dictionary<int, Song>();

            SQL sql = new SQL();
            try
            {
                // Retrieve all artist details for the given parameter of artistID
                sql.Parameters.Add("@artistID", artistID);
                DataTable data = sql.ExecuteStoredProcedureDT("GetArtistDetails");

                // Consume and process data 
                foreach (DataRow row in data.Rows)
                {
                    // Save info for current artist once
                    if (string.IsNullOrEmpty(Artist.Title))
                    {
                        Artist.ArtistID = artistID;
                        Artist.Biography = (string)row["biography"];
                        Artist.DateCreation = (DateTime)row["Artist_DateCreation"];
                        Artist.HeroURL = (string)row["heroURL"];
                        Artist.ImageURL = (string)row["Artist_ImageURL"];
                        Artist.Title = (string)row["Artist_Title"];
                    }

                    // Store all song related info for this row
                    int songID = (int)row["songID"];
                    int albumID = (int)row["albumID"];
                    Song song = new Song()
                    {
                        AlbumID = albumID,
                        ArtistID = artistID,
                        Bpm = (decimal)row["bpm"],
                        Chart = (bool)row["chart"],
                        CustomMix = (bool)row["customMix"],
                        DateCreation = (DateTime)row["Song_DateCreation"],
                        MultiTracks = (bool)row["multitracks"],
                        Patches = (bool)row["patches"],
                        ProPresenter = (bool)row["proPresenter"],
                        RehearsalMix = (bool)row["rehearsalMix"],
                        SongID = songID,
                        SongSpecificPatches = (bool)row["songSpecificPatches"],
                        TimeSignature = (string)row["timeSignature"],
                        Title = (string)row["Song_Title"]
                    };
                    songs.Add(songID, song);

                    // Store album related info for current row only if not present
                    if (!Albums.ContainsKey(albumID))
                    {
                        Album album = new Album()
                        {
                            AlbumID = albumID,
                            ArtistID = artistID,
                            DateCreation = (DateTime)row["Album_DateCreation"],
                            ImageURL = (string)row["Album_ImageURL"],
                            Title = (string)row["Album_Title"],
                            Year = (int)row["year"]
                        };
                        album.Songs = new Dictionary<int, Song>()
                        {
                            {songID, song }
                        };
                        Albums.Add(albumID, album);
                    }
                    else // Only add new song info
                    {
                        Albums[albumID].Songs.Add(songID, song);
                    }
                }

                // Update page elements with appropriate data
                albumInfo.DataSource = Albums.Values;
                albumInfo.DataBind();
                // Here further logic can be applied to determine top songs from list of songs
                topSongInfo.DataSource = songs.Values?.Take(3);
                topSongInfo.DataBind();

                // Only display short excerpt of Bio
                string newBioHTML = "";
                if (!String.IsNullOrEmpty(Artist.Biography))
                {
                    int indexOfReadMore = Artist.Biography.IndexOf("<!-- read more -->");
                    string bioExcerpt = Artist.Biography.Substring(0, indexOfReadMore).Trim();
                    string[] bioExcerptPTag = bioExcerpt.Split('\n');
                    foreach (string paragraph in bioExcerptPTag)
                    {
                        newBioHTML += "<p>" + paragraph + "</p>";
                    }
                    artistDetailsBio.InnerHtml = newBioHTML + artistDetailsBio.InnerHtml;
                }
                else
                {
                    // There is nothing yet to read
                    artistDetailsBio.InnerHtml = "<p>" + Artist.Title + "</p>";
                }
            }
            catch
            {
                Console.WriteLine("Failed to retrieve artist info from DB");
            }
        }
        catch
        {
            Console.WriteLine("No artistID");
        }
    }
}