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
    [Migration("20211204063543_ConfiguracionP-C")]
    partial class ConfiguracionPC
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

                    b.Property<DateTime>("FechaFin")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaInicio")
                        .HasColumnType("datetime2");

                    b.Property<string>("NoDocumento")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("CodAgenda");

                    b.HasIndex("NoDocumento");

                    b.ToTable("Agendas");
                });

            modelBuilder.Entity("Entity.Antecedente", b =>
                {
                    b.Property<int>("IdAntecedente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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

                    b.Property<int>("IdAntecedentes")
                        .HasColumnType("int");

                    b.Property<int>("IdServicio")
                        .HasColumnType("int");

                    b.Property<int>("IdSolicitudCita")
                        .HasColumnType("int");

                    b.Property<string>("Medicacion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Motivo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NoDocumento")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RecetaMedica")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Valoracion")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdConsultaOdontologica");

                    b.HasIndex("IdAntecedentes")
                        .IsUnique();

                    b.HasIndex("IdServicio");

                    b.HasIndex("IdSolicitudCita")
                        .IsUnique();

                    b.HasIndex("NoDocumento");

                    b.ToTable("ConsultasOdontologicas");
                });

            modelBuilder.Entity("Entity.DetalleServicio", b =>
                {
                    b.Property<int>("IdDetalleServicio")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdServicio")
                        .HasColumnType("int");

                    b.Property<string>("ReferenciaProducto")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("UnidadesUsadas")
                        .HasColumnType("int");

                    b.HasKey("IdDetalleServicio");

                    b.HasIndex("IdServicio");

                    b.HasIndex("ReferenciaProducto");

                    b.ToTable("DetallesServicios");
                });

            modelBuilder.Entity("Entity.Odontologo", b =>
                {
                    b.Property<string>("NoDocumento")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Apellidos")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombres")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TipoDocumento")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("NoDocumento");

                    b.ToTable("Odontologos");
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

            modelBuilder.Entity("Entity.Producto", b =>
                {
                    b.Property<string>("Referencia")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Laboratorio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Marca")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StockActual")
                        .HasColumnType("int");

                    b.HasKey("Referencia");

                    b.ToTable("Productos");
                });

            modelBuilder.Entity("Entity.Servicio", b =>
                {
                    b.Property<int>("IdServico")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Duracion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Precio")
                        .HasColumnType("decimal");

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

                    b.Property<string>("NoDocumento")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("IdSolicitudCita");

                    b.HasIndex("CodAgenda")
                        .IsUnique();

                    b.HasIndex("NoDocumento");

                    b.ToTable("Citas");
                });

            modelBuilder.Entity("Entity.User", b =>
                {
                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CorreoElectronico")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Estado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rol")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserName");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Entity.Agenda", b =>
                {
                    b.HasOne("Entity.Odontologo", "Odontologo")
                        .WithMany("Agendas")
                        .HasForeignKey("NoDocumento");

                    b.Navigation("Odontologo");
                });

            modelBuilder.Entity("Entity.ConsultaOdontologica", b =>
                {
                    b.HasOne("Entity.Antecedente", "Antecedente")
                        .WithOne("ConsultaOdontologica")
                        .HasForeignKey("Entity.ConsultaOdontologica", "IdAntecedentes")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entity.Servicio", "Servicio")
                        .WithMany("ConsultasOdontologicas")
                        .HasForeignKey("IdServicio")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entity.SolicitudCita", "SolicitudCita")
                        .WithOne("ConsultaOdontologica")
                        .HasForeignKey("Entity.ConsultaOdontologica", "IdSolicitudCita")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entity.Paciente", "Paciente")
                        .WithMany("ConsultasOdontologicas")
                        .HasForeignKey("NoDocumento");

                    b.Navigation("Antecedente");

                    b.Navigation("Paciente");

                    b.Navigation("Servicio");

                    b.Navigation("SolicitudCita");
                });

            modelBuilder.Entity("Entity.DetalleServicio", b =>
                {
                    b.HasOne("Entity.Servicio", "Servicio")
                        .WithMany("DetallesServicios")
                        .HasForeignKey("IdServicio")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entity.Producto", "Producto")
                        .WithMany("DetalleServicios")
                        .HasForeignKey("ReferenciaProducto");

                    b.Navigation("Producto");

                    b.Navigation("Servicio");
                });

            modelBuilder.Entity("Entity.SolicitudCita", b =>
                {
                    b.HasOne("Entity.Agenda", "Agenda")
                        .WithOne("Cita")
                        .HasForeignKey("Entity.SolicitudCita", "CodAgenda")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entity.Paciente", "Paciente")
                        .WithMany("SolicitudesCitas")
                        .HasForeignKey("NoDocumento");

                    b.Navigation("Agenda");

                    b.Navigation("Paciente");
                });

            modelBuilder.Entity("Entity.Agenda", b =>
                {
                    b.Navigation("Cita");
                });

            modelBuilder.Entity("Entity.Antecedente", b =>
                {
                    b.Navigation("ConsultaOdontologica");
                });

            modelBuilder.Entity("Entity.Odontologo", b =>
                {
                    b.Navigation("Agendas");
                });

            modelBuilder.Entity("Entity.Paciente", b =>
                {
                    b.Navigation("ConsultasOdontologicas");

                    b.Navigation("SolicitudesCitas");
                });

            modelBuilder.Entity("Entity.Producto", b =>
                {
                    b.Navigation("DetalleServicios");
                });

            modelBuilder.Entity("Entity.Servicio", b =>
                {
                    b.Navigation("ConsultasOdontologicas");

                    b.Navigation("DetallesServicios");
                });

            modelBuilder.Entity("Entity.SolicitudCita", b =>
                {
                    b.Navigation("ConsultaOdontologica");
                });
#pragma warning restore 612, 618
        }
    }
}
