using Microsoft.AspNetCore.Mvc;
using MultiTracksAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiTracksAPI.Interfaces
{
    public interface ISongRepository
    {
        public Task<IEnumerable<Song>> Get(SongQueryParameters parameters);
    }
}
