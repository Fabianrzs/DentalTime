﻿using DAL;
using Entity;
using Microsoft.EntityFrameworkCore;
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

        public HistorialLogResponse Save(HistoriaOdontologica historia)
        {
            try
            {
                Paciente paciente = _context.Pacientes.Find(historia.NoDocumentoPaciente);
                if (paciente != null)   
                {
                    if(_context.HistoriasOdontologicas.Find(historia.IdHistoriaOdontologica) == null)
                    {
                        historia.Paciente = paciente;
                        _context.Antecedentes.Add(historia.Antecedentes);
                        _context.HistoriasOdontologicas.Add(historia);
                        _context.SaveChanges();

                        return new HistorialLogResponse(historia);

                    } else return new HistorialLogResponse($"Error al Guardar: El paciente ya ha iniciado una historia odontologica");
                }
                else return new HistorialLogResponse($"Error al Guardar: El paciente no se encuentra registrado");
 
            }
            catch (Exception e) {return new HistorialLogResponse($"Error al Guardar: Se presento lo siguiente {e.Message}");}
        }

        public HistorialConsultaResponse Consult()
        {
            try
            {
                List<HistoriaOdontologica> historiasClinicas = _context.HistoriasOdontologicas.Include(h => h.Antecedentes).Include(h=> h.Paciente).ToList();
                if (historiasClinicas != null)
                {
                    return new HistorialConsultaResponse(historiasClinicas);
                }
                return new HistorialConsultaResponse($"No se han agregado registros");
            }
            catch (Exception e) { return new HistorialConsultaResponse($"Error al Consultar: Se presento lo siguiente {e.Message}"); }
        }


        public HistorialLogResponse Find(string id){
            try
            {    var historia = _context.HistoriasOdontologicas.Where(h => h.IdHistoriaOdontologica == id).Include(h => h.Antecedentes).Include(h=> h.Paciente).FirstOrDefault();
                historia.Antecedentes.HistoriaOdontologica = historia;

                return new HistorialLogResponse(historia);
            }
            catch (Exception e)
            {
                return new HistorialLogResponse("Error en la aplicacion" + e.Message);
            }
        }

    }
    public class HistorialLogResponse
    {
        public HistoriaOdontologica HistoriaClinica { get; set; }
        public string Mensaje { get; set; }
        public bool Error { get; set; }

        public HistorialLogResponse(HistoriaOdontologica historiaClinica)
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
        public List<HistoriaOdontologica> HistoriasClinicas { get; set; }
        public string Mensaje { get; set; }
        public bool Error { get; set; }

        public HistorialConsultaResponse(List<HistoriaOdontologica> historiasClinicas)
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
