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
                new Location { LocationId = 1, GameVersionId = 1, LocationName = "Plaza" },
                new Location { LocationId = 2, GameVersionId = 1, LocationName = "Peaceful Meadow" },
                new Location { LocationId = 3, GameVersionId = 1, LocationName = "Dazzle Beach", Cost = "1000 Dreamlight" },
                new Location { LocationId = 4, GameVersionId = 1, LocationName = "Forest of Valor", Cost = "3000 Dreamlight" },
                new Location { LocationId = 5, GameVersionId = 1, LocationName = "Glade of Trust", Cost = "5000 Dreamlight" },
                new Location { LocationId = 6, GameVersionId = 1, LocationName = "Sunlit Plateau", Cost = "7000 Dreamlight" },
                new Location { LocationId = 7, GameVersionId = 1, LocationName = "Frosted Heights", Cost = "10000 Dreamlight" },
                new Location { LocationId = 8, GameVersionId = 1, LocationName = "Forgotten Lands", Cost = "15000 Dreamlight" },
                new Location { LocationId = 9, GameVersionId = 2, LocationName = "Ancient's Landing" },
                new Location { LocationId = 10, GameVersionId = 2, LocationName = "Glittering Dunes" },
                new Location { LocationId = 11, GameVersionId = 2, LocationName = "Wild Tangle" },
                new Location { LocationId = 12, GameVersionId = 2, LocationName = "The Docks" },
                new Location { LocationId = 13, GameVersionId = 2, LocationName = "The Overlook", Cost = "6000 Mist" },
                new Location { LocationId = 14, GameVersionId = 2, LocationName = "The Ruins", Cost = "10000 Mist" },
                new Location { LocationId = 15, GameVersionId = 2, LocationName = "The Courtyard" },
                new Location { LocationId = 16, GameVersionId = 2, LocationName = "The Plains" },
                new Location { LocationId = 17, GameVersionId = 2, LocationName = "The Wastes", Cost = "4000 Mist" },
                new Location { LocationId = 18, GameVersionId = 2, LocationName = "The Oasis", Cost = "6000 Mist" },
                new Location { LocationId = 19, GameVersionId = 2, LocationName = "The Borderlands", Cost = "10000 Mist" },
                new Location { LocationId = 20, GameVersionId = 2, LocationName = "The Grasslands", Cost = "2000 Mist" },
                new Location { LocationId = 21, GameVersionId = 2, LocationName = "The Grove", Cost = "4000 Mist" },
                new Location { LocationId = 22, GameVersionId = 2, LocationName = "The Promenade", Cost = "6000 Mist" },
                new Location { LocationId = 23, GameVersionId = 2, LocationName = "The Lagoon", Cost = "10000 Mist" },
                new Location { LocationId = 24, GameVersionId = 1, LocationName = "Beauty and the Beast Realm", Cost = "12500 Dreamlight" },
                new Location { LocationId = 25, GameVersionId = 1, LocationName = "Frozen Realm", Cost = "4000 Dreamlight" },
                new Location { LocationId = 26, GameVersionId = 1, LocationName = "Moana Realm", Cost = "3000 Dreamlight" },
                new Location { LocationId = 27, GameVersionId = 1, LocationName = "Monsters, Inc. Realm", Cost = "15000 Dreamlight" },
                new Location { LocationId = 28, GameVersionId = 1, LocationName = "Ratatouille Realm", Cost = "3000 Dreamlight" },
                new Location { LocationId = 29, GameVersionId = 1, LocationName = "The Lion King Realm", Cost = "10000 Dreamlight" },
                new Location { LocationId = 30, GameVersionId = 1, LocationName = "Toy Story Realm", Cost = "7000 Dreamlight" },
                new Location { LocationId = 31, GameVersionId = 1, LocationName = "WALL-E Realm", Cost = "3000 Dreamlight" },
                new Location { LocationId = 32, GameVersionId = 1, LocationName = "Chez Remy"}

            );

            modelBuilder.Entity<Character>().HasData(
                new Character { CharacterId = 1, GameVersionId = 1, CharacterName = "Anna", AcquiredBy = "Realm", AcquiredFrom = "Frozen Realm", Notes = "Unlock Realm" },
                new Character { CharacterId = 2, GameVersionId = 1, CharacterName = "Ariel", AcquiredBy = "Quest", AcquiredFrom = "Goofy", Notes = "The Mysterious Wreck" },
                new Character { CharacterId = 3, GameVersionId = 1, CharacterName = "Belle", AcquiredBy = "Realm", AcquiredFrom = "Beauty and the Beast Realm", Notes = "Unlock Realm" },
                new Character { CharacterId = 4, GameVersionId = 1, CharacterName = "Buzz Lightyear", AcquiredBy = "Realm", AcquiredFrom = "Toy Story Realm", Notes = "Unlock Realm" },
                new Character { CharacterId = 5, GameVersionId = 1, CharacterName = "Daisy", AcquiredBy = "Quest", AcquiredFrom = "Mickey Mouse", Notes = "You Have Mail!" },
                new Character { CharacterId = 6, GameVersionId = 1, CharacterName = "Donald Duck", AcquiredBy = "Quest", AcquiredFrom = "Kristoff", Notes = "Story - Lost in the Dark Grove" },
                new Character { CharacterId = 7, GameVersionId = 1, CharacterName = "Elsa", AcquiredBy = "Realm", AcquiredFrom = "Frozen Realm", Notes = "Complete initial realm  quest" },
                new Character { CharacterId = 8, GameVersionId = 1, CharacterName = "Goofy", AcquiredBy = "Quest", AcquiredFrom = "Peaceful Meadow", Notes = "The Royal Tools" },
                new Character { CharacterId = 9, GameVersionId = 1, CharacterName = "Jack Skellington", AcquiredBy = "Quest", AcquiredFrom = "ForgottenLands", Notes = "After Fairy Godmother's Fire Alarm quest, search for Matryoshka Dolls to trigger quest." },
                new Character { CharacterId = 10, GameVersionId = 1, CharacterName = "Kristoff", AcquiredBy = "Quest", AcquiredFrom = "Forest of Valor", Notes = "Unlock Biome" },
                new Character { CharacterId = 11, GameVersionId = 1, CharacterName = "Maui", AcquiredBy = "Realm", AcquiredFrom = "Moana Realm", Notes = "Complete initial realm  quest" },
                new Character { CharacterId = 12, GameVersionId = 1, CharacterName = "Merlin", AcquiredFrom = "The Plaza", Notes = "Unlock Realm" },
                new Character { CharacterId = 13, GameVersionId = 1, CharacterName = "Mickey Mouse", AcquiredFrom = "The Plaza", Notes = "Unlock Realm" },
                new Character { CharacterId = 14, GameVersionId = 1, CharacterName = "Mike Wazowski", AcquiredBy = "Realm", AcquiredFrom = "Monsters Inc. Realm	", Notes = "Complete initial realm  quest" },
                new Character { CharacterId = 15, GameVersionId = 1, CharacterName = "Minnie Mouse", AcquiredBy = "Quest", AcquiredFrom = "Mickey Mouse", Notes = "Memory Magnification" },
                new Character { CharacterId = 16, GameVersionId = 1, CharacterName = "Mirabel", AcquiredBy = "Quest", AcquiredFrom = "Merlin", Notes = "The Golden Dorknob" },
                new Character { CharacterId = 17, GameVersionId = 1, CharacterName = "Moana", AcquiredBy = "Realm", AcquiredFrom = "Moana Realm", Notes = "Unlock Realm" },
                new Character { CharacterId = 18, GameVersionId = 1, CharacterName = "Mother Gothel", AcquiredBy = "Quest", AcquiredFrom = "Glade of Trust", Notes = "Story - The Curse" },
                new Character { CharacterId = 19, GameVersionId = 1, CharacterName = "Nala", AcquiredBy = "Realm", AcquiredFrom = "The Lion King Realm", Notes = "Unlock Realm" },
                new Character { CharacterId = 20, GameVersionId = 1, CharacterName = "Olaf", AcquiredBy = "Quest", AcquiredFrom = "Frosted Heights", Notes = "Story - The Great Blizzard" },
                new Character { CharacterId = 21, GameVersionId = 1, CharacterName = "Prince Eric", AcquiredBy = "Quest	", AcquiredFrom = "Ursala", Notes = "After Ariel and Ursala reach level 10" },
                new Character { CharacterId = 22, GameVersionId = 1, CharacterName = "Remy", AcquiredBy = "Realm", AcquiredFrom = "Ratatouille Realm", Notes = "Unlock Realm" },
                new Character { CharacterId = 23, GameVersionId = 1, CharacterName = "Scar", AcquiredBy = "Quest", AcquiredFrom = "Sunlit Plateau", Notes = "After The Curse in completed." },
                new Character { CharacterId = 24, GameVersionId = 1, CharacterName = "Scrooge McDuck", AcquiredFrom = "The Plaza", Notes = "Unlock Realm" },
                new Character { CharacterId = 25, GameVersionId = 1, CharacterName = "Simba", AcquiredBy = "Realm", AcquiredFrom = "The Lion King Realm", Notes = "Complete initial realm  quest" },
                new Character { CharacterId = 26, GameVersionId = 1, CharacterName = "Stitch", AcquiredBy = "Quest", AcquiredFrom = "Donald Duck", Notes = "The Mystery of the Stolen Socks" },
                new Character { CharacterId = 27, GameVersionId = 1, CharacterName = "Sulley", AcquiredBy = "Realm", AcquiredFrom = "Monsters Inc. Realm", Notes = "Unlock Realm" },
                new Character { CharacterId = 28, GameVersionId = 1, CharacterName = "The Beast", AcquiredBy = "Realm", AcquiredFrom = "Beauty and the Beast Realm", Notes = "Complete initial realm  quest" },
                new Character { CharacterId = 29, GameVersionId = 1, CharacterName = "The Fairy Godmother", AcquiredBy = "Quest	", AcquiredFrom = "	ForgottenLands", Notes = " After repairing the 6 Pillars" },
                new Character { CharacterId = 30, GameVersionId = 1, CharacterName = "Ursula", AcquiredBy = "Quest", AcquiredFrom = "Dazzle Beach", Notes = "Story - With Great Power" },
                new Character { CharacterId = 31, GameVersionId = 1, CharacterName = "Vanellope", AcquiredBy = "Quest", AcquiredFrom = "Scrooge", Notes = " The Haunting of Dreamlight Valley" },
                new Character { CharacterId = 32, GameVersionId = 1, CharacterName = "WALL-E", AcquiredBy = "Realm", AcquiredFrom = "WALL-E Realm", Notes = "Unlock Realm" },
                new Character { CharacterId = 33, GameVersionId = 1, CharacterName = "Woody", AcquiredBy = "Realm", AcquiredFrom = "Toy Story Realm", Notes = "Complete initial realm  quest" },
                new Character { CharacterId = 34, GameVersionId = 2, CharacterName = "EVE", AcquiredBy = "Quest", AcquiredFrom = "Ancient's Landing", Notes = "After receiving pickaxe upgrade	" },
                new Character { CharacterId = 35, GameVersionId = 2, CharacterName = "Gaston", AcquiredBy = "Quest", AcquiredFrom = "Glittering Dunes", Notes = "Unlock Biome" },
                new Character { CharacterId = 36, GameVersionId = 2, CharacterName = "Oswald", AcquiredBy = "Quest", AcquiredFrom = "Ancient's Landing", Notes = " The Spark of Imagination." },
                new Character { CharacterId = 37, GameVersionId = 2, CharacterName = "Rapunzel", AcquiredBy = "Quest", AcquiredFrom = "Wild Tangle", Notes = "Unlock Biome" }


            );

            modelBuilder.Entity<Fish>().HasData(
                new Fish { FishId = 1, GameVersionId = 1, FishName = "Anglerfish", RippleColor = "Orange", SellsFor = 1500, Energy = 2000, },
                new Fish { FishId = 2, GameVersionId = 1, FishName = "Bass", RippleColor = "White", SellsFor = 25, Energy = 150, Notes = "Could be outside of Ripples" },
                new Fish { FishId = 3, GameVersionId = 1, FishName = "Bream", RippleColor = "Blue", SellsFor = 280, Energy = 1300, },
                new Fish { FishId = 4, GameVersionId = 1, FishName = "Carp", RippleColor = "Blue", SellsFor = 400, Energy = 800, Notes = "Can be White" },
                new Fish { FishId = 5, GameVersionId = 1, FishName = "Catfish", RippleColor = "Orange", SellsFor = 550, Energy = 1200, },
                new Fish { FishId = 6, GameVersionId = 1, FishName = "Cod", RippleColor = "White", SellsFor = 35, Energy = 150, Notes = "Could be outside of Ripples" },
                new Fish { FishId = 7, GameVersionId = 1, FishName = "Crab", RippleColor = "Blue", SellsFor = 600, Energy = 1550, Notes = "Can be White" },
                new Fish { FishId = 8, GameVersionId = 1, FishName = "Fugu", RippleColor = "Orange", SellsFor = 900, Energy = 1700, Notes = "Requires rain" },
                new Fish { FishId = 9, GameVersionId = 1, FishName = "Here and There Fish", RippleColor = "	White", SellsFor = 2000, Energy = 1000, Notes = "Also outside of Ripples. Requires morning (6-10am) or evening (6-10pm) after completing Menu Icon Quests.png Here and There and Back Again" },
                new Fish { FishId = 10, GameVersionId = 1, FishName = "Herring", RippleColor = "White", SellsFor = 65, Energy = 250, },
                new Fish { FishId = 11, GameVersionId = 1, FishName = "Kingfish", RippleColor = "Blue", SellsFor = 450, Energy = 800, Notes = "Requires night (6pm-5am)" },
                new Fish { FishId = 12, GameVersionId = 1, FishName = "Lancetfish", RippleColor = "Blue", SellsFor = 650, Energy = 1300, },
                new Fish { FishId = 13, GameVersionId = 1, FishName = "Lobster", RippleColor = "Orange", SellsFor = 950, Energy = 1600, },
                new Fish { FishId = 14, GameVersionId = 1, FishName = "Perch", RippleColor = "Blue", SellsFor = 80, Energy = 400, Notes = "Can be White" },
                new Fish { FishId = 15, GameVersionId = 1, FishName = "Pike", RippleColor = "Orange", SellsFor = 800, Energy = 1500, },
                new Fish { FishId = 16, GameVersionId = 1, FishName = "Rainbow Trout", RippleColor = "White", SellsFor = 50, Energy = 300, },
                new Fish { FishId = 17, GameVersionId = 1, FishName = "Salmon", RippleColor = "White", SellsFor = 150, Energy = 500, Notes = "Can be blue" },
                new Fish { FishId = 18, GameVersionId = 1, FishName = "Seaweed", SellsFor = 20, Energy = 25, },
                new Fish { FishId = 19, GameVersionId = 1, FishName = "Shrimp", RippleColor = "Blue", SellsFor = 300, Energy = 750, Notes = "Can be White" },
                new Fish { FishId = 20, GameVersionId = 1, FishName = "Sole", RippleColor = "White", SellsFor = 200, Energy = 500, Notes = "Can be blue" },
                new Fish { FishId = 21, GameVersionId = 1, FishName = "Squid", RippleColor = "Blue", SellsFor = 500, Energy = 1000, Notes = "Can be White" },
                new Fish { FishId = 22, GameVersionId = 1, FishName = "Swordfish", RippleColor = "Orange", SellsFor = 700, Energy = 1500, },
                new Fish { FishId = 23, GameVersionId = 1, FishName = "Tilapia", RippleColor = "Blue", SellsFor = 600, Energy = 1150, },
                new Fish { FishId = 24, GameVersionId = 1, FishName = "Tuna", RippleColor = "White", SellsFor = 95, Energy = 350, Notes = "Can be blue" },
                new Fish { FishId = 25, GameVersionId = 1, FishName = "Walleye", RippleColor = "Orange", SellsFor = 1100, Energy = 1700, },
                new Fish { FishId = 26, GameVersionId = 1, FishName = "White Sturgeon", RippleColor = "Orange", SellsFor = 1250, Energy = 1800, },
                new Fish { FishId = 27, GameVersionId = 2, FishName = "Brilliant Blue Starfish", RippleColor = "Orange", SellsFor = 875, Energy = 1650, },
                new Fish { FishId = 28, GameVersionId = 2, FishName = "Dunebopper", RippleColor = "Blue", SellsFor = 550, Energy = 1100, },
                new Fish { FishId = 29, GameVersionId = 2, FishName = "Electric Eel", RippleColor = "Orange", SellsFor = 1025, Energy = 1200, },
                new Fish { FishId = 30, GameVersionId = 2, FishName = "Octopus", RippleColor = "Blue", SellsFor = 290, Energy = 700, Notes = "Can be White" },
                new Fish { FishId = 31, GameVersionId = 2, FishName = "Piranha", RippleColor = "Orange", SellsFor = 1300, Energy = 1900, },
                new Fish { FishId = 32, GameVersionId = 2, FishName = "Pirarucu", RippleColor = "Blue", SellsFor = 625, Energy = 1250, },
                new Fish { FishId = 33, GameVersionId = 2, FishName = "Pretty Pink Starfish", RippleColor = "Orange", SellsFor = 875, Energy = 1500, },
                new Fish { FishId = 34, GameVersionId = 2, FishName = "Prisma Shrimp", RippleColor = "Orange", SellsFor = 1100, Energy = 1600, },
                new Fish { FishId = 35, GameVersionId = 2, FishName = "Robot Fish", RippleColor = "Orange", SellsFor = 625, Energy = 1350, },
                new Fish { FishId = 36, GameVersionId = 2, FishName = "Sand Fish", RippleColor = "White", SellsFor = 30, Energy = 150, Notes = "Could be outside of Ripples" },
                new Fish { FishId = 37, GameVersionId = 2, FishName = "Sand Worm", RippleColor = "Orange", SellsFor = 800, Energy = 1650, },
                new Fish { FishId = 38, GameVersionId = 2, FishName = "Scorpion", RippleColor = "Blue", SellsFor = 425, Energy = 900, },
                new Fish { FishId = 39, GameVersionId = 2, FishName = "Sea Snail", RippleColor = "Blue", SellsFor = 250, Energy = 800, Notes = "Can be White" },
                new Fish { FishId = 40, GameVersionId = 2, FishName = "Shad", RippleColor = "White", SellsFor = 60, Energy = 300 },
                new Fish { FishId = 41, GameVersionId = 2, FishName = "Skeleton Fish", RippleColor = "White", SellsFor = 100, Energy = 500, Notes = "Can be blue" }
            );

            modelBuilder.Entity<FishLocation>().HasData(
                new FishLocation { FishLocationId = 1, FishId = 1, LocationId = 8 },
                new FishLocation { FishLocationId = 2, FishId = 2, LocationId = 4 },
                new FishLocation { FishLocationId = 3, FishId = 2, LocationId = 7 },
                new FishLocation { FishLocationId = 4, FishId = 2, LocationId = 2 },
                new FishLocation { FishLocationId = 5, FishId = 2, LocationId = 6 },
                new FishLocation { FishLocationId = 6, FishId = 2, LocationId = 17 },
                new FishLocation { FishLocationId = 7, FishId = 2, LocationId = 18 },
                new FishLocation { FishLocationId = 8, FishId = 3, LocationId = 2 },
                new FishLocation { FishLocationId = 9, FishId = 27, LocationId = 18 },
                new FishLocation { FishLocationId = 10, FishId = 4, LocationId = 4 },
                new FishLocation { FishLocationId = 11, FishId = 4, LocationId = 6 },
                new FishLocation { FishLocationId = 12, FishId = 5, LocationId = 2 },
                new FishLocation { FishLocationId = 13, FishId = 6, LocationId = 3 },
                new FishLocation { FishLocationId = 14, FishId = 6, LocationId = 8 },
                new FishLocation { FishLocationId = 15, FishId = 6, LocationId = 5 },
                new FishLocation { FishLocationId = 16, FishId = 6, LocationId = 12 },
                new FishLocation { FishLocationId = 17, FishId = 6, LocationId = 13 },
                new FishLocation { FishLocationId = 18, FishId = 7, LocationId = 7 },
                new FishLocation { FishLocationId = 19, FishId = 28, LocationId = 18 },
                new FishLocation { FishLocationId = 20, FishId = 29, LocationId = 20 },
                new FishLocation { FishLocationId = 21, FishId = 29, LocationId = 22 },
                new FishLocation { FishLocationId = 22, FishId = 8, LocationId = 3 },
                new FishLocation { FishLocationId = 23, FishId = 9, LocationId = 3 },
                new FishLocation { FishLocationId = 24, FishId = 9, LocationId = 4 },
                new FishLocation { FishLocationId = 25, FishId = 9, LocationId = 8 },
                new FishLocation { FishLocationId = 26, FishId = 9, LocationId = 7 },
                new FishLocation { FishLocationId = 27, FishId = 9, LocationId = 5 },
                new FishLocation { FishLocationId = 28, FishId = 9, LocationId = 2 },
                new FishLocation { FishLocationId = 29, FishId = 9, LocationId = 6 },
                new FishLocation { FishLocationId = 30, FishId = 10, LocationId = 3 },
                new FishLocation { FishLocationId = 31, FishId = 10, LocationId = 5 },
                new FishLocation { FishLocationId = 32, FishId = 11, LocationId = 3 },
                new FishLocation { FishLocationId = 33, FishId = 12, LocationId = 8 },
                new FishLocation { FishLocationId = 34, FishId = 13, LocationId = 5 },
                new FishLocation { FishLocationId = 35, FishId = 30, LocationId = 12 },
                new FishLocation { FishLocationId = 36, FishId = 30, LocationId = 13 },
                new FishLocation { FishLocationId = 37, FishId = 14, LocationId = 4 },
                new FishLocation { FishLocationId = 38, FishId = 14, LocationId = 6 },
                new FishLocation { FishLocationId = 39, FishId = 14, LocationId = 21 },
                new FishLocation { FishLocationId = 40, FishId = 14, LocationId = 23 },
                new FishLocation { FishLocationId = 41, FishId = 15, LocationId = 4 },
                new FishLocation { FishLocationId = 42, FishId = 31, LocationId = 23 },
                new FishLocation { FishLocationId = 43, FishId = 31, LocationId = 20 },
                new FishLocation { FishLocationId = 44, FishId = 31, LocationId = 21 },
                new FishLocation { FishLocationId = 45, FishId = 31, LocationId = 23 },
                new FishLocation { FishLocationId = 46, FishId = 31, LocationId = 22 },
                new FishLocation { FishLocationId = 47, FishId = 33, LocationId = 18 },
                new FishLocation { FishLocationId = 48, FishId = 34, LocationId = 21 },
                new FishLocation { FishLocationId = 49, FishId = 16, LocationId = 4 },
                new FishLocation { FishLocationId = 50, FishId = 16, LocationId = 2 },
                new FishLocation { FishLocationId = 51, FishId = 35, LocationId = 12 },
                new FishLocation { FishLocationId = 52, FishId = 35, LocationId = 13 },
                new FishLocation { FishLocationId = 53, FishId = 17, LocationId = 7 },
                new FishLocation { FishLocationId = 54, FishId = 17, LocationId = 6 },
                new FishLocation { FishLocationId = 55, FishId = 17, LocationId = 20 },
                new FishLocation { FishLocationId = 56, FishId = 17, LocationId = 22 },
                new FishLocation { FishLocationId = 57, FishId = 36, LocationId = 19 },
                new FishLocation { FishLocationId = 58, FishId = 36, LocationId = 16 },
                new FishLocation { FishLocationId = 59, FishId = 36, LocationId = 17 },
                new FishLocation { FishLocationId = 60, FishId = 37, LocationId = 19 },
                new FishLocation { FishLocationId = 61, FishId = 37, LocationId = 16 },
                new FishLocation { FishLocationId = 62, FishId = 37, LocationId = 17 },
                new FishLocation { FishLocationId = 63, FishId = 38, LocationId = 19 },
                new FishLocation { FishLocationId = 64, FishId = 38, LocationId = 16 },
                new FishLocation { FishLocationId = 65, FishId = 38, LocationId = 17 },
                new FishLocation { FishLocationId = 66, FishId = 39, LocationId = 12 },
                new FishLocation { FishLocationId = 67, FishId = 39, LocationId = 13 },
                new FishLocation { FishLocationId = 68, FishId = 40, LocationId = 12 },
                new FishLocation { FishLocationId = 69, FishId = 40, LocationId = 13 },
                new FishLocation { FishLocationId = 70, FishId = 19, LocationId = 3 },
                new FishLocation { FishLocationId = 71, FishId = 41, LocationId = 19 },
                new FishLocation { FishLocationId = 72, FishId = 41, LocationId = 16 },
                new FishLocation { FishLocationId = 73, FishId = 41, LocationId = 17 },
                new FishLocation { FishLocationId = 74, FishId = 20, LocationId = 8 },
                new FishLocation { FishLocationId = 75, FishId = 20, LocationId = 12 },
                new FishLocation { FishLocationId = 76, FishId = 20, LocationId = 13 },
                new FishLocation { FishLocationId = 77, FishId = 21, LocationId = 8 },
                new FishLocation { FishLocationId = 78, FishId = 21, LocationId = 5 },
                new FishLocation { FishLocationId = 79, FishId = 22, LocationId = 3 },
                new FishLocation { FishLocationId = 80, FishId = 23, LocationId = 7 },
                new FishLocation { FishLocationId = 81, FishId = 23, LocationId = 6 },
                new FishLocation { FishLocationId = 82, FishId = 24, LocationId = 8 },
                new FishLocation { FishLocationId = 83, FishId = 24, LocationId = 5 },
                new FishLocation { FishLocationId = 84, FishId = 25, LocationId = 6 },
                new FishLocation { FishLocationId = 85, FishId = 26, LocationId = 7 }

            );

            // Set up the foreign key relationship. One Theme to many characters
            modelBuilder.Entity<Character>().HasOne(c => c.GameVersion).WithMany(gv => gv.Characters).HasForeignKey(c => c.GameVersionId);

            modelBuilder.Entity<FishLocation>()
                .HasOne(fl => fl.Fish)
                .WithMany(f => f.FishLocations)
                .HasForeignKey(fl => fl.FishId)
                .OnDelete(DeleteBehavior.Restrict); // Restrict delete;

            modelBuilder.Entity<FishLocation>()
                .HasOne(fl => fl.Location)
                .WithMany(l => l.FishLocations)
                .HasForeignKey(fl => fl.LocationId)
                .OnDelete(DeleteBehavior.Restrict); // Restrict delete;

        }


    }
}
