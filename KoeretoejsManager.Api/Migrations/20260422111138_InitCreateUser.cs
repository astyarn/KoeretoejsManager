using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KoeretoejsManager.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitCreateUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DrivingLicenses",
                columns: table => new
                {
                    DrivingLicenseId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Type = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrivingLicenses", x => x.DrivingLicenseId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserName = table.Column<string>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "UserDrivingLicenses",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    DrivingLicenseId = table.Column<int>(type: "INTEGER", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDrivingLicenses", x => new { x.UserId, x.DrivingLicenseId });
                    table.ForeignKey(
                        name: "FK_UserDrivingLicenses_DrivingLicenses_DrivingLicenseId",
                        column: x => x.DrivingLicenseId,
                        principalTable: "DrivingLicenses",
                        principalColumn: "DrivingLicenseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserDrivingLicenses_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "DrivingLicenses",
                columns: new[] { "DrivingLicenseId", "Type" },
                values: new object[,]
                {
                    { 1, "Unknown" },
                    { 2, "B" },
                    { 3, "BE" },
                    { 4, "C" },
                    { 5, "C1" },
                    { 6, "CE" },
                    { 7, "C1E" },
                    { 8, "D" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserDrivingLicenses_DrivingLicenseId",
                table: "UserDrivingLicenses",
                column: "DrivingLicenseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserDrivingLicenses");

            migrationBuilder.DropTable(
                name: "DrivingLicenses");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
