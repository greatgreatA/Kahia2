using Microsoft.EntityFrameworkCore.Migrations;

namespace Kahia2.Migrations
{
    public partial class kacontest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Patho",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomPatho = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patho", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Patient",
                columns: table => new
                {
                    IdPatient = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Poids = table.Column<int>(nullable: false),
                    SituationMatrimoniale = table.Column<bool>(nullable: false),
                    GroupeSanguin = table.Column<string>(nullable: false),
                    Age = table.Column<int>(nullable: false),
                    Taille = table.Column<int>(nullable: false),
                    Sexe = table.Column<string>(nullable: false),
                    Patho1Id = table.Column<int>(nullable: true),
                    Patho2Id = table.Column<int>(nullable: true),
                    Patho3Id = table.Column<int>(nullable: true),
                    Patho4Id = table.Column<int>(nullable: true),
                    Patho5Id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient", x => x.IdPatient);
                    table.ForeignKey(
                        name: "FK_Patient_Patho_Patho1Id",
                        column: x => x.Patho1Id,
                        principalTable: "Patho",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Patient_Patho_Patho2Id",
                        column: x => x.Patho2Id,
                        principalTable: "Patho",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Patient_Patho_Patho3Id",
                        column: x => x.Patho3Id,
                        principalTable: "Patho",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Patient_Patho_Patho4Id",
                        column: x => x.Patho4Id,
                        principalTable: "Patho",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Patient_Patho_Patho5Id",
                        column: x => x.Patho5Id,
                        principalTable: "Patho",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Patient_Patho1Id",
                table: "Patient",
                column: "Patho1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Patient_Patho2Id",
                table: "Patient",
                column: "Patho2Id");

            migrationBuilder.CreateIndex(
                name: "IX_Patient_Patho3Id",
                table: "Patient",
                column: "Patho3Id");

            migrationBuilder.CreateIndex(
                name: "IX_Patient_Patho4Id",
                table: "Patient",
                column: "Patho4Id");

            migrationBuilder.CreateIndex(
                name: "IX_Patient_Patho5Id",
                table: "Patient",
                column: "Patho5Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Patient");

            migrationBuilder.DropTable(
                name: "Patho");
        }
    }
}
