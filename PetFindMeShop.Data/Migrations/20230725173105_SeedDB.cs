using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetFindMeShop.Data.Migrations
{
    public partial class SeedDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "ShopsManagers",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()",
                comment: "Date and time of updation",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldComment: "Date and time of updation");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "ShopsManagers",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()",
                comment: "Date and time of creation",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldComment: "Date and time of creation");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Shops",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()",
                comment: "Date and time of updation",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldComment: "Date and time of updation");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Shops",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()",
                comment: "Date and time of creation",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldComment: "Date and time of creation");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "ShopManager",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()",
                comment: "Date and time of updation",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldComment: "Date and time of updation");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "ShopManager",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()",
                comment: "Date and time of creation",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldComment: "Date and time of creation");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()",
                comment: "Date and time of updation",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldComment: "Date and time of updation");

            migrationBuilder.AlterColumn<bool>(
                name: "IsAvailable",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: true,
                comment: "Is the product in stock",
                oldClrType: typeof(bool),
                oldType: "bit",
                oldComment: "Is the product in stock");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()",
                comment: "Date and time of creation",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldComment: "Date and time of creation");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()",
                comment: "Date and time of updation",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldComment: "Date and time of updation");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()",
                comment: "Date and time of creation",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldComment: "Date and time of creation");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()",
                comment: "Date and time of updation",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldComment: "Date and time of updation");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()",
                comment: "Date and time of creation",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldComment: "Date and time of creation");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("6dcf663d-7cc9-4249-73fc-08db7fe046b6"), 0, "ab1755fa-4ea8-47e8-aa13-c57fae13a4a9", "admin@petfindmeshop.bg", true, true, null, "ADMIN@PETFINDME.BG", "ADMIN", "AQAAAAEAACcQAAAAEAWQi3fwl9yqk3ATPnMmQc39RMkcLopu1Zn3nbhBJYe4NoxVMEZTPYE9stUKniMm0Q==", null, false, "KAKHTVIWBHSUI4ESCAVXXEFC2UZ2JX44", false, "admin" },
                    { new Guid("811c2b9d-b754-44ef-783b-08db7fbc8275"), 0, "4300bc13-f79a-42fb-abce-a54c520bbac5", "maneger@abv.bg", true, true, null, "MANAGER@ABV.BG", "MANAGER", "AQAAAAEAACcQAAAAEFuPOJ5mdKMDB9I0+/vVJNkgMB1twju+giCSwqmKrtM1Ve7mms5GZ4lanT29Gc0hKQ==", null, false, "JZDXAYLLGTFDW2QPGEWCOEMNS2XMOHE5", false, "maneger" },
                    { new Guid("98c666ac-9aee-80c3-5686-08db7fbb6666"), 0, "ffc7bb00-b000-4c61-b41b-e34f908c34c1", "customer@abv.bg", true, true, null, "CUSTOMER@ABV.BG", "CUSTOMER", "AQAAAAEAACcQAAAAEM70SESpMVjM15PnlBngqGO9FL7bTPV/zNSzBqtJ6p6OV1PfLKo4bmNRyVE2uQhVMg==", null, false, "LUTV3ZFEY6XFBCSJEGW3JIA62BBWBETZ", false, "customer" }
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6dcf663d-7cc9-4249-73fc-08db7fe046b6"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("98c666ac-9aee-80c3-5686-08db7fbb6666"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ShopsManagers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "ShopManager",
                keyColumn: "Id",
                keyValue: new Guid("98c929ac-9aee-40c3-5691-08db7fbb6193"));

            migrationBuilder.DeleteData(
                table: "Shops",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("811c2b9d-b754-44ef-783b-08db7fbc8275"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "ShopsManagers",
                type: "datetime2",
                nullable: false,
                comment: "Date and time of updation",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETDATE()",
                oldComment: "Date and time of updation");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "ShopsManagers",
                type: "datetime2",
                nullable: false,
                comment: "Date and time of creation",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETDATE()",
                oldComment: "Date and time of creation");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Shops",
                type: "datetime2",
                nullable: false,
                comment: "Date and time of updation",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETDATE()",
                oldComment: "Date and time of updation");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Shops",
                type: "datetime2",
                nullable: false,
                comment: "Date and time of creation",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETDATE()",
                oldComment: "Date and time of creation");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "ShopManager",
                type: "datetime2",
                nullable: false,
                comment: "Date and time of updation",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETDATE()",
                oldComment: "Date and time of updation");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "ShopManager",
                type: "datetime2",
                nullable: false,
                comment: "Date and time of creation",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETDATE()",
                oldComment: "Date and time of creation");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Products",
                type: "datetime2",
                nullable: false,
                comment: "Date and time of updation",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETDATE()",
                oldComment: "Date and time of updation");

            migrationBuilder.AlterColumn<bool>(
                name: "IsAvailable",
                table: "Products",
                type: "bit",
                nullable: false,
                comment: "Is the product in stock",
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true,
                oldComment: "Is the product in stock");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Products",
                type: "datetime2",
                nullable: false,
                comment: "Date and time of creation",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETDATE()",
                oldComment: "Date and time of creation");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                comment: "Date and time of updation",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETDATE()",
                oldComment: "Date and time of updation");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                comment: "Date and time of creation",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETDATE()",
                oldComment: "Date and time of creation");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                comment: "Date and time of updation",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETDATE()",
                oldComment: "Date and time of updation");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                comment: "Date and time of creation",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETDATE()",
                oldComment: "Date and time of creation");
        }
    }
}
