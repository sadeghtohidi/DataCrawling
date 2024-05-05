using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App_Avval.Migrations
{
    /// <inheritdoc />
    public partial class addtablelink : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_rubikaPosts_RubikaModels_RubikaModelId",
                table: "rubikaPosts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_rubikaPosts",
                table: "rubikaPosts");

            migrationBuilder.RenameTable(
                name: "rubikaPosts",
                newName: "RubikaPosts");

            migrationBuilder.RenameIndex(
                name: "IX_rubikaPosts_RubikaModelId",
                table: "RubikaPosts",
                newName: "IX_RubikaPosts_RubikaModelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RubikaPosts",
                table: "RubikaPosts",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "RubikaLinks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChannelId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VisitedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RubikaLinks", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_RubikaPosts_RubikaModels_RubikaModelId",
                table: "RubikaPosts",
                column: "RubikaModelId",
                principalTable: "RubikaModels",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RubikaPosts_RubikaModels_RubikaModelId",
                table: "RubikaPosts");

            migrationBuilder.DropTable(
                name: "RubikaLinks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RubikaPosts",
                table: "RubikaPosts");

            migrationBuilder.RenameTable(
                name: "RubikaPosts",
                newName: "rubikaPosts");

            migrationBuilder.RenameIndex(
                name: "IX_RubikaPosts_RubikaModelId",
                table: "rubikaPosts",
                newName: "IX_rubikaPosts_RubikaModelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_rubikaPosts",
                table: "rubikaPosts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_rubikaPosts_RubikaModels_RubikaModelId",
                table: "rubikaPosts",
                column: "RubikaModelId",
                principalTable: "RubikaModels",
                principalColumn: "Id");
        }
    }
}
