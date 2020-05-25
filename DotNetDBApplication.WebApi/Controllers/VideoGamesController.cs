using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DotNet.DataAccess;
using DotNet.Models;

namespace DotNet.DBApplication.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoGamesController : ControllerBase
    {
        private readonly DotNetContext _context;

        public VideoGamesController(DotNetContext context)
        {
            _context = context;
        }

        // GET: api/VideoGames
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VideoGame>>> GetVideoGames()
        {
            return await _context.VideoGames.ToListAsync();
        }

        // GET: api/VideoGames/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VideoGame>> GetVideoGame(int id)
        {
            var videoGame = await _context.VideoGames.FindAsync(id);

            if (videoGame == null)
            {
                return NotFound();
            }

            return videoGame;
        }

        // PUT: api/VideoGames/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVideoGame(int id, VideoGame videoGame)
        {
            if (id != videoGame.GameId)
            {
                return BadRequest();
            }

            _context.Entry(videoGame).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VideoGameExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/VideoGames
        [HttpPost]
        public async Task<ActionResult<VideoGame>> PostVideoGame(VideoGame videoGame)
        {
            _context.VideoGames.Add(videoGame);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (VideoGameExists(videoGame.GameId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetVideoGame", new { id = videoGame.GameId }, videoGame);
        }

        // DELETE: api/VideoGames/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<VideoGame>> DeleteVideoGame(int id)
        {
            var videoGame = await _context.VideoGames.FindAsync(id);
            if (videoGame == null)
            {
                return NotFound();
            }

            _context.VideoGames.Remove(videoGame);
            await _context.SaveChangesAsync();

            return videoGame;
        }

        private bool VideoGameExists(int id)
        {
            return _context.VideoGames.Any(e => e.GameId == id);
        }
    }
}
