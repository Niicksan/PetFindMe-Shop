using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetFindMeShop.Data.Migrations
{
    public partial class AddAllEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterTable(
                name: "AspNetUsers",
                comment: "Customer");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "AspNetUserTokens",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                comment: "Date and time of creation");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                comment: "Date and time of updation");

            migrationBuilder.AlterColumn<Guid>(
                name: "RoleId",
                table: "AspNetUserRoles",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "AspNetUserRoles",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "AspNetUserLogins",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "AspNetUserClaims",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "AspNetRoles",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<Guid>(
                name: "RoleId",
                table: "AspNetRoleClaims",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Primery key")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Name of the Category"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date and time of creation"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date and time of updation")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                },
                comment: "Category");

            migrationBuilder.CreateTable(
                name: "ShopManager",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Primery key"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "ShopManager FirstName"),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "ShopManager LastName"),
                    PhoneNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false, comment: "ShopManager PhoneNumber"),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "ForeignKey to Customer"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date and time of creation"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date and time of updation")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopManager", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShopManager_AspNetUsers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "ShopManager");

            migrationBuilder.CreateTable(
                name: "Shops",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Primery key")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Name of the Shop"),
                    ShopImageName = table.Column<string>(type: "nvarchar(max)", maxLength: 4096, nullable: false, comment: "Shop image name"),
                    Description = table.Column<string>(type: "nvarchar(3000)", maxLength: 3000, nullable: false, comment: "Description of the shop"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date and time of creation"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date and time of updation")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shops", x => x.Id);
                },
                comment: "Shop");

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Primery key"),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "ForeignKey to Customer"),
                    ShopId = table.Column<int>(type: "int", nullable: false, comment: "ForeignKey to Shop"),
                    FullName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false, comment: "Customer's Full Name"),
                    City = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, comment: "Customer's City for delivery"),
                    Address = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false, comment: "Customer's Address for delivery"),
                    Phone = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false, comment: "Customer's Phone"),
                    OrderedProducts = table.Column<int>(type: "int", nullable: false, comment: "Total number of ordered"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date and time of creation"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date and time of updation")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_AspNetUsers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_Shops_ShopId",
                        column: x => x.ShopId,
                        principalTable: "Shops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Order");

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Primery key")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false, comment: "Title of the product"),
                    ImageName = table.Column<string>(type: "nvarchar(max)", maxLength: 4096, nullable: false, comment: "Image name of the product"),
                    Description = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: false, comment: "Description of the product"),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Price of the product"),
                    AvailableQuantity = table.Column<int>(type: "int", nullable: false, comment: "Quantity of the product"),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false, comment: "Is the product in stock"),
                    CategoryId = table.Column<int>(type: "int", nullable: false, comment: "ForeignKey to Category"),
                    ShopId = table.Column<int>(type: "int", nullable: false, comment: "ForeignKey to Shop"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date and time of creation"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date and time of updation"),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date and time of deletion")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Shops_ShopId",
                        column: x => x.ShopId,
                        principalTable: "Shops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Product");

            migrationBuilder.CreateTable(
                name: "ShopsManagers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Primery key")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShopId = table.Column<int>(type: "int", nullable: false, comment: "ForeignKey to Shop"),
                    ShopManagerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "ForeignKey to ShopManager"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date and time of creation"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date and time of updation")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopsManagers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShopsManagers_ShopManager_ShopManagerId",
                        column: x => x.ShopManagerId,
                        principalTable: "ShopManager",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShopsManagers_Shops_ShopId",
                        column: x => x.ShopId,
                        principalTable: "Shops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Shops Manager");

            migrationBuilder.CreateTable(
                name: "LikedProduct",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Primery key")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "ForeignKey to Customer"),
                    ProductId = table.Column<int>(type: "int", nullable: false, comment: "ForeignKey to Product"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date and time of creation"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date and time of updation")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LikedProduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LikedProduct_AspNetUsers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LikedProduct_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Liked Product");

            migrationBuilder.CreateTable(
                name: "OrderItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Primery key")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false, comment: "ForeignKey to Product"),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "ForeignKey to Order"),
                    BoughtQuantity = table.Column<int>(type: "int", nullable: false, comment: "Bought Quantity of the Product"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date and time of creation"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date and time of updation")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItem_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItem_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Order Item");

            migrationBuilder.CreateIndex(
                name: "IX_LikedProduct_CustomerId",
                table: "LikedProduct",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_LikedProduct_ProductId",
                table: "LikedProduct",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_CustomerId",
                table: "Order",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_ShopId",
                table: "Order",
                column: "ShopId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_OrderId",
                table: "OrderItem",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_ProductId",
                table: "OrderItem",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ShopId",
                table: "Products",
                column: "ShopId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopManager_CustomerId",
                table: "ShopManager",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopsManagers_ShopId",
                table: "ShopsManagers",
                column: "ShopId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopsManagers_ShopManagerId",
                table: "ShopsManagers",
                column: "ShopManagerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LikedProduct");

            migrationBuilder.DropTable(
                name: "OrderItem");

            migrationBuilder.DropTable(
                name: "ShopsManagers");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "ShopManager");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Shops");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "AspNetUsers");

            migrationBuilder.AlterTable(
                name: "AspNetUsers",
                oldComment: "Customer");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "RoleId",
                table: "AspNetUserRoles",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "AspNetUserRoles",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "AspNetUserClaims",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "AspNetRoles",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "RoleId",
                table: "AspNetRoleClaims",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");
        }
    }
}
