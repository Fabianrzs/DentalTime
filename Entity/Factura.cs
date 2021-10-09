using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Factura
    {
        public Paciente Paciente { get; set; }
        public Servicio Servicio { get; set; }
        public DateTime FechaFactura { get; set; }
    }
}
