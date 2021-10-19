using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class ocvatamigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Agendas",
                columns: table => new
                {
                    CodAgenda = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaHora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agendas", x => x.CodAgenda);
                });

            migrationBuilder.CreateTable(
                name: "ConsultasClinicas",
                columns: table => new
                {
                    CodConsultaClinica = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Motivo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Complicaciones = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Antecedentes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Medicacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UltimaConsulta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ValoracionMedica = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsultasClinicas", x => x.CodConsultaClinica);
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
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaisNacimiento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CiudadNacimiento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoSaguineo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeroTelefonico = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CorreoElectronico = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacientes", x => x.NoDocumento);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    Referencia = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Marca = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Categoria = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StockMin = table.Column<int>(type: "int", nullable: false),
                    StockMax = table.Column<int>(type: "int", nullable: false),
                    StockActual = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.Referencia);
                });

            migrationBuilder.CreateTable(
                name: "Servicios",
                columns: table => new
                {
                    Referencia = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Duracion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicios", x => x.Referencia);
                });

            migrationBuilder.CreateTable(
                name: "HistoriasClinicas",
                columns: table => new
                {
                    CodHistoriaClinica = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NoDocumentoOfHistoria = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CodConsultaOfHistoria = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoriasClinicas", x => x.CodHistoriaClinica);
                    table.ForeignKey(
                        name: "FK_HistoriasClinicas_ConsultasClinicas_CodConsultaOfHistoria",
                        column: x => x.CodConsultaOfHistoria,
                        principalTable: "ConsultasClinicas",
                        principalColumn: "CodConsultaClinica",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HistoriasClinicas_Pacientes_NoDocumentoOfHistoria",
                        column: x => x.NoDocumentoOfHistoria,
                        principalTable: "Pacientes",
                        principalColumn: "NoDocumento",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Citas",
                columns: table => new
                {
                    CodCita = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Motivo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoDocumentoOfCita = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CodAgendaOfCita = table.Column<int>(type: "int", nullable: false),
                    ReferenciaServicioOfCita = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Citas", x => x.CodCita);
                    table.ForeignKey(
                        name: "FK_Citas_Agendas_CodAgendaOfCita",
                        column: x => x.CodAgendaOfCita,
                        principalTable: "Agendas",
                        principalColumn: "CodAgenda",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Citas_Pacientes_NoDocumentoOfCita",
                        column: x => x.NoDocumentoOfCita,
                        principalTable: "Pacientes",
                        principalColumn: "NoDocumento",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Citas_Servicios_ReferenciaServicioOfCita",
                        column: x => x.ReferenciaServicioOfCita,
                        principalTable: "Servicios",
                        principalColumn: "Referencia",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Citas_CodAgendaOfCita",
                table: "Citas",
                column: "CodAgendaOfCita");

            migrationBuilder.CreateIndex(
                name: "IX_Citas_NoDocumentoOfCita",
                table: "Citas",
                column: "NoDocumentoOfCita");

            migrationBuilder.CreateIndex(
                name: "IX_Citas_ReferenciaServicioOfCita",
                table: "Citas",
                column: "ReferenciaServicioOfCita");

            migrationBuilder.CreateIndex(
                name: "IX_HistoriasClinicas_CodConsultaOfHistoria",
                table: "HistoriasClinicas",
                column: "CodConsultaOfHistoria",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HistoriasClinicas_NoDocumentoOfHistoria",
                table: "HistoriasClinicas",
                column: "NoDocumentoOfHistoria");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Citas");

            migrationBuilder.DropTable(
                name: "HistoriasClinicas");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Agendas");

            migrationBuilder.DropTable(
                name: "Servicios");

            migrationBuilder.DropTable(
                name: "ConsultasClinicas");

            migrationBuilder.DropTable(
                name: "Pacientes");
        }
    }
}
