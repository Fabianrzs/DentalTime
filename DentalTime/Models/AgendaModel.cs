using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentalTime.Models
{
    public class AgendaInputModel
    {
        public DateTime FechaHora { get; set; }
        public string Estado { get; set; }

    }

    public class AgendaViewModel : AgendaInputModel
    {
        public int CodAgenda { get; set; }
        public AgendaViewModel()
        {
        }
    }
}
