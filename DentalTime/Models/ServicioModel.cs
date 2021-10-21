using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentalTime.Models
{
    public class ServicioInputModel
    {
        public string Referencia { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public string Duracion { get; set; }
        public string Descripcion { get; set; }
    }

    public class ServicioViewModel : ServicioInputModel
    {
        public ServicioViewModel(Servicio servicio)
        {

            Nombre = servicio.Nombre;
            Precio = servicio.Precio;
            Duracion = servicio.Duracion;

        }
    }
}
