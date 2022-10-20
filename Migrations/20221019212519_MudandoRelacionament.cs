using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace todo_api.Migrations
{
    public partial class MudandoRelacionament : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Name = table.Column<string>(type: "NVARCHAR(80)", maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Email = table.Column<string>(type: "NVARCHAR(80)", maxLength: 80, nullable: false),
                    Name = table.Column<string>(type: "NVARCHAR(80)", maxLength: 80, nullable: false),
                    PasswordHash = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Email);
                });

            migrationBuilder.CreateTable(
                name: "Todo",
                columns: table => new
                {
                    Title = table.Column<string>(type: "NVARCHAR(30)", maxLength: 30, nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR(80)", nullable: false),
                    Done = table.Column<bool>(type: "BIT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "SMALLDATETIME", maxLength: 60, nullable: false, defaultValue: new DateTime(2022, 10, 19, 21, 25, 19, 576, DateTimeKind.Utc).AddTicks(5915)),
                    LastUpdate = table.Column<DateTime>(type: "SMALLDATETIME", maxLength: 60, nullable: false, defaultValue: new DateTime(2022, 10, 19, 21, 25, 19, 576, DateTimeKind.Utc).AddTicks(6176))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Todo", x => new { x.Title, x.Email });
                    table.ForeignKey(
                        name: "FK_Todo_User_Email",
                        column: x => x.Email,
                        principalTable: "User",
                        principalColumn: "Email",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    RoleName = table.Column<string>(type: "NVARCHAR(80)", nullable: false),
                    UserEmail = table.Column<string>(type: "NVARCHAR(80)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => new { x.RoleName, x.UserEmail });
                    table.ForeignKey(
                        name: "FK_UserRole_Role_RoleName",
                        column: x => x.RoleName,
                        principalTable: "Role",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRole_User_UserEmail",
                        column: x => x.UserEmail,
                        principalTable: "User",
                        principalColumn: "Email",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Todo_Email",
                table: "Todo",
                column: "Email");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_UserEmail",
                table: "UserRole",
                column: "UserEmail");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Todo");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
