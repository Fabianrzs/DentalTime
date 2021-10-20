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
        public DentalTimeContext(DbContextOptions contextOptions): base(contextOptions)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           



        }

        public DbSet<Producto> Productos { get; set; }




        public DbSet<SolicitudCita> Citas { get; set; }
        public DbSet<ConsultaOdontologica> ConsultasClinicas { get; set; }
        public DbSet<HistoriaOdontologica> HistoriasClinicas { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        
        public DbSet<Servicio> Servicios { get; set; }
    }
}
