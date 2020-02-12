using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace api_server_new.Migrations
{
    public partial class lee1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Orders",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2020, 2, 11, 14, 49, 30, 52, DateTimeKind.Local).AddTicks(6148));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2020, 2, 11, 14, 49, 30, 57, DateTimeKind.Local).AddTicks(1153));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Orders");

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2020, 2, 10, 13, 21, 54, 883, DateTimeKind.Local).AddTicks(2674));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2020, 2, 10, 13, 21, 54, 887, DateTimeKind.Local).AddTicks(1997));
        }
    }
}
