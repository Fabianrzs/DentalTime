using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Procedimiento
    {
        [Key]
        public int IdProcedimineto { get; set; }
        public string Descripcion { get; set; }


        public int IdConsultaOdontologica { get; set; }
        public ConsultaOdontologica ConsultaOdontologica { get; set; }

        public string IdServico { get; set; }
        public Servicio Servicio { get; set; }
    }
}
