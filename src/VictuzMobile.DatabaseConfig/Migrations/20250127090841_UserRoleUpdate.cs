using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VictuzMobile.DatabaseConfig.Migrations
{
    /// <inheritdoc />
    public partial class UserRoleUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "Users",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Role",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Role",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Role",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "Role",
                value: 1);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "DisplayName", "Email", "Limited", "PasswordHash", "PhoneNumber", "Role", "StudentNumber", "SuggestionId", "Username" },
                values: new object[,]
                {
                    { 5, "User", "user@example.com", false, "$2a$11$C/eNd9h0Ju/wRySYCJCyp.t.qh3pZzD0aEhUyNmc1murYt/G9J3Xq", "123456789", 1, 8971627, null, "user" },
                    { 6, "Admin", "admin@example.com", false, "$2a$11$C/eNd9h0Ju/wRySYCJCyp.t.qh3pZzD0aEhUyNmc1murYt/G9J3Xq", "123456789", 0, 7176123, null, "admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DropColumn(
                name: "Role",
                table: "Users");
        }
    }
}
