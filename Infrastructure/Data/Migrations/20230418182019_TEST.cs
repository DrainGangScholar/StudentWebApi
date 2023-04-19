using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class TEST : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kursevi",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Sifra = table.Column<string>(type: "TEXT", nullable: true),
                    Ime = table.Column<string>(type: "TEXT", nullable: true),
                    Opis = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kursevi", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Studenti",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Ime = table.Column<string>(type: "TEXT", nullable: true),
                    Prezime = table.Column<string>(type: "TEXT", nullable: true),
                    Adresa = table.Column<string>(type: "TEXT", nullable: true),
                    Grad = table.Column<string>(type: "TEXT", nullable: true),
                    Drzava = table.Column<string>(type: "TEXT", nullable: true),
                    DatumRodjenja = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Pol = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Studenti", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PohadjaniKursevi",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Ocena = table.Column<int>(type: "INTEGER", nullable: false),
                    StudentID = table.Column<int>(type: "INTEGER", nullable: true),
                    KursID = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PohadjaniKursevi", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PohadjaniKursevi_Kursevi_KursID",
                        column: x => x.KursID,
                        principalTable: "Kursevi",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_PohadjaniKursevi_Studenti_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Studenti",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PohadjaniKursevi_KursID",
                table: "PohadjaniKursevi",
                column: "KursID");

            migrationBuilder.CreateIndex(
                name: "IX_PohadjaniKursevi_StudentID",
                table: "PohadjaniKursevi",
                column: "StudentID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PohadjaniKursevi");

            migrationBuilder.DropTable(
                name: "Kursevi");

            migrationBuilder.DropTable(
                name: "Studenti");
        }
    }
}
