using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class CitaService
    {
        private readonly DentalTimeContext _context;
        
        public CitaService(DentalTimeContext context)
        {
            _context = context;
        }

        public CitaLogResponse Save(Cita cita)
        {
            try
            {
                if (_context.Citas.Find(cita.CodCita) == null)
                {
                    _context.Citas.Add(cita);
                    return new CitaLogResponse(cita);
                }
                return new CitaLogResponse($"La cita ya se encuentra registrado");
            }
            catch (Exception e) { return new CitaLogResponse($"Error al Guardar: Se presento lo siguiente {e.Message}"); }
        }

        public CitaLogResponse Update(Cita citaNew, int codCita)
        {
            try
            {
                Cita cita = _context.Citas.Find(codCita);
                if (cita != null)
                {
                    cita = citaNew;
                    _context.Citas.Update(cita);
                    return new CitaLogResponse(cita);
                }
                return new CitaLogResponse($"No se encuentra registro a modificar");
            }
            catch (Exception e) { return new CitaLogResponse($"Error al Modificar: Se presento lo siguiente {e.Message}"); }
        }

        public CitaLogResponse Find(int codCita)
        {
            try
            {
                Cita cita = _context.Citas.Find(codCita);
                if (cita != null)
                {
                    return new CitaLogResponse(cita);
                }
                return new CitaLogResponse($"No se encuentra el registro buscado");
            }
            catch (Exception e) { return new CitaLogResponse($"Error al Buscar: Se presento lo siguiente {e.Message}"); }
        }

        public string Delete(int codCita)
        {
            try
            {
                Cita cita = _context.Citas.Find(codCita);
                if (cita != null)
                {
                    _context.Citas.Remove(cita);
                    return "Registro eliminado satisfactoriamente";
                }
                return ($"No se encuentra el registro a eliminar");
            }
            catch (Exception e) { return ($"Error al Eliminar: Se presento lo siguiente {e.Message}"); }
        }

        public CitaConsultaResponse Consult()
        {
            try
            {
                List<Cita> citas = _context.Citas.ToList();
                if (citas != null)
                {
                    return new CitaConsultaResponse(citas);
                }
                return new CitaConsultaResponse($"No se han agregado registros");
            }
            catch (Exception e) { return new CitaConsultaResponse($"Error al Consultar: Se presento lo siguiente {e.Message}"); }
        }
    }

    public class CitaLogResponse
    {
        public Cita Cita { get; set; }
        public string Mensaje { get; set; }
        public bool Error { get; set; }

        public CitaLogResponse(Cita cita)
        {
            Cita = cita;
            Error = false;
        }

        public CitaLogResponse(string mensaje)
        {
            Mensaje = mensaje;
            Error = true;
        }
    }

    public class CitaConsultaResponse
    {
        public List<Cita> Citas { get; set; }
        public string Mensaje { get; set; }
        public bool Error { get; set; }
        public CitaConsultaResponse(List<Cita> citas)
        {
            Citas = citas;
            Error = false;
        }
        public CitaConsultaResponse(string mensaje)
        {
            Mensaje = mensaje;
            Error = true;
        }
    }
}
