using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetFindMeShop.Data.Migrations
{
    public partial class AddAllEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()", comment: "Date and time of creation"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()", comment: "Date and time of updation"),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                },
                comment: "Customer");

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Primery key")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Name of the Category"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()", comment: "Date and time of creation"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()", comment: "Date and time of updation")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                },
                comment: "Category");

            migrationBuilder.CreateTable(
                name: "Shops",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Primery key")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Name of the Shop"),
                    ShopImageName = table.Column<string>(type: "nvarchar(max)", maxLength: 4096, nullable: false, comment: "Shop image name"),
                    Description = table.Column<string>(type: "nvarchar(3000)", maxLength: 3000, nullable: false, comment: "Description of the shop"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()", comment: "Date and time of creation"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()", comment: "Date and time of updation")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shops", x => x.Id);
                },
                comment: "Shop");

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Primery key"),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "ForeignKey to Customer"),
                    FisrtName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false, comment: "Customer's First Name"),
                    LastName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false, comment: "Customer's Last Name"),
                    City = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, comment: "Customer's City for delivery"),
                    Address = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false, comment: "Customer's Address for delivery"),
                    Phone = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false, comment: "Customer's Phone"),
                    TotalProductsPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Total Products Price"),
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
                },
                comment: "Order");

            migrationBuilder.CreateTable(
                name: "ShopManager",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Primery key"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "ShopManager FirstName"),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "ShopManager LastName"),
                    PhoneNumber = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false, comment: "ShopManager PhoneNumber"),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "ForeignKey to Customer"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()", comment: "Date and time of creation"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()", comment: "Date and time of updation")
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
                name: "ShoppingCarts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Primery key"),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "ForeignKey to Customer"),
                    TotalProductsPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Total Products Price"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date and time of creation"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date and time of updation")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCarts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoppingCarts_AspNetUsers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Shopping Cart");

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
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false, defaultValue: true, comment: "Is the product in stock"),
                    CategoryId = table.Column<int>(type: "int", nullable: false, comment: "ForeignKey to Category"),
                    ShopId = table.Column<int>(type: "int", nullable: false, comment: "ForeignKey to Shop"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()", comment: "Date and time of creation"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()", comment: "Date and time of updation"),
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
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()", comment: "Date and time of creation"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()", comment: "Date and time of updation")
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
                    ShopId = table.Column<int>(type: "int", nullable: false, comment: "ForeignKey to Shop"),
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
                    table.ForeignKey(
                        name: "FK_OrderItem_Shops_ShopId",
                        column: x => x.ShopId,
                        principalTable: "Shops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Order Item");

            migrationBuilder.CreateTable(
                name: "ShoppingCartItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Primery key")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false, comment: "ForeignKey to Product"),
                    ShoppingCartId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "ForeignKey to Shopping Cart"),
                    BoughtQuantity = table.Column<int>(type: "int", nullable: false, comment: "Bought Quantity of the Product"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date and time of creation"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date and time of updation")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCartItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoppingCartItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShoppingCartItems_ShoppingCarts_ShoppingCartId",
                        column: x => x.ShoppingCartId,
                        principalTable: "ShoppingCarts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Shopping Cart Item");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("6dcf663d-7cc9-4249-73fc-08db7fe046b6"), 0, "ab1755fa-4ea8-47e8-aa13-c57fae13a4a9", "admin@petfindmeshop.bg", true, true, null, "ADMIN@PETFINDME.BG", "ADMIN", "AQAAAAEAACcQAAAAEIQgYMg7O5kz2TFizJcIHhbWWZ/WKDk9wnYC8ZUqKkATg0O4cM5tpqm/MeC0akVuYg==", null, false, "KAKHTVIWBHSUI4ESCAVXXEFC2UZ2JX44", false, "admin" },
                    { new Guid("811c2b9d-b754-44ef-783b-08db7fbc8275"), 0, "4300bc13-f79a-42fb-abce-a54c520bbac5", "maneger@abv.bg", true, true, null, "MANAGER@ABV.BG", "MANAGER", "AQAAAAEAACcQAAAAEGHe5VpU7YcGJEl2cW2YKNOZH2Tham+ppx4D/445+1UrE01UxPPDbvr6BYsJ2+boQQ==", null, false, "JZDXAYLLGTFDW2QPGEWCOEMNS2XMOHE5", false, "maneger" },
                    { new Guid("98c666ac-9aee-80c3-5686-08db7fbb6666"), 0, "ffc7bb00-b000-4c61-b41b-e34f908c34c1", "customer@abv.bg", true, true, null, "CUSTOMER@ABV.BG", "CUSTOMER", "AQAAAAEAACcQAAAAELhEjbSIfCkhGNJ7d5s280DOXxzjDCXbq/Z+Vv3j+vXpbAYq5xKbewpC8437GZ/FdA==", null, false, "LUTV3ZFEY6XFBCSJEGW3JIA62BBWBETZ", false, "customer" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Купи и диспенсъри за храна и вода" },
                    { 2, "Гребени и четки" },
                    { 3, "Сухи храни за кучета" },
                    { 4, "Консервирани храни за кучета" },
                    { 5, "Нашийници, нагръдници, поводи" },
                    { 6, "Легла за куче" },
                    { 7, "Играчки за кучета" },
                    { 8, "Шампоани за кучета" },
                    { 9, "Сухи храни за котки" },
                    { 10, "Консервирани храни за котки" },
                    { 11, "Транспортни клетки" },
                    { 12, "Катерушки и легла" },
                    { 13, "Котешки тоалетни и консумативи" },
                    { 14, "Играчки за катки" },
                    { 15, "Шампоани за котки" }
                });

            migrationBuilder.InsertData(
                table: "Shops",
                columns: new[] { "Id", "Description", "Name", "ShopImageName" },
                values: new object[] { 1, "Very cool Pet Shop", "NikPetShop", "https://www.petshop.bg/media/t46s-10/1603.webp" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "AvailableQuantity", "CategoryId", "DeletedAt", "Description", "ImageName", "Price", "ShopId", "Title" },
                values: new object[,]
                {
                    { 1, 1000, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Advance Veterinary Diets Hypoallergenic е диетична храна за кучета с алергичен дерматит и гастрит или пък с непоносимости към определени храни. В състава на храната се влагат само внимателно подбрани източници на протеини и въглехидрати, което я прави много добре поносима. Advance Veterinary Diets Hypoallergenic може да подпомогне оздравителния процес при последващи заболявания като лимфангиектазия или възпаление на червата. Като източник на протеини е използван хидролизиран соев протеин. Той няма антигенен потенциал и съответно няма как да отключи алергична реакция. Изключително високата смилаемост на тази храна е фактор с основно значение при терапията на ентеропатии и стомашно-чревни смущения.", "https://www.petshop.bg/media/t46s-4/183.webp", 16.50m, 1, "Advance Dog VET DIETS HYPOALLERGENIC 2.5кг" },
                    { 2, 1000, 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Вашата котка е предразположена към образуване на топки косми? Специфична храна може да бъде полезна за този проблем. Natural Trainer Hairball with Chicken е разработена за тази цел, нейната адаптирана формула с високо съдържание на фибри може да помогне за намаляване на образуването на топки косми в стомаха и естествено елиминиране на погълнатите косми.\r\n\r\nТази суха храна за котки е формулирана със специфични компоненти от естествен произход, за да осигури пълноценна и балансирана диета. Освен това Natural Trainer Hairball с пиле се откроява с контролираното си минерално съдържание, което, заедно с корен от цикория и екстракт от червена боровинка, помага за поддържане на правилното функциониране на пикочните пътища през целия живот на котката. Съставът също подкрепя здравето на кожата и блясъка на козината, благодарение на есенциалните мастни киселини, биотин и цинк. Natural Trainer Hairball с пиле е разработена за възрастни котки, над една година.", "https://www.petshop.bg/media/t46s-4/436.webp", 23.50m, 1, "Natural TRAINER Cat Hairball Chicken 1.5 кг – с пиле" },
                    { 3, 1000, 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Меко двулицево легълце, със зимна страна от пухкава имитация на овча вълна и лятна страна от гладка найлонова тъкан с правоъгълна форма, нисък борд, може да се пере, подходящо за кучета", "https://s13emagst.akamaized.net/products/28760/28759268/images/res_15a701aad0f1906034a15c9bf3423014.jpg?width=450&height=450&hash=6252F38AE44582D99492052092FAA02F", 43.44m, 1, "Легло кучета с лапичка" }
                });

            migrationBuilder.InsertData(
                table: "ShopManager",
                columns: new[] { "Id", "CustomerId", "FirstName", "LastName", "PhoneNumber" },
                values: new object[] { new Guid("98c929ac-9aee-40c3-5691-08db7fbb6193"), new Guid("811c2b9d-b754-44ef-783b-08db7fbc8275"), "Shop", "Manager", "+359888888888" });

            migrationBuilder.InsertData(
                table: "ShopsManagers",
                columns: new[] { "Id", "ShopId", "ShopManagerId" },
                values: new object[] { 1, 1, new Guid("98c929ac-9aee-40c3-5691-08db7fbb6193") });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

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
                name: "IX_OrderItem_OrderId",
                table: "OrderItem",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_ProductId",
                table: "OrderItem",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_ShopId",
                table: "OrderItem",
                column: "ShopId");

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
                name: "IX_ShoppingCartItems_ProductId",
                table: "ShoppingCartItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartItems_ShoppingCartId",
                table: "ShoppingCartItems",
                column: "ShoppingCartId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCarts_CustomerId",
                table: "ShoppingCarts",
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
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "LikedProduct");

            migrationBuilder.DropTable(
                name: "OrderItem");

            migrationBuilder.DropTable(
                name: "ShoppingCartItems");

            migrationBuilder.DropTable(
                name: "ShopsManagers");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "ShoppingCarts");

            migrationBuilder.DropTable(
                name: "ShopManager");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Shops");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
