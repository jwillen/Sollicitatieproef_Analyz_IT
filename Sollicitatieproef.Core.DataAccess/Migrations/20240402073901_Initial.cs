using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sollicitatieproef.Core.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Gebruikers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Voornaam = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Naam = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Geboortedatum = table.Column<DateTime>(type: "date", maxLength: 50, nullable: false),
                    Emailadres = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Serienummer = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gebruikers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rechten",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Omschrijving = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rechten", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GebruikerRechten",
                columns: table => new
                {
                    GebruikerId = table.Column<int>(type: "int", nullable: false),
                    RechtId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GebruikerRechten", x => new { x.GebruikerId, x.RechtId });
                    table.ForeignKey(
                        name: "FK_GebruikerRechten_Gebruikers_GebruikerId",
                        column: x => x.GebruikerId,
                        principalTable: "Gebruikers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GebruikerRechten_Rechten_RechtId",
                        column: x => x.RechtId,
                        principalTable: "Rechten",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GebruikerRechten_RechtId",
                table: "GebruikerRechten",
                column: "RechtId");

            migrationBuilder.CreateIndex(
                name: "IX_Gebruikers_Emailadres",
                table: "Gebruikers",
                column: "Emailadres",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Gebruikers_Serienummer",
                table: "Gebruikers",
                column: "Serienummer",
                unique: true);

            migrationBuilder.Sql("INSERT INTO Rechten(Omschrijving) VALUES('Lezen')");
            migrationBuilder.Sql("INSERT INTO Rechten(Omschrijving) VALUES('Schrijven')");
            migrationBuilder.Sql("INSERT INTO Rechten(Omschrijving) VALUES('Wijzigen')");
            migrationBuilder.Sql("INSERT INTO Rechten(Omschrijving) VALUES('Verwijderen')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GebruikerRechten");

            migrationBuilder.DropTable(
                name: "Gebruikers");

            migrationBuilder.DropTable(
                name: "Rechten");
        }
    }
}
