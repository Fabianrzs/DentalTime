using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class ConsultaPaciente
    {
        public ConsultaPaciente(string identificacion){}
        public Paciente Paciente { get; set; }
        public Servicio Servicio { get; set; }
        public DateTime FechaConsulta { get; set; }
        public string Descripcion { get; set; }
    }
}
