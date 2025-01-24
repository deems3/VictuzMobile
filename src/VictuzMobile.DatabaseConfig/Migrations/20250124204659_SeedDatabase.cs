using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VictuzMobile.DatabaseConfig.Migrations
{
    /// <inheritdoc />
    public partial class SeedDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Sport" },
                    { 2, "AI" },
                    { 3, "Workshop" },
                    { 4, "Programmeren" }
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "City", "Country", "Housenumber", "PostalCode", "Province", "Street" },
                values: new object[] { 1, "Heerlen", "Nederland", "300", "6419 DJ", "Limburg", "Nieuw Eyckholt" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "DisplayName", "Email", "Limited", "PasswordHash", "PhoneNumber", "StudentNumber", "SuggestionId", "Username" },
                values: new object[,]
                {
                    { 1, "Demi", "demi@example.com", false, "$2a$11$C/eNd9h0Ju/wRySYCJCyp.t.qh3pZzD0aEhUyNmc1murYt/G9J3Xq", "123456789", 1234567, null, "demi" },
                    { 2, "Mees", "mees@example.com", false, "$2a$11$C/eNd9h0Ju/wRySYCJCyp.t.qh3pZzD0aEhUyNmc1murYt/G9J3Xq", "123456789", 2345678, null, "mees" },
                    { 3, "Bas", "bas@example.com", false, "$2a$11$C/eNd9h0Ju/wRySYCJCyp.t.qh3pZzD0aEhUyNmc1murYt/G9J3Xq", "123456789", 3456789, null, "bas" },
                    { 4, "Finn", "finn@example.com", false, "$2a$11$C/eNd9h0Ju/wRySYCJCyp.t.qh3pZzD0aEhUyNmc1murYt/G9J3Xq", "123456789", 4567890, null, "finn" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "CategoryId", "Description", "Discriminator", "EndDate", "ImageURL", "LocationId", "MaxRegistrations", "Name", "OrganiserId", "StartDate" },
                values: new object[,]
                {
                    { 1, 1, "Kom voetballen", "Activity", new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://cdn.pixabay.com/photo/2014/10/14/20/24/ball-488718_640.jpg", 1, 22, "Voetbal Toernooi", 2, new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 2, "Leer hoe jij je eigen AI kunt maken", "Activity", new DateTime(2024, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://img.freepik.com/free-photo/ai-human-technology-background_1409-5588.jpg", 1, 6, "Omgaan met AI", 1, new DateTime(2024, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 3, "Klei je eigen technische tool", "Activity", new DateTime(2024, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://cdn.pixabay.com/photo/2016/03/27/17/10/pottery-1283146_1280.jpg", 1, 10, "Kleien", 3, new DateTime(2024, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) }
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

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
