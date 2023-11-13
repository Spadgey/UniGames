using Microsoft.EntityFrameworkCore;
using UniGames.Api.Models.Domain;

namespace UniGames.Api.Data

{
    public class UniGamesDbContext: DbContext
    {
        public UniGamesDbContext(DbContextOptions dbContextOptions): base(dbContextOptions) 
        {
        
        }

        public DbSet<Game> Game { get; set; }

        public DbSet<Platform> Platform { get; set; }

        public DbSet<Review> Review { get; set; }

        public DbSet<User> User { get; set; }
    }
}
