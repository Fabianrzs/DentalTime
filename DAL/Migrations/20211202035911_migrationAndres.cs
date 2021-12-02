using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class migrationAndres : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConsultasOdontologicas_Servicios_ServicioIdServico",
                table: "ConsultasOdontologicas");

            migrationBuilder.DropForeignKey(
                name: "FK_DetallesServicios_Servicios_ServicioIdServico",
                table: "DetallesServicios");

            migrationBuilder.DropIndex(
                name: "IX_DetallesServicios_ServicioIdServico",
                table: "DetallesServicios");

            migrationBuilder.DropIndex(
                name: "IX_ConsultasOdontologicas_ServicioIdServico",
                table: "ConsultasOdontologicas");

            migrationBuilder.DropColumn(
                name: "ServicioIdServico",
                table: "DetallesServicios");

            migrationBuilder.DropColumn(
                name: "ServicioIdServico",
                table: "ConsultasOdontologicas");

            migrationBuilder.CreateIndex(
                name: "IX_DetallesServicios_IdServicio",
                table: "DetallesServicios",
                column: "IdServicio");

            migrationBuilder.CreateIndex(
                name: "IX_ConsultasOdontologicas_IdServicio",
                table: "ConsultasOdontologicas",
                column: "IdServicio");

            migrationBuilder.AddForeignKey(
                name: "FK_ConsultasOdontologicas_Servicios_IdServicio",
                table: "ConsultasOdontologicas",
                column: "IdServicio",
                principalTable: "Servicios",
                principalColumn: "IdServico",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DetallesServicios_Servicios_IdServicio",
                table: "DetallesServicios",
                column: "IdServicio",
                principalTable: "Servicios",
                principalColumn: "IdServico",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConsultasOdontologicas_Servicios_IdServicio",
                table: "ConsultasOdontologicas");

            migrationBuilder.DropForeignKey(
                name: "FK_DetallesServicios_Servicios_IdServicio",
                table: "DetallesServicios");

            migrationBuilder.DropIndex(
                name: "IX_DetallesServicios_IdServicio",
                table: "DetallesServicios");

            migrationBuilder.DropIndex(
                name: "IX_ConsultasOdontologicas_IdServicio",
                table: "ConsultasOdontologicas");

            migrationBuilder.AddColumn<int>(
                name: "ServicioIdServico",
                table: "DetallesServicios",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ServicioIdServico",
                table: "ConsultasOdontologicas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DetallesServicios_ServicioIdServico",
                table: "DetallesServicios",
                column: "ServicioIdServico");

            migrationBuilder.CreateIndex(
                name: "IX_ConsultasOdontologicas_ServicioIdServico",
                table: "ConsultasOdontologicas",
                column: "ServicioIdServico");

            migrationBuilder.AddForeignKey(
                name: "FK_ConsultasOdontologicas_Servicios_ServicioIdServico",
                table: "ConsultasOdontologicas",
                column: "ServicioIdServico",
                principalTable: "Servicios",
                principalColumn: "IdServico",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DetallesServicios_Servicios_ServicioIdServico",
                table: "DetallesServicios",
                column: "ServicioIdServico",
                principalTable: "Servicios",
                principalColumn: "IdServico",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
