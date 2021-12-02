using Entity;

namespace DentalTime.Models
{
    public class DetallesServicioInputModel
    {        
        public string ReferenciaProducto { get; set; }
        public int IdServicio { get; set; }
        public int UnidadesUsadas { get; set; }
    }

    public class DetallesServicioViewModel:DetallesServicioInputModel
    {
        public int IdDetalleServicio { get; set; }
        public Producto Producto { get; set; }
        public Servicio Servicio { get; set; }

        public DetallesServicioViewModel(DetalleServicio detalleServicio)
        {
            IdDetalleServicio = detalleServicio.IdDetalleServicio;
            ReferenciaProducto = detalleServicio.ReferenciaProducto;
            Producto = detalleServicio.Producto;
            IdServicio = detalleServicio.IdServicio;
            Servicio = detalleServicio.Servicio;
        }
    }
}