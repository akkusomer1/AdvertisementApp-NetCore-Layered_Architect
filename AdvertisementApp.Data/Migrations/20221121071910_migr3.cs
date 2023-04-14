using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Udemy.AdvertisementApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class migr3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Advertisements",
                columns: new[] { "Id", "CreatedDate", "Description", "Status", "Title" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 10, 20, 10, 19, 10, 756, DateTimeKind.Local).AddTicks(9452), "Descpription 1", true, "Senior Yazılım Geliştirme Uzmanı" },
                    { 2, new DateTime(2022, 11, 09, 10, 19, 10, 756, DateTimeKind.Local).AddTicks(9457), "Descpription 2", true, "Middle Yazılım Geliştirme Uzmanı" },
                    { 3, new DateTime(2022, 10, 28, 10, 19, 10, 756, DateTimeKind.Local).AddTicks(9459), "Descpription 3", true, "Junior Yazılım Geliştirme Uzmanı" },
                    { 4, new DateTime(2022, 11, 21, 10, 19, 10, 756, DateTimeKind.Local).AddTicks(9461), "Descpription 4", true, "Stajyer Yazılım Geliştirme Uzmanı" },
                    { 5, new DateTime(2022, 09, 11, 10, 19, 10, 756, DateTimeKind.Local).AddTicks(9462), "Descpription 4", false, "Senior Mobil Yazılım Geliştirme Uzmanı" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
