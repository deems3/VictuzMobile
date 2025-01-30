using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VictuzMobile.DatabaseConfig.Migrations
{
    /// <inheritdoc />
    public partial class SecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2026, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2026, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2026, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Suggestions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2026, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2026, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2026, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2026, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Suggestions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2026, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
