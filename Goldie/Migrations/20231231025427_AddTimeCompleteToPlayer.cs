using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Goldie.Migrations
{
    /// <inheritdoc />
    public partial class AddTimeCompleteToPlayer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "TimeComplete",
                table: "Players",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TimeComplete",
                table: "Players");
        }
    }
}
