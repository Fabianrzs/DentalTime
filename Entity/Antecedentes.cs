using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Antecedentes
    {
        [Key]
        public string IdAntecedente { get; set; }
        public string Enfermedades { get; set; }
        public string Farmaceuticos { get; set; }
        public string Quimicos { get; set; }
        public string Complicaciones { get; set; }

        public HistoriaOdontologica HistoriaOdontologica { get; set; }
    }
}
