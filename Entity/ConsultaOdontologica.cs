using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entity
{
    public class ConsultaOdontologica
    {
        [Key]
        public int IdConsultaOdontologica { get; set; }
        public string Motivo { get; set; }
        public string Medicacion { get; set; }
        public string Diagnostico { get; set; }
        public string Valoracion { get; set; }
        public string RecetaMedica { get; set; }

        public int IdAntecedentes { get; set; }
        public Antecedente Antecedente { get; set; }

        public string NoDocumento { get; set; }
        [JsonIgnore]
        public Paciente Paciente { get; set; }

        public int IdSolicitudCita { get; set; }
        [JsonIgnore]
        public SolicitudCita SolicitudCita { get; set; }

        public int IdServicio { get; set; }
        [JsonIgnore]
        public Servicio Servicio { get; set; }


    }
}
