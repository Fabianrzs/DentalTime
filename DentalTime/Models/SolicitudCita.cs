using Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DentalTime.Models
{
    public class SolicitudCitaInputModel
    {
               
        [Required(ErrorMessage = "Numero de Documento del Paciente requerido")]
        public string NoDocumento { get; set; }
        public int CodAgenda { get; set; }

    }

    public class SolicitudCitaCitaViewModel : SolicitudCitaInputModel
    {
        public int IdSolicitudCita { get; set; }
        public string Estado { get; set; }
        public DateTime Fecha { get; set; }
        public Paciente Paciente { get; set; }
        public Agenda Agenda { get; set; }
        public SolicitudCitaCitaViewModel(SolicitudCita cita)
        {

            IdSolicitudCita = cita.IdSolicitudCita;
            Estado = cita.Estado;
            Fecha = cita.Fecha;
            Estado = cita.Estado;
            Paciente = cita.Paciente;
            Agenda = cita.Agenda;
            CodAgenda = cita.CodAgenda;
            NoDocumento = cita.NoDocumento;
        }
    }
}
