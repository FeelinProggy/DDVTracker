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
                name: "Characters",
                columns: table => new
                {
                    CharacterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameVersionId = table.Column<int>(type: "int", nullable: false),
                    CharacterName = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                columns: new[] { "CharacterId", "AssignedSkill", "CharacterLevel", "CharacterName", "FavoriteThing1", "FavoriteThing2", "FavoriteThing3", "GameVersionId", "isUnlocked" },
                values: new object[,]
                {
                    { 1, null, 1, "Mickey Mouse", null, null, null, 1, null },
                    { 2, null, 5, "Rapunzel", null, null, null, 2, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Characters_GameVersionId",
                table: "Characters",
                column: "GameVersionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Characters");

            migrationBuilder.DropTable(
                name: "GameVersion");
        }
    }
}
