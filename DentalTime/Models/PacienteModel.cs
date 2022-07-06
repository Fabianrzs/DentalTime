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

        [StringLength(12, ErrorMessage = "Numero de documeto Menor o igual a 12"), MinLength(7, ErrorMessage = "Numero de documeto Mayor o igual a 7")]
        public string NoDocumento { get; set; }
        [Required(ErrorMessage = "Nombres requerido")]
        [StringLength(12, ErrorMessage = "Nombre Menor o igual a 50"), MinLength(7, ErrorMessage = "Nombre Mayor o igual a 2")]
        public string Nombres { get; set; }
        [Required(ErrorMessage = "Apellidos requerido")]
        [StringLength(12, ErrorMessage = "Apellido Menor o igual a 70"), MinLength(7, ErrorMessage = "Apellido Mayor o igual a 2")]
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
        [StringLength(10,ErrorMessage = "Numero de telefono debe tener 10 digitos"), MinLength(10, ErrorMessage = "Numero de telefono debe tener 10 digitos")]
        public string NumeroTelefonico { get; set; }
    }

    public class PacienteViewModel : PacienteInputModel
    {
        public ICollection<ConsultaOdontologica> ConsultasOdontologicas { get; set; }
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
            ConsultasOdontologicas = paciente.ConsultasOdontologicas;
        }
    }
}
