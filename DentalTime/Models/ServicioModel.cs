using Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DentalTime.Models
{
    public class ServicioInputModel
    {
        [Required(ErrorMessage = "Nombre requerido")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Precio requerido")]
        public decimal Precio { get; set; }
        [Required(ErrorMessage = "Duracion requerida")]
        public string Duracion { get; set; }

        public class ServicioViewModel : ServicioInputModel
        {
            public ICollection<DetalleServicio> DetallesServicios { get; set; }
            public ServicioViewModel(Servicio servicio)
            {
                Nombre = servicio.Nombre;
                Precio = servicio.Precio;
                Duracion = servicio.Duracion;
                DetallesServicios = servicio.DetallesServicios;
            }
        }
    }
}
