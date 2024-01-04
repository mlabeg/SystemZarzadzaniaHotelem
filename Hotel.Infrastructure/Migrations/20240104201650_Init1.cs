using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Init1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rezerwacje_Osoby_OsobaId",
                table: "Rezerwacje");

            migrationBuilder.DropForeignKey(
                name: "FK_Rezerwacje_Pokoje_PokojId",
                table: "Rezerwacje");

            migrationBuilder.AlterColumn<int>(
                name: "PokojId",
                table: "Rezerwacje",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "OsobaId",
                table: "Rezerwacje",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Rezerwacje_Osoby_OsobaId",
                table: "Rezerwacje",
                column: "OsobaId",
                principalTable: "Osoby",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Rezerwacje_Pokoje_PokojId",
                table: "Rezerwacje",
                column: "PokojId",
                principalTable: "Pokoje",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rezerwacje_Osoby_OsobaId",
                table: "Rezerwacje");

            migrationBuilder.DropForeignKey(
                name: "FK_Rezerwacje_Pokoje_PokojId",
                table: "Rezerwacje");

            migrationBuilder.AlterColumn<int>(
                name: "PokojId",
                table: "Rezerwacje",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OsobaId",
                table: "Rezerwacje",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Rezerwacje_Osoby_OsobaId",
                table: "Rezerwacje",
                column: "OsobaId",
                principalTable: "Osoby",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rezerwacje_Pokoje_PokojId",
                table: "Rezerwacje",
                column: "PokojId",
                principalTable: "Pokoje",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
