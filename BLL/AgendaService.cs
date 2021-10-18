using DAL;
using Entity;
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

        public LogAgendaResponse Guardar(Agenda agenda)
        {
            try
            {
                _context.Agendas.Add(agenda);
                return new LogAgendaResponse(agenda);
            }
            catch (Exception e) { return new LogAgendaResponse($"Error al Guardar: Se presento lo siguiente {e.Message}"); }
        }
    }

    public class LogAgendaResponse
    {
        public Agenda Agenda { get; set; }
        public string Mensaje { get; set; }
        public bool Error { get; set; }
        public LogAgendaResponse(Agenda agenda)
        {
            Agenda = agenda;
            Error = false;
        }

        public LogAgendaResponse(string mensaje)
        {
            Mensaje = mensaje;
            Error = true;
        }
    }

    public class ConsultaAgendaResponse
    {
        public List<Agenda> Agendas { get; set; }
        public string Mensaje { get; set; }
        public bool Error { get; set; }
        public ConsultaAgendaResponse(List<Agenda> agendas)
        {
            Agendas = agendas;
            Error = false;
        }

        public ConsultaAgendaResponse(string mensaje)
        {
            Mensaje = mensaje;
            Error = true;
        }
    }
}
