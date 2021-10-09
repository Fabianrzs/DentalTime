using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Producto
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Laboratorio { get; set; }
        public int UnidadesCompradas { get; set; }
        public decimal ValorCompra { get; set; }
    }
}
