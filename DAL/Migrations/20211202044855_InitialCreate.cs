using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Antecedentes",
                columns: table => new
                {
                    IdAntecedente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                name: "Odontologos",
                columns: table => new
                {
                    NoDocumento = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TipoDocumento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nombres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Apellidos = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Odontologos", x => x.NoDocumento);
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
                name: "Productos",
                columns: table => new
                {
                    Referencia = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Laboratorio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Marca = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    IdServico = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Precio = table.Column<decimal>(type: "decimal", nullable: false),
                    Duracion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicios", x => x.IdServico);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rol = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CorreoElectronico = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserName);
                });

            migrationBuilder.CreateTable(
                name: "Agendas",
                columns: table => new
                {
                    CodAgenda = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NoDocumento = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agendas", x => x.CodAgenda);
                    table.ForeignKey(
                        name: "FK_Agendas_Odontologos_NoDocumento",
                        column: x => x.NoDocumento,
                        principalTable: "Odontologos",
                        principalColumn: "NoDocumento",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DetallesServicios",
                columns: table => new
                {
                    IdDetalleServicio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReferenciaProducto = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IdServicio = table.Column<int>(type: "int", nullable: false),
                    UnidadesUsadas = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetallesServicios", x => x.IdDetalleServicio);
                    table.ForeignKey(
                        name: "FK_DetallesServicios_Productos_ReferenciaProducto",
                        column: x => x.ReferenciaProducto,
                        principalTable: "Productos",
                        principalColumn: "Referencia",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DetallesServicios_Servicios_IdServicio",
                        column: x => x.IdServicio,
                        principalTable: "Servicios",
                        principalColumn: "IdServico",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Citas",
                columns: table => new
                {
                    IdSolicitudCita = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoDocumento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PacienteNoDocumento = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CodAgenda = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Citas", x => x.IdSolicitudCita);
                    table.ForeignKey(
                        name: "FK_Citas_Agendas_CodAgenda",
                        column: x => x.CodAgenda,
                        principalTable: "Agendas",
                        principalColumn: "CodAgenda",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Citas_Pacientes_PacienteNoDocumento",
                        column: x => x.PacienteNoDocumento,
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
                    IdAntecedentes = table.Column<int>(type: "int", nullable: false),
                    NoDocumento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PacienteNoDocumento = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IdSolicitudCita = table.Column<int>(type: "int", nullable: false),
                    IdServicio = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsultasOdontologicas", x => x.IdConsultaOdontologica);
                    table.ForeignKey(
                        name: "FK_ConsultasOdontologicas_Antecedentes_IdAntecedentes",
                        column: x => x.IdAntecedentes,
                        principalTable: "Antecedentes",
                        principalColumn: "IdAntecedente",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConsultasOdontologicas_Citas_IdSolicitudCita",
                        column: x => x.IdSolicitudCita,
                        principalTable: "Citas",
                        principalColumn: "IdSolicitudCita",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConsultasOdontologicas_Pacientes_PacienteNoDocumento",
                        column: x => x.PacienteNoDocumento,
                        principalTable: "Pacientes",
                        principalColumn: "NoDocumento",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ConsultasOdontologicas_Servicios_IdServicio",
                        column: x => x.IdServicio,
                        principalTable: "Servicios",
                        principalColumn: "IdServico",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agendas_NoDocumento",
                table: "Agendas",
                column: "NoDocumento",
                unique: true,
                filter: "[NoDocumento] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Citas_CodAgenda",
                table: "Citas",
                column: "CodAgenda",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Citas_PacienteNoDocumento",
                table: "Citas",
                column: "PacienteNoDocumento");

            migrationBuilder.CreateIndex(
                name: "IX_ConsultasOdontologicas_IdAntecedentes",
                table: "ConsultasOdontologicas",
                column: "IdAntecedentes",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ConsultasOdontologicas_IdServicio",
                table: "ConsultasOdontologicas",
                column: "IdServicio");

            migrationBuilder.CreateIndex(
                name: "IX_ConsultasOdontologicas_IdSolicitudCita",
                table: "ConsultasOdontologicas",
                column: "IdSolicitudCita",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ConsultasOdontologicas_PacienteNoDocumento",
                table: "ConsultasOdontologicas",
                column: "PacienteNoDocumento");

            migrationBuilder.CreateIndex(
                name: "IX_DetallesServicios_IdServicio",
                table: "DetallesServicios",
                column: "IdServicio");

            migrationBuilder.CreateIndex(
                name: "IX_DetallesServicios_ReferenciaProducto",
                table: "DetallesServicios",
                column: "ReferenciaProducto",
                unique: true,
                filter: "[ReferenciaProducto] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConsultasOdontologicas");

            migrationBuilder.DropTable(
                name: "DetallesServicios");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Antecedentes");

            migrationBuilder.DropTable(
                name: "Citas");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Servicios");

            migrationBuilder.DropTable(
                name: "Agendas");

            migrationBuilder.DropTable(
                name: "Pacientes");

            migrationBuilder.DropTable(
                name: "Odontologos");
        }
    }
}
