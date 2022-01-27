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
    [Route("api/tweeters/linkedins")]
    [ApiController]
    public class TweeterLinkedinsController : ControllerBase
    {
        private readonly twitter_contest_dotnetContext _context;

        public TweeterLinkedinsController(twitter_contest_dotnetContext context)
        {
            _context = context;
        }

        // POST: api/Tweeters
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TweeterLinkedin>> PostTweeterLinkedin(TweeterLinkedin tweeterLinkedin)
        {
            Tweeter tweeter = new Tweeter();
            tweeter.Name = tweeterLinkedin.Name;
            tweeter.LinkedinUserId = 10;
            _context.Tweeter.Add(tweeter);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTweeter", new { id = tweeter.Id }, tweeter);
        }

    }
}
