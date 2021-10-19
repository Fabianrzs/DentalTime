using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class seventhMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NoDocumeto",
                table: "Pacientes",
                newName: "NoDocumento");

            migrationBuilder.RenameColumn(
                name: "FachaHora",
                table: "HistoriasClinicas",
                newName: "Fecha");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NoDocumento",
                table: "Pacientes",
                newName: "NoDocumeto");

            migrationBuilder.RenameColumn(
                name: "Fecha",
                table: "HistoriasClinicas",
                newName: "FachaHora");
        }
    }
}
