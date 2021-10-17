using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class ConsultaClinica
    {
        [Key]
        public int CodConsultaClinica { get; set; }
        public string Motivo { get; set; }
        public string Antecedentes { get; set; }
        public string Medicacion { get; set; }
        public DateTime UltimaConsulta { get; set; }
        public string ValoracionMedica { get; set; }

        public HistoriaClinica HistoriaClinica { get; set; }
    }
}
