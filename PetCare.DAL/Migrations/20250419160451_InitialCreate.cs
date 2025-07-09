using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetCare.DAL.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Proprietaires",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adresse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telephone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proprietaires", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypesAnimaux",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Libelle = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypesAnimaux", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Veterinaires",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Specialite = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Veterinaires", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Animaux",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    ProprietaireId = table.Column<int>(type: "int", nullable: false),
                    TypeAnimalId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animaux", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Animaux_Proprietaires_ProprietaireId",
                        column: x => x.ProprietaireId,
                        principalTable: "Proprietaires",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Animaux_TypesAnimaux_TypeAnimalId",
                        column: x => x.TypeAnimalId,
                        principalTable: "TypesAnimaux",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Consultations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateConsultation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Diagnostic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnimalId = table.Column<int>(type: "int", nullable: false),
                    VeterinaireId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consultations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Consultations_Animaux_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "Animaux",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Consultations_Veterinaires_VeterinaireId",
                        column: x => x.VeterinaireId,
                        principalTable: "Veterinaires",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Animaux_ProprietaireId",
                table: "Animaux",
                column: "ProprietaireId");

            migrationBuilder.CreateIndex(
                name: "IX_Animaux_TypeAnimalId",
                table: "Animaux",
                column: "TypeAnimalId");

            migrationBuilder.CreateIndex(
                name: "IX_Consultations_AnimalId",
                table: "Consultations",
                column: "AnimalId");

            migrationBuilder.CreateIndex(
                name: "IX_Consultations_VeterinaireId",
                table: "Consultations",
                column: "VeterinaireId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Consultations");

            migrationBuilder.DropTable(
                name: "Animaux");

            migrationBuilder.DropTable(
                name: "Veterinaires");

            migrationBuilder.DropTable(
                name: "Proprietaires");

            migrationBuilder.DropTable(
                name: "TypesAnimaux");
        }
    }
}
