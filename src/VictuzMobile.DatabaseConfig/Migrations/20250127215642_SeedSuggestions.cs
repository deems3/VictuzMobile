using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VictuzMobile.DatabaseConfig.Migrations
{
    /// <inheritdoc />
    public partial class SeedSuggestions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Activities_SuggestionId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_SuggestionId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "SuggestionId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Activities");

            migrationBuilder.AddColumn<int>(
                name: "SuggestionId",
                table: "Registrations",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Suggestions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    MaxRegistrations = table.Column<int>(type: "INTEGER", nullable: false),
                    ImageURL = table.Column<string>(type: "TEXT", nullable: false),
                    StartDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false),
                    OrganiserId = table.Column<int>(type: "INTEGER", nullable: false),
                    LocationId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suggestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Suggestions_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Suggestions_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Suggestions_Users_OrganiserId",
                        column: x => x.OrganiserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SuggestionLikes",
                columns: table => new
                {
                    LikedByUsersId = table.Column<int>(type: "INTEGER", nullable: false),
                    LikedSuggestionsId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuggestionLikes", x => new { x.LikedByUsersId, x.LikedSuggestionsId });
                    table.ForeignKey(
                        name: "FK_SuggestionLikes_Suggestions_LikedSuggestionsId",
                        column: x => x.LikedSuggestionsId,
                        principalTable: "Suggestions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SuggestionLikes_Users_LikedByUsersId",
                        column: x => x.LikedByUsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Suggestions",
                columns: new[] { "Id", "CategoryId", "Description", "EndDate", "ImageURL", "LocationId", "MaxRegistrations", "Name", "OrganiserId", "StartDate" },
                values: new object[,]
                {
                    { 1, 3, "Leer hoe jij je eigen netwerk kunt beveiligen", new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "cybersecurity.jpg", 1, 10, "Cybersecurity", 2, new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 4, "Programmeer je eigen robot", new DateTime(2025, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "robot_suggestion.jpg", 1, 6, "Robots programmeren", 1, new DateTime(2025, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Registrations_SuggestionId",
                table: "Registrations",
                column: "SuggestionId");

            migrationBuilder.CreateIndex(
                name: "IX_SuggestionLikes_LikedSuggestionsId",
                table: "SuggestionLikes",
                column: "LikedSuggestionsId");

            migrationBuilder.CreateIndex(
                name: "IX_Suggestions_CategoryId",
                table: "Suggestions",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Suggestions_LocationId",
                table: "Suggestions",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Suggestions_OrganiserId",
                table: "Suggestions",
                column: "OrganiserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Registrations_Suggestions_SuggestionId",
                table: "Registrations",
                column: "SuggestionId",
                principalTable: "Suggestions",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Registrations_Suggestions_SuggestionId",
                table: "Registrations");

            migrationBuilder.DropTable(
                name: "SuggestionLikes");

            migrationBuilder.DropTable(
                name: "Suggestions");

            migrationBuilder.DropIndex(
                name: "IX_Registrations_SuggestionId",
                table: "Registrations");

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

            migrationBuilder.DropColumn(
                name: "SuggestionId",
                table: "Registrations");

            migrationBuilder.AddColumn<int>(
                name: "SuggestionId",
                table: "Users",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Activities",
                type: "TEXT",
                maxLength: 13,
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "CategoryId", "Description", "Discriminator", "EndDate", "ImageURL", "LocationId", "MaxRegistrations", "Name", "OrganiserId", "StartDate" },
                values: new object[,]
                {
                    { 1, 1, "Kom voetballen", "Activity", new DateTime(2025, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://cdn.pixabay.com/photo/2014/10/14/20/24/ball-488718_640.jpg", 1, 22, "Voetbal Toernooi", 2, new DateTime(2025, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 2, "Leer hoe jij je eigen AI kunt maken", "Activity", new DateTime(2025, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://img.freepik.com/free-photo/ai-human-technology-background_1409-5588.jpg", 1, 6, "Omgaan met AI", 1, new DateTime(2025, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 3, "Klei je eigen technische tool", "Activity", new DateTime(2025, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://cdn.pixabay.com/photo/2016/03/27/17/10/pottery-1283146_1280.jpg", 1, 10, "Kleien", 3, new DateTime(2025, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "SuggestionId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "SuggestionId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "SuggestionId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "SuggestionId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "SuggestionId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                column: "SuggestionId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Users_SuggestionId",
                table: "Users",
                column: "SuggestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Activities_SuggestionId",
                table: "Users",
                column: "SuggestionId",
                principalTable: "Activities",
                principalColumn: "Id");
        }
    }
}
