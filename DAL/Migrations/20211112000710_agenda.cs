using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class agenda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CodAgenda",
                table: "Citas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Agendas",
                columns: table => new
                {
                    CodAgenda = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaHoraInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaHoraFin = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agendas", x => x.CodAgenda);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Citas_CodAgenda",
                table: "Citas",
                column: "CodAgenda",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Citas_Agendas_CodAgenda",
                table: "Citas",
                column: "CodAgenda",
                principalTable: "Agendas",
                principalColumn: "CodAgenda",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Citas_Agendas_CodAgenda",
                table: "Citas");

            migrationBuilder.DropTable(
                name: "Agendas");

            migrationBuilder.DropIndex(
                name: "IX_Citas_CodAgenda",
                table: "Citas");

            migrationBuilder.DropColumn(
                name: "CodAgenda",
                table: "Citas");
        }
    }
}
