using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class configuracionPC : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Citas_Pacientes_PacienteNoDocumento",
                table: "Citas");

            migrationBuilder.DropIndex(
                name: "IX_Citas_PacienteNoDocumento",
                table: "Citas");

            migrationBuilder.DropColumn(
                name: "PacienteNoDocumento",
                table: "Citas");

            migrationBuilder.AlterColumn<string>(
                name: "NoDocumento",
                table: "Citas",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Citas_NoDocumento",
                table: "Citas",
                column: "NoDocumento");

            migrationBuilder.AddForeignKey(
                name: "FK_Citas_Pacientes_NoDocumento",
                table: "Citas",
                column: "NoDocumento",
                principalTable: "Pacientes",
                principalColumn: "NoDocumento",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Citas_Pacientes_NoDocumento",
                table: "Citas");

            migrationBuilder.DropIndex(
                name: "IX_Citas_NoDocumento",
                table: "Citas");

            migrationBuilder.AlterColumn<string>(
                name: "NoDocumento",
                table: "Citas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PacienteNoDocumento",
                table: "Citas",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Citas_PacienteNoDocumento",
                table: "Citas",
                column: "PacienteNoDocumento");

            migrationBuilder.AddForeignKey(
                name: "FK_Citas_Pacientes_PacienteNoDocumento",
                table: "Citas",
                column: "PacienteNoDocumento",
                principalTable: "Pacientes",
                principalColumn: "NoDocumento",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
