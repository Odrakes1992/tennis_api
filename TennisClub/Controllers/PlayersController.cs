using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TennisClub.Models;
using TennisClub.Repositories;

namespace TennisClub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase

    {
        private readonly iPlayerRepository _playerRepository;

        public PlayersController(iPlayerRepository playerRepository)

        {
            _playerRepository = playerRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Player>> GetPlayers()
        {
        return await _playerRepository.Get();
        }


        [HttpGet("{id}")]

        public async Task<ActionResult<Player>> GetPlayers(int id)
        {
        return await _playerRepository.Get(id);
        }

        [HttpPost]

        public async Task<ActionResult<Player>>PostPlayers([FromBody] Player player)

        {
            if (ModelState.IsValid)
            {
                var newPlayer = await _playerRepository.Create(player);
             return CreatedAtAction(nameof(GetPlayers), new {id = newPlayer.Id}, newPlayer);
                //return NoContent();
            } else
            {
                return BadRequest();
            }
        }



        [HttpPut]

        public async Task<ActionResult> PutPlayers(int id, [FromBody] Player player)
        {
            if(id != player.Id)
            {
                return BadRequest();
            }

            await _playerRepository.Update(player);

            return NoContent();

        }
    }
}