using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Entity
{
    public class DetalleServicio
    {
        [Key]
        public int IdDetalleServicio { get; set; }
        
        public string ReferenciaProducto { get; set; }
        public Producto Producto { get; set; }

        public int IdServicio { get; set; }
        public Servicio Servicio { get; set; }

        public int UnidadesUsadas { get; set; }
    }
}