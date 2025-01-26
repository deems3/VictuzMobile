using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VictuzMobile.DatabaseConfig.Migrations
{
    /// <inheritdoc />
    public partial class ReAddSeededActivities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "CategoryId", "Description", "Discriminator", "EndDate", "ImageURL", "LocationId", "MaxRegistrations", "Name", "OrganiserId", "StartDate" },
                values: new object[,]
                {
                    { 1, 1, "Kom voetballen", "Activity", new DateTime(2025, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://cdn.pixabay.com/photo/2014/10/14/20/24/ball-488718_640.jpg", 1, 22, "Voetbal Toernooi", 2, new DateTime(2025, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 2, "Leer hoe jij je eigen AI kunt maken", "Activity", new DateTime(2025, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://img.freepik.com/free-photo/ai-human-technology-background_1409-5588.jpg", 1, 6, "Omgaan met AI", 1, new DateTime(2025, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 3, "Klei je eigen technische tool", "Activity", new DateTime(2025, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://cdn.pixabay.com/photo/2016/03/27/17/10/pottery-1283146_1280.jpg", 1, 10, "Kleien", 3, new DateTime(2025, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
