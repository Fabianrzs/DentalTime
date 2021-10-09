using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentalTime.Models
{
    public class PacienteInputModels
    {
        public string Identificacion { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Sexo { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Tipo { get; set; }
        public string TipoSaguineo { get; set; }
        public string NumeroTelefonico { get; set; }
        public string CorreoElectronico { get; set; }
        public string Antecedentes { get; set; }
        public string Complicaciones { get; set; }
    }
    public class PacienteViewModels : PacienteInputModels
    {
        public PacienteViewModels(Paciente paciente)
        {
            Identificacion = paciente.Identificacion;
            Nombres = paciente.Nombres;
            Apellidos = paciente.Apellidos;
            Sexo = paciente.Sexo;
            FechaNacimiento = paciente.FechaNacimiento;
            Tipo = paciente.Tipo;
            TipoSaguineo = paciente.TipoSaguineo;
            NumeroTelefonico = paciente.NumeroTelefonico;
            CorreoElectronico = paciente.CorreoElectronico;
            Antecedentes = paciente.Antecedentes;
            Complicaciones = paciente.Complicaciones;
        }
        
    }
}

