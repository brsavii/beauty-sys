using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class avcbc2223 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Schedulings_CustomerId",
                table: "Schedulings");

            migrationBuilder.CreateIndex(
                name: "IX_Schedulings_CustomerId",
                table: "Schedulings",
                column: "CustomerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Schedulings_CustomerId",
                table: "Schedulings");

            migrationBuilder.CreateIndex(
                name: "IX_Schedulings_CustomerId",
                table: "Schedulings",
                column: "CustomerId",
                unique: true);
        }
    }
}
