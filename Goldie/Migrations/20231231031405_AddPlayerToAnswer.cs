using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Goldie.Migrations
{
    /// <inheritdoc />
    public partial class AddPlayerToAnswer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_Players_PlayerId",
                table: "Answers");

            migrationBuilder.AlterColumn<int>(
                name: "PlayerId",
                table: "Answers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_Players_PlayerId",
                table: "Answers",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "PlayerId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_Players_PlayerId",
                table: "Answers");

            migrationBuilder.AlterColumn<int>(
                name: "PlayerId",
                table: "Answers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_Players_PlayerId",
                table: "Answers",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "PlayerId");
        }
    }
}
