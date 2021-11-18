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
    [Migration("20211112003514_agendas")]
    partial class agendas
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

                    b.Property<DateTime>("FechaHoraFin")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaHoraInicio")
                        .HasColumnType("datetime2");

                    b.HasKey("CodAgenda");

                    b.ToTable("Agendas");
                });

            modelBuilder.Entity("Entity.Antecedente", b =>
                {
                    b.Property<string>("IdAntecedente")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Complicaciones")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Enfermedades")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Farmaceuticos")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Quimicos")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdAntecedente");

                    b.ToTable("Antecedentes");
                });

            modelBuilder.Entity("Entity.ConsultaOdontologica", b =>
                {
                    b.Property<int>("IdConsultaOdontologica")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Diagnostico")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdHistoriaOdontologica")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("IdSolicitudCita")
                        .HasColumnType("int");

                    b.Property<string>("Medicacion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Motivo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RecetaMedica")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Valoracion")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdConsultaOdontologica");

                    b.HasIndex("IdHistoriaOdontologica");

                    b.HasIndex("IdSolicitudCita")
                        .IsUnique();

                    b.ToTable("ConsultasOdontologicas");
                });

            modelBuilder.Entity("Entity.HistoriaOdontologica", b =>
                {
                    b.Property<string>("IdHistoriaOdontologica")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("FechaInicio")
                        .HasColumnType("datetime2");

                    b.Property<string>("IdAntecedentesOfHO")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("NoDocumentoPaciente")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("IdHistoriaOdontologica");

                    b.HasIndex("IdAntecedentesOfHO")
                        .IsUnique()
                        .HasFilter("[IdAntecedentesOfHO] IS NOT NULL");

                    b.HasIndex("NoDocumentoPaciente")
                        .IsUnique()
                        .HasFilter("[NoDocumentoPaciente] IS NOT NULL");

                    b.ToTable("HistoriasOdontologicas");
                });

            modelBuilder.Entity("Entity.Inventario", b =>
                {
                    b.Property<string>("IdInventario")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("IdInventario");

                    b.ToTable("Inventarios");
                });

            modelBuilder.Entity("Entity.Paciente", b =>
                {
                    b.Property<string>("NoDocumento")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Apellidos")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CorreoElectronico")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("datetime2");

                    b.Property<string>("LugarNacimiento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombres")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumeroTelefonico")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sexo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TipoDocumento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TipoSanguineo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("NoDocumento");

                    b.ToTable("Pacientes");
                });

            modelBuilder.Entity("Entity.Procedimiento", b =>
                {
                    b.Property<int>("IdProcedimineto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdConsultaOdontologica")
                        .HasColumnType("int");

                    b.Property<string>("IdServico")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("IdProcedimineto");

                    b.HasIndex("IdConsultaOdontologica");

                    b.HasIndex("IdServico")
                        .IsUnique()
                        .HasFilter("[IdServico] IS NOT NULL");

                    b.ToTable("Procedimientos");
                });

            modelBuilder.Entity("Entity.Producto", b =>
                {
                    b.Property<string>("Referencia")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("IdInventario")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Laboratorio")
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

                    b.HasIndex("IdInventario");

                    b.ToTable("Productos");
                });

            modelBuilder.Entity("Entity.Servicio", b =>
                {
                    b.Property<string>("IdServico")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Duracion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Precio")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("IdServico");

                    b.ToTable("Servicios");
                });

            modelBuilder.Entity("Entity.SolicitudCita", b =>
                {
                    b.Property<int>("IdSolicitudCita")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CodAgenda")
                        .HasColumnType("int");

                    b.Property<string>("Estado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<string>("NoDocumentoPaciente")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("IdSolicitudCita");

                    b.HasIndex("CodAgenda")
                        .IsUnique();

                    b.HasIndex("NoDocumentoPaciente");

                    b.ToTable("Citas");
                });

            modelBuilder.Entity("Entity.ConsultaOdontologica", b =>
                {
                    b.HasOne("Entity.HistoriaOdontologica", "HistoriaOdontologica")
                        .WithMany("ConsultasOdontologica")
                        .HasForeignKey("IdHistoriaOdontologica");

                    b.HasOne("Entity.SolicitudCita", "SolicitudCita")
                        .WithOne("ConsultaOdontologica")
                        .HasForeignKey("Entity.ConsultaOdontologica", "IdSolicitudCita")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HistoriaOdontologica");

                    b.Navigation("SolicitudCita");
                });

            modelBuilder.Entity("Entity.HistoriaOdontologica", b =>
                {
                    b.HasOne("Entity.Antecedente", "Antecedentes")
                        .WithOne("HistoriaOdontologica")
                        .HasForeignKey("Entity.HistoriaOdontologica", "IdAntecedentesOfHO");

                    b.HasOne("Entity.Paciente", "Paciente")
                        .WithOne("HistorialOdontologico")
                        .HasForeignKey("Entity.HistoriaOdontologica", "NoDocumentoPaciente");

                    b.Navigation("Antecedentes");

                    b.Navigation("Paciente");
                });

            modelBuilder.Entity("Entity.Procedimiento", b =>
                {
                    b.HasOne("Entity.ConsultaOdontologica", "ConsultaOdontologica")
                        .WithMany("Procedimientos")
                        .HasForeignKey("IdConsultaOdontologica")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entity.Servicio", "Servicio")
                        .WithOne("Procedimiento")
                        .HasForeignKey("Entity.Procedimiento", "IdServico");

                    b.Navigation("ConsultaOdontologica");

                    b.Navigation("Servicio");
                });

            modelBuilder.Entity("Entity.Producto", b =>
                {
                    b.HasOne("Entity.Inventario", "Inventario")
                        .WithMany("Productos")
                        .HasForeignKey("IdInventario");

                    b.Navigation("Inventario");
                });

            modelBuilder.Entity("Entity.SolicitudCita", b =>
                {
                    b.HasOne("Entity.Agenda", "Agenda")
                        .WithOne("Cita")
                        .HasForeignKey("Entity.SolicitudCita", "CodAgenda")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entity.Paciente", "Paciente")
                        .WithMany("HistorialCitas")
                        .HasForeignKey("NoDocumentoPaciente");

                    b.Navigation("Agenda");

                    b.Navigation("Paciente");
                });

            modelBuilder.Entity("Entity.Agenda", b =>
                {
                    b.Navigation("Cita");
                });

            modelBuilder.Entity("Entity.Antecedente", b =>
                {
                    b.Navigation("HistoriaOdontologica");
                });

            modelBuilder.Entity("Entity.ConsultaOdontologica", b =>
                {
                    b.Navigation("Procedimientos");
                });

            modelBuilder.Entity("Entity.HistoriaOdontologica", b =>
                {
                    b.Navigation("ConsultasOdontologica");
                });

            modelBuilder.Entity("Entity.Inventario", b =>
                {
                    b.Navigation("Productos");
                });

            modelBuilder.Entity("Entity.Paciente", b =>
                {
                    b.Navigation("HistorialCitas");

                    b.Navigation("HistorialOdontologico");
                });

            modelBuilder.Entity("Entity.Servicio", b =>
                {
                    b.Navigation("Procedimiento");
                });

            modelBuilder.Entity("Entity.SolicitudCita", b =>
                {
                    b.Navigation("ConsultaOdontologica");
                });
#pragma warning restore 612, 618
        }
    }
}
