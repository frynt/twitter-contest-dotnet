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
    [Route("api/duels")]
    [ApiController]
    public class DuelsController : ControllerBase
    {
        private readonly twitter_contest_dotnetContext _context;
        private readonly DuelService _twitterService;

        public DuelsController(
            twitter_contest_dotnetContext context,
            DuelService twiterService)
        {
            _context = context;
            _twitterService = twiterService;
        }

        // GET: api/Duels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DuelDto>> GetDuel(string id)
        {
            var duel = await _context.Duel.FindAsync(id);

            if (duel == null)
            {
                return NotFound();
            }

            return Ok(new DuelDto
            {
                Id = duel.Id,
                ProposalTweeterAId = duel.ProposalTweeterAId,
                ProposalTweeterBId = duel.ProposalTweeterBId,
                TweeterALikes = duel.TweeterALikes,
                TweeterBLikes = duel.TweeterBLikes
            });
        }
    }
}
