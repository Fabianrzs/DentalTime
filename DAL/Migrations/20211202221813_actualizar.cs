using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class actualizar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agendas_Odontologos_NoDocumento",
                table: "Agendas");

            migrationBuilder.DropIndex(
                name: "IX_Agendas_NoDocumento",
                table: "Agendas");

            migrationBuilder.AddColumn<string>(
                name: "OdontologoNoDocumento",
                table: "Odontologos",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NoDocumento",
                table: "Agendas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OdontologoNoDocumento",
                table: "Agendas",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Odontologos_OdontologoNoDocumento",
                table: "Odontologos",
                column: "OdontologoNoDocumento");

            migrationBuilder.CreateIndex(
                name: "IX_Agendas_OdontologoNoDocumento",
                table: "Agendas",
                column: "OdontologoNoDocumento");

            migrationBuilder.AddForeignKey(
                name: "FK_Agendas_Odontologos_OdontologoNoDocumento",
                table: "Agendas",
                column: "OdontologoNoDocumento",
                principalTable: "Odontologos",
                principalColumn: "NoDocumento",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Odontologos_Odontologos_OdontologoNoDocumento",
                table: "Odontologos",
                column: "OdontologoNoDocumento",
                principalTable: "Odontologos",
                principalColumn: "NoDocumento",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agendas_Odontologos_OdontologoNoDocumento",
                table: "Agendas");

            migrationBuilder.DropForeignKey(
                name: "FK_Odontologos_Odontologos_OdontologoNoDocumento",
                table: "Odontologos");

            migrationBuilder.DropIndex(
                name: "IX_Odontologos_OdontologoNoDocumento",
                table: "Odontologos");

            migrationBuilder.DropIndex(
                name: "IX_Agendas_OdontologoNoDocumento",
                table: "Agendas");

            migrationBuilder.DropColumn(
                name: "OdontologoNoDocumento",
                table: "Odontologos");

            migrationBuilder.DropColumn(
                name: "OdontologoNoDocumento",
                table: "Agendas");

            migrationBuilder.AlterColumn<string>(
                name: "NoDocumento",
                table: "Agendas",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Agendas_NoDocumento",
                table: "Agendas",
                column: "NoDocumento",
                unique: true,
                filter: "[NoDocumento] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Agendas_Odontologos_NoDocumento",
                table: "Agendas",
                column: "NoDocumento",
                principalTable: "Odontologos",
                principalColumn: "NoDocumento",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
