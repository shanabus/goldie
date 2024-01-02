using Microsoft.EntityFrameworkCore;

// help on setup and migrations here: https://learn.microsoft.com/en-us/ef/core/get-started/overview/first-app?tabs=netcore-cli

namespace Goldie.Data
{
    public class GoldieDbContext : DbContext
    {
        public GoldieDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Player> Players { get; set; }

        public DbSet<Question> Questions { get; set; }


        public DbSet<Answer> Answers { get; set; }
    }
}
