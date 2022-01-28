#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using twitter_contest_dotnet.Data;
using twitter_contest_dotnet.Dto;
using twitter_contest_dotnet.Models;

namespace twitter_contest_dotnet.Controllers
{
    [Route("api/tweeters")]
    [ApiController]
    public class TweetersController : ControllerBase
    {
        private readonly twitter_contest_dotnetContext _context;

        public TweetersController(twitter_contest_dotnetContext context)
        {
            _context = context;
        }

        // GET: api/Tweeters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TweeterDto>>> GetTweeter()
        {
            var tweeters = await _context.Tweeter.ToListAsync();
            return Ok(tweeters.Select(t => new TweeterDto{
                Id = t.Id,
                ProfilePictureURL = "lolpicture",
                Username = "username"
            }));
        }

        // GET: api/Tweeters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TweeterDto>> GetTweeter(string id)
        {
            var tweeter = await _context.Tweeter.FindAsync(id);

            if (tweeter == null)
            {
                return NotFound();
            }

            return Ok(new TweeterDto
            {
                Id = tweeter.Id,
                ProfilePictureURL = "lolpicture",
                Username = "username"
            });
        }

        // DELETE: api/Tweeters/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTweeter(string id)
        {
            var tweeter = await _context.Tweeter.FindAsync(id);
            if (tweeter == null)
            {
                return NotFound();
            }

            _context.Tweeter.Remove(tweeter);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
