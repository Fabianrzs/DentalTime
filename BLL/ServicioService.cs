using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ServicioService
    {
        private readonly DentalTimeContext _context;
        public ServicioService(DentalTimeContext context)
        {
            _context = context;
        }

        public ServicioLogResponse Save(Servicio servicio)
        {
            try
            {
                if (_context.Servicios.Find(servicio.IdServico) == null)
                {
                    _context.Servicios.Add(servicio);
                    _context.SaveChanges();
                    return new ServicioLogResponse(servicio);
                }
                return new ServicioLogResponse($"El producto ya se encuentra registrado");
            }
            catch (Exception e) { return new ServicioLogResponse($"Error al Guardar: Se presento lo siguiente {e.Message}"); }
        }

        public ServicioLogResponse Update(Servicio servicioNew, string referencia)
        {
            try
            {
                Servicio servicio = _context.Servicios.Find(referencia);
                if (servicio != null)
                {
                    servicio = servicioNew;
                    _context.Servicios.Update(servicio);
                    _context.SaveChanges();
                    return new ServicioLogResponse(servicio);
                }
                return new ServicioLogResponse($"No se encuentra registro a modificar");
            }
            catch (Exception e) { return new ServicioLogResponse($"Error al Modificar: Se presento lo siguiente {e.Message}"); }
        }

        public ServicioLogResponse Find(string referencia)
        {
            try
            {
                Servicio servicio = _context.Servicios.Find(referencia);
                if (servicio != null)
                {
                    return new ServicioLogResponse(servicio);
                }
                return new ServicioLogResponse($"No se encuentra el registro buscado");
            }
            catch (Exception e) { return new ServicioLogResponse($"Error al Buscar: Se presento lo siguiente {e.Message}"); }
        }

        public string Delete(string referencia)
        {
            try
            {
                Servicio servicio = _context.Servicios.Find(referencia);
                if (servicio != null)
                {
                    _context.Servicios.Remove(servicio);
                    return "Registro eliminado satisfactoriamente";
                }
                return ($"No se encuentra el registro a eliminar");
            }
            catch (Exception e) { return ($"Error al Eliminar: Se presento lo siguiente {e.Message}"); }
        }

        public ServicioConsultaResponse Consult()
        {
            try
            {
                List<Servicio> servicios = _context.Servicios.ToList();
                if (servicios != null)
                {
                    return new ServicioConsultaResponse(servicios);
                }
                return new ServicioConsultaResponse($"No se han agregado registros");
            }
            catch (Exception e) { return new ServicioConsultaResponse($"Error al Consultar: Se presento lo siguiente {e.Message}"); }
        }
    }

    public class ServicioLogResponse
    {
        public Servicio Servicio { get; set; }
        public string Mensaje { get; set; }
        public bool Error { get; set; }

        public ServicioLogResponse(Servicio servicio)
        {
            Servicio = servicio;
            Error = false;
        }

        public ServicioLogResponse(string mensaje)
        {
            Mensaje = mensaje;
            Error = true;
        }
    }

    public class ServicioConsultaResponse
    {
        public List<Servicio> Servicios { get; set; }
        public string Mensaje { get; set; }
        public bool Error { get; set; }
        public ServicioConsultaResponse(List<Servicio> servicios)
        {
            Servicios = servicios;
            Error = false;
        }
        public ServicioConsultaResponse(string mensaje)
        {
            Mensaje = mensaje;
            Error = true;
        }
    }
}
