using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace todo_api.Migrations
{
    public partial class Initial3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Todo",
                table: "Todo");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdate",
                table: "Todo",
                type: "SMALLDATETIME",
                maxLength: 60,
                nullable: false,
                defaultValue: new DateTime(2022, 10, 17, 19, 24, 39, 954, DateTimeKind.Utc).AddTicks(278),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldMaxLength: 60,
                oldDefaultValue: new DateTime(2022, 10, 17, 18, 13, 40, 657, DateTimeKind.Utc).AddTicks(235));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Todo",
                type: "SMALLDATETIME",
                maxLength: 60,
                nullable: false,
                defaultValue: new DateTime(2022, 10, 17, 19, 24, 39, 954, DateTimeKind.Utc).AddTicks(28),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldMaxLength: 60,
                oldDefaultValue: new DateTime(2022, 10, 17, 18, 13, 40, 656, DateTimeKind.Utc).AddTicks(9994));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Todo",
                table: "Todo",
                columns: new[] { "Title", "UserId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Todo",
                table: "Todo");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdate",
                table: "Todo",
                type: "DATETIME",
                maxLength: 60,
                nullable: false,
                defaultValue: new DateTime(2022, 10, 17, 18, 13, 40, 657, DateTimeKind.Utc).AddTicks(235),
                oldClrType: typeof(DateTime),
                oldType: "SMALLDATETIME",
                oldMaxLength: 60,
                oldDefaultValue: new DateTime(2022, 10, 17, 19, 24, 39, 954, DateTimeKind.Utc).AddTicks(278));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Todo",
                type: "DATETIME",
                maxLength: 60,
                nullable: false,
                defaultValue: new DateTime(2022, 10, 17, 18, 13, 40, 656, DateTimeKind.Utc).AddTicks(9994),
                oldClrType: typeof(DateTime),
                oldType: "SMALLDATETIME",
                oldMaxLength: 60,
                oldDefaultValue: new DateTime(2022, 10, 17, 19, 24, 39, 954, DateTimeKind.Utc).AddTicks(28));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Todo",
                table: "Todo",
                column: "Title");
        }
    }
}
