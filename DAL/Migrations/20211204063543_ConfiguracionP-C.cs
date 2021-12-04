using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class ConfiguracionPC : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConsultasOdontologicas_Pacientes_PacienteNoDocumento",
                table: "ConsultasOdontologicas");

            migrationBuilder.DropIndex(
                name: "IX_ConsultasOdontologicas_PacienteNoDocumento",
                table: "ConsultasOdontologicas");

            migrationBuilder.DropColumn(
                name: "PacienteNoDocumento",
                table: "ConsultasOdontologicas");

            migrationBuilder.AlterColumn<string>(
                name: "NoDocumento",
                table: "ConsultasOdontologicas",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ConsultasOdontologicas_NoDocumento",
                table: "ConsultasOdontologicas",
                column: "NoDocumento");

            migrationBuilder.AddForeignKey(
                name: "FK_ConsultasOdontologicas_Pacientes_NoDocumento",
                table: "ConsultasOdontologicas",
                column: "NoDocumento",
                principalTable: "Pacientes",
                principalColumn: "NoDocumento",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConsultasOdontologicas_Pacientes_NoDocumento",
                table: "ConsultasOdontologicas");

            migrationBuilder.DropIndex(
                name: "IX_ConsultasOdontologicas_NoDocumento",
                table: "ConsultasOdontologicas");

            migrationBuilder.AlterColumn<string>(
                name: "NoDocumento",
                table: "ConsultasOdontologicas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PacienteNoDocumento",
                table: "ConsultasOdontologicas",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ConsultasOdontologicas_PacienteNoDocumento",
                table: "ConsultasOdontologicas",
                column: "PacienteNoDocumento");

            migrationBuilder.AddForeignKey(
                name: "FK_ConsultasOdontologicas_Pacientes_PacienteNoDocumento",
                table: "ConsultasOdontologicas",
                column: "PacienteNoDocumento",
                principalTable: "Pacientes",
                principalColumn: "NoDocumento",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
