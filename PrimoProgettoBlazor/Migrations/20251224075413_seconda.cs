using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrimoProgettoBlazor.Migrations
{
    /// <inheritdoc />
    public partial class seconda : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Perks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Punteggio = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsAbilità = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Perks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AttacchiPerks",
                columns: table => new
                {
                    AttaccoId = table.Column<int>(type: "int", nullable: false),
                    PerkId = table.Column<int>(type: "int", nullable: false),
                    Punteggio = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttacchiPerks", x => new { x.AttaccoId, x.PerkId });
                    table.ForeignKey(
                        name: "FK_AttacchiPerks_Attacchi_AttaccoId",
                        column: x => x.AttaccoId,
                        principalTable: "Attacchi",
                        principalColumn: "IdAttacco",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AttacchiPerks_Perks_PerkId",
                        column: x => x.PerkId,
                        principalTable: "Perks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AttacchiPerks_PerkId",
                table: "AttacchiPerks",
                column: "PerkId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AttacchiPerks");

            migrationBuilder.DropTable(
                name: "Perks");
        }
    }
}
