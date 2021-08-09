using Dapper;
using Microsoft.AspNetCore.Mvc;
using MultiTracksAPI.Interfaces;
using MultiTracksAPI.Models;
using MultiTracksAPI.Dto;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MultiTracksAPI.Repositories
{
    public class ArtistRepository: IArtistRepository
    {
        private readonly DBContext _context;
        public ArtistRepository(DBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Artist>> Get([FromQuery] ArtistQueryParameters parameters)
        {
            using var conn = _context.CreateConnection();
            IEnumerable<Artist> artists = await conn.QueryAsync<Artist>
                ("GetArtists", commandType: CommandType.StoredProcedure);

            if (!artists.Any()) return artists;

            // Apply query parameters
            IEnumerable<Artist> queriedArtists = artists.Skip((parameters.Page - 1) * parameters.Size)
                .Take(parameters.Size)
                .ToList();
            
            if (!queriedArtists.Any() || String.IsNullOrEmpty(parameters.Name)) return queriedArtists;

            queriedArtists = queriedArtists.Where(a => a.Title.ToLower().Contains(parameters.Name.Trim().ToLower()))
                .OrderBy(a => a.Title);
            return queriedArtists;
        }

        public async Task<int> Create(ArtistParameter artist)
        {
            using var conn = _context.CreateConnection();
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("title", artist.Title, DbType.String);
            parameters.Add("biography", artist.Biography, DbType.String);
            parameters.Add("imageURL", artist.ImageURL, DbType.String);
            parameters.Add("heroURL", artist.HeroURL, DbType.String);

            // Returning newly added artist's artistID to later add Albums and Songs for this newly added artist
            int artistID = await conn.QuerySingleAsync<int>("CreateArtist", parameters, commandType: CommandType.StoredProcedure);
            return artistID;
        }
    }
}