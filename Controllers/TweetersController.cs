#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using twitter_contest_dotnet.Data;
using twitter_contest_dotnet.Models;

namespace twitter_contest_dotnet.Controllers
{
    [Route("api/[controller]")]
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
        public async Task<ActionResult<IEnumerable<Tweeter>>> GetTweeter()
        {
            return await _context.Tweeter.ToListAsync();
        }

        // GET: api/Tweeters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tweeter>> GetTweeter(int id)
        {
            var tweeter = await _context.Tweeter.FindAsync(id);

            if (tweeter == null)
            {
                return NotFound();
            }

            return tweeter;
        }

        // PUT: api/Tweeters/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTweeter(int id, Tweeter tweeter)
        {
            if (id != tweeter.Id)
            {
                return BadRequest();
            }

            _context.Entry(tweeter).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TweeterExists(id))
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

        // POST: api/Tweeters
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tweeter>> PostTweeter(Tweeter tweeter)
        {
            _context.Tweeter.Add(tweeter);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTweeter", new { id = tweeter.Id }, tweeter);
        }

        // DELETE: api/Tweeters/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTweeter(int id)
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

        private bool TweeterExists(int id)
        {
            return _context.Tweeter.Any(e => e.Id == id);
        }
    }
}
