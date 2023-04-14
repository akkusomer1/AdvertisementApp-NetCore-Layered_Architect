using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Udemy.AdvertisementApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class migr2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ProvidedServices",
                columns: new[] { "Id", "Description", "ImagePath", "Title" },
                values: new object[,]
                {
                    { 2, "Web Uygulaması Descpription", "/images/01.jpg", "Web Uygulaması" },
                    { 3, "Pc Uygulaması Descpription", "/images/02.jpg", "Pc Uygulaması" },
                    { 4, "Mobil Uygulaması Descpription", "/images/03.jpg", "Mobil Uygulaması" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProvidedServices",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProvidedServices",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ProvidedServices",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
