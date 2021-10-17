using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Cita
    {
        [Key]
        public int CodCita { get; set; }
        public DateTime FechaHora { get; set; }
        public string Motivo { get; set; }


        public int CodAgenda { get; set; }
        public Agenda Agenda { get; set; }

        public string NoDocumento { get; set; }
        public Paciente Paciente { get; set; }


        public int Referencia { get; set; }
        public Servicio Servicio { get; set; }
    }
}
