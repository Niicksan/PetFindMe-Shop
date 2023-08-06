using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetFindMeShop.Data.Migrations
{
    public partial class SetDefaultValueOfNullForDeletedAt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LikedProduct_AspNetUsers_CustomerId",
                table: "LikedProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_LikedProduct_Products_ProductId",
                table: "LikedProduct");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LikedProduct",
                table: "LikedProduct");

            migrationBuilder.RenameTable(
                name: "LikedProduct",
                newName: "LikedProducts");

            migrationBuilder.RenameIndex(
                name: "IX_LikedProduct_ProductId",
                table: "LikedProducts",
                newName: "IX_LikedProducts_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_LikedProduct_CustomerId",
                table: "LikedProducts",
                newName: "IX_LikedProducts_CustomerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LikedProducts",
                table: "LikedProducts",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6dcf663d-7cc9-4249-73fc-08db7fe046b6"),
                columns: new[] { "NormalizedEmail", "NormalizedUserName", "PasswordHash" },
                values: new object[] { "ADMIN@PETFINDMESHOP.BG", "ADMIN@PETFINDMESHOP.BG", "AQAAAAEAACcQAAAAELXrLJBFATd6rK2sJg/fa4tdZtmqfP7UIis2RkrIva4B3NBru9AokhKBmFRr8u4Z1Q==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("811c2b9d-b754-44ef-783b-08db7fbc8275"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEI4hankhW9TQLZeWQ/9I13dPLVEb7JpqlH+GXDU9fuHPRX01gwQWEqXfxo8A9wEY8w==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("98c666ac-9aee-80c3-5686-08db7fbb6666"),
                columns: new[] { "NormalizedUserName", "PasswordHash" },
                values: new object[] { "CUSTOMER@ABV.BG", "AQAAAAEAACcQAAAAEElbnwbgaDWrgjDO81ZS2IPqTNUO+5yp5R9I+iSqE59qsFHEQJe5qtjRZQm5kvNSNg==" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "Title",
                value: "Легло за кучета с лапичка");

            migrationBuilder.UpdateData(
                table: "Shops",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Нашата мисия е да предоставим на родителите на кучета и котки всичко необходимо, за да гарантират дълъг и щастлив живот на домашния си любимец. Обичаме да говорим за домашни любимци от всякакъв вид и се вълнуваме още повече, когато доведете косматия си член на семейството в магазина, за да се срещне с нас! Ние непрекъснато проучваме и научаваме нови продукти, които могат да направят живота на нашите домашни любимци по-добър. Нашата цел е да осигурим чист магазин, подходящ за домашни любимци, който разполага с всичко, от което се нуждае вашето куче или котка. Въпреки че нашият магазин не е много голям, ние предлагаме изживяване, което е бързо, приятелско, местно и по-евтино от магазините за домашни любимци „PetShop.BG“.", "PetShop.BG" });

            migrationBuilder.AddForeignKey(
                name: "FK_LikedProducts_AspNetUsers_CustomerId",
                table: "LikedProducts",
                column: "CustomerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LikedProducts_Products_ProductId",
                table: "LikedProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LikedProducts_AspNetUsers_CustomerId",
                table: "LikedProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_LikedProducts_Products_ProductId",
                table: "LikedProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LikedProducts",
                table: "LikedProducts");

            migrationBuilder.RenameTable(
                name: "LikedProducts",
                newName: "LikedProduct");

            migrationBuilder.RenameIndex(
                name: "IX_LikedProducts_ProductId",
                table: "LikedProduct",
                newName: "IX_LikedProduct_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_LikedProducts_CustomerId",
                table: "LikedProduct",
                newName: "IX_LikedProduct_CustomerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LikedProduct",
                table: "LikedProduct",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6dcf663d-7cc9-4249-73fc-08db7fe046b6"),
                columns: new[] { "NormalizedEmail", "NormalizedUserName", "PasswordHash" },
                values: new object[] { "ADMIN@PETFINDME.BG", "ADMIN@PETFINDME.BG", "AQAAAAEAACcQAAAAEHwyqdwgblJCp7yHU3+rj9r+tk53PZKil//ZzfeoGpAwCmWFJVNT1TPOKioKhLsnmQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("811c2b9d-b754-44ef-783b-08db7fbc8275"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEIx982Dr4YQ2TwVeccxTQk8ISJLnUo4dnurJZYdNGvgqGC+Wg8kScJnSgPXTyIGCaw==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("98c666ac-9aee-80c3-5686-08db7fbb6666"),
                columns: new[] { "NormalizedUserName", "PasswordHash" },
                values: new object[] { "CUSTOMER", "AQAAAAEAACcQAAAAEEIfD2PfMO0LwnhFOFi+Mn6mGWSfLw0C/U1mB59jTCF/RUmC2Qv07HQFjIzq1Q2Tng==" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "Title",
                value: "Легло кучета с лапичка");

            migrationBuilder.UpdateData(
                table: "Shops",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Very cool Pet Shop", "NikPetShop" });

            migrationBuilder.AddForeignKey(
                name: "FK_LikedProduct_AspNetUsers_CustomerId",
                table: "LikedProduct",
                column: "CustomerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LikedProduct_Products_ProductId",
                table: "LikedProduct",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
