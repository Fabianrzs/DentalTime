using Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DentalTime.Models
{
    public class PacienteInputModel
    {
        [Required(ErrorMessage = "Tipo de documento requerido")]
        public string TipoDocumento { get; set; }
        [Required(ErrorMessage = "Numero de documento requerido")]
        public string NoDocumento { get; set; }
        [Required(ErrorMessage = "Nombres requerido")]
        public string Nombres { get; set; }
        [Required(ErrorMessage = "Apellidos requerido")]     
        public string Apellidos { get; set; }
        [Required(ErrorMessage = "Sexo requerido")]
        public string Sexo { get; set; }
        [Required(ErrorMessage = "Tipo sanguineo requerido")]
        public string TipoSanguineo { get; set; }
        [Required(ErrorMessage = "Fecha de nacimiento requerido")]
        public DateTime FechaNacimiento { get; set; }
        [Required(ErrorMessage = "Lugar de nacimiento requerido")]
        public string LugarNacimiento { get; set; }
        [Required(ErrorMessage = "Correo elctronico requerido")]
        public string CorreoElectronico { get; set; }
        [Required(ErrorMessage = "Numero telefonico requerido")]
        public string NumeroTelefonico { get; set; }
    }

    public class PacienteViewModel : PacienteInputModel
    {
        public PacienteViewModel(Paciente paciente)
        {
            TipoDocumento = paciente.TipoDocumento;
            NoDocumento = paciente.NoDocumento;
            Nombres = paciente.Nombres;
            Apellidos = paciente.Apellidos;
            Sexo = paciente.Sexo;
            TipoSanguineo = paciente.TipoSanguineo;
            FechaNacimiento = paciente.FechaNacimiento;
            LugarNacimiento = paciente.LugarNacimiento;
            CorreoElectronico = paciente.CorreoElectronico;
            NumeroTelefonico = paciente.NumeroTelefonico;
        }
    }
}
