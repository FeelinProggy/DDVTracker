using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DDVTracker.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "FishLocations",
                keyColumn: "FishLocationId",
                keyValue: 2,
                column: "LocationId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "FishLocations",
                keyColumn: "FishLocationId",
                keyValue: 3,
                column: "LocationId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "FishLocations",
                keyColumn: "FishLocationId",
                keyValue: 4,
                column: "LocationId",
                value: 4);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "FishLocations",
                keyColumn: "FishLocationId",
                keyValue: 2,
                column: "LocationId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "FishLocations",
                keyColumn: "FishLocationId",
                keyValue: 3,
                column: "LocationId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "FishLocations",
                keyColumn: "FishLocationId",
                keyValue: 4,
                column: "LocationId",
                value: 1);
        }
    }
}
