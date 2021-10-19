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
        public string Motivo { get; set; }



        public string NoDocumentoOfCita { get; set; }
        public Paciente Paciente { get; set; }



        public int CodAgendaOfCita { get; set; }
        public Agenda Agenda { get; set; }



        public string ReferenciaServicioOfCita { get; set; }
        public Servicio Servicio { get; set; }

    }
}
