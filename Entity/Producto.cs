using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Producto
    {
        [Key]
        public string Referencia { get; set; }
        public string Nombre { get; set; }
        public string Fabricante { get; set; }
        public int UnidadesMin { get; set; }
        public int UnidadesMax { get; set; }
        public int UnidadesActuales { get; set; }
    }
}
