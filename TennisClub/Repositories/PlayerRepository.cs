using System;
using TennisClub.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;


namespace TennisClub.Repositories
{
    public class PlayerRepository : iPlayerRepository

    {
        private readonly PlayerContext _context;

        public PlayerRepository(PlayerContext context)
        {
            _context = context;
        }

        public async Task<Player> Create(Player player)
        {
            _context.Players.Add(player);
            await _context.SaveChangesAsync();

            return player;
        }

        public async Task Delete(int id)
        {
            var playerToDelete = await _context.Players.FindAsync(id);
            _context.Players.Remove(playerToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Player>> Get()
        {
            return await _context.Players.ToListAsync();
        }

        public async Task<Player> Get(int id)
        {
            return await _context.Players.FindAsync(id);
        }

        public async Task Update(Player player)
        {
            _context.Entry(player).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
