using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetFindMeShop.Data.Migrations
{
    public partial class AddMissingEntityCongigurations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_AspNetUsers_CustomerId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItem_Order_OrderId",
                table: "OrderItem");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItem_Products_ProductId",
                table: "OrderItem");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItem_Shops_ShopId",
                table: "OrderItem");

            migrationBuilder.DropForeignKey(
                name: "FK_ShopManager_AspNetUsers_CustomerId",
                table: "ShopManager");

            migrationBuilder.DropForeignKey(
                name: "FK_ShopsManagers_ShopManager_ShopManagerId",
                table: "ShopsManagers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShopManager",
                table: "ShopManager");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderItem",
                table: "OrderItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Order",
                table: "Order");

            migrationBuilder.RenameTable(
                name: "ShopManager",
                newName: "ShopManagers");

            migrationBuilder.RenameTable(
                name: "OrderItem",
                newName: "OrderItems");

            migrationBuilder.RenameTable(
                name: "Order",
                newName: "Orders");

            migrationBuilder.RenameIndex(
                name: "IX_ShopManager_CustomerId",
                table: "ShopManagers",
                newName: "IX_ShopManagers_CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItem_ShopId",
                table: "OrderItems",
                newName: "IX_OrderItems_ShopId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItem_ProductId",
                table: "OrderItems",
                newName: "IX_OrderItems_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItem_OrderId",
                table: "OrderItems",
                newName: "IX_OrderItems_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_Order_CustomerId",
                table: "Orders",
                newName: "IX_Orders_CustomerId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "ShoppingCarts",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()",
                comment: "Date and time of updation",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldComment: "Date and time of updation");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "ShoppingCarts",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()",
                comment: "Date and time of creation",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldComment: "Date and time of creation");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "ShoppingCartItems",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()",
                comment: "Date and time of updation",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldComment: "Date and time of updation");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "ShoppingCartItems",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()",
                comment: "Date and time of creation",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldComment: "Date and time of creation");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "OrderItems",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()",
                comment: "Date and time of updation",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldComment: "Date and time of updation");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "OrderItems",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()",
                comment: "Date and time of creation",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldComment: "Date and time of creation");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()",
                comment: "Date and time of updation",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldComment: "Date and time of updation");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()",
                comment: "Date and time of creation",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldComment: "Date and time of creation");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShopManagers",
                table: "ShopManagers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderItems",
                table: "OrderItems",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6dcf663d-7cc9-4249-73fc-08db7fe046b6"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEI4C3hfEcZChfA8jLjwp+dVz7vJPoqmHsYM+ClZLCWeZ9Kn65ZNs34wXr9lGf+Iirw==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("811c2b9d-b754-44ef-783b-08db7fbc8275"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEPmPzZnyq0D4NdMdDd42+oPKg5/th1PdQzuhv4FUs8yVLIaaLFKqIXYAIqrb7oB7JQ==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("98c666ac-9aee-80c3-5686-08db7fbb6666"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEJNW5nkLdANp5ccQz45tagw7actFj3vzuOPDqJiVDNT/Nq+Gxe7pzwbZ2OvdblN2cw==");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Orders_OrderId",
                table: "OrderItems",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Products_ProductId",
                table: "OrderItems",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Shops_ShopId",
                table: "OrderItems",
                column: "ShopId",
                principalTable: "Shops",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_CustomerId",
                table: "Orders",
                column: "CustomerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShopManagers_AspNetUsers_CustomerId",
                table: "ShopManagers",
                column: "CustomerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShopsManagers_ShopManagers_ShopManagerId",
                table: "ShopsManagers",
                column: "ShopManagerId",
                principalTable: "ShopManagers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Orders_OrderId",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Products_ProductId",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Shops_ShopId",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_CustomerId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_ShopManagers_AspNetUsers_CustomerId",
                table: "ShopManagers");

            migrationBuilder.DropForeignKey(
                name: "FK_ShopsManagers_ShopManagers_ShopManagerId",
                table: "ShopsManagers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShopManagers",
                table: "ShopManagers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderItems",
                table: "OrderItems");

            migrationBuilder.RenameTable(
                name: "ShopManagers",
                newName: "ShopManager");

            migrationBuilder.RenameTable(
                name: "Orders",
                newName: "Order");

            migrationBuilder.RenameTable(
                name: "OrderItems",
                newName: "OrderItem");

            migrationBuilder.RenameIndex(
                name: "IX_ShopManagers_CustomerId",
                table: "ShopManager",
                newName: "IX_ShopManager_CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_CustomerId",
                table: "Order",
                newName: "IX_Order_CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItems_ShopId",
                table: "OrderItem",
                newName: "IX_OrderItem_ShopId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItems_ProductId",
                table: "OrderItem",
                newName: "IX_OrderItem_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItem",
                newName: "IX_OrderItem_OrderId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "ShoppingCarts",
                type: "datetime2",
                nullable: false,
                comment: "Date and time of updation",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETDATE()",
                oldComment: "Date and time of updation");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "ShoppingCarts",
                type: "datetime2",
                nullable: false,
                comment: "Date and time of creation",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETDATE()",
                oldComment: "Date and time of creation");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "ShoppingCartItems",
                type: "datetime2",
                nullable: false,
                comment: "Date and time of updation",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETDATE()",
                oldComment: "Date and time of updation");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "ShoppingCartItems",
                type: "datetime2",
                nullable: false,
                comment: "Date and time of creation",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETDATE()",
                oldComment: "Date and time of creation");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Order",
                type: "datetime2",
                nullable: false,
                comment: "Date and time of updation",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETDATE()",
                oldComment: "Date and time of updation");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Order",
                type: "datetime2",
                nullable: false,
                comment: "Date and time of creation",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETDATE()",
                oldComment: "Date and time of creation");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "OrderItem",
                type: "datetime2",
                nullable: false,
                comment: "Date and time of updation",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETDATE()",
                oldComment: "Date and time of updation");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "OrderItem",
                type: "datetime2",
                nullable: false,
                comment: "Date and time of creation",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETDATE()",
                oldComment: "Date and time of creation");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShopManager",
                table: "ShopManager",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Order",
                table: "Order",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderItem",
                table: "OrderItem",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6dcf663d-7cc9-4249-73fc-08db7fe046b6"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAELIB5k91ZCJFpZJS8MBtXQpivf+i7vJSVKHn6XxWt6ZMOND1jJ+u1Jj+4GMhIzcwMQ==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("811c2b9d-b754-44ef-783b-08db7fbc8275"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEJOXzIb3Nicaq6a6rWkJxmePbuzVaqJV/EkBarf52jxr658AufmqSsm9aMVEeqtz1A==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("98c666ac-9aee-80c3-5686-08db7fbb6666"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAECw7JCrlezCoBJZUpi325vizU6PaMcunOtJj3hIOQkzTS+Sa4YMWKbqQyLDmSMXwlA==");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_AspNetUsers_CustomerId",
                table: "Order",
                column: "CustomerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItem_Order_OrderId",
                table: "OrderItem",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItem_Products_ProductId",
                table: "OrderItem",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItem_Shops_ShopId",
                table: "OrderItem",
                column: "ShopId",
                principalTable: "Shops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShopManager_AspNetUsers_CustomerId",
                table: "ShopManager",
                column: "CustomerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShopsManagers_ShopManager_ShopManagerId",
                table: "ShopsManagers",
                column: "ShopManagerId",
                principalTable: "ShopManager",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
