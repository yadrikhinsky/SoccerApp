using System.Data.Entity;

namespace SoccerApp
{
    class SoccerContext : DbContext
    {
        public SoccerContext()
            : base("DefaultConnection")
        { }

        public DbSet<Player> Players { get; set; }
    }
}
