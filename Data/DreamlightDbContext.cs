using DDVTracker.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Drawing;
using System.Text.RegularExpressions;

namespace DDVTracker.Data
{
    public class DreamlightDbContext : IdentityDbContext
    {
        public DreamlightDbContext(DbContextOptions<DreamlightDbContext> options) : base(options)
        {
        }

        public DbSet<GameVersion> GameVersion { get; set; }
        public DbSet<Character> Characters { get; set; }

        public DbSet<Location> Locations { get; set; }

        public DbSet<Fish> Fish { get; set; }

        public DbSet<FishLocation> FishLocations { get; set; }



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
                new Location { LocationId = 2, GameVersionId = 1, LocationName = "Peaceful Meadow" },
                new Location { LocationId = 3, GameVersionId = 1, LocationName = "Forest of Valor" },
                new Location { LocationId = 4, GameVersionId = 1, LocationName = "Sunlit Plateau" },
                new Location { LocationId = 5, GameVersionId = 2, LocationName = "The Oasis" },
                new Location { LocationId = 6, GameVersionId = 2, LocationName = "The Grasslands" },
                new Location { LocationId = 7, GameVersionId = 2, LocationName = "The Promenade" },
                new Location { LocationId = 8, GameVersionId = 2, LocationName = "The Docks"}
            );

            modelBuilder.Entity<Character>().HasData(
                new Character { CharacterId = 1, GameVersionId = 1, CharacterName = "Mickey Mouse", CharacterLevel = 1 },
                new Character { CharacterId = 2, GameVersionId = 2, CharacterName = "Rapunzel", CharacterLevel = 5 }
            );

            modelBuilder.Entity<Fish>().HasData(
                new Fish { FishId = 1, GameVersionId = 1, FishName = "Bass", RippleColor = "white" },
                new Fish { FishId = 2, GameVersionId = 2, FishName = "Robot Fish", RippleColor = "blue" }
            );

            modelBuilder.Entity<FishLocation>().HasData(
                new FishLocation { FishLocationId = 1, FishId = 1, LocationId = 1 },
                new FishLocation { FishLocationId = 2, FishId = 1, LocationId = 1 },
                new FishLocation { FishLocationId = 3, FishId = 1, LocationId = 1 },
                new FishLocation { FishLocationId = 4, FishId = 1, LocationId = 1 },
                new FishLocation { FishLocationId = 5, FishId = 2, LocationId = 2 }
            );

            // Set up the foreign key relationship. One Theme to many characters
            modelBuilder.Entity<Character>().HasOne(c => c.GameVersion).WithMany(gv => gv.Characters).HasForeignKey(c => c.GameVersionId);

            modelBuilder.Entity<FishLocation>()
                .HasOne(fl => fl.Fish)
                .WithMany(f => f.FishLocations)
                .HasForeignKey(fl => fl.FishId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<FishLocation>()
                .HasOne(fl => fl.Location)
                .WithMany(l => l.FishLocations)
                .HasForeignKey(fl => fl.LocationId)
                .OnDelete(DeleteBehavior.Cascade);

        }


    }
}
