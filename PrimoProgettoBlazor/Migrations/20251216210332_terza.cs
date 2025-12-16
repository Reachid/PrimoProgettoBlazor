using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrimoProgettoBlazor.Migrations
{
    /// <inheritdoc />
    public partial class terza : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personaggi_Sessione_SessioneId",
                table: "Personaggi");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sessione",
                table: "Sessione");

            migrationBuilder.RenameTable(
                name: "Sessione",
                newName: "Sessioni");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sessioni",
                table: "Sessioni",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Personaggi_Sessioni_SessioneId",
                table: "Personaggi",
                column: "SessioneId",
                principalTable: "Sessioni",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personaggi_Sessioni_SessioneId",
                table: "Personaggi");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sessioni",
                table: "Sessioni");

            migrationBuilder.RenameTable(
                name: "Sessioni",
                newName: "Sessione");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sessione",
                table: "Sessione",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Personaggi_Sessione_SessioneId",
                table: "Personaggi",
                column: "SessioneId",
                principalTable: "Sessione",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
