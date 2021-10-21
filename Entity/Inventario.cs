using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Inventario
    {
        [Key]
        public string IdInventario { get; set; }
        

        public ICollection<Producto> Productos { get; set; }
    }
}
