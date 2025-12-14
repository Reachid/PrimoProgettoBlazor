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
            migrationBuilder.AddColumn<bool>(
                name: "IsAbilità",
                table: "Abilità",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAbilità",
                table: "Abilità");
        }
    }
}
