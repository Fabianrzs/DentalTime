using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class SolicitudCita
    {

        [Key]
        public int IdSolicitudCita { get; set; }
        public DateTime Fecha { get; set; }
        public string Estado { get; set; }

        public ConsultaOdontologica ConsultaOdontologica { get; set; }

        public string NoDocumentoPaciente { get; set; }
        public Paciente Paciente { get; set; }
        
        public int CodAgenda { get; set; }
        public Agenda Agenda { get; set; }
    }
}
