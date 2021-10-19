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
                _context.Agendas.Add(agenda);
                return new AgendaLogResponse(agenda);
            }
            catch (Exception e) { return new AgendaLogResponse($"Error al Guardar: Se presento lo siguiente {e.Message}"); }
        }
        public AgendaLogResponse Update(Agenda AgendaNew, string codAgenda)
        {
            try
            {
                Agenda agenda = _context.Agendas.Find(codAgenda);
                if (agenda != null)
                {
                    agenda = AgendaNew;
                    _context.Agendas.Update(agenda);
                    return new AgendaLogResponse(agenda);
                }
                return new AgendaLogResponse($"No se encuentra registro a modificar");
            }
            catch (Exception e) { return new AgendaLogResponse($"Error al Modificar: Se presento lo siguiente {e.Message}"); }
        }

        public AgendaLogResponse Find(string codAgenda)
        {
            try
            {
                Agenda agenda = _context.Agendas.Find(codAgenda);
                if (agenda != null)
                {
                    return new AgendaLogResponse(agenda);
                }
                return new AgendaLogResponse($"No se encuentra el registro buscado");
            }
            catch (Exception e) { return new AgendaLogResponse($"Error al Buscar: Se presento lo siguiente {e.Message}"); }
        }

        public string Delete(string codAgenda)
        {
            try
            {
                Agenda agenda = _context.Agendas.Find(codAgenda);
                if (agenda != null)
                {
                    _context.Agendas.Remove(agenda);
                    return "Registro eliminado satisfactoriamente";
                }
                return ($"No se encuentra el registro a eliminar");
            }
            catch (Exception e) { return ($"Error al Eliminar: Se presento lo siguiente {e.Message}"); }
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
