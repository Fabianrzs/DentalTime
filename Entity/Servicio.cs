using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Servicio
    {
        [Key]
        public int IdServico { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public string Duracion { get; set; }

        public ICollection<DetalleServicio> DetallesServicios { get; set; }

        public ICollection<ConsultaOdontologica> ConsultasOdontologicas { get; set; }
    }
}
