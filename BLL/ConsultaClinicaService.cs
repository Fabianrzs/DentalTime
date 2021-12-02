﻿using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace BLL
{
    public class ConsultaClinicaService
    {

        private readonly DentalTimeContext _context;

        public ConsultaClinicaService(DentalTimeContext context)
        {
            _context = context;
        }

        public ConsultaClinicaLogResponse Save(ConsultaOdontologica consultaClinica)
        {
            try
            {
                
                if(_context.Pacientes.Find(consultaClinica.NoDocumento) != null )
                    if (_context.Citas.Find(consultaClinica.IdSolicitudCita) != null){
                        if(_context.Servicios.Find(consultaClinica.IdServicio) != null){
                            
                        }
                    }
                _context.ConsultasOdontologicas.Add(consultaClinica);
                _context.SaveChanges();
                return new ConsultaClinicaLogResponse(consultaClinica);
            }
            catch (Exception e)
            {
                return new ConsultaClinicaLogResponse($"Error al Guardar: Se presento lo siguiente {e.Message}");
            }
        }

        public ConsultaClinicaLogResponse Find()
        {
            try
            {
                ConsultaOdontologica consulta = null;
                
                /* _context.ConsultasOdontologicas.OrderByDescending(c => c.ConsultaOdontologica).FirstOrDefault();*/

                if (consulta == null)
                {
                    return new ConsultaClinicaLogResponse($"Error al buscar: consulta no asociada");
                }
                return new ConsultaClinicaLogResponse(consulta);
            }
            catch (Exception e)
            {
                return new ConsultaClinicaLogResponse($"Error al Buscar: Se presento lo siguiente {e.Message}");
            }

        }

        public ConsultaClinicaConsultaResponse Consult(string id)
        {
            try
            {

                //List<ConsultaOdontologica> consultas = _context.ConsultasOdontologicas.Where(c => c.IdHistoriaOdontologica == id).Include(c => c.SolicitudCita).ToList();
                //if (consultas != null)
                //{
                //    return new ConsultaClinicaConsultaResponse(consultas);
                //}
                return new ConsultaClinicaConsultaResponse($"No se han agregado registros");
            }
            catch (Exception e) { return new ConsultaClinicaConsultaResponse($"Error al Consultar: Se presento lo siguiente {e.Message}"); }
        }

    }

    public class ConsultaClinicaLogResponse
    {
        public ConsultaOdontologica ConsultaClinica { get; set; }
        public string Mensaje { get; set; }
        public bool Error { get; set; }

        public ConsultaClinicaLogResponse(ConsultaOdontologica consultaClinica)
        {
            ConsultaClinica = consultaClinica;
            Error = false;
        }

        public ConsultaClinicaLogResponse(string mensaje)
        {
            Mensaje = mensaje;
            Error = true;
        }

    }

    public class ConsultaClinicaConsultaResponse
    {
        public List<ConsultaOdontologica> ConsultaClinicas { get; set; }
        public string Mensaje { get; set; }
        public bool Error { get; set; }

        public ConsultaClinicaConsultaResponse(List<ConsultaOdontologica> consultaClinica)
        {
            ConsultaClinicas = consultaClinica;
            Error = false;
        }

        public ConsultaClinicaConsultaResponse(string mensaje)
        {
            Mensaje = mensaje;
            Error = true;
        }

    }
}
