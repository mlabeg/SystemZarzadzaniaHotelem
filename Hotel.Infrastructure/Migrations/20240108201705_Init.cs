using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Osoby",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nazwisko = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumerTelefonu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdresEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    osoba_type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Stanowisko = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Osoby", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pokoje",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypPokoju = table.Column<int>(type: "int", nullable: true),
                    Numer = table.Column<int>(type: "int", nullable: false),
                    LiczbaMiejsc = table.Column<int>(type: "int", nullable: false),
                    CenaZaNoc = table.Column<int>(type: "int", nullable: false),
                    CzyWolny = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pokoje", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rezerwacje",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataOd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataDo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IloscOsob = table.Column<int>(type: "int", nullable: false),
                    CzyZameldowano = table.Column<bool>(type: "bit", nullable: false),
                    CzyWymeldowano = table.Column<bool>(type: "bit", nullable: false),
                    PokojId = table.Column<int>(type: "int", nullable: true),
                    OsobaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rezerwacje", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rezerwacje_Osoby_OsobaId",
                        column: x => x.OsobaId,
                        principalTable: "Osoby",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Rezerwacje_Pokoje_PokojId",
                        column: x => x.PokojId,
                        principalTable: "Pokoje",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rezerwacje_OsobaId",
                table: "Rezerwacje",
                column: "OsobaId");

            migrationBuilder.CreateIndex(
                name: "IX_Rezerwacje_PokojId",
                table: "Rezerwacje",
                column: "PokojId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rezerwacje");

            migrationBuilder.DropTable(
                name: "Osoby");

            migrationBuilder.DropTable(
                name: "Pokoje");
        }
    }
}
