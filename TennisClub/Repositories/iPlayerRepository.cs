using System;
using TennisClub.Models;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace TennisClub.Repositories
{
    public interface iPlayerRepository
    {
        Task<IEnumerable<Player>> Get();
        Task<Player> Get(int id);
        Task<Player> Create(Player player);
        Task Update(Player player);
        Task Delete(int id);
    }
}
