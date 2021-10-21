using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentalTime.Models
{
    public class PacienteInputModel
    {
        public string TipoDocumento { get; set; }
        public string NoDocumento { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Sexo { get; set; }
        public string TipoSanguineo { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string LugarNacimiento { get; set; }
        public string CorreoElectronico { get; set; }
        public string NumeroTelefonico { get; set; }
    }

    public class PacienteViewModel : PacienteInputModel
    {
        public PacienteViewModel(Paciente paciente)
        {
            
        }
    }
}
