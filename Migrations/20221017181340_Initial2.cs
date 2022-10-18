using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace todo_api.Migrations
{
    public partial class Initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                oldDefaultValue: new DateTime(2022, 10, 17, 17, 44, 1, 498, DateTimeKind.Utc).AddTicks(14));

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
                oldDefaultValue: new DateTime(2022, 10, 17, 17, 44, 1, 497, DateTimeKind.Utc).AddTicks(9773));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdate",
                table: "Todo",
                type: "SMALLDATETIME",
                maxLength: 60,
                nullable: false,
                defaultValue: new DateTime(2022, 10, 17, 17, 44, 1, 498, DateTimeKind.Utc).AddTicks(14),
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
                defaultValue: new DateTime(2022, 10, 17, 17, 44, 1, 497, DateTimeKind.Utc).AddTicks(9773),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldMaxLength: 60,
                oldDefaultValue: new DateTime(2022, 10, 17, 18, 13, 40, 656, DateTimeKind.Utc).AddTicks(9994));
        }
    }
}
