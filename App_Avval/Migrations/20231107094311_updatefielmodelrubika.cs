using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App_Avval.Migrations
{
    /// <inheritdoc />
    public partial class updatefielmodelrubika : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RubikaPosts_RubikaModels_RubikaModelId",
                table: "RubikaPosts");

            migrationBuilder.DropIndex(
                name: "IX_RubikaPosts_RubikaModelId",
                table: "RubikaPosts");

            migrationBuilder.DropColumn(
                name: "RubikaModelId",
                table: "RubikaPosts");

            migrationBuilder.AddColumn<int>(
                name: "Count",
                table: "RubikaKeywords",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Count",
                table: "RubikaKeywords");

            migrationBuilder.AddColumn<int>(
                name: "RubikaModelId",
                table: "RubikaPosts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RubikaPosts_RubikaModelId",
                table: "RubikaPosts",
                column: "RubikaModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_RubikaPosts_RubikaModels_RubikaModelId",
                table: "RubikaPosts",
                column: "RubikaModelId",
                principalTable: "RubikaModels",
                principalColumn: "Id");
        }
    }
}
