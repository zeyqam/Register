using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Educal_PB101.Migrations
{
    public partial class AddCourseAndInstructorProperities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseImages_Courses_ProductId",
                table: "CourseImages");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "CourseImages",
                newName: "CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_CourseImages_ProductId",
                table: "CourseImages",
                newName: "IX_CourseImages_CourseId");

            migrationBuilder.AddColumn<string>(
                name: "InstructorImageUrl",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InstructorName",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LessonCount",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "Rating",
                table: "Courses",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseImages_Courses_CourseId",
                table: "CourseImages",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseImages_Courses_CourseId",
                table: "CourseImages");

            migrationBuilder.DropColumn(
                name: "InstructorImageUrl",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "InstructorName",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "LessonCount",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Courses");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                table: "CourseImages",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_CourseImages_CourseId",
                table: "CourseImages",
                newName: "IX_CourseImages_ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseImages_Courses_ProductId",
                table: "CourseImages",
                column: "ProductId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
