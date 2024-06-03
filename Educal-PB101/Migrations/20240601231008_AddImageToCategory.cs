using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Educal_PB101.Migrations
{
    public partial class AddImageToCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Icon",
                table: "Categories",
                newName: "Image");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Image",
                table: "Categories",
                newName: "Icon");
        }
    }
}
