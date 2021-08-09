using Microsoft.AspNetCore.Mvc;
using MultiTracksAPI.Dto;
using MultiTracksAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiTracksAPI.Interfaces
{
    public interface IArtistRepository
    {
        public Task<IEnumerable<Artist>> Get([FromQuery] ArtistQueryParameters parameters);
        public Task<int> Create(ArtistParameter artist);
    }
}
