using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entity
{
    public class Agenda
    {
        [Key]
        public int CodAgenda { get; set; }
        public string Estado { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }

        public string NoDocumento { get; set; }
        [JsonIgnore]
        public Odontologo Odontologo { get; set; }
        
        public SolicitudCita Cita { get; set; }
    }
}
