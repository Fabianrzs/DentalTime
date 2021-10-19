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
            modelBuilder.Entity<Cita>()
                .HasOne<Servicio>(c => c.Servicio)
                .WithMany(s => s.Citas)
                .HasForeignKey(c => c.ReferenciaServicioOfCita);

            modelBuilder.Entity<Cita>()
                .HasOne<Agenda>(c => c.Agenda)
                .WithMany(a => a.Citas)
                .HasForeignKey(c => c.CodAgendaOfCita);

            modelBuilder.Entity<Cita>()
                .HasOne<Paciente>(c => c.Paciente)
                .WithMany(p => p.HistorialCita)
                .HasForeignKey(c => c.NoDocumentoOfCita);



        }

        public DbSet<Agenda> Agendas { get; set; }
        public DbSet<Cita> Citas { get; set; }
        public DbSet<ConsultaClinica> ConsultasClinicas { get; set; }
        public DbSet<HistoriaClinica> HistoriasClinicas { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Servicio> Servicios { get; set; }
    }
}
