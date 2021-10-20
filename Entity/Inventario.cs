using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Inventario
    {
        public string IdInventario { get; set; }
        public int StockActual { get; set; }

        public ICollection<Producto> Productos { get; set; }
    }
}
