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
        public string NoDocumeto { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Sexo { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string PaisNacimiento { get; set; }
        public string CiudadNacimiento { get; set; }
        public string TipoSaguineo { get; set; }
        public string NumeroTelefonico { get; set; }
        public string CorreoElectronico { get; set; }
    }

    public class PacienteViewModel : PacienteInputModel
    {
        public PacienteViewModel(Paciente paciente)
        {
            TipoDocumento = paciente.TipoDocumento;
            NoDocumeto = paciente.NoDocumento;
            Nombres = paciente.Nombres;
            Apellidos = paciente.Apellidos;
            Sexo = paciente.Sexo;
            FechaNacimiento = paciente.FechaNacimiento;
          /**  PaisNacimiento = paciente.PaisNacimiento;
            CiudadNacimiento = paciente.CiudadNacimiento;
            TipoSaguineo = paciente.TipoSaguineo; **/
             NumeroTelefonico = paciente.NumeroTelefonico;
            CorreoElectronico = paciente.CorreoElectronico;
        }
    }
}
