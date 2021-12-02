using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Citas_Pacientes_NoDocumentoPaciente",
                table: "Citas");

            migrationBuilder.DropForeignKey(
                name: "FK_ConsultasOdontologicas_HistoriasOdontologicas_IdHistoriaOdontologica",
                table: "ConsultasOdontologicas");

            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Inventarios_IdInventario",
                table: "Productos");

            migrationBuilder.DropTable(
                name: "HistoriasOdontologicas");

            migrationBuilder.DropTable(
                name: "Inventarios");

            migrationBuilder.DropTable(
                name: "Procedimientos");

            migrationBuilder.DropIndex(
                name: "IX_Productos_IdInventario",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "IdInventario",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "StockMax",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "StockMin",
                table: "Productos");

            migrationBuilder.RenameColumn(
                name: "IdHistoriaOdontologica",
                table: "ConsultasOdontologicas",
                newName: "PacienteNoDocumento");

            migrationBuilder.RenameIndex(
                name: "IX_ConsultasOdontologicas_IdHistoriaOdontologica",
                table: "ConsultasOdontologicas",
                newName: "IX_ConsultasOdontologicas_PacienteNoDocumento");

            migrationBuilder.RenameColumn(
                name: "NoDocumentoPaciente",
                table: "Citas",
                newName: "PacienteNoDocumento");

            migrationBuilder.RenameIndex(
                name: "IX_Citas_NoDocumentoPaciente",
                table: "Citas",
                newName: "IX_Citas_PacienteNoDocumento");

            migrationBuilder.RenameColumn(
                name: "FechaHoraInicio",
                table: "Agendas",
                newName: "FechaInicio");

            migrationBuilder.RenameColumn(
                name: "FechaHoraFin",
                table: "Agendas",
                newName: "FechaFin");

            migrationBuilder.AlterColumn<int>(
                name: "IdServico",
                table: "Servicios",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "IdAntecedentes",
                table: "ConsultasOdontologicas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdServicio",
                table: "ConsultasOdontologicas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "NoDocumento",
                table: "ConsultasOdontologicas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ServicioIdServico",
                table: "ConsultasOdontologicas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NoDocumento",
                table: "Citas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IdAntecedente",
                table: "Antecedentes",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "NoDocumento",
                table: "Agendas",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DetallesServicios",
                columns: table => new
                {
                    IdDetalleServicio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReferenciaProducto = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IdServicio = table.Column<int>(type: "int", nullable: false),
                    ServicioIdServico = table.Column<int>(type: "int", nullable: true),
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
                        name: "FK_DetallesServicios_Servicios_ServicioIdServico",
                        column: x => x.ServicioIdServico,
                        principalTable: "Servicios",
                        principalColumn: "IdServico",
                        onDelete: ReferentialAction.Restrict);
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

            migrationBuilder.CreateIndex(
                name: "IX_ConsultasOdontologicas_IdAntecedentes",
                table: "ConsultasOdontologicas",
                column: "IdAntecedentes",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ConsultasOdontologicas_ServicioIdServico",
                table: "ConsultasOdontologicas",
                column: "ServicioIdServico");

            migrationBuilder.CreateIndex(
                name: "IX_Agendas_NoDocumento",
                table: "Agendas",
                column: "NoDocumento",
                unique: true,
                filter: "[NoDocumento] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_DetallesServicios_ReferenciaProducto",
                table: "DetallesServicios",
                column: "ReferenciaProducto",
                unique: true,
                filter: "[ReferenciaProducto] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_DetallesServicios_ServicioIdServico",
                table: "DetallesServicios",
                column: "ServicioIdServico");

            migrationBuilder.AddForeignKey(
                name: "FK_Agendas_Odontologos_NoDocumento",
                table: "Agendas",
                column: "NoDocumento",
                principalTable: "Odontologos",
                principalColumn: "NoDocumento",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Citas_Pacientes_PacienteNoDocumento",
                table: "Citas",
                column: "PacienteNoDocumento",
                principalTable: "Pacientes",
                principalColumn: "NoDocumento",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ConsultasOdontologicas_Antecedentes_IdAntecedentes",
                table: "ConsultasOdontologicas",
                column: "IdAntecedentes",
                principalTable: "Antecedentes",
                principalColumn: "IdAntecedente",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ConsultasOdontologicas_Pacientes_PacienteNoDocumento",
                table: "ConsultasOdontologicas",
                column: "PacienteNoDocumento",
                principalTable: "Pacientes",
                principalColumn: "NoDocumento",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ConsultasOdontologicas_Servicios_ServicioIdServico",
                table: "ConsultasOdontologicas",
                column: "ServicioIdServico",
                principalTable: "Servicios",
                principalColumn: "IdServico",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agendas_Odontologos_NoDocumento",
                table: "Agendas");

            migrationBuilder.DropForeignKey(
                name: "FK_Citas_Pacientes_PacienteNoDocumento",
                table: "Citas");

            migrationBuilder.DropForeignKey(
                name: "FK_ConsultasOdontologicas_Antecedentes_IdAntecedentes",
                table: "ConsultasOdontologicas");

            migrationBuilder.DropForeignKey(
                name: "FK_ConsultasOdontologicas_Pacientes_PacienteNoDocumento",
                table: "ConsultasOdontologicas");

            migrationBuilder.DropForeignKey(
                name: "FK_ConsultasOdontologicas_Servicios_ServicioIdServico",
                table: "ConsultasOdontologicas");

            migrationBuilder.DropTable(
                name: "DetallesServicios");

            migrationBuilder.DropTable(
                name: "Odontologos");

            migrationBuilder.DropIndex(
                name: "IX_ConsultasOdontologicas_IdAntecedentes",
                table: "ConsultasOdontologicas");

            migrationBuilder.DropIndex(
                name: "IX_ConsultasOdontologicas_ServicioIdServico",
                table: "ConsultasOdontologicas");

            migrationBuilder.DropIndex(
                name: "IX_Agendas_NoDocumento",
                table: "Agendas");

            migrationBuilder.DropColumn(
                name: "IdAntecedentes",
                table: "ConsultasOdontologicas");

            migrationBuilder.DropColumn(
                name: "IdServicio",
                table: "ConsultasOdontologicas");

            migrationBuilder.DropColumn(
                name: "NoDocumento",
                table: "ConsultasOdontologicas");

            migrationBuilder.DropColumn(
                name: "ServicioIdServico",
                table: "ConsultasOdontologicas");

            migrationBuilder.DropColumn(
                name: "NoDocumento",
                table: "Citas");

            migrationBuilder.DropColumn(
                name: "NoDocumento",
                table: "Agendas");

            migrationBuilder.RenameColumn(
                name: "PacienteNoDocumento",
                table: "ConsultasOdontologicas",
                newName: "IdHistoriaOdontologica");

            migrationBuilder.RenameIndex(
                name: "IX_ConsultasOdontologicas_PacienteNoDocumento",
                table: "ConsultasOdontologicas",
                newName: "IX_ConsultasOdontologicas_IdHistoriaOdontologica");

            migrationBuilder.RenameColumn(
                name: "PacienteNoDocumento",
                table: "Citas",
                newName: "NoDocumentoPaciente");

            migrationBuilder.RenameIndex(
                name: "IX_Citas_PacienteNoDocumento",
                table: "Citas",
                newName: "IX_Citas_NoDocumentoPaciente");

            migrationBuilder.RenameColumn(
                name: "FechaInicio",
                table: "Agendas",
                newName: "FechaHoraInicio");

            migrationBuilder.RenameColumn(
                name: "FechaFin",
                table: "Agendas",
                newName: "FechaHoraFin");

            migrationBuilder.AlterColumn<string>(
                name: "IdServico",
                table: "Servicios",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "IdInventario",
                table: "Productos",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StockMax",
                table: "Productos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StockMin",
                table: "Productos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "IdAntecedente",
                table: "Antecedentes",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.CreateTable(
                name: "HistoriasOdontologicas",
                columns: table => new
                {
                    IdHistoriaOdontologica = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdAntecedentesOfHO = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    NoDocumentoPaciente = table.Column<string>(type: "nvarchar(450)", nullable: true)
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
                name: "IX_Productos_IdInventario",
                table: "Productos",
                column: "IdInventario");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Citas_Pacientes_NoDocumentoPaciente",
                table: "Citas",
                column: "NoDocumentoPaciente",
                principalTable: "Pacientes",
                principalColumn: "NoDocumento",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ConsultasOdontologicas_HistoriasOdontologicas_IdHistoriaOdontologica",
                table: "ConsultasOdontologicas",
                column: "IdHistoriaOdontologica",
                principalTable: "HistoriasOdontologicas",
                principalColumn: "IdHistoriaOdontologica",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Inventarios_IdInventario",
                table: "Productos",
                column: "IdInventario",
                principalTable: "Inventarios",
                principalColumn: "IdInventario",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
