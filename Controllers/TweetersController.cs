#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using twitter_contest_dotnet.Data;
using twitter_contest_dotnet.Dto;
using twitter_contest_dotnet.Models;
using twitter_contest_dotnet.Paging;
using twitter_contest_dotnet.Services;

namespace twitter_contest_dotnet.Controllers
{
    [Route("api/tweeters")]
    [ApiController]
    public class TweetersController : ControllerBase
    {
        private readonly twitter_contest_dotnetContext _context;
        private readonly ITwitterService _twitterService;

        public TweetersController(
            twitter_contest_dotnetContext context,
            ITwitterService twiterService)
        {
            _context = context;
            _twitterService = twiterService;
        }

        // GET: api/Tweeters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TweeterDto>>> GetTweeter([FromQuery] PagingParameterModel pagingParameterModel)
        {
            var tweetersSource = (from tweeter in _context.Tweeter.OrderBy(tweeter => tweeter.Name) select tweeter).AsQueryable();
            // Get's No of Rows Count   
            int count = tweetersSource.Count();

            // Parameter is passed from Query string if it is null then it default Value will be pageNumber:1  
            int CurrentPage = pagingParameterModel.pageNumber;

            // Parameter is passed from Query string if it is null then it default Value will be pageSize:20  
            int PageSize = pagingParameterModel.pageSize;

            // Display TotalCount to Records to User  
            int TotalCount = count;

            // Calculating Totalpage by Dividing (No of Records / Pagesize)  
            int TotalPages = (int)Math.Ceiling(count / (double)PageSize);

            // Returns List of Customer after applying Paging   
            var tweeters = tweetersSource.Skip((CurrentPage - 1) * PageSize).Take(PageSize).ToList();

            // if CurrentPage is greater than 1 means it has previousPage  
            var previousPage = CurrentPage > 1 ? "Yes" : "No";

            // if TotalPages is greater than CurrentPage means it has nextPage  
            var nextPage = CurrentPage < TotalPages ? "Yes" : "No";

            // Object which we are going to send in header   
            var paginationMetadata = new
            {
                totalCount = TotalCount,
                pageSize = PageSize,
                currentPage = CurrentPage,
                totalPages = TotalPages,
                previousPage,
                nextPage
            };
            var tweeterTwitters = await _twitterService.GetUsersByIds(ids: tweeters.Select(tweeter => tweeter.TwitterUserId).ToArray());
            Response.Headers.Add("Paging-Headers", JsonConvert.SerializeObject(paginationMetadata));
            return Ok(tweeters.Select(t => {
                var tweeterTwitter = tweeterTwitters.First(user => user.Id == t.TwitterUserId);
                return new TweeterDto {
                    Id = t.Id,
                    ProfilePictureURL = tweeterTwitter.ProfilePictureURL,
                    Username = tweeterTwitter.Username,
                    Name = tweeterTwitter.Name
                };
            }));
        }

        // GET: api/Tweeters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TweeterDto>> GetTweeter(string id)
        {
            var tweeter = await _context.Tweeter.FindAsync(id);
            var tweeterTwitters = await _twitterService.GetUsersByIds(ids: new string[] {id});

            if (tweeter == null)
            {
                return NotFound();
            }

            return Ok(new TweeterDto
            {
                Id = tweeter.Id,
                ProfilePictureURL = tweeterTwitters.First().ProfilePictureURL,
                Username = tweeterTwitters.First().Username,
                Name = tweeterTwitters.First().Name,
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
