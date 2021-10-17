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
        public DateTime FachaHora { get; set; }

        public string NoDocumento { get; set; }
        public Paciente Paciente { get; set; }

        public int CodConsulta { get; set; }
        public ConsultaClinica Consulta { get; set; }

    }
}
