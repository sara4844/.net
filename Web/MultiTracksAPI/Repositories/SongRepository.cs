using Dapper;
using Microsoft.AspNetCore.Mvc;
using MultiTracksAPI.Interfaces;
using MultiTracksAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MultiTracksAPI.Repositories
{
    public class SongRepository: ISongRepository
    {
        private readonly DBContext _context;
        public SongRepository(DBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Song>> Get(SongQueryParameters parameters)
        {
            using var connection = _context.CreateConnection();
            IEnumerable<Song> songs = await connection.QueryAsync<Song>
                ("GetSongs", commandType: CommandType.StoredProcedure);

            if (!songs.Any()) return songs;

            // Apply query parameters
            IEnumerable<Song> queriedSongs = songs.Skip((parameters.Page - 1) * parameters.Size)
                .Take(parameters.Size)
                .ToList();

            return queriedSongs;
        }
    }
}
