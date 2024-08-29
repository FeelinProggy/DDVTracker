using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DDVTracker.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GameVersion",
                columns: table => new
                {
                    GameVersionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameVersionName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameVersion", x => x.GameVersionId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    CharacterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameVersionId = table.Column<int>(type: "int", nullable: false),
                    CharacterName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AcquiredBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AcquiredFrom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CharacterImageUpload = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isUnlocked = table.Column<bool>(type: "bit", nullable: true),
                    CharacterLevel = table.Column<int>(type: "int", nullable: true),
                    AssignedSkill = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FavoriteThing1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FavoriteThing2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FavoriteThing3 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.CharacterId);
                    table.ForeignKey(
                        name: "FK_Characters_GameVersion_GameVersionId",
                        column: x => x.GameVersionId,
                        principalTable: "GameVersion",
                        principalColumn: "GameVersionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Fish",
                columns: table => new
                {
                    FishId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameVersionId = table.Column<int>(type: "int", nullable: false),
                    FishName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FishImage = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    RippleColor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SellsFor = table.Column<int>(type: "int", nullable: true),
                    Energy = table.Column<int>(type: "int", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fish", x => x.FishId);
                    table.ForeignKey(
                        name: "FK_Fish_GameVersion_GameVersionId",
                        column: x => x.GameVersionId,
                        principalTable: "GameVersion",
                        principalColumn: "GameVersionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    IngredientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameVersionId = table.Column<int>(type: "int", nullable: false),
                    IngredientName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IngredientCategory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BuyPrice = table.Column<int>(type: "int", nullable: true),
                    SellsFor = table.Column<int>(type: "int", nullable: true),
                    Energy = table.Column<int>(type: "int", nullable: true),
                    GrowTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Water = table.Column<int>(type: "int", nullable: true),
                    Yield = table.Column<int>(type: "int", nullable: true),
                    LocationId = table.Column<int>(type: "int", nullable: true),
                    Method = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.IngredientId);
                    table.ForeignKey(
                        name: "FK_Ingredients_GameVersion_GameVersionId",
                        column: x => x.GameVersionId,
                        principalTable: "GameVersion",
                        principalColumn: "GameVersionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    LocationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameVersionId = table.Column<int>(type: "int", nullable: false),
                    LocationName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cost = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.LocationId);
                    table.ForeignKey(
                        name: "FK_Locations_GameVersion_GameVersionId",
                        column: x => x.GameVersionId,
                        principalTable: "GameVersion",
                        principalColumn: "GameVersionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Meals",
                columns: table => new
                {
                    MealId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameVersionId = table.Column<int>(type: "int", nullable: false),
                    MealName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MealType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SellsFor = table.Column<int>(type: "int", nullable: true),
                    Energy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meals", x => x.MealId);
                    table.ForeignKey(
                        name: "FK_Meals_GameVersion_GameVersionId",
                        column: x => x.GameVersionId,
                        principalTable: "GameVersion",
                        principalColumn: "GameVersionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FishLocations",
                columns: table => new
                {
                    FishLocationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FishId = table.Column<int>(type: "int", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FishLocations", x => x.FishLocationId);
                    table.ForeignKey(
                        name: "FK_FishLocations_Fish_FishId",
                        column: x => x.FishId,
                        principalTable: "Fish",
                        principalColumn: "FishId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FishLocations_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IngredientMeal",
                columns: table => new
                {
                    IngredientsIngredientId = table.Column<int>(type: "int", nullable: false),
                    MealsMealId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientMeal", x => new { x.IngredientsIngredientId, x.MealsMealId });
                    table.ForeignKey(
                        name: "FK_IngredientMeal_Ingredients_IngredientsIngredientId",
                        column: x => x.IngredientsIngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "IngredientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IngredientMeal_Meals_MealsMealId",
                        column: x => x.MealsMealId,
                        principalTable: "Meals",
                        principalColumn: "MealId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MealIngredients",
                columns: table => new
                {
                    MealId = table.Column<int>(type: "int", nullable: false),
                    IngredientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealIngredients", x => new { x.MealId, x.IngredientId });
                    table.ForeignKey(
                        name: "FK_MealIngredients_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "IngredientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MealIngredients_Meals_MealId",
                        column: x => x.MealId,
                        principalTable: "Meals",
                        principalColumn: "MealId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "GameVersion",
                columns: new[] { "GameVersionId", "GameVersionName" },
                values: new object[,]
                {
                    { 1, "Base Game" },
                    { 2, "A Rift In Time" }
                });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "CharacterId", "AcquiredBy", "AcquiredFrom", "AssignedSkill", "CharacterImageUpload", "CharacterLevel", "CharacterName", "FavoriteThing1", "FavoriteThing2", "FavoriteThing3", "GameVersionId", "Notes", "isUnlocked" },
                values: new object[,]
                {
                    { 1, "Realm", "Frozen Realm", null, null, null, "Anna", null, null, null, 1, "Unlock Realm", null },
                    { 2, "Quest", "Goofy", null, null, null, "Ariel", null, null, null, 1, "The Mysterious Wreck", null },
                    { 3, "Realm", "Beauty and the Beast Realm", null, null, null, "Belle", null, null, null, 1, "Unlock Realm", null },
                    { 4, "Realm", "Toy Story Realm", null, null, null, "Buzz Lightyear", null, null, null, 1, "Unlock Realm", null },
                    { 5, "Quest", "Mickey Mouse", null, null, null, "Daisy", null, null, null, 1, "You Have Mail!", null },
                    { 6, "Quest", "Kristoff", null, null, null, "Donald Duck", null, null, null, 1, "Story - Lost in the Dark Grove", null },
                    { 7, "Realm", "Frozen Realm", null, null, null, "Elsa", null, null, null, 1, "Complete initial realm  quest", null },
                    { 8, "Quest", "Peaceful Meadow", null, null, null, "Goofy", null, null, null, 1, "The Royal Tools", null },
                    { 9, "Quest", "ForgottenLands", null, null, null, "Jack Skellington", null, null, null, 1, "After Fairy Godmother's Fire Alarm quest, search for Matryoshka Dolls to trigger quest.", null },
                    { 10, "Quest", "Forest of Valor", null, null, null, "Kristoff", null, null, null, 1, "Unlock Biome", null },
                    { 11, "Realm", "Moana Realm", null, null, null, "Maui", null, null, null, 1, "Complete initial realm  quest", null },
                    { 12, null, "The Plaza", null, null, null, "Merlin", null, null, null, 1, "Unlock Realm", null },
                    { 13, null, "The Plaza", null, null, null, "Mickey Mouse", null, null, null, 1, "Unlock Realm", null },
                    { 14, "Realm", "Monsters Inc. Realm	", null, null, null, "Mike Wazowski", null, null, null, 1, "Complete initial realm  quest", null },
                    { 15, "Quest", "Mickey Mouse", null, null, null, "Minnie Mouse", null, null, null, 1, "Memory Magnification", null },
                    { 16, "Quest", "Merlin", null, null, null, "Mirabel", null, null, null, 1, "The Golden Dorknob", null },
                    { 17, "Realm", "Moana Realm", null, null, null, "Moana", null, null, null, 1, "Unlock Realm", null },
                    { 18, "Quest", "Glade of Trust", null, null, null, "Mother Gothel", null, null, null, 1, "Story - The Curse", null },
                    { 19, "Realm", "The Lion King Realm", null, null, null, "Nala", null, null, null, 1, "Unlock Realm", null },
                    { 20, "Quest", "Frosted Heights", null, null, null, "Olaf", null, null, null, 1, "Story - The Great Blizzard", null },
                    { 21, "Quest	", "Ursala", null, null, null, "Prince Eric", null, null, null, 1, "After Ariel and Ursala reach level 10", null },
                    { 22, "Realm", "Ratatouille Realm", null, null, null, "Remy", null, null, null, 1, "Unlock Realm", null },
                    { 23, "Quest", "Sunlit Plateau", null, null, null, "Scar", null, null, null, 1, "After The Curse in completed.", null },
                    { 24, null, "The Plaza", null, null, null, "Scrooge McDuck", null, null, null, 1, "Unlock Realm", null },
                    { 25, "Realm", "The Lion King Realm", null, null, null, "Simba", null, null, null, 1, "Complete initial realm  quest", null },
                    { 26, "Quest", "Donald Duck", null, null, null, "Stitch", null, null, null, 1, "The Mystery of the Stolen Socks", null },
                    { 27, "Realm", "Monsters Inc. Realm", null, null, null, "Sulley", null, null, null, 1, "Unlock Realm", null },
                    { 28, "Realm", "Beauty and the Beast Realm", null, null, null, "The Beast", null, null, null, 1, "Complete initial realm  quest", null },
                    { 29, "Quest	", "	ForgottenLands", null, null, null, "The Fairy Godmother", null, null, null, 1, " After repairing the 6 Pillars", null },
                    { 30, "Quest", "Dazzle Beach", null, null, null, "Ursula", null, null, null, 1, "Story - With Great Power", null },
                    { 31, "Quest", "Scrooge", null, null, null, "Vanellope", null, null, null, 1, " The Haunting of Dreamlight Valley", null },
                    { 32, "Realm", "WALL-E Realm", null, null, null, "WALL-E", null, null, null, 1, "Unlock Realm", null },
                    { 33, "Realm", "Toy Story Realm", null, null, null, "Woody", null, null, null, 1, "Complete initial realm  quest", null },
                    { 34, "Quest", "Ancient's Landing", null, null, null, "EVE", null, null, null, 2, "After receiving pickaxe upgrade	", null },
                    { 35, "Quest", "Glittering Dunes", null, null, null, "Gaston", null, null, null, 2, "Unlock Biome", null },
                    { 36, "Quest", "Ancient's Landing", null, null, null, "Oswald", null, null, null, 2, " The Spark of Imagination.", null },
                    { 37, "Quest", "Wild Tangle", null, null, null, "Rapunzel", null, null, null, 2, "Unlock Biome", null }
                });

            migrationBuilder.InsertData(
                table: "Fish",
                columns: new[] { "FishId", "Energy", "FishImage", "FishName", "GameVersionId", "Notes", "RippleColor", "SellsFor" },
                values: new object[,]
                {
                    { 1, 2000, null, "Anglerfish", 1, null, "Orange", 1500 },
                    { 2, 150, null, "Bass", 1, "Could be outside of Ripples", "White", 25 },
                    { 3, 1300, null, "Bream", 1, null, "Blue", 280 },
                    { 4, 800, null, "Carp", 1, "Can be White", "Blue", 400 },
                    { 5, 1200, null, "Catfish", 1, null, "Orange", 550 },
                    { 6, 150, null, "Cod", 1, "Could be outside of Ripples", "White", 35 },
                    { 7, 1550, null, "Crab", 1, "Can be White", "Blue", 600 },
                    { 8, 1700, null, "Fugu", 1, "Requires rain", "Orange", 900 },
                    { 9, 1000, null, "Here and There Fish", 1, "Also outside of Ripples. Requires morning (6-10am) or evening (6-10pm) after completing Menu Icon Quests.png Here and There and Back Again", "	White", 2000 },
                    { 10, 250, null, "Herring", 1, null, "White", 65 },
                    { 11, 800, null, "Kingfish", 1, "Requires night (6pm-5am)", "Blue", 450 },
                    { 12, 1300, null, "Lancetfish", 1, null, "Blue", 650 },
                    { 13, 1600, null, "Lobster", 1, null, "Orange", 950 },
                    { 14, 400, null, "Perch", 1, "Can be White", "Blue", 80 },
                    { 15, 1500, null, "Pike", 1, null, "Orange", 800 },
                    { 16, 300, null, "Rainbow Trout", 1, null, "White", 50 },
                    { 17, 500, null, "Salmon", 1, "Can be blue", "White", 150 },
                    { 18, 25, null, "Seaweed", 1, null, null, 20 },
                    { 19, 750, null, "Shrimp", 1, "Can be White", "Blue", 300 },
                    { 20, 500, null, "Sole", 1, "Can be blue", "White", 200 },
                    { 21, 1000, null, "Squid", 1, "Can be White", "Blue", 500 },
                    { 22, 1500, null, "Swordfish", 1, null, "Orange", 700 },
                    { 23, 1150, null, "Tilapia", 1, null, "Blue", 600 },
                    { 24, 350, null, "Tuna", 1, "Can be blue", "White", 95 },
                    { 25, 1700, null, "Walleye", 1, null, "Orange", 1100 },
                    { 26, 1800, null, "White Sturgeon", 1, null, "Orange", 1250 },
                    { 27, 1650, null, "Brilliant Blue Starfish", 2, null, "Orange", 875 },
                    { 28, 1100, null, "Dunebopper", 2, null, "Blue", 550 },
                    { 29, 1200, null, "Electric Eel", 2, null, "Orange", 1025 },
                    { 30, 700, null, "Octopus", 2, "Can be White", "Blue", 290 },
                    { 31, 1900, null, "Piranha", 2, null, "Orange", 1300 },
                    { 32, 1250, null, "Pirarucu", 2, null, "Blue", 625 },
                    { 33, 1500, null, "Pretty Pink Starfish", 2, null, "Orange", 875 },
                    { 34, 1600, null, "Prisma Shrimp", 2, null, "Orange", 1100 },
                    { 35, 1350, null, "Robot Fish", 2, null, "Orange", 625 },
                    { 36, 150, null, "Sand Fish", 2, "Could be outside of Ripples", "White", 30 },
                    { 37, 1650, null, "Sand Worm", 2, null, "Orange", 800 },
                    { 38, 900, null, "Scorpion", 2, null, "Blue", 425 },
                    { 39, 800, null, "Sea Snail", 2, "Can be White", "Blue", 250 },
                    { 40, 300, null, "Shad", 2, null, "White", 60 },
                    { 41, 500, null, "Skeleton Fish", 2, "Can be blue", "White", 100 }
                });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "IngredientId", "BuyPrice", "Energy", "GameVersionId", "GrowTime", "IngredientCategory", "IngredientName", "LocationId", "Method", "Notes", "SellsFor", "Water", "Yield" },
                values: new object[,]
                {
                    { 1, 50, 300, 1, "20 m", "Fruit", "Apple", 1, "Gardening", null, 25, null, 3 },
                    { 2, 200, 42, 1, "2 h 15 m", "Vegetables", "Asparagus", 7, "Gardening", null, 133, 2, 3 },
                    { 3, 58, 350, 1, "23 m", "Fruit", "Banana", 3, "Gardening", null, 29, null, 3 },
                    { 4, null, 100, 1, null, "Spices", "Basil", 2, "Foraging", null, 50, null, null },
                    { 5, 50, 79, 1, "15 m", "Vegetables", "Bell Pepper", 4, "Gardening", null, 33, 1, 1 },
                    { 6, 58, 350, 1, "23 m", "Fruit", "Blueberry", 4, "Gardening", null, 29, null, 3 },
                    { 7, 190, 285, 1, null, "Dairy and Oil", "Butter", 32, "Purchase", "After A Restaurant Makeover", 190, null, null },
                    { 8, 164, 59, 1, "35 m", "Dairy and Oil", "Canola", 4, "Gardening", null, 109, 3, 1 },
                    { 9, 66, 57, 1, "15 m", "Vegetables", "Carrot", 2, "Gardening", null, 44, 1, 1 },
                    { 10, 180, 270, 1, null, "Dairy and Oil", "Cheese", 32, "Purchase", "After A Restaurant Makeover", 180, null, null },
                    { 11, 83, 500, 1, "33 m", "Fruit", "Cherry", 7, "Gardening", null, 42, null, 3 },
                    { 12, 117, 140, 1, "45 m", "Vegetables", "Chili Pepper", 6, "Gardening", null, 78, 1, 1 },
                    { 13, null, 120, 1, null, "Seafood", "Clam", 3, "Foraging", null, 50, null, null },
                    { 14, 75, 450, 1, "30 m", "Sweetener", "Cocoa Bean", 5, "Gardening", null, 38, null, 3 },
                    { 15, null, 500, 1, "23 m", "Fruit", "Coconut", 3, "Foraging", "After Burying the Eel", 42, null, 3 },
                    { 16, null, 425, 1, "40 m", "Fruit", "Coffee Bean", 5, "Foraging", "After Very Sleepy Stitch", 36, null, 3 },
                    { 17, 24, 30, 1, "12 m", "Vegetables", "Corn", 3, "Gardening", null, 16, 1, 2 },
                    { 18, 239, 145, 1, "1 h 15 m", "Vegetables", "Cucumber", 7, "Gardening", null, 159, 1, 1 },
                    { 19, null, 500, 1, "1 d", "Fruit", "Dreamlight Fruit", 6, "Foraging", "After The Dreamlight Grove", 40, null, 3 },
                    { 20, 220, 330, 1, null, "Dairy and Oil", "Egg", 32, "Purchase", "After A Restaurant Makeover", 220, null, null },
                    { 21, 462, 451, 1, "3 h", "Vegetables", "Eggplant", 7, "Gardening", null, 308, 2, 1 },
                    { 22, null, 135, 1, null, "Spices", "Garlic", 4, "Foraging", null, 50, null, null },
                    { 23, null, 175, 1, null, "Spices", "Ginger", 8, "Foraging", null, 50, null, null },
                    { 24, 100, 600, 1, "40 m", "Fruit", "Gooseberry", 7, "Gardening", null, 50, null, 3 },
                    { 25, 464, 228, 1, "2 h", "Vegetables", "Leek", 8, "Gardening", null, 309, 2, 1 },
                    { 26, 67, 400, 1, "27 m", "Fruit", "Lemon", 5, "Gardening", null, 33, null, 3 },
                    { 27, 12, 56, 1, "3 m", "Vegetables", "Lettuce", 2, "Gardening", null, 8, 1, 1 },
                    { 28, 230, 345, 1, null, "Dairy and Oil", "Milk", 32, "Purchase", "After A Restaurant Makeover", 230, null, null },
                    { 29, null, 155, 1, null, "Spices", "Mint", 7, "Foraging", null, 50, null, null },
                    { 30, null, 105, 1, null, "Vegetables", "Mushroom", 5, "Foraging", null, 30, null, null },
                    { 31, 171, 31, 1, "2 h", "Vegetables", "Okra", 5, "Gardening", null, 114, 1, 3 },
                    { 32, 255, 146, 1, "1 h 15 m", "Vegetables", "Onion", 4, "Gardening", null, 170, 2, 1 },
                    { 33, null, 95, 1, null, "Spices", "Oregano", 1, "Foraging", null, 50, null, null },
                    { 34, null, 250, 1, null, "Seafood", "Oyster", 3, "Foraging", null, 50, null, null },
                    { 35, 200, 300, 1, null, "Dairy and Oil", "Peanut", 32, "Purchase", "After Remy's Recipe Book", 200, null, null },
                    { 36, 189, 113, 1, "35 m", "Vegetables", "Potato", 8, "Gardening", null, 126, 3, 1 },
                    { 37, 996, 187, 1, "4 h", "Vegetables", "Pumpkin", 8, "Gardening", null, 664, 2, 1 },
                    { 38, null, 275, 1, "17 m", "Fruit", "Raspberry", 2, "Gardening", null, 21, null, 3 },
                    { 39, 92, 59, 1, "50 m", "Grains", "Rice", 5, "Gardening", null, 61, 2, 2 },
                    { 40, null, 125, 1, null, "Seafood", "Scallop", 3, "Foraging", null, 50, null, null },
                    { 41, 150, 225, 1, null, "Ice", "Slush Ice", 32, "Purchase", "After The Unknown Flavor", 150, null, null },
                    { 42, 104, 58, 1, "1 h 30 m", "Dairy and Oil", "Soya", 6, "Gardening", null, 69, 2, 3 },
                    { 43, 62, 60, 1, "1 h", "Vegetables", "Spinach", 5, "Gardening", null, 41, 2, 3 },
                    { 44, 29, 46, 1, "7 m", "Sweetener", "Sugarcane", 3, "Gardening", null, 19, 1, 1 },
                    { 45, 33, 21, 1, "25 m", "Vegetables", "Tomato", 3, "Gardening", null, 22, 2, 3 },
                    { 46, null, 135, 1, null, "Sweetener", "Vanilla", 6, "Foraging", null, 50, null, null },
                    { 47, 3, 19, 1, "1 m", "Grains", "Wheat", 2, "Gardening", null, 2, 1, 2 },
                    { 48, 78, 48, 1, "40 m", "Vegetables", "Zucchini", 6, "Gardening", null, 52, 2, 2 },
                    { 49, null, 100, 2, null, "Sweetener", "Agave", 10, "Foraging", null, 25, null, null },
                    { 50, null, 500, 2, "50 m", "Fruit", "Almonds", 11, "Foraging", null, 42, null, 2 },
                    { 51, null, 155, 2, null, "Vegetables", "Bamboo", 11, "Foraging", null, 80, null, null },
                    { 52, null, 41, 2, "1 h", "Vegetables", "Beans", 10, "Gardening", null, 49, null, 3 },
                    { 53, null, 73, 2, "40 m", "Vegetables", "Broccoli", 10, "Gardening", null, 152, null, 1 },
                    { 54, null, 142, 2, "1 h", "Vegetables", "Cabbage", 11, "Gardening", null, 256, null, 1 },
                    { 55, null, 400, 2, "45 m", "Fruit", "Cactoberries", 10, "Foraging", null, 34, null, 2 },
                    { 56, null, 60, 2, "10 m", "Vegetables", "Celery", 9, "Gardening", null, 65, null, 1 },
                    { 57, null, 155, 2, null, "Spices", "Cinnamon", 11, "Foraging", null, 30, null, null },
                    { 58, null, 52, 2, "25 m", "Fruit", "Cosmic Figs", 9, "Gardening", null, 22, null, 2 },
                    { 59, null, 90, 2, null, "Spices", "Cumin", 9, "Foraging", null, 15, null, null },
                    { 60, null, 350, 2, "55 m", "Fruit", "Dates", 10, "Foraging", null, 29, null, 3 },
                    { 61, null, 600, 2, "1 h", "Fruit", "Dreamango", 11, "Foraging", null, 50, null, 2 },
                    { 62, null, 46, 2, "10 m", "Vegetables", "Flute Root", 9, "Gardening", null, 112, null, 2 },
                    { 63, null, 21, 2, "20 m", "Fruit", "Grapes", 9, "Gardening", null, 9, null, 3 },
                    { 64, null, 105, 2, null, "Spices", "Majestea", 9, "Foraging", null, 30, null, null },
                    { 65, null, 88, 2, "30 m", "Fruit", "Melon", 10, "Gardening", null, 93, null, 1 },
                    { 66, null, 300, 2, "35 m", "Fruit", "Nestling Pear", 9, "Foraging", null, 25, null, 2 },
                    { 67, null, 125, 2, null, "Spices", "Paprika", 10, "Foraging", null, 50, null, null },
                    { 68, null, 168, 2, "3 h", "Fruit", "Pineapple", 11, "Gardening", null, 532, null, 1 },
                    { 69, 250, 250, 2, null, "Protein", "Pork", 10, "Purchase", null, 250, null, null },
                    { 70, 500, 250, 2, null, "Protein", "Poultry", 10, "Purchase", null, 500, null, null },
                    { 71, null, 37, 2, "2 h", "Vegetables", "Ruby Lentils", 11, "Gardening", null, 156, null, 3 },
                    { 72, null, 275, 2, "30 m", "Fruit", "Strawberry", 9, "Foraging", null, 23, null, 2 },
                    { 73, null, 263, 2, "4 h", "Vegetables", "Turnip", 11, "Gardening", null, 187, null, 2 },
                    { 74, 1000, 250, 2, null, "Protein", "Venison", 10, "Purchase", null, 500, null, null },
                    { 75, null, 83, 2, "4 h", "Vegetables", "Yam", 9, "Gardening", null, 36, null, 1 }
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "LocationId", "Cost", "GameVersionId", "LocationName" },
                values: new object[,]
                {
                    { 1, null, 1, "Plaza" },
                    { 2, null, 1, "Peaceful Meadow" },
                    { 3, "1000 Dreamlight", 1, "Dazzle Beach" },
                    { 4, "3000 Dreamlight", 1, "Forest of Valor" },
                    { 5, "5000 Dreamlight", 1, "Glade of Trust" },
                    { 6, "7000 Dreamlight", 1, "Sunlit Plateau" },
                    { 7, "10000 Dreamlight", 1, "Frosted Heights" },
                    { 8, "15000 Dreamlight", 1, "Forgotten Lands" },
                    { 9, null, 2, "Ancient's Landing" },
                    { 10, null, 2, "Glittering Dunes" },
                    { 11, null, 2, "Wild Tangle" },
                    { 12, null, 2, "The Docks" },
                    { 13, "6000 Mist", 2, "The Overlook" },
                    { 14, "10000 Mist", 2, "The Ruins" },
                    { 15, null, 2, "The Courtyard" },
                    { 16, null, 2, "The Plains" },
                    { 17, "4000 Mist", 2, "The Wastes" },
                    { 18, "6000 Mist", 2, "The Oasis" },
                    { 19, "10000 Mist", 2, "The Borderlands" },
                    { 20, "2000 Mist", 2, "The Grasslands" },
                    { 21, "4000 Mist", 2, "The Grove" },
                    { 22, "6000 Mist", 2, "The Promenade" },
                    { 23, "10000 Mist", 2, "The Lagoon" },
                    { 24, "12500 Dreamlight", 1, "Beauty and the Beast Realm" },
                    { 25, "4000 Dreamlight", 1, "Frozen Realm" },
                    { 26, "3000 Dreamlight", 1, "Moana Realm" },
                    { 27, "15000 Dreamlight", 1, "Monsters, Inc. Realm" },
                    { 28, "3000 Dreamlight", 1, "Ratatouille Realm" },
                    { 29, "10000 Dreamlight", 1, "The Lion King Realm" },
                    { 30, "7000 Dreamlight", 1, "Toy Story Realm" },
                    { 31, "3000 Dreamlight", 1, "WALL-E Realm" },
                    { 32, null, 1, "Chez Remy" }
                });

            migrationBuilder.InsertData(
                table: "Meals",
                columns: new[] { "MealId", "Energy", "GameVersionId", "MealName", "MealType", "SellsFor" },
                values: new object[,]
                {
                    { 1, 679, 1, "My Hero Cookie", "Desserts", 294 },
                    { 2, 757, 2, "Ajiaco", "Entrées", 898 },
                    { 3, 1137, 1, "Apple Pie", "Desserts", 303 },
                    { 4, 823, 2, "Apple Sauce", "Desserts", 71 },
                    { 5, 1077, 1, "Apple Sorbet", "Desserts", 271 },
                    { 6, 1572, 1, "Apple-Cider-Glazed Salmon", "Entrées", 271 },
                    { 7, 2092, 1, "Arendellian Pickled Herring", "Appetizers", 532 },
                    { 8, 770, 2, "Arepas Con Queso", "Appetizers", 309 },
                    { 9, 1572, 1, "Aurora's Cake", "Desserts", 767 },
                    { 10, 544, 2, "Baked Beans", "Entrées", 388 },
                    { 11, 1894, 1, "Baked Carp", "Entrées", 767 },
                    { 12, 1884, 1, "Banana Ice Cream", "Desserts", 641 },
                    { 13, 1227, 1, "Banana Pie", "Desserts", 308 },
                    { 14, 2074, 1, "Banana Split", "Desserts", 714 },
                    { 15, 842, 2, "Baozi", "Appetizers", 503 },
                    { 16, 3118, 2, "Barbecued Brilliant Blue Starfish", "Appetizers", 1202 },
                    { 17, 2812, 2, "Barbecued Pretty Pink Starfish", "Appetizers", 1202 },
                    { 18, 1355, 2, "Basil Berry Salad", "Desserts", 142 },
                    { 19, 2035, 1, "Basil Omelet", "Entrées", 1020 },
                    { 20, 912, 1, "Beignets", "Desserts", 524 },
                    { 21, 1272, 1, "Bell Pepper Puffs", "Appetizers", 606 },
                    { 22, 2255, 1, "Berry Salad", "Desserts", 139 },
                    { 23, 4420, 2, "Best Fish Forever", "Entrées", 1400 },
                    { 24, 2310, 1, "Birthday Cake", "Desserts", 749 },
                    { 25, 1468, 2, "Biryani", "Entrées", 1049 },
                    { 26, 679, 1, "Biscuits", "Desserts", 294 },
                    { 27, 4238, 2, "Blend of the Bayou", "Entrées", 2409 },
                    { 28, 1227, 1, "Blueberry Pie", "Desserts", 308 },
                    { 29, 714, 1, "Boba Tea", "Desserts", 323 },
                    { 30, 1192, 2, "Bony Osso Buco", "Entrées", 272 },
                    { 31, 2114, 1, "Bouillabaisse", "Entrées", 529 },
                    { 32, 2500, 2, "Braised Abalone", "Entrées", 570 },
                    { 33, 898, 2, "Braised Bamboo Shoots", "Entrées", 461 },
                    { 34, 2336, 2, "Brandade de Morue", "Entrées", 757 },
                    { 35, 910, 2, "Bulgur Salad", "Appetizers", 396 },
                    { 36, 1881, 1, "Buñuelos", "Appetizers", 948 },
                    { 37, 809, 2, "Burrito", "Entrées", 473 },
                    { 38, 2142, 2, "Butter Chicken", "Entrées", 1200 },
                    { 39, 123, 1, "Candy", "Desserts", 22 },
                    { 40, 1482, 2, "Cannoli", "Desserts", 678 },
                    { 41, 638, 1, "Caramel Apples", "Desserts", 56 },
                    { 42, 1724, 2, "Caramel Macarons", "Desserts", 401 },
                    { 43, 2310, 1, "Carp Salad", "Entrées", 617 },
                    { 44, 908, 1, "Carrot Cake", "Desserts", 427 },
                    { 45, 759, 2, "Charlotte Cake", "Desserts", 69 }
                });

            migrationBuilder.InsertData(
                table: "FishLocations",
                columns: new[] { "FishLocationId", "FishId", "LocationId" },
                values: new object[,]
                {
                    { 1, 1, 8 },
                    { 2, 2, 4 },
                    { 3, 2, 7 },
                    { 4, 2, 2 },
                    { 5, 2, 6 },
                    { 6, 2, 17 },
                    { 7, 2, 18 },
                    { 8, 3, 2 },
                    { 9, 27, 18 },
                    { 10, 4, 4 },
                    { 11, 4, 6 },
                    { 12, 5, 2 },
                    { 13, 6, 3 },
                    { 14, 6, 8 },
                    { 15, 6, 5 },
                    { 16, 6, 12 },
                    { 17, 6, 13 },
                    { 18, 7, 7 },
                    { 19, 28, 18 },
                    { 20, 29, 20 },
                    { 21, 29, 22 },
                    { 22, 8, 3 },
                    { 23, 9, 3 },
                    { 24, 9, 4 },
                    { 25, 9, 8 },
                    { 26, 9, 7 },
                    { 27, 9, 5 },
                    { 28, 9, 2 },
                    { 29, 9, 6 },
                    { 30, 10, 3 },
                    { 31, 10, 5 },
                    { 32, 11, 3 },
                    { 33, 12, 8 },
                    { 34, 13, 5 },
                    { 35, 30, 12 },
                    { 36, 30, 13 },
                    { 37, 14, 4 },
                    { 38, 14, 6 },
                    { 39, 14, 21 },
                    { 40, 14, 23 },
                    { 41, 15, 4 },
                    { 42, 31, 23 },
                    { 43, 31, 20 },
                    { 44, 31, 21 },
                    { 45, 31, 23 },
                    { 46, 31, 22 },
                    { 47, 33, 18 },
                    { 48, 34, 21 },
                    { 49, 16, 4 },
                    { 50, 16, 2 },
                    { 51, 35, 12 },
                    { 52, 35, 13 },
                    { 53, 17, 7 },
                    { 54, 17, 6 },
                    { 55, 17, 20 },
                    { 56, 17, 22 },
                    { 57, 36, 19 },
                    { 58, 36, 16 },
                    { 59, 36, 17 },
                    { 60, 37, 19 },
                    { 61, 37, 16 },
                    { 62, 37, 17 },
                    { 63, 38, 19 },
                    { 64, 38, 16 },
                    { 65, 38, 17 },
                    { 66, 39, 12 },
                    { 67, 39, 13 },
                    { 68, 40, 12 },
                    { 69, 40, 13 },
                    { 70, 19, 3 },
                    { 71, 41, 19 },
                    { 72, 41, 16 },
                    { 73, 41, 17 },
                    { 74, 20, 8 },
                    { 75, 20, 12 },
                    { 76, 20, 13 },
                    { 77, 21, 8 },
                    { 78, 21, 5 },
                    { 79, 22, 3 },
                    { 80, 23, 7 },
                    { 81, 23, 6 },
                    { 82, 24, 8 },
                    { 83, 24, 5 },
                    { 84, 25, 6 },
                    { 85, 26, 7 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_GameVersionId",
                table: "Characters",
                column: "GameVersionId");

            migrationBuilder.CreateIndex(
                name: "IX_Fish_GameVersionId",
                table: "Fish",
                column: "GameVersionId");

            migrationBuilder.CreateIndex(
                name: "IX_FishLocations_FishId",
                table: "FishLocations",
                column: "FishId");

            migrationBuilder.CreateIndex(
                name: "IX_FishLocations_LocationId",
                table: "FishLocations",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_IngredientMeal_MealsMealId",
                table: "IngredientMeal",
                column: "MealsMealId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_GameVersionId",
                table: "Ingredients",
                column: "GameVersionId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_GameVersionId",
                table: "Locations",
                column: "GameVersionId");

            migrationBuilder.CreateIndex(
                name: "IX_MealIngredients_IngredientId",
                table: "MealIngredients",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_Meals_GameVersionId",
                table: "Meals",
                column: "GameVersionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Characters");

            migrationBuilder.DropTable(
                name: "FishLocations");

            migrationBuilder.DropTable(
                name: "IngredientMeal");

            migrationBuilder.DropTable(
                name: "MealIngredients");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Fish");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "Meals");

            migrationBuilder.DropTable(
                name: "GameVersion");
        }
    }
}
