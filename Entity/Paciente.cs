using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Paciente: Persona
    {
        public Paciente()
        {
            Tipo = "Paciente";
        }
        public string TipoSaguineo { get; set; }
        public string NumeroTelefonico { get; set; }
        public string CorreoElectronico { get; set; }
        public string Antecedentes { get; set; }
        public string Complicaciones { get; set; }
    }
}
