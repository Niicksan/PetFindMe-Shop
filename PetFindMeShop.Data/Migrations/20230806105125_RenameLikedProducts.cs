using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetFindMeShop.Data.Migrations
{
    public partial class RenameLikedProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterTable(
                name: "LikedProducts",
                comment: "Liked Products",
                oldComment: "Liked Product");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterTable(
                name: "LikedProducts",
                comment: "Liked Product",
                oldComment: "Liked Products");

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
        }
    }
}
