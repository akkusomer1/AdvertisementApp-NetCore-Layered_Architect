using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Udemy.AdvertisementApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class migr4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 21, 13, 6, 46, 735, DateTimeKind.Local).AddTicks(3549));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 21, 13, 6, 46, 735, DateTimeKind.Local).AddTicks(3552));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 21, 13, 6, 46, 735, DateTimeKind.Local).AddTicks(3554));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 21, 13, 6, 46, 735, DateTimeKind.Local).AddTicks(3556));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 21, 13, 6, 46, 735, DateTimeKind.Local).AddTicks(3557));

            migrationBuilder.InsertData(
                table: "Genders",
                columns: new[] { "Id", "Defination" },
                values: new object[,]
                {
                    { 1, "Erkek" },
                    { 2, "Kadın" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 21, 10, 19, 10, 756, DateTimeKind.Local).AddTicks(9452));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 21, 10, 19, 10, 756, DateTimeKind.Local).AddTicks(9457));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 21, 10, 19, 10, 756, DateTimeKind.Local).AddTicks(9459));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 21, 10, 19, 10, 756, DateTimeKind.Local).AddTicks(9461));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 21, 10, 19, 10, 756, DateTimeKind.Local).AddTicks(9462));
        }
    }
}
