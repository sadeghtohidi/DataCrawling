using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App_Avval.Migrations
{
    /// <inheritdoc />
    public partial class firstinitDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RubikaModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChannelId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MemberCount = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description_Links = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RubikaModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "rubikaPosts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChannelId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MessageId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ViewCount = table.Column<int>(type: "int", nullable: false),
                    HTML = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RubikaModelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rubikaPosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_rubikaPosts_RubikaModels_RubikaModelId",
                        column: x => x.RubikaModelId,
                        principalTable: "RubikaModels",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_rubikaPosts_RubikaModelId",
                table: "rubikaPosts",
                column: "RubikaModelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "rubikaPosts");

            migrationBuilder.DropTable(
                name: "RubikaModels");
        }
    }
}
