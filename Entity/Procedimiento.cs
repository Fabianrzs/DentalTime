using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Procedimiento
    {
        public int IdProcedimineto { get; set; }
        public string Descripcion { get; set; }


        public int IdConsultaOdontologica { get; set; }
        public ConsultaOdontologica ConsultaOdontologica { get; set; }

        public int IdServico { get; set; }
        public Servicio Servicio { get; set; }
    }
}
