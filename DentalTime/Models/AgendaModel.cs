using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentalTime.Models
{
    public class AgendaInputModel
    {
        public string Estado { get; set; }
        public DateTime FechaHoraInicio { get; set; }
        public DateTime FechaHoraFin { get; set; }
    }
    public class AgendaViewModel : AgendaInputModel
    {
        public int CodAgenda { get; set; }

        public AgendaViewModel(Agenda agenda)
        {
            CodAgenda = agenda.CodAgenda;
            Estado = agenda.Estado;
            FechaHoraInicio = agenda.FechaHoraInicio;
            FechaHoraFin = agenda.FechaHoraFin;
        }

    }
}
