using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Agenda
    {
        [Key]
        public int CodAgenda { get; set; }
        public string Estado { get; set; }
        public DateTime FechaHoraInicio { get; set; }
        public DateTime FechaHoraFin { get; set; }


        public SolicitudCita Cita { get; set; }
    }
}
