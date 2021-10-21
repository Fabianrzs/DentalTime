﻿using Entity;
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
            TipoDocumento = paciente.TipoDocumento;
            NoDocumento = paciente.NoDocumento;
            Nombres = paciente.Nombres;
            Apellidos = paciente.Apellidos;
            Sexo = paciente.Sexo;
            LugarNacimiento = paciente.LugarNacimiento;
            FechaNacimiento = paciente.FechaNacimiento;
<<<<<<< HEAD
            LugarNacimiento = paciente.LugarNacimiento;
            NumeroTelefonico = paciente.NumeroTelefonico;
=======
          /**  PaisNacimiento = paciente.PaisNacimiento;
            CiudadNacimiento = paciente.CiudadNacimiento;
            TipoSaguineo = paciente.TipoSaguineo; **/
             NumeroTelefonico = paciente.NumeroTelefonico;
>>>>>>> 4c67271d38f14c9e5d4ead7cecfdadf57afbdacc
            CorreoElectronico = paciente.CorreoElectronico;
        }
    }
}
