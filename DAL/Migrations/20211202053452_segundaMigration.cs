using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class segundaMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_DetallesServicios_ReferenciaProducto",
                table: "DetallesServicios");

            migrationBuilder.CreateIndex(
                name: "IX_DetallesServicios_ReferenciaProducto",
                table: "DetallesServicios",
                column: "ReferenciaProducto");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_DetallesServicios_ReferenciaProducto",
                table: "DetallesServicios");

            migrationBuilder.CreateIndex(
                name: "IX_DetallesServicios_ReferenciaProducto",
                table: "DetallesServicios",
                column: "ReferenciaProducto",
                unique: true,
                filter: "[ReferenciaProducto] IS NOT NULL");
        }
    }
}
