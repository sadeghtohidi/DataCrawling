using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App_Avval.Migrations
{
    /// <inheritdoc />
    public partial class addeitakeyword : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CountEitaa",
                table: "RubikaKeywords",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "VisitedDateEitaa",
                table: "RubikaKeywords",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CountEitaa",
                table: "RubikaKeywords");

            migrationBuilder.DropColumn(
                name: "VisitedDateEitaa",
                table: "RubikaKeywords");
        }
    }
}
