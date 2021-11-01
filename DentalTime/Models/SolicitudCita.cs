using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentalTime.Models
{
    public class SolicitudCitaInputModel
    {
        public DateTime Fecha { get; set; }
        public string Estado { get; set; }
        public string NoDocumentoPaciente { get; set; }
    }

    public class SolicitudCitaCitaViewModel : SolicitudCitaInputModel
    {
        public int CodAgenda { get; set; }
        public SolicitudCitaCitaViewModel(SolicitudCita cita)
        {
            CodAgenda = cita.IdSolicitudCita;
            Fecha = cita.Fecha;
            Estado = cita.Estado;
            NoDocumentoPaciente = cita.NoDocumentoPaciente;
        }
    }
}
