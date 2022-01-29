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
    [Route("api/contests")]
    [ApiController]
    public class ContestsController : ControllerBase
    {
        private readonly twitter_contest_dotnetContext _context;
        private readonly ITwitterService _twitterService;
        private readonly IDuelService _duelService;

        public ContestsController(
            twitter_contest_dotnetContext context,
            ITwitterService twitterService,
            IDuelService duelService)
     {
            _context = context;
            _twitterService = twitterService;
            _duelService = duelService;
        }

        // GET: api/Contests/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ContestDto>> GetContest(string id)
        {
            var contest = await _context.Contest.Include("Duels").FirstAsync(contest => contest.Id == id);
            var contestDto = this._populateContestDto(contest);

            if (contest == null)
            {
                return NotFound();
            }

            return Ok(contestDto);
        }

        [HttpPost]
        public async Task<ActionResult<ContestDto>> CreateContest()
        {
            var contest = (await _context.Contest.AddAsync(new Contest())).Entity;
            contest.Duels = new List<Duel>();
            _context.SaveChanges();

            var tweeters = _context.Tweeter.ToList();
            var likesByTweeterId = new Dictionary<string, int>();
            foreach (Tweeter tweeter in tweeters)
            {
                var likes = await this._twitterService.GetTweetsLike(tweeter.TwitterUserId);
                likesByTweeterId.Add(tweeter.Id, likes);
            }
            var duelLights = this._duelService.GenerateDuelLights(tweeters, likesByTweeterId);
            foreach (DuelLight duelLight in duelLights)
            {
                var duel = new Duel()
                {
                    ContestId = contest.Id,
                    ProposalTweeterAId = duelLight.TweeterA.Id,
                    ProposalTweeterBId = duelLight.TweeterB.Id,
                    ResponseTweeterId = duelLight.LikesTweeterA > duelLight.LikesTweeterB ?
                        duelLight.TweeterA.Id : duelLight.TweeterB.Id,
                    TweeterALikes = duelLight.LikesTweeterA,
                    TweeterBLikes = duelLight.LikesTweeterB,
                };
                contest.Duels.Add(duel);
                _context.Duel.Add(duel);
            }
            _context.SaveChanges();
            var contestDto = this._populateContestDto(contest);


            return Ok(contestDto);
        }

        private ContestDto _populateContestDto(Contest contest)
        {
            var contestDto = new ContestDto();
            contestDto.Id = contest.Id;
            contestDto.NextDuelsIds = contest.Duels
                .Where(contest => contest.UserProposalTweeterId == null)
                .Select(contest => contest.Id).ToArray();
            contestDto.PreviousDuelsIds = contest.Duels
            .Where(contest => contest.UserProposalTweeterId != null)
            .Select(contest => contest.Id).ToArray();
            return contestDto;
        }
    }
}
