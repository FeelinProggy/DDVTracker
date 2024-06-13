using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DDVTracker.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddIngredients : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ingredient",
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
                    table.PrimaryKey("PK_Ingredient", x => x.IngredientId);
                    table.ForeignKey(
                        name: "FK_Ingredient_GameVersion_GameVersionId",
                        column: x => x.GameVersionId,
                        principalTable: "GameVersion",
                        principalColumn: "GameVersionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Ingredient",
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
                values: new object[] { 32, null, 1, "Chez Remy" });

            migrationBuilder.CreateIndex(
                name: "IX_Ingredient_GameVersionId",
                table: "Ingredient",
                column: "GameVersionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ingredient");

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 32);
        }
    }
}
