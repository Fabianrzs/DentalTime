using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class InformacionBasica
    {
        public string IdInformacionBasica { get; set; }
        public string Enfermedades { get; set; }
        public string AntecedentesQuimicos { get; set; }
        public string AntecedentesFamaceuticos { get; set; }
        public string Complicaciones { get; set; }

        public string IdHistoriaClinica { get; set; }
        public HistoriaClinica HistoriaClinica { get; set; }
    }
}
