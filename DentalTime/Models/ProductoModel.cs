using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentalTime.Models
{
    public class ProductoInputModel
    {
        public string Referencia { get; set; }
        public string Nombre { get; set; }
        public string Marca { get; set; }
        public string Categoria { get; set; }
        public string Descripcion { get; set; }
        public int StockMin { get; set; }
        public int StockMax { get; set; }
        public int StockActual { get; set; }
    }

    public class ProductoViewModel : ProductoInputModel
    {
        public ProductoViewModel(Producto producto)
        {
            Referencia = producto.Referencia;
            Nombre = producto.Nombre;
            Marca = producto.Marca;
            Categoria = producto.Categoria;
            Descripcion = producto.Descripcion;
            StockMin = producto.StockMin;
            StockMax = producto.StockMax;
            StockActual = producto.StockActual;
        }
    }
}
