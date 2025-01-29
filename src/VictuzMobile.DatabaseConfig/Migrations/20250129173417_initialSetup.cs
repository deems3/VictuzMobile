using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VictuzMobile.DatabaseConfig.Migrations
{
    /// <inheritdoc />
    public partial class initialSetup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Street = table.Column<string>(type: "TEXT", nullable: false),
                    Housenumber = table.Column<string>(type: "TEXT", nullable: false),
                    PostalCode = table.Column<string>(type: "TEXT", nullable: false),
                    Province = table.Column<string>(type: "TEXT", nullable: false),
                    City = table.Column<string>(type: "TEXT", nullable: false),
                    Country = table.Column<string>(type: "TEXT", nullable: false),
                    CustomText = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Username = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: false),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: false),
                    DisplayName = table.Column<string>(type: "TEXT", nullable: false),
                    StudentNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    Limited = table.Column<bool>(type: "INTEGER", nullable: false),
                    Role = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Activities",
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
                    table.PrimaryKey("PK_Activities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Activities_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Activities_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Activities_Users_OrganiserId",
                        column: x => x.OrganiserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "Registrations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    ActivityId = table.Column<int>(type: "INTEGER", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    SuggestionId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registrations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Registrations_Activities_ActivityId",
                        column: x => x.ActivityId,
                        principalTable: "Activities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Registrations_Suggestions_SuggestionId",
                        column: x => x.SuggestionId,
                        principalTable: "Suggestions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Registrations_Users_UserId",
                        column: x => x.UserId,
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
                columns: new[] { "Id", "City", "Country", "CustomText", "Housenumber", "PostalCode", "Province", "Street" },
                values: new object[] { 1, "Heerlen", "Nederland", null, "300", "6419 DJ", "Limburg", "Nieuw Eyckholt" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "DisplayName", "Email", "Limited", "PasswordHash", "PhoneNumber", "Role", "StudentNumber", "Username" },
                values: new object[,]
                {
                    { 1, "Demi", "demi@example.com", false, "$2a$11$C/eNd9h0Ju/wRySYCJCyp.t.qh3pZzD0aEhUyNmc1murYt/G9J3Xq", "123456789", 1, 1234567, "demi" },
                    { 2, "Mees", "mees@example.com", false, "$2a$11$C/eNd9h0Ju/wRySYCJCyp.t.qh3pZzD0aEhUyNmc1murYt/G9J3Xq", "123456789", 1, 2345678, "mees" },
                    { 3, "Bas", "bas@example.com", false, "$2a$11$C/eNd9h0Ju/wRySYCJCyp.t.qh3pZzD0aEhUyNmc1murYt/G9J3Xq", "123456789", 1, 3456789, "bas" },
                    { 4, "Finn", "finn@example.com", false, "$2a$11$C/eNd9h0Ju/wRySYCJCyp.t.qh3pZzD0aEhUyNmc1murYt/G9J3Xq", "123456789", 1, 4567890, "finn" },
                    { 5, "User", "user@example.com", false, "$2a$11$C/eNd9h0Ju/wRySYCJCyp.t.qh3pZzD0aEhUyNmc1murYt/G9J3Xq", "123456789", 1, 8971627, "user" },
                    { 6, "Admin", "admin@example.com", false, "$2a$11$C/eNd9h0Ju/wRySYCJCyp.t.qh3pZzD0aEhUyNmc1murYt/G9J3Xq", "123456789", 0, 7176123, "admin" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "CategoryId", "Description", "EndDate", "ImageURL", "LocationId", "MaxRegistrations", "Name", "OrganiserId", "StartDate" },
                values: new object[,]
                {
                    { 1, 1, "Kom voetballen", new DateTime(2026, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://cdn.pixabay.com/photo/2014/10/14/20/24/ball-488718_640.jpg", 1, 22, "Voetbal Toernooi", 2, new DateTime(2026, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 2, "Leer hoe jij je eigen AI kunt maken", new DateTime(2026, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://img.freepik.com/free-photo/ai-human-technology-background_1409-5588.jpg", 1, 6, "Omgaan met AI", 1, new DateTime(2026, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 3, "Klei je eigen technische tool", new DateTime(2026, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://cdn.pixabay.com/photo/2016/03/27/17/10/pottery-1283146_1280.jpg", 1, 10, "Kleien", 3, new DateTime(2026, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Suggestions",
                columns: new[] { "Id", "CategoryId", "Description", "EndDate", "ImageURL", "LocationId", "MaxRegistrations", "Name", "OrganiserId", "StartDate" },
                values: new object[,]
                {
                    { 1, 3, "Leer hoe jij je eigen netwerk kunt beveiligen", new DateTime(2026, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "cybersecurity.jpg", 1, 10, "Cybersecurity", 2, new DateTime(2026, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 4, "Programmeer je eigen robot", new DateTime(2026, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "robot_suggestion.jpg", 1, 6, "Robots programmeren", 1, new DateTime(2026, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activities_CategoryId",
                table: "Activities",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_LocationId",
                table: "Activities",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_OrganiserId",
                table: "Activities",
                column: "OrganiserId");

            migrationBuilder.CreateIndex(
                name: "IX_Registrations_ActivityId",
                table: "Registrations",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_Registrations_SuggestionId",
                table: "Registrations",
                column: "SuggestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Registrations_UserId",
                table: "Registrations",
                column: "UserId");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Registrations");

            migrationBuilder.DropTable(
                name: "SuggestionLikes");

            migrationBuilder.DropTable(
                name: "Activities");

            migrationBuilder.DropTable(
                name: "Suggestions");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
