﻿// <auto-generated />
using System;
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DAL.Migrations
{
    [DbContext(typeof(DentalTimeContext))]
    [Migration("20211018154956_QuarterMigration")]
    partial class QuarterMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Entity.Agenda", b =>
                {
                    b.Property<int>("CodAgenda")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Estado")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CodAgenda");

                    b.ToTable("Agendas");
                });

            modelBuilder.Entity("Entity.Cita", b =>
                {
                    b.Property<int>("CodCita")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CodAgendaOfCita")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaHora")
                        .HasColumnType("datetime2");

                    b.Property<string>("Motivo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NoDocumentoOfCita")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ReferenciaServicioOfCita")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("CodCita");

                    b.HasIndex("CodAgendaOfCita");

                    b.HasIndex("NoDocumentoOfCita");

                    b.HasIndex("ReferenciaServicioOfCita");

                    b.ToTable("Citas");
                });

            modelBuilder.Entity("Entity.ConsultaClinica", b =>
                {
                    b.Property<int>("CodConsultaClinica")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Antecedentes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Medicacion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Motivo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UltimaConsulta")
                        .HasColumnType("datetime2");

                    b.Property<string>("ValoracionMedica")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CodConsultaClinica");

                    b.ToTable("Consultas");
                });

            modelBuilder.Entity("Entity.HistoriaClinica", b =>
                {
                    b.Property<int>("CodHistoriaClinica")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CodConsultaOfHistoria")
                        .HasColumnType("int");

                    b.Property<DateTime>("FachaHora")
                        .HasColumnType("datetime2");

                    b.Property<string>("NoDocumentoOfHistoria")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("CodHistoriaClinica");

                    b.HasIndex("CodConsultaOfHistoria")
                        .IsUnique();

                    b.HasIndex("NoDocumentoOfHistoria");

                    b.ToTable("HistoriasClinicas");
                });

            modelBuilder.Entity("Entity.Paciente", b =>
                {
                    b.Property<string>("NoDocumeto")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Apellidos")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CiudadNacimiento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CorreoElectronico")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombres")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumeroTelefonico")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PaisNacimiento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sexo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TipoDocumento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TipoSaguineo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("NoDocumeto");

                    b.ToTable("Pacientes");
                });

            modelBuilder.Entity("Entity.Producto", b =>
                {
                    b.Property<string>("Referencia")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Categoria")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Marca")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StockActual")
                        .HasColumnType("int");

                    b.Property<int>("StockMax")
                        .HasColumnType("int");

                    b.Property<int>("StockMin")
                        .HasColumnType("int");

                    b.HasKey("Referencia");

                    b.ToTable("Productos");
                });

            modelBuilder.Entity("Entity.Servicio", b =>
                {
                    b.Property<string>("Referencia")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Duracion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Precio")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Referencia");

                    b.ToTable("Servicios");
                });

            modelBuilder.Entity("Entity.Cita", b =>
                {
                    b.HasOne("Entity.Agenda", "Agenda")
                        .WithMany("Citas")
                        .HasForeignKey("CodAgendaOfCita")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entity.Paciente", "Paciente")
                        .WithMany("HistorialCita")
                        .HasForeignKey("NoDocumentoOfCita");

                    b.HasOne("Entity.Servicio", "Servicio")
                        .WithMany("Citas")
                        .HasForeignKey("ReferenciaServicioOfCita");

                    b.Navigation("Agenda");

                    b.Navigation("Paciente");

                    b.Navigation("Servicio");
                });

            modelBuilder.Entity("Entity.HistoriaClinica", b =>
                {
                    b.HasOne("Entity.ConsultaClinica", "ConsultaClinica")
                        .WithOne("HistoriaClinica")
                        .HasForeignKey("Entity.HistoriaClinica", "CodConsultaOfHistoria")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entity.Paciente", "Paciente")
                        .WithMany("HistorialClinico")
                        .HasForeignKey("NoDocumentoOfHistoria");

                    b.Navigation("ConsultaClinica");

                    b.Navigation("Paciente");
                });

            modelBuilder.Entity("Entity.Agenda", b =>
                {
                    b.Navigation("Citas");
                });

            modelBuilder.Entity("Entity.ConsultaClinica", b =>
                {
                    b.Navigation("HistoriaClinica");
                });

            modelBuilder.Entity("Entity.Paciente", b =>
                {
                    b.Navigation("HistorialCita");

                    b.Navigation("HistorialClinico");
                });

            modelBuilder.Entity("Entity.Servicio", b =>
                {
                    b.Navigation("Citas");
                });
#pragma warning restore 612, 618
        }
    }
}
