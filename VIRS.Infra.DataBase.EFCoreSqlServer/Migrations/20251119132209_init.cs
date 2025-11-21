using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VIRS.Infra.DataBase.EFCoreSqlServer.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarModels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Family = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Manufacturer = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CarOwners",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NID = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarOwners", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SystemsAdmins",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemsAdmins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlateFirstPart = table.Column<int>(type: "int", maxLength: 2, nullable: false),
                    PlateLetter = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    PlateSecondPart = table.Column<int>(type: "int", maxLength: 3, nullable: false),
                    PlateProvinceCode = table.Column<int>(type: "int", maxLength: 2, nullable: false),
                    VIN = table.Column<string>(type: "nvarchar(17)", maxLength: 17, nullable: false),
                    ManufactureYear = table.Column<int>(type: "int", maxLength: 4, nullable: false),
                    CarOwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CarModelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cars_CarModels_CarModelId",
                        column: x => x.CarModelId,
                        principalTable: "CarModels",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Cars_CarOwners_CarOwnerId",
                        column: x => x.CarOwnerId,
                        principalTable: "CarOwners",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "InspectionRequests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CarId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CarOwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InspectionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    StatusChangedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TrackingNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAcceptable = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InspectionRequests_CarOwners_CarOwnerId",
                        column: x => x.CarOwnerId,
                        principalTable: "CarOwners",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InspectionRequests_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "CarModels",
                columns: new[] { "Id", "Family", "Manufacturer", "Name" },
                values: new object[,]
                {
                    { new Guid("10000000-0000-0000-0000-000000000001"), "پژو", "ایرانخودرو", "405 GLX" },
                    { new Guid("10000000-0000-0000-0000-000000000002"), "پژو", "ایرانخودرو", "405 SLX" },
                    { new Guid("10000000-0000-0000-0000-000000000003"), "پژو", "ایرانخودرو", "پارس" },
                    { new Guid("10000000-0000-0000-0000-000000000004"), "پژو", "ایرانخودرو", "پارس TU5" },
                    { new Guid("10000000-0000-0000-0000-000000000005"), "پژو", "ایرانخودرو", "پارس LX" },
                    { new Guid("10000000-0000-0000-0000-000000000006"), "پژو", "ایرانخودرو", "پارس XU7P" },
                    { new Guid("10000000-0000-0000-0000-000000000007"), "پژو", "ایرانخودرو", "206 Type 2" },
                    { new Guid("10000000-0000-0000-0000-000000000008"), "پژو", "ایرانخودرو", "206 Type 5" },
                    { new Guid("10000000-0000-0000-0000-000000000009"), "پژو", "ایرانخودرو", "206 SD V8" },
                    { new Guid("10000000-0000-0000-0000-00000000000a"), "پژو", "ایرانخودرو", "207i دستی" },
                    { new Guid("10000000-0000-0000-0000-00000000000b"), "پژو", "ایرانخودرو", "207i اتوماتیک" },
                    { new Guid("10000000-0000-0000-0000-00000000000c"), "پژو", "ایرانخودرو", "207i پانوراما" },
                    { new Guid("10000000-0000-0000-0000-00000000000d"), "پژو", "ایرانخودرو", "207i MC" },
                    { new Guid("10000000-0000-0000-0000-00000000000e"), "پژو", "ایرانخودرو", "207i SD" },
                    { new Guid("10000000-0000-0000-0000-00000000000f"), "سمند", "ایرانخودرو", "LX" },
                    { new Guid("10000000-0000-0000-0000-000000000010"), "سمند", "ایرانخودرو", "LX EF7" },
                    { new Guid("10000000-0000-0000-0000-000000000011"), "سمند", "ایرانخودرو", "EF7 بنزینی" },
                    { new Guid("10000000-0000-0000-0000-000000000012"), "سمند", "ایرانخودرو", "EF7 دوگانه‌سوز" },
                    { new Guid("10000000-0000-0000-0000-000000000013"), "سمند", "ایرانخودرو", "SE" },
                    { new Guid("10000000-0000-0000-0000-000000000014"), "سورن", "ایرانخودرو", "ELX" },
                    { new Guid("10000000-0000-0000-0000-000000000015"), "سورن", "ایرانخودرو", "ELX EF7" },
                    { new Guid("10000000-0000-0000-0000-000000000016"), "سورن", "ایرانخودرو", "پلاس" },
                    { new Guid("10000000-0000-0000-0000-000000000017"), "دنا", "ایرانخودرو", "عادی" },
                    { new Guid("10000000-0000-0000-0000-000000000018"), "دنا", "ایرانخودرو", "پلاس" },
                    { new Guid("10000000-0000-0000-0000-000000000019"), "دنا", "ایرانخودرو", "پلاس توربو" },
                    { new Guid("10000000-0000-0000-0000-00000000001a"), "دنا", "ایرانخودرو", "پلاس 6 سرعته" },
                    { new Guid("10000000-0000-0000-0000-00000000001b"), "رانا", "ایرانخودرو", "عادی" },
                    { new Guid("10000000-0000-0000-0000-00000000001c"), "رانا", "ایرانخودرو", "پلاس" },
                    { new Guid("10000000-0000-0000-0000-00000000001d"), "تارا", "ایرانخودرو", "V1 دستی" },
                    { new Guid("10000000-0000-0000-0000-00000000001e"), "تارا", "ایرانخودرو", "V2 اتوماتیک" },
                    { new Guid("10000000-0000-0000-0000-00000000001f"), "تارا", "ایرانخودرو", "LX" },
                    { new Guid("10000000-0000-0000-0000-000000000020"), "تارا", "ایرانخودرو", "6AT جدید" },
                    { new Guid("20000000-0000-0000-0000-000000000001"), "پراید", "سایپا", "111" },
                    { new Guid("20000000-0000-0000-0000-000000000002"), "پراید", "سایپا", "131" },
                    { new Guid("20000000-0000-0000-0000-000000000003"), "پراید", "سایپا", "132" },
                    { new Guid("20000000-0000-0000-0000-000000000004"), "پراید", "سایپا", "141" },
                    { new Guid("20000000-0000-0000-0000-000000000005"), "پراید", "سایپا", "SE" },
                    { new Guid("20000000-0000-0000-0000-000000000006"), "پراید", "سایپا", "LE" },
                    { new Guid("20000000-0000-0000-0000-000000000007"), "تیبا", "سایپا", "صندوق‌دار" },
                    { new Guid("20000000-0000-0000-0000-000000000008"), "تیبا", "سایپا", "2" },
                    { new Guid("20000000-0000-0000-0000-000000000009"), "تیبا", "سایپا", "SX" },
                    { new Guid("20000000-0000-0000-0000-00000000000a"), "تیبا", "سایپا", "EX" },
                    { new Guid("20000000-0000-0000-0000-00000000000b"), "ساینا", "سایپا", "عادی" },
                    { new Guid("20000000-0000-0000-0000-00000000000c"), "ساینا", "سایپا", "EX" },
                    { new Guid("20000000-0000-0000-0000-00000000000d"), "ساینا", "سایپا", "SX" },
                    { new Guid("20000000-0000-0000-0000-00000000000e"), "ساینا", "سایپا", "پلاس" },
                    { new Guid("20000000-0000-0000-0000-00000000000f"), "ساینا", "سایپا", "پلاس اتوماتیک" },
                    { new Guid("20000000-0000-0000-0000-000000000010"), "کوئیک", "سایپا", "عادی" },
                    { new Guid("20000000-0000-0000-0000-000000000011"), "کوئیک", "سایپا", "R" },
                    { new Guid("20000000-0000-0000-0000-000000000012"), "کوئیک", "سایپا", "S" },
                    { new Guid("20000000-0000-0000-0000-000000000013"), "کوئیک", "سایپا", "GX" },
                    { new Guid("20000000-0000-0000-0000-000000000014"), "کوئیک", "سایپا", "GXR" },
                    { new Guid("20000000-0000-0000-0000-000000000015"), "کوئیک", "سایپا", "اتوماتیک" },
                    { new Guid("20000000-0000-0000-0000-000000000016"), "کوئیک", "سایپا", "R اتوماتیک" },
                    { new Guid("20000000-0000-0000-0000-000000000017"), "شاهین", "سایپا", "S" },
                    { new Guid("20000000-0000-0000-0000-000000000018"), "شاهین", "سایپا", "G" },
                    { new Guid("20000000-0000-0000-0000-000000000019"), "شاهین", "سایپا", "اتوماتیک" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarModels_Manufacturer_Family_Name",
                table: "CarModels",
                columns: new[] { "Manufacturer", "Family", "Name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CarOwners_NID",
                table: "CarOwners",
                column: "NID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cars_CarModelId",
                table: "Cars",
                column: "CarModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_CarOwnerId",
                table: "Cars",
                column: "CarOwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_VIN",
                table: "Cars",
                column: "VIN",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InspectionRequests_CarId",
                table: "InspectionRequests",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionRequests_CarOwnerId",
                table: "InspectionRequests",
                column: "CarOwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_SystemAdmins_Username",
                table: "SystemsAdmins",
                column: "Username",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InspectionRequests");

            migrationBuilder.DropTable(
                name: "SystemsAdmins");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "CarModels");

            migrationBuilder.DropTable(
                name: "CarOwners");
        }
    }
}
