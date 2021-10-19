﻿using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PacienteService
    {
        private readonly DentalTimeContext _context;

        public PacienteService(DentalTimeContext context)
        {
            _context = context;
        }

        public PacienteLogResponse Save(Paciente paciente)
        {
            try
            {
                var buscarPaciente = _context.Pacientes.Find(paciente.NoDocumento);
                if (buscarPaciente != null)
                {
                    return new PacienteLogResponse("Error el paciente ya se encuentra registrado");
                }
                _context.Pacientes.Add(paciente);
                _context.SaveChanges();
                return new PacienteLogResponse(paciente);
            }
            catch (Exception e)
            {
                return new PacienteLogResponse("Error en la aplicacion"+e.Message);
            }
        }

        public PacienteLogResponse Find (string documento)
        {
            try
            {
                var buscarPaciente = _context.Pacientes.Find(documento);
                if (buscarPaciente != null)
                {
                    return new PacienteLogResponse(buscarPaciente);
                }
                return new PacienteLogResponse("Error el paciente no se encuentra registrado");
            }
            catch (Exception e)
            {
                return new PacienteLogResponse("Error en la aplicacion" + e.Message);
            }
        }

        public PacienteConsultaResponse Consult()
        {
            try
            {
                List<Paciente> pacientes = _context.Pacientes.ToList();
                if (pacientes != null)
                {
                    return new PacienteConsultaResponse(pacientes);
                }
                return new PacienteConsultaResponse($"No se han agregado registros");
            }
            catch (Exception e) { return new PacienteConsultaResponse($"Error al Consultar: Se presento lo siguiente {e.Message}"); }
        }
    }

    public class PacienteLogResponse
    {
        public Paciente Paciente { get; set; }
        public string Mensaje { get; set; }
        public bool Error { get; set; }


        public PacienteLogResponse(string mensaje)
        {
            Mensaje = mensaje;
            Error = true;
        }

        public PacienteLogResponse(Paciente paciente)
        {
            Paciente = paciente;
            Error = false;
        }

    }
    public class PacienteConsultaResponse
    {
        public List<Paciente> Pacientes { get; set; }
        public string Mensaje { get; set; }
        public bool Error { get; set; }


        public PacienteConsultaResponse(string mensaje)
        {
            Mensaje = mensaje;
            Error = true;
        }

        public PacienteConsultaResponse(List<Paciente> pacientes)
        {
            Pacientes = pacientes;
            Error = false;
        }

    }
}
