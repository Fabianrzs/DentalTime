using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace DentalTime.Models
{
    public class ProductoInputModel
    {
        [Required(ErrorMessage = "Referencia requerido")]
        public string Referencia { get; set; }
        [Required(ErrorMessage = "Nombre requerido")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Laboratorio requerido")]
        public string Laboratorio { get; set; }
        [Required(ErrorMessage = "Marca requerido")]
        public string Marca { get; set; }
        [Required(ErrorMessage = "StockMin requerido")]
        public int StockActual { get; set; }

    }

    public class ProductoViewModel : ProductoInputModel
    {
        public ProductoViewModel(Producto producto)
        {
            Referencia = producto.Referencia;
            Nombre = producto.Nombre;
            Laboratorio = producto.Laboratorio;
            Marca = producto.Marca;
            StockActual = producto.StockActual;
            
        }
    }
}
