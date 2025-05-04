using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wypozyczalnia.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Klienci",
                columns: table => new
                {
                    Id_klient = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imie = table.Column<string>(type: "nvarchar(24)", maxLength: 24, nullable: false),
                    Nazwisko = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Data_rejestracja = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Klienci", x => x.Id_klient);
                });

            migrationBuilder.CreateTable(
                name: "Sprzety",
                columns: table => new
                {
                    Id_sprzetu = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kategoria = table.Column<int>(type: "int", nullable: false),
                    Producent = table.Column<int>(type: "int", nullable: false),
                    Rozmiar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cena_za_tydz = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sprzety", x => x.Id_sprzetu);
                });

            migrationBuilder.CreateTable(
                name: "Wypozyczenia",
                columns: table => new
                {
                    Id_wypozyczenia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data_wypozyczenia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Data_zwrotu = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Cena_calkowita = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Id_klient = table.Column<int>(type: "int", nullable: false),
                    KlientId_klient = table.Column<int>(type: "int", nullable: false),
                    Id_sprzetu = table.Column<int>(type: "int", nullable: false),
                    SprzetId_sprzetu = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wypozyczenia", x => x.Id_wypozyczenia);
                    table.ForeignKey(
                        name: "FK_Wypozyczenia_Klienci_KlientId_klient",
                        column: x => x.KlientId_klient,
                        principalTable: "Klienci",
                        principalColumn: "Id_klient",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Wypozyczenia_Sprzety_SprzetId_sprzetu",
                        column: x => x.SprzetId_sprzetu,
                        principalTable: "Sprzety",
                        principalColumn: "Id_sprzetu",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Wypozyczenia_KlientId_klient",
                table: "Wypozyczenia",
                column: "KlientId_klient");

            migrationBuilder.CreateIndex(
                name: "IX_Wypozyczenia_SprzetId_sprzetu",
                table: "Wypozyczenia",
                column: "SprzetId_sprzetu");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Wypozyczenia");

            migrationBuilder.DropTable(
                name: "Klienci");

            migrationBuilder.DropTable(
                name: "Sprzety");
        }
    }
}
