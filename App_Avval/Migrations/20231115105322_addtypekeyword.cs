using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App_Avval.Migrations
{
    /// <inheritdoc />
    public partial class addtypekeyword : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "RubikaKeywords",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "RubikaKeywords");
        }
    }
}
