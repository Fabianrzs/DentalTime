﻿using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class HistorialClinicoService
    {
        private readonly DentalTimeContext _context;

        public HistorialClinicoService(DentalTimeContext context)
        {
            _context = context;
        }

        public HistorialLogResponse Save(HistoriaClinica historia)
        {
            try
            {
                /*Paciente paciente = _context.Pacientes.Find(historia.NoDocumentoOfHistoria);
                ConsultaClinica consulta = _context.ConsultasClinicas.OrderByDescending(c => c.CodConsultaClinica).FirstOrDefault();

                if (paciente == null)
                {
                    return new HistorialLogResponse($"Error al Guardar: El paciente no se encuentra registrado");
                }
                else if (consulta == null)
                {
                    return new HistorialLogResponse($"Error al Guardar: El paciente no se encuentro consulta asociada");
                }
                historia.Paciente = paciente;
                historia.ConsultaClinica = consulta;*/

                _context.HistoriasClinicas.Add(historia);
                _context.SaveChanges();
                return new HistorialLogResponse(historia);
            }
            catch (Exception e) 
            { 
                return new HistorialLogResponse($"Error al Guardar: Se presento lo siguiente {e.Message}"); 
            }
        }

        public HistorialConsultaResponse Consult()
        {
            try
            {
                List<HistoriaClinica> historiasClinicas = _context.HistoriasClinicas.ToList();
                if (historiasClinicas != null)
                {
                    return new HistorialConsultaResponse(historiasClinicas);
                }
                return new HistorialConsultaResponse($"No se han agregado registros");
            }
            catch (Exception e) { return new HistorialConsultaResponse($"Error al Consultar: Se presento lo siguiente {e.Message}"); }
        }

    }
    public class HistorialLogResponse
    {
        public HistoriaClinica HistoriaClinica { get; set; }
        public string Mensaje { get; set; }
        public bool Error { get; set; }

        public HistorialLogResponse(HistoriaClinica historiaClinica)
        {
            HistoriaClinica = historiaClinica;
            Error = false;
        }

        public HistorialLogResponse(string mensaje)
        {
            Mensaje = mensaje;
            Error = true;
        }

    }
    public class HistorialConsultaResponse
    {
        public List<HistoriaClinica> HistoriasClinicas { get; set; }
        public string Mensaje { get; set; }
        public bool Error { get; set; }

        public HistorialConsultaResponse(List<HistoriaClinica> historiasClinicas)
        {
            HistoriasClinicas = historiasClinicas;
            Error = false;
        }

        public HistorialConsultaResponse(string mensaje)
        {
            Mensaje = mensaje;
            Error = true;
        }

    }
}
