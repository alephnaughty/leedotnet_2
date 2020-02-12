using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace api_server_new.Migrations
{
    public partial class lee2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Users",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Orders",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Orders",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date", "Status" },
                values: new object[] { new DateTime(2020, 2, 11, 17, 32, 11, 760, DateTimeKind.Local).AddTicks(7925), "Open" });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date", "Status" },
                values: new object[] { new DateTime(2020, 2, 11, 17, 32, 11, 766, DateTimeKind.Local).AddTicks(435), "Open" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "Orders");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Orders",
                type: "int",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date", "Status" },
                values: new object[] { new DateTime(2020, 2, 11, 14, 49, 30, 52, DateTimeKind.Local).AddTicks(6148), 0 });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date", "Status" },
                values: new object[] { new DateTime(2020, 2, 11, 14, 49, 30, 57, DateTimeKind.Local).AddTicks(1153), 0 });
        }
    }
}
