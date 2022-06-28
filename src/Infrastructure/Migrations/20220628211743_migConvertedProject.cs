using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class migConvertedProject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "ProductShopList");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "ShopLists");

            migrationBuilder.DropColumn(
                name: "IsExist",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "StockAmount",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "ShopLists",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Products",
                newName: "ShopListId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                newName: "IX_Products_ShopListId");

            migrationBuilder.AddColumn<string>(
                name: "CategoryId",
                table: "ShopLists",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Unit",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<bool>(
                name: "IsBuy",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_ShopLists_CategoryId",
                table: "ShopLists",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ShopLists_ShopListId",
                table: "Products",
                column: "ShopListId",
                principalTable: "ShopLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShopLists_Categories_CategoryId",
                table: "ShopLists",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ShopLists_ShopListId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_ShopLists_Categories_CategoryId",
                table: "ShopLists");

            migrationBuilder.DropIndex(
                name: "IX_ShopLists_CategoryId",
                table: "ShopLists");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "ShopLists");

            migrationBuilder.DropColumn(
                name: "IsBuy",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "ShopLists",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "ShopListId",
                table: "Products",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_ShopListId",
                table: "Products",
                newName: "IX_Products_CategoryId");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "ShopLists",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "Unit",
                table: "Products",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<bool>(
                name: "IsExist",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<int>(
                name: "StockAmount",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ProductShopList",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProductId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ShopListId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    IsBuy = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductShopList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductShopList_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductShopList_ShopLists_ShopListId",
                        column: x => x.ShopListId,
                        principalTable: "ShopLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductShopList_ProductId",
                table: "ProductShopList",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductShopList_ShopListId",
                table: "ProductShopList",
                column: "ShopListId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
