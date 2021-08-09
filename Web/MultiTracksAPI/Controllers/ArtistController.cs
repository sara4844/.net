using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiTracksAPI.Interfaces;
using MultiTracksAPI.Models;
using MultiTracksAPI.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiTracksAPI.Controllers
{
    [Route("artist")]
    [ApiController]
    public class ArtistController : ControllerBase
    {
        private readonly IArtistRepository _artistRepo;
        public ArtistController(IArtistRepository artistRepo)
        {
            _artistRepo = artistRepo;
        }

        [HttpGet("search")]
        public async Task<ActionResult<Artist>> Get([FromQuery] ArtistQueryParameters parameters)
        {
            try
            {
                IEnumerable<Artist> artists = await _artistRepo.Get(parameters);
                return Ok(artists);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("add")]
        public async Task<ActionResult<int>> Create(ArtistParameter artist)
        {
            try
            {
                int artistID = await _artistRepo.Create(artist);
                return Ok(artistID);
            } catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
