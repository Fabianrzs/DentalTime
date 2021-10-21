using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentalTime.Models
{
    public class InventarioInputModel
    {
        public string IdInventario { get; set; }
    }
    public class InventarioViewModel:InventarioInputModel
    {
        public InventarioViewModel(Inventario inventario)
        {
            IdInventario = inventario.IdInventario;
        }
    }
}
