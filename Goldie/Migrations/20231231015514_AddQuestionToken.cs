using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Goldie.Migrations
{
    /// <inheritdoc />
    public partial class AddQuestionToken : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "QuestionToken",
                table: "Questions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuestionToken",
                table: "Questions");
        }
    }
}
