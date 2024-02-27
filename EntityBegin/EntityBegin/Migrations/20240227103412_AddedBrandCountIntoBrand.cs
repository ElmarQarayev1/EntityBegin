using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityBegin.Migrations
{
    /// <inheritdoc />
    public partial class AddedBrandCountIntoBrand : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BrandCount",
                table: "Brands",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BrandCount",
                table: "Brands");
        }
    }
}
