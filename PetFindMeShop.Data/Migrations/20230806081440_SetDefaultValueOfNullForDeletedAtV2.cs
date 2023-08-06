using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetFindMeShop.Data.Migrations
{
    public partial class SetDefaultValueOfNullForDeletedAtV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletedAt",
                table: "Products",
                type: "datetime2",
                nullable: true,
                comment: "Date and time of deletion",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldComment: "Date and time of deletion");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6dcf663d-7cc9-4249-73fc-08db7fe046b6"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEOcS2sySW2gBFttHLMGkEUFoea7/67w+wSMZyQKFQwN9wGR9UNvRvy5uQsE+jS7w1A==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("811c2b9d-b754-44ef-783b-08db7fbc8275"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEO/LYkUrr+0LEEss/VcCfko5S3rgy9pfpELbbimLQUa/3RzIjrt3g9yAH4L3ksNMmw==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("98c666ac-9aee-80c3-5686-08db7fbb6666"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAELfGuPJGRE60nLdxVRX9RMiPlQp5Y0Z7UsG33a00acRWEfYE+6xzgvxKtlHxbFkUDA==");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DeletedAt",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "DeletedAt",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "DeletedAt",
                value: null);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletedAt",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                comment: "Date and time of deletion",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldComment: "Date and time of deletion");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6dcf663d-7cc9-4249-73fc-08db7fe046b6"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAELXrLJBFATd6rK2sJg/fa4tdZtmqfP7UIis2RkrIva4B3NBru9AokhKBmFRr8u4Z1Q==");

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
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEElbnwbgaDWrgjDO81ZS2IPqTNUO+5yp5R9I+iSqE59qsFHEQJe5qtjRZQm5kvNSNg==");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DeletedAt",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "DeletedAt",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "DeletedAt",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
