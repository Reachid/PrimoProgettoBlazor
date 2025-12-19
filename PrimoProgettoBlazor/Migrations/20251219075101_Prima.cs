using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrimoProgettoBlazor.Migrations
{
    /// <inheritdoc />
    public partial class Prima : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Abilità",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsAbilità = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Abilità", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Giocatori",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Giocatori", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sessioni",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessioni", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Personaggi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Iniziativa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TiroColpire = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TiroDifesa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifAttacco = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salute = table.Column<int>(type: "int", nullable: false),
                    Vigore = table.Column<int>(type: "int", nullable: false),
                    Armatura = table.Column<int>(type: "int", nullable: false),
                    LivelloMinaccia = table.Column<int>(type: "int", nullable: false),
                    GiocatoreId = table.Column<int>(type: "int", nullable: false),
                    SessioneId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personaggi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Personaggi_Giocatori_GiocatoreId",
                        column: x => x.GiocatoreId,
                        principalTable: "Giocatori",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Personaggi_Sessioni_SessioneId",
                        column: x => x.SessioneId,
                        principalTable: "Sessioni",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AbilitàPersonaggi",
                columns: table => new
                {
                    AbilitàIdAbilità = table.Column<int>(type: "int", nullable: false),
                    PersonaggioId = table.Column<int>(type: "int", nullable: false),
                    AbilitàId = table.Column<int>(type: "int", nullable: false),
                    Punteggio = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbilitàPersonaggi", x => new { x.AbilitàIdAbilità, x.PersonaggioId });
                    table.ForeignKey(
                        name: "FK_AbilitàPersonaggi_Abilità_AbilitàId",
                        column: x => x.AbilitàId,
                        principalTable: "Abilità",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AbilitàPersonaggi_Personaggi_PersonaggioId",
                        column: x => x.PersonaggioId,
                        principalTable: "Personaggi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Attacchi",
                columns: table => new
                {
                    IdAttacco = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Roll = table.Column<int>(type: "int", nullable: false),
                    Moltiplicatore = table.Column<int>(type: "int", nullable: false),
                    Vigore = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonaggioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attacchi", x => x.IdAttacco);
                    table.ForeignKey(
                        name: "FK_Attacchi_Personaggi_PersonaggioId",
                        column: x => x.PersonaggioId,
                        principalTable: "Personaggi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AbilitàPersonaggi_AbilitàId",
                table: "AbilitàPersonaggi",
                column: "AbilitàId");

            migrationBuilder.CreateIndex(
                name: "IX_AbilitàPersonaggi_PersonaggioId",
                table: "AbilitàPersonaggi",
                column: "PersonaggioId");

            migrationBuilder.CreateIndex(
                name: "IX_Attacchi_PersonaggioId",
                table: "Attacchi",
                column: "PersonaggioId");

            migrationBuilder.CreateIndex(
                name: "IX_Personaggi_GiocatoreId",
                table: "Personaggi",
                column: "GiocatoreId");

            migrationBuilder.CreateIndex(
                name: "IX_Personaggi_SessioneId",
                table: "Personaggi",
                column: "SessioneId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AbilitàPersonaggi");

            migrationBuilder.DropTable(
                name: "Attacchi");

            migrationBuilder.DropTable(
                name: "Abilità");

            migrationBuilder.DropTable(
                name: "Personaggi");

            migrationBuilder.DropTable(
                name: "Giocatori");

            migrationBuilder.DropTable(
                name: "Sessioni");
        }
    }
}
