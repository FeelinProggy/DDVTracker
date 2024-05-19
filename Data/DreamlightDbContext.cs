using DDVTracker.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DDVTracker.Data
{
    public class DreamlightDbContext : IdentityDbContext
    {
        public DreamlightDbContext(DbContextOptions<DreamlightDbContext> options) : base(options)
        {
        }

        public DbSet<GameVersion> GameVersion { get; set; }
        public DbSet<Character> Characters { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Call the base class's OnModelCreating method
            base.OnModelCreating(modelBuilder); 

            modelBuilder.Entity<GameVersion>().HasData(
                new GameVersion { GameVersionId = 1, GameVersionName = "Base Game"},
                new GameVersion { GameVersionId = 2, GameVersionName = "A Rift In Time"}
            );

            modelBuilder.Entity<Location>().HasData(
                new Location { LocationId = 1, GameVersionId = 1, LocationName = "Plaza"},
                new Location { LocationId = 2, GameVersionId = 2, LocationName = "The Docks"}
            );

            modelBuilder.Entity<Character>().HasData(
                new Character { CharacterId = 1, GameVersionId = 1, CharacterName = "Mickey Mouse", CharacterLevel = 1 },
                new Character { CharacterId = 2, GameVersionId = 2, CharacterName = "Rapunzel", CharacterLevel = 5 }
            );

            modelBuilder.Entity<Fish>().HasData(
                new Fish { FishId = 1, GameVersionId = 1, FishName = "Bass", RippleColor = "white" },
                new Fish { FishId = 2, GameVersionId = 2, FishName = "Robot Fish", RippleColor = "blue" }
            );

            // Set up the foreign key relationship. One Theme to many characters
            modelBuilder.Entity<Character>().HasOne(c => c.GameVersion).WithMany(gv => gv.Characters).HasForeignKey(c => c.GameVersionId);

        }
        public DbSet<DDVTracker.Models.Fish> Fish { get; set; } = default!;


    }
}
