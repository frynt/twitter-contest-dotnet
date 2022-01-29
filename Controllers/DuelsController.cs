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
        private readonly IDuelService _duelService;

        public DuelsController(
            twitter_contest_dotnetContext context,
            IDuelService duelService)
        {
            _context = context;
            _duelService = duelService;
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
                TweeterALikes = duel.UserProposalTweeterId != null ? duel.TweeterALikes : null,
                TweeterBLikes = duel.UserProposalTweeterId != null ? duel.TweeterBLikes : null,
                isWin = duel.UserProposalTweeterId == duel.ResponseTweeterId,
                ResponseTweeterId = duel.ResponseTweeterId
            });
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<DuelDto>> PatchDuel(string id,
        [FromBody] DuelDtoPatch duelDto)
        {
            if (duelDto != null)
            {
                var duel = this._context.Duel.Find(id);

                duel.UserProposalTweeterId = duelDto.UserProposalTweeterId;

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                _context.SaveChanges();
                return await this.GetDuel(id);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}
