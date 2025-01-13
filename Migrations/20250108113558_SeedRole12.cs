using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlogWeb.Migrations
{
    /// <inheritdoc />
    public partial class SeedRole12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "681d0618-2167-429d-a44b-ecb3ce0af6e6", null, "Admin", "ADMIN" },
                    { "9602ce72-19cb-4e11-9d7f-b0698a1493fe", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "681d0618-2167-429d-a44b-ecb3ce0af6e6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9602ce72-19cb-4e11-9d7f-b0698a1493fe");
        }
    }
}
