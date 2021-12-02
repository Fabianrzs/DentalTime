using Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DentalTime.Models
{
    public class AgendaInputModel
    {
        [Required(ErrorMessage = "Estado requerido")]
        public string Estado { get; set; }
        [Required(ErrorMessage = "Fecha de inicio requerido")]
        public DateTime FechaHoraInicio { get; set; }
        [Required(ErrorMessage = "Fecha de fin requerido")]
        public DateTime FechaHoraFin { get; set; }
    }
    public class AgendaViewModel : AgendaInputModel
    {
        public int CodAgenda { get; set; }

        public AgendaViewModel(Agenda agenda)
        {
            CodAgenda = agenda.CodAgenda;
            Estado = agenda.Estado;
            FechaHoraInicio = agenda.FechaInicio;
            FechaHoraFin = agenda.FechaFin;
        }

    }
}
