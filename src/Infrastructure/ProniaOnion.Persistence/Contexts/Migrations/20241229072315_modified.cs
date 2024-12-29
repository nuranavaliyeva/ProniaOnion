using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProniaOnion.Persistence.Contexts.Migrations
{
    /// <inheritdoc />
    public partial class modified : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductColors_ProductColors_ProductColorProductId_ProductColorColorId",
                table: "ProductColors");

            migrationBuilder.DropIndex(
                name: "IX_ProductColors_ProductColorProductId_ProductColorColorId",
                table: "ProductColors");

            migrationBuilder.DropColumn(
                name: "ProductColorColorId",
                table: "ProductColors");

            migrationBuilder.DropColumn(
                name: "ProductColorProductId",
                table: "ProductColors");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductColorColorId",
                table: "ProductColors",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductColorProductId",
                table: "ProductColors",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductColors_ProductColorProductId_ProductColorColorId",
                table: "ProductColors",
                columns: new[] { "ProductColorProductId", "ProductColorColorId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ProductColors_ProductColors_ProductColorProductId_ProductColorColorId",
                table: "ProductColors",
                columns: new[] { "ProductColorProductId", "ProductColorColorId" },
                principalTable: "ProductColors",
                principalColumns: new[] { "ProductId", "ColorId" });
        }
    }
}
