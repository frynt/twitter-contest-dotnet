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
using twitter_contest_dotnet.Services;

namespace twitter_contest_dotnet.Controllers
{
    [Route("api/tweeters/twitter")]
    [ApiController]
    public class TweeterTwitterController : ControllerBase
    {
        private readonly twitter_contest_dotnetContext _context;
        private readonly ITwitterService _twitterService;

        public TweeterTwitterController(
            twitter_contest_dotnetContext context,
            ITwitterService twitterService)
        {
            _context = context;
            _twitterService = twitterService;
        }

        // POST: api/Tweeters
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TweeterTwitterDto>> PostTweeterTwitter(TweeterTwitterDto tweeterTwitterDto)
        {
            twitter_contest_dotnet.Services.User twitterUser = await this._twitterService.GetUserByUsername(tweeterTwitterDto.Username); 
            if (_context.Tweeter.Where(item => item.TwitterUserId == twitterUser.Id).Count() >= 1)
            {
                return BadRequest(new { error =  "twitterUserId is already present" });
            }
            Tweeter tweeter = new Tweeter();
            tweeter.Name = tweeterTwitterDto.Name;
            tweeter.TwitterUserId = twitterUser.Id;
            _context.Tweeter.Add(tweeter);
            await _context.SaveChangesAsync();
            //return CreatedAtAction(nameof(GetTweeterAsync), new { id = tweeter.Id });
            return Ok(new { id = tweeter.Id });
        }

    }
}
