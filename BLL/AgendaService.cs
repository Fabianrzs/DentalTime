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
    public class AgendaService
    {
        private readonly DentalTimeContext _context;

        public AgendaService(DentalTimeContext context)
        {
            _context = context;
        }

        public AgendaLogResponse Save(Agenda agenda)
        {
            try
            {
                var odonto = _context.Odontologos.Find(agenda.NoDocumento);
                if (odonto != null)
                {
                    agenda.Estado = "DISPONIBLE";
                    _context.Agendas.Add(agenda);
                    _context.SaveChanges();
                    return new AgendaLogResponse(agenda);
                }

                return new AgendaLogResponse($"Error al Guardar: Fecha Ocupada");
            }
            catch (Exception e) { return new AgendaLogResponse($"Error al Guardar: Se presento lo siguiente {e.Message}"); }
        }

        public AgendaConsultaResponse Consult(string noDocumento)
        {
            try
            {
                List<Agenda> agendas = _context.Agendas.Where(a => a.Cita == null && a.NoDocumento.Equals(noDocumento)).Include(a => a.Odontologo).ToList();
                if (agendas != null)
                {
                    return new AgendaConsultaResponse(agendas);
                }
                return new AgendaConsultaResponse($"No se han agregado registros");
            }
            catch (Exception e) { return new AgendaConsultaResponse($"Error al Consultar: Se presento lo siguiente {e.Message}"); }
        }

        public AgendaConsultaResponse FiltroAgenda(DateTime fecha, string noDocumento)
        {
            try
            {
                List<Agenda> agendas = _context.Agendas.Where(a => a.Cita == null && a.NoDocumento.Equals(noDocumento)).Include(a => a.Odontologo).ToList();
                var response = AgendasDelMes(agendas, fecha);
                if (!response.Error)
                {
                    return new AgendaConsultaResponse(response.Agendas);
                }
                return new AgendaConsultaResponse(response.Mensaje);
            }
            catch (Exception e) { return new AgendaConsultaResponse($"Error al Consultar: Se presento lo siguiente {e.Message}"); }
        }
        private AgendaConsultaResponse AgendasDelMes(ICollection<Agenda> agendas, DateTime fecha)
        {
            try
            {
                var lista = new List<Agenda>();
                foreach (var item in agendas)
                {
                    if (fecha.ToString("MM/dd/yyyy") == item.FechaInicio.ToString("MM/dd/yyyy"))
                    {
                        lista.Add(item);
                    }
                }
                if (lista.Count()>0)
                {
                    return new AgendaConsultaResponse(lista);
                }
                return new AgendaConsultaResponse("No se encontro ninguna agenda en la fehca establecida");
            }
            catch (Exception e)
            {

                return new AgendaConsultaResponse("Ocurrio el siguiente error: "+e.Message);
            }
        }
    }



    public class AgendaLogResponse
    {
        public Agenda Agenda { get; set; }
        public string Mensaje { get; set; }
        public bool Error { get; set; }

        public AgendaLogResponse(Agenda agenda)
        {
            Agenda = agenda;
            Error = false;
        }

        public AgendaLogResponse(string mensaje)
        {
            Mensaje = mensaje;
            Error = true;
        }
    }

    public class AgendaConsultaResponse
    {
        public List<Agenda> Agendas { get; set; }
        public string Mensaje { get; set; }
        public bool Error { get; set; }
        public AgendaConsultaResponse(List<Agenda> agendas)
        {
            Agendas = agendas;
            Error = false;
        }
        public AgendaConsultaResponse(string mensaje)
        {
            Mensaje = mensaje;
            Error = true;
        }
    }
}
