using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class HistoriaClinica
    {
        [Key]
        public int CodHistoriaClinica { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaActual { get; set; }

        public string NoDocumentoOfHistoria { get; set; }
        public Paciente Paciente { get; set; }

        public int CodConsultaClinica { get; set; }
        public List<ConsultaClinica> ConsultasClinicas { get; set; }

    }
}
