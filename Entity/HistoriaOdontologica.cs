using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class HistoriaOdontologica
    {
        [Key]
        public int IdHistoriaOdontologica { get; set; }
        public DateTime FechaInicio { get; set; }


        public string NoDocumentoPaciente { get; set; }
        public Paciente Paciente { get; set; }

        public string IdAntecedentes { get; set; }
        public Antecedentes Antecedentes { get; set; }

    }
}
