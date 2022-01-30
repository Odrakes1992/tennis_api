using System;
using Microsoft.EntityFrameworkCore;


namespace TennisClub.Models
{
    public class PlayerContext : DbContext
    {
      public PlayerContext(DbContextOptions<PlayerContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Player> Players { get; set; }
    }
}
