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
        [Required(ErrorMessage = "Fecha requerida")]
        public DateTime Fecha { get; set; }
        [Required(ErrorMessage = "Estado requerido")]
        public string Estado { get; set; }
        [Required(ErrorMessage = "Numero de Documento del Paciente requerido")]
        public string NoDocumentoPaciente { get; set; }
    }

    public class SolicitudCitaCitaViewModel : SolicitudCitaInputModel
    {
        public int IdSolicitudCita { get; set; }
        public SolicitudCitaCitaViewModel(SolicitudCita cita)
        {
            IdSolicitudCita = cita.IdSolicitudCita;
            Fecha = cita.Fecha;
            Estado = cita.Estado;
            NoDocumentoPaciente = cita.NoDocumentoPaciente;
        }
    }
}
