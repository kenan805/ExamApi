using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Exam.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addIdToExamModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Exams",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "Exams");
        }
    }
}
