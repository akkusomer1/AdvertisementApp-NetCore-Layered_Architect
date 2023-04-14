using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Udemy.AdvertisementApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class migr6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 21, 21, 10, 11, 507, DateTimeKind.Local).AddTicks(2095));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 21, 21, 10, 11, 507, DateTimeKind.Local).AddTicks(2099));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 21, 21, 10, 11, 507, DateTimeKind.Local).AddTicks(2101));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 21, 21, 10, 11, 507, DateTimeKind.Local).AddTicks(2103));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 21, 21, 10, 11, 507, DateTimeKind.Local).AddTicks(2104));

            migrationBuilder.CreateIndex(
                name: "IX_AppUsers_Username",
                table: "AppUsers",
                column: "Username",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AppUsers_Username",
                table: "AppUsers");

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 21, 21, 0, 57, 66, DateTimeKind.Local).AddTicks(4476));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 21, 21, 0, 57, 66, DateTimeKind.Local).AddTicks(4484));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 21, 21, 0, 57, 66, DateTimeKind.Local).AddTicks(4486));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 21, 21, 0, 57, 66, DateTimeKind.Local).AddTicks(4489));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 21, 21, 0, 57, 66, DateTimeKind.Local).AddTicks(4491));
        }
    }
}
