﻿using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class SolicitudCitaService
    {
        private readonly DentalTimeContext _context;
        
        public SolicitudCitaService(DentalTimeContext context)
        {
            _context = context;
        }

        public CitaLogResponse Save (SolicitudCita cita)
        {
            try
            {
                if (_context.Citas.Find(cita.IdSolicitudCita) == null)
                {
                    _context.Citas.Add(cita);
                    return new CitaLogResponse(cita);
                }
                return new CitaLogResponse($"La cita ya se encuentra registrado");
            }
            catch (Exception e) { return new CitaLogResponse($"Error al Guardar: Se presento lo siguiente {e.Message}"); }
        }

        public CitaLogResponse Update(SolicitudCita citaNew, int codCita)
        {
            try
            {
                SolicitudCita cita = _context.Citas.Find(codCita);
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
                SolicitudCita cita = _context.Citas.Find(codCita);
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
                SolicitudCita cita = _context.Citas.Find(codCita);
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
                List<SolicitudCita> citas = _context.Citas.ToList();
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
        public SolicitudCita Cita { get; set; }
        public string Mensaje { get; set; }
        public bool Error { get; set; }

        public CitaLogResponse(SolicitudCita cita)
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
        public List<SolicitudCita> Citas { get; set; }
        public string Mensaje { get; set; }
        public bool Error { get; set; }
        public CitaConsultaResponse(List<SolicitudCita> citas)
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