using Microsoft.EntityFrameworkCore.Migrations;

namespace Kahia2.Data.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Adresse",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nom",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Prenom",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Pathis",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomPatho = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pathis", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
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
                    table.PrimaryKey("PK_Patients", x => x.IdPatient);
                    table.ForeignKey(
                        name: "FK_Patients_Pathis_Patho1Id",
                        column: x => x.Patho1Id,
                        principalTable: "Pathis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Patients_Pathis_Patho2Id",
                        column: x => x.Patho2Id,
                        principalTable: "Pathis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Patients_Pathis_Patho3Id",
                        column: x => x.Patho3Id,
                        principalTable: "Pathis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Patients_Pathis_Patho4Id",
                        column: x => x.Patho4Id,
                        principalTable: "Pathis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Patients_Pathis_Patho5Id",
                        column: x => x.Patho5Id,
                        principalTable: "Pathis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Patients_Patho1Id",
                table: "Patients",
                column: "Patho1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_Patho2Id",
                table: "Patients",
                column: "Patho2Id");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_Patho3Id",
                table: "Patients",
                column: "Patho3Id");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_Patho4Id",
                table: "Patients",
                column: "Patho4Id");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_Patho5Id",
                table: "Patients",
                column: "Patho5Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Pathis");

            migrationBuilder.DropColumn(
                name: "Adresse",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Nom",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Prenom",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");
        }
    }
}
