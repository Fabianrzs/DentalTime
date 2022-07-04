using DAL;
using Entity;
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

        public DentalTimeContext()
        {
                
        }

        public DentalTimeContext(DbContextOptions contextOptions): base(contextOptions)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DKP-FABIAN\\SQLEXPRESS;Database=DBDental;Trusted_Connection = True; MultipleActiveResultSets = true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<ConsultaOdontologica>()
                .HasOne<Paciente>(a => a.Paciente)
                .WithMany(p => p.ConsultasOdontologicas)
                .HasForeignKey(a => a.NoDocumento);
                
            modelBuilder.Entity<Agenda>()
                .HasOne<SolicitudCita>(a => a.Cita)
                .WithOne(s => s.Agenda)
                .HasForeignKey<SolicitudCita>(s => s.CodAgenda);

             modelBuilder.Entity<Agenda>()
                .HasOne<Odontologo>(d => d.Odontologo)
                .WithMany(p => p.Agendas)
                .HasForeignKey(d => d.NoDocumento);    

            modelBuilder.Entity<SolicitudCita>()
                .HasOne<Paciente>(a => a.Paciente)
                .WithMany(p => p.SolicitudesCitas)
                .HasForeignKey(a => a.NoDocumento);

            modelBuilder.Entity<ConsultaOdontologica>()
                .HasOne<Antecedente>(c => c.Antecedente)
                .WithOne(a => a.ConsultaOdontologica)
                .HasForeignKey<ConsultaOdontologica>(c => c.IdAntecedentes);

            modelBuilder.Entity<DetalleServicio>()
                .HasOne<Producto>(d => d.Producto)
                .WithMany(p => p.DetalleServicios)
                .HasForeignKey(d => d.ReferenciaProducto);

            modelBuilder.Entity<DetalleServicio>()
                .HasOne<Servicio>(d => d.Servicio)
                .WithMany(s => s.DetallesServicios)
                .HasForeignKey(d => d.IdServicio);
                
            modelBuilder.Entity<SolicitudCita>()
                .HasOne<ConsultaOdontologica>(s => s.ConsultaOdontologica)
                .WithOne(c => c.SolicitudCita)
                .HasForeignKey<ConsultaOdontologica>(s => s.IdSolicitudCita);

            modelBuilder.Entity<ConsultaOdontologica>()
                .HasOne<Servicio>(c => c.Servicio)
                .WithMany(s => s.ConsultasOdontologicas)
                .HasForeignKey(c => c.IdServicio);
                
        }

        public DbSet<Agenda> Agendas { get; set; }
        public DbSet<Antecedente> Antecedentes { get; set; }
        public DbSet<ConsultaOdontologica> ConsultasOdontologicas { get; set; }
        public DbSet<DetalleServicio> DetallesServicios { get; set; }
        public DbSet<Odontologo> Odontologos { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Servicio> Servicios { get; set; }
        public DbSet<SolicitudCita> Citas { get; set; }
        public DbSet<User> Users { get; set; }

    }
}



        // public DbSet<Antecedente> Antecedentes { get; set; }
        // public DbSet<Producto> Productos { get; set; }
        // public DbSet<SolicitudCita> Citas { get; set; }
        // public DbSet<ConsultaOdontologica> ConsultasOdontologicas { get; set; }
        // public DbSet<HistoriaOdontologica> HistoriasOdontologicas { get; set; }
        
        // public DbSet<Servicio> Servicios { get; set; }
        // public DbSet<Procedimiento> Procedimientos { get; set; }
        // public DbSet<Inventario> Inventarios { get; set; }
        // public DbSet<Agenda> Agendas { get; set; }
        // public DbSet<User> Users { get; set; }



        // modelBuilder.Entity<Paciente>()
            //     .HasOne<HistoriaOdontologica>(p => p.HistorialOdontologico)
            //     .WithOne(ho => ho.Paciente)
            //     .HasForeignKey<HistoriaOdontologica>(ho => ho.NoDocumentoPaciente);

            // modelBuilder.Entity<HistoriaOdontologica>()
            //     .HasOne<Antecedente>(ho => ho.Antecedentes)
            //     .WithOne(a => a.HistoriaOdontologica)
            //     .HasForeignKey<HistoriaOdontologica>(ho => ho.IdAntecedentesOfHO);

            // modelBuilder.Entity<Procedimiento>()
            //     .HasOne<Servicio>(p => p.Servicio)
            //     .WithOne(s => s.Procedimiento)
            //     .HasForeignKey<Procedimiento>(p => p.IdServico);

            // modelBuilder.Entity<SolicitudCita>()
            //    .HasOne<ConsultaOdontologica>(sc => sc.ConsultaOdontologica)
            //    .WithOne(co => co.SolicitudCita)
            //    .HasForeignKey<ConsultaOdontologica>(co => co.IdSolicitudCita);

            // modelBuilder.Entity<Agenda>()
            //     .HasOne<SolicitudCita>(a => a.Cita)
            //     .WithOne(s => s.Agenda)
            //     .HasForeignKey<SolicitudCita>(s => s.CodAgenda);

            // //---------------------------------------------------

            // modelBuilder.Entity<SolicitudCita>()
            //     .HasOne<Paciente>(sc => sc.Paciente)
            //     .WithMany(p => p.HistorialCitas)
            //     .HasForeignKey(sc => sc.NoDocumentoPaciente);

            // modelBuilder.Entity<ConsultaOdontologica>()
            //     .HasOne<HistoriaOdontologica>(co => co.HistoriaOdontologica)
            //     .WithMany(ho => ho.ConsultasOdontologica)
            //     .HasForeignKey(co => co.IdHistoriaOdontologica);

            // modelBuilder.Entity<Procedimiento>()
            //     .HasOne<ConsultaOdontologica>(p => p.ConsultaOdontologica)
            //     .WithMany(co => co.Procedimientos)
            //     .HasForeignKey(p => p.IdConsultaOdontologica);

            // modelBuilder.Entity<Producto>()
            //     .HasOne<Inventario>(p => p.Inventario)
            //     .WithMany(i => i.Productos)
            //     .HasForeignKey(p => p.IdInventario);