using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShoeLandia.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedItemsProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Color",
                table: "Items",
                newName: "Colors");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Colors",
                table: "Items",
                newName: "Color");
        }
    }
}
