using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DDVTracker.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddFish : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Fish",
                columns: table => new
                {
                    FishId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameVersionId = table.Column<int>(type: "int", nullable: false),
                    FishName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FishImage = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    FishLocations = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RippleColor = table.Column<string>(type: "nvarchar(max)", nullable: false)
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

            migrationBuilder.InsertData(
                table: "Fish",
                columns: new[] { "FishId", "FishImage", "FishLocations", "FishName", "GameVersionId", "RippleColor" },
                values: new object[,]
                {
                    { 1, null, null, "Bass", 1, "white" },
                    { 2, null, null, "Robot Fish", 2, "blue" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Fish_GameVersionId",
                table: "Fish",
                column: "GameVersionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fish");
        }
    }
}
