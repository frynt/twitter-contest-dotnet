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
        private readonly DuelService _twitterService;

        public ContestsController(
            twitter_contest_dotnetContext context,
            DuelService twiterService)
        {
            _context = context;
            _twitterService = twiterService;
        }

        // GET: api/Contests/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ContestDto>> GetContest(string id)
        {
            var contest = await _context.Contest.FindAsync(id);
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
            _context.SaveChanges();
            var contestDto = this._populateContestDto(contest);

            var tweeters = _context.Tweeter.ToList();


            return Ok(contestDto);
        }

        private ContestDto _populateContestDto(Contest contest)
        {
            var contestDto = new ContestDto();
            contestDto.Id = contest.Id;
            return contestDto;
        }
    }
}
