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
        public DateTime Fecha { get; set; }
        public string Motivo { get; set; }
        public string MedicacionActual { get; set; }
        public string Diagnostico { get; set; }
        public string ValoracionMedica { get; set; }
        public string RecetaClinica { get; set; }

        public string IdHistoriaClinica { get; set; }
        public HistoriaClinica HistoriaClinica { get; set; }
    }
}
