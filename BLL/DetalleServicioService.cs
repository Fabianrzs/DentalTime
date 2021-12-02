using DAL;
using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class DetalleServicioService
    {
        private readonly DentalTimeContext _context;

        public DetalleServicioService(DentalTimeContext context)
        {
            _context = context;
        }

        public DetallesServicioResponse Save (DetalleServicio detalleServicio)
        {
            try
            {
                Servicio servicio = _context.Servicios.Find(detalleServicio.IdServicio);
                Producto producto = _context.Productos.Find(detalleServicio.ReferenciaProducto);

                if (servicio != null & producto != null)
                {
                    _context.DetallesServicios.Add(detalleServicio);
                    _context.SaveChanges();
                    return new DetallesServicioResponse(detalleServicio);
                }
                return new DetallesServicioResponse("Productos y Servicios no disponibles");
            }
            catch (Exception e)
            {
                return new DetallesServicioResponse("Error de la aplicación: "+e.Message);
            }
        }

        public DetallesServiciosResponse Consult()
        {
            try
            {
                List<DetalleServicio> detallesServicio = _context.DetallesServicios.Include(d => d.Producto).ToList();
                if (detallesServicio != null)
                {
                    return new DetallesServiciosResponse (detallesServicio);
                }
                return new DetallesServiciosResponse ($"No se han agregado registros");
            }
            catch (Exception e)
            {
                return new DetallesServiciosResponse ("Error de la aplicación: " + e.Message);
            }
        }
    }

    public class DetallesServicioResponse
    {
        public DetalleServicio DetalleServicio { get; set; }
        public string Mensaje { get; set; }
        public bool Error { get; set; }

        public DetallesServicioResponse(string mensaje)
        {
            Mensaje = mensaje;
            Error = true;
        }

        public DetallesServicioResponse(DetalleServicio detalleServicio)
        {
            DetalleServicio = detalleServicio;
            Error = false;
        }
    }

    public class DetallesServiciosResponse
    {
        public List<DetalleServicio> DetalleServicios{ get; set; }
        public string Mensaje { get; set; }
        public bool Error { get; set; }

        public DetallesServiciosResponse(string mensaje)
        {
            Mensaje = mensaje;
            Error = true;
        }

        public DetallesServiciosResponse(List<DetalleServicio> detalleServicios)
        {
            DetalleServicios = detalleServicios;
            Error = false;
        }
    }
}
