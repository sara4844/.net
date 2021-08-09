using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiTracksAPI.Interfaces;
using MultiTracksAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiTracksAPI.Controllers
{
    [Route("song")]
    [ApiController]
    public class SongController : ControllerBase
    {
        private readonly ISongRepository _songRepo;
        public SongController(ISongRepository songRepo)
        {
            _songRepo = songRepo;
        }

        [HttpGet("list")]
        public async Task<ActionResult<Song>> Get([FromQuery] SongQueryParameters parameters)
        {
            try
            {
                IEnumerable<Song> songs = await _songRepo.Get(parameters);
                return Ok(songs);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
