using Microsoft.EntityFrameworkCore.Migrations;

namespace Kahia2.Data.Migrations
{
    public partial class chercheurs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Medecin_Adresse",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Medecin_Nom",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Medecin_Prenom",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Medecin_Adresse",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Medecin_Nom",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Medecin_Prenom",
                table: "AspNetUsers");
        }
    }
}
