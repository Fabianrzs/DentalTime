using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class a : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HistoriasClinicas_Consultas_CodConsultaOfHistoria",
                table: "HistoriasClinicas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Consultas",
                table: "Consultas");

            migrationBuilder.RenameTable(
                name: "Consultas",
                newName: "ConsultasClinicas");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ConsultasClinicas",
                table: "ConsultasClinicas",
                column: "CodConsultaClinica");

            migrationBuilder.AddForeignKey(
                name: "FK_HistoriasClinicas_ConsultasClinicas_CodConsultaOfHistoria",
                table: "HistoriasClinicas",
                column: "CodConsultaOfHistoria",
                principalTable: "ConsultasClinicas",
                principalColumn: "CodConsultaClinica",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HistoriasClinicas_ConsultasClinicas_CodConsultaOfHistoria",
                table: "HistoriasClinicas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ConsultasClinicas",
                table: "ConsultasClinicas");

            migrationBuilder.RenameTable(
                name: "ConsultasClinicas",
                newName: "Consultas");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Consultas",
                table: "Consultas",
                column: "CodConsultaClinica");

            migrationBuilder.AddForeignKey(
                name: "FK_HistoriasClinicas_Consultas_CodConsultaOfHistoria",
                table: "HistoriasClinicas",
                column: "CodConsultaOfHistoria",
                principalTable: "Consultas",
                principalColumn: "CodConsultaClinica",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
