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

        public AgendaLogResponse Save(Agenda agenda)
        {
            try
            {
                if(_context.Agendas.FirstOrDefault(a => a.FechaFin == agenda.FechaFin || a.FechaInicio == agenda.FechaInicio) == null){
                    _context.Agendas.Add(agenda);
                    _context.SaveChanges();
                    return new AgendaLogResponse(agenda);
                }

                return new AgendaLogResponse($"Error al Guardar: Fecha Ocupada"); 
            }
            catch (Exception e) { return new AgendaLogResponse($"Error al Guardar: Se presento lo siguiente {e.Message}"); }
        }

        public AgendaConsultaResponse Consult()
        {
            try
            {
                List<Agenda> agendas = _context.Agendas.ToList();
                if (agendas != null)
                {
                    return new AgendaConsultaResponse(agendas);
                }
                return new AgendaConsultaResponse($"No se han agregado registros");
            }
            catch (Exception e) { return new AgendaConsultaResponse($"Error al Consultar: Se presento lo siguiente {e.Message}"); }
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
