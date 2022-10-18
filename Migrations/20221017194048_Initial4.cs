using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace todo_api.Migrations
{
    public partial class Initial4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdate",
                table: "Todo",
                type: "SMALLDATETIME",
                maxLength: 60,
                nullable: false,
                defaultValue: new DateTime(2022, 10, 17, 19, 40, 48, 520, DateTimeKind.Utc).AddTicks(569),
                oldClrType: typeof(DateTime),
                oldType: "SMALLDATETIME",
                oldMaxLength: 60,
                oldDefaultValue: new DateTime(2022, 10, 17, 19, 24, 39, 954, DateTimeKind.Utc).AddTicks(278));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Todo",
                type: "SMALLDATETIME",
                maxLength: 60,
                nullable: false,
                defaultValue: new DateTime(2022, 10, 17, 19, 40, 48, 520, DateTimeKind.Utc).AddTicks(320),
                oldClrType: typeof(DateTime),
                oldType: "SMALLDATETIME",
                oldMaxLength: 60,
                oldDefaultValue: new DateTime(2022, 10, 17, 19, 24, 39, 954, DateTimeKind.Utc).AddTicks(28));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdate",
                table: "Todo",
                type: "SMALLDATETIME",
                maxLength: 60,
                nullable: false,
                defaultValue: new DateTime(2022, 10, 17, 19, 24, 39, 954, DateTimeKind.Utc).AddTicks(278),
                oldClrType: typeof(DateTime),
                oldType: "SMALLDATETIME",
                oldMaxLength: 60,
                oldDefaultValue: new DateTime(2022, 10, 17, 19, 40, 48, 520, DateTimeKind.Utc).AddTicks(569));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Todo",
                type: "SMALLDATETIME",
                maxLength: 60,
                nullable: false,
                defaultValue: new DateTime(2022, 10, 17, 19, 24, 39, 954, DateTimeKind.Utc).AddTicks(28),
                oldClrType: typeof(DateTime),
                oldType: "SMALLDATETIME",
                oldMaxLength: 60,
                oldDefaultValue: new DateTime(2022, 10, 17, 19, 40, 48, 520, DateTimeKind.Utc).AddTicks(320));
        }
    }
}
