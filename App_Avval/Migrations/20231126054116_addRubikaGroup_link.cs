using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App_Avval.Migrations
{
    /// <inheritdoc />
    public partial class addRubikaGroup_link : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Link",
                table: "RubikaGroups",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Link",
                table: "RubikaGroups");
        }
    }
}
