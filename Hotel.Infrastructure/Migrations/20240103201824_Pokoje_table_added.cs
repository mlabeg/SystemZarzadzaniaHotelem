using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Pokoje_table_added : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rezerwacje_Pokoj_PokojNumer",
                table: "Rezerwacje");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pokoj",
                table: "Pokoj");

            migrationBuilder.RenameTable(
                name: "Pokoj",
                newName: "Pokoje");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pokoje",
                table: "Pokoje",
                column: "Numer");

            migrationBuilder.AddForeignKey(
                name: "FK_Rezerwacje_Pokoje_PokojNumer",
                table: "Rezerwacje",
                column: "PokojNumer",
                principalTable: "Pokoje",
                principalColumn: "Numer",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rezerwacje_Pokoje_PokojNumer",
                table: "Rezerwacje");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pokoje",
                table: "Pokoje");

            migrationBuilder.RenameTable(
                name: "Pokoje",
                newName: "Pokoj");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pokoj",
                table: "Pokoj",
                column: "Numer");

            migrationBuilder.AddForeignKey(
                name: "FK_Rezerwacje_Pokoj_PokojNumer",
                table: "Rezerwacje",
                column: "PokojNumer",
                principalTable: "Pokoj",
                principalColumn: "Numer",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
