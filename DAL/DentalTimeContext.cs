﻿using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DentalTimeContext:DbContext
    {
        public DentalTimeContext(DbContextOptions contextOptions): base(contextOptions)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Paciente>()
                .HasOne<HistoriaOdontologica>(p => p.HistorialOdontologico)
                .WithOne(ho => ho.Paciente)
                .HasForeignKey<HistoriaOdontologica>(ho => ho.NoDocumentoPaciente);

            modelBuilder.Entity<HistoriaOdontologica>()
                .HasOne<Antecedentes>(ho => ho.Antecedentes)
                .WithOne(a => a.HistoriaOdontologica)
                .HasForeignKey<HistoriaOdontologica>(ho => ho.IdAntecedentesOfHO);

            modelBuilder.Entity<SolicitudCita>()
                .HasOne<Paciente>(sc => sc.Paciente)
                .WithMany(p => p.HistorialCitas)
                .HasForeignKey(sc => sc.NoDocumentoPaciente);

            modelBuilder.Entity<SolicitudCita>()
                .HasOne<ConsultaOdontologica>(sc => sc.ConsultaOdontologica)
                .WithOne(co => co.SolicitudCita)
                .HasForeignKey<ConsultaOdontologica>(co => co.IdSolicitudCita);

            modelBuilder.Entity<ConsultaOdontologica>()
                .HasOne<HistoriaOdontologica>(co => co.HistoriaOdontologica)
                .WithMany(ho => ho.ConsultasOdontologica)
                .HasForeignKey(co => co.IdHistoriaOdontologica);

            modelBuilder.Entity<Procedimiento>()
                .HasOne<ConsultaOdontologica>(p => p.ConsultaOdontologica)
                .WithMany(co => co.Procedimientos)
                .HasForeignKey(p => p.IdConsultaOdontologica);

            modelBuilder.Entity<Procedimiento>()
                .HasOne<Servicio>(p => p.Servicio)
                .WithOne(s => s.Procedimiento)
                .HasForeignKey<Procedimiento>(p => p.IdServico);

            modelBuilder.Entity<Producto>()
                .HasOne<Inventario>(p => p.Inventario)
                .WithMany(i => i.Productos)
                .HasForeignKey(p => p.IdInventario);
        }

        public DbSet<Producto> Productos { get; set; }
        public DbSet<SolicitudCita> Citas { get; set; }
        public DbSet<ConsultaOdontologica> ConsultasOdontologicas { get; set; }
        public DbSet<HistoriaOdontologica> HistoriasOdontologicas { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Servicio> Servicios { get; set; }
        public DbSet<Procedimiento> Procedimientos { get; set; }
        public DbSet<Inventario> Inventarios { get; set; }
    }
}
