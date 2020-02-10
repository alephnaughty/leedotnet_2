using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace api_server.Migrations
{
    public partial class Relations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
               //migrationBuilder.DropForeignKey(
               // name: "FK_Order_Order_ContentId",
               // table: "Order");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_Product_OrderC_OrderContentId",
            //    table: "Product");

            migrationBuilder.DropTable(
                name: "OrderContent");

            migrationBuilder.DropIndex(
                name: "IX_Product_OrderContentId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Order_ContentId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "OrderContentId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ContentId",
                table: "Order");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Order",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "OrderLineitem",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ProductId = table.Column<Guid>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    OrderId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderLineitem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderLineitem_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderLineitem_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_UserId",
                table: "Order",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderLineitem_OrderId",
                table: "OrderLineitem",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderLineitem_ProductId",
                table: "OrderLineitem",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_User_UserId",
                table: "Order",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_User_UserId",
                table: "Order");

            migrationBuilder.DropTable(
                name: "OrderLineitem");

            migrationBuilder.DropIndex(
                name: "IX_Order_UserId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Order");

            migrationBuilder.AddColumn<Guid>(
                name: "OrderContentId",
                table: "Product",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ContentId",
                table: "Order",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_OrderContentId",
                table: "Product",
                column: "OrderContentId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_ContentId",
                table: "Order",
                column: "ContentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_OrderItems_ContentId",
                table: "Order",
                column: "ContentId",
                principalTable: "OrderItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_OrderItems_OrderContentId",
                table: "Product",
                column: "OrderContentId",
                principalTable: "OrderItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
