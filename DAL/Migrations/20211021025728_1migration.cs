using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class _1migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Antecedentes",
                columns: table => new
                {
                    IdAntecedente = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Enfermedades = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Farmaceuticos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quimicos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Complicaciones = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Antecedentes", x => x.IdAntecedente);
                });

            migrationBuilder.CreateTable(
                name: "Inventarios",
                columns: table => new
                {
                    IdInventario = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventarios", x => x.IdInventario);
                });

            migrationBuilder.CreateTable(
                name: "Pacientes",
                columns: table => new
                {
                    NoDocumento = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TipoDocumento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nombres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Apellidos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sexo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoSanguineo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LugarNacimiento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CorreoElectronico = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeroTelefonico = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacientes", x => x.NoDocumento);
                });

            migrationBuilder.CreateTable(
                name: "Servicios",
                columns: table => new
                {
                    IdServico = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Duracion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicios", x => x.IdServico);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    Referencia = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Laboratorio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Marca = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StockMin = table.Column<int>(type: "int", nullable: false),
                    StockMax = table.Column<int>(type: "int", nullable: false),
                    StockActual = table.Column<int>(type: "int", nullable: false),
                    IdInventario = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.Referencia);
                    table.ForeignKey(
                        name: "FK_Productos_Inventarios_IdInventario",
                        column: x => x.IdInventario,
                        principalTable: "Inventarios",
                        principalColumn: "IdInventario",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Citas",
                columns: table => new
                {
                    IdSolicitudCita = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoDocumentoPaciente = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Citas", x => x.IdSolicitudCita);
                    table.ForeignKey(
                        name: "FK_Citas_Pacientes_NoDocumentoPaciente",
                        column: x => x.NoDocumentoPaciente,
                        principalTable: "Pacientes",
                        principalColumn: "NoDocumento",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HistoriasOdontologicas",
                columns: table => new
                {
                    IdHistoriaOdontologica = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NoDocumentoPaciente = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IdAntecedentesOfHO = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoriasOdontologicas", x => x.IdHistoriaOdontologica);
                    table.ForeignKey(
                        name: "FK_HistoriasOdontologicas_Antecedentes_IdAntecedentesOfHO",
                        column: x => x.IdAntecedentesOfHO,
                        principalTable: "Antecedentes",
                        principalColumn: "IdAntecedente",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HistoriasOdontologicas_Pacientes_NoDocumentoPaciente",
                        column: x => x.NoDocumentoPaciente,
                        principalTable: "Pacientes",
                        principalColumn: "NoDocumento",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ConsultasOdontologicas",
                columns: table => new
                {
                    IdConsultaOdontologica = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Motivo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Medicacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Diagnostico = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Valoracion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecetaMedica = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdSolicitudCita = table.Column<int>(type: "int", nullable: false),
                    IdHistoriaOdontologica = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsultasOdontologicas", x => x.IdConsultaOdontologica);
                    table.ForeignKey(
                        name: "FK_ConsultasOdontologicas_Citas_IdSolicitudCita",
                        column: x => x.IdSolicitudCita,
                        principalTable: "Citas",
                        principalColumn: "IdSolicitudCita",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConsultasOdontologicas_HistoriasOdontologicas_IdHistoriaOdontologica",
                        column: x => x.IdHistoriaOdontologica,
                        principalTable: "HistoriasOdontologicas",
                        principalColumn: "IdHistoriaOdontologica",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Procedimientos",
                columns: table => new
                {
                    IdProcedimineto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdConsultaOdontologica = table.Column<int>(type: "int", nullable: false),
                    IdServico = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Procedimientos", x => x.IdProcedimineto);
                    table.ForeignKey(
                        name: "FK_Procedimientos_ConsultasOdontologicas_IdConsultaOdontologica",
                        column: x => x.IdConsultaOdontologica,
                        principalTable: "ConsultasOdontologicas",
                        principalColumn: "IdConsultaOdontologica",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Procedimientos_Servicios_IdServico",
                        column: x => x.IdServico,
                        principalTable: "Servicios",
                        principalColumn: "IdServico",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Citas_NoDocumentoPaciente",
                table: "Citas",
                column: "NoDocumentoPaciente");

            migrationBuilder.CreateIndex(
                name: "IX_ConsultasOdontologicas_IdHistoriaOdontologica",
                table: "ConsultasOdontologicas",
                column: "IdHistoriaOdontologica");

            migrationBuilder.CreateIndex(
                name: "IX_ConsultasOdontologicas_IdSolicitudCita",
                table: "ConsultasOdontologicas",
                column: "IdSolicitudCita",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HistoriasOdontologicas_IdAntecedentesOfHO",
                table: "HistoriasOdontologicas",
                column: "IdAntecedentesOfHO",
                unique: true,
                filter: "[IdAntecedentesOfHO] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_HistoriasOdontologicas_NoDocumentoPaciente",
                table: "HistoriasOdontologicas",
                column: "NoDocumentoPaciente",
                unique: true,
                filter: "[NoDocumentoPaciente] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Procedimientos_IdConsultaOdontologica",
                table: "Procedimientos",
                column: "IdConsultaOdontologica");

            migrationBuilder.CreateIndex(
                name: "IX_Procedimientos_IdServico",
                table: "Procedimientos",
                column: "IdServico",
                unique: true,
                filter: "[IdServico] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_IdInventario",
                table: "Productos",
                column: "IdInventario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Procedimientos");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "ConsultasOdontologicas");

            migrationBuilder.DropTable(
                name: "Servicios");

            migrationBuilder.DropTable(
                name: "Inventarios");

            migrationBuilder.DropTable(
                name: "Citas");

            migrationBuilder.DropTable(
                name: "HistoriasOdontologicas");

            migrationBuilder.DropTable(
                name: "Antecedentes");

            migrationBuilder.DropTable(
                name: "Pacientes");
        }
    }
}
