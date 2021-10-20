using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
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

        public int IdHistoriaOdontologica { get; set; }
        public HistoriaOdontologica HistoriaOdontologica { get; set; }

        public ICollection<Procedimiento> Procedimiento { get; set; }
    }
}
