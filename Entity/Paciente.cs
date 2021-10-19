using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Paciente
    {
        public string TipoDocumento { get; set; }
        [Key]
        public string NoDocumento { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Sexo { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string PaisNacimiento { get; set; }
        public string CiudadNacimiento { get; set; }
        public string TipoSaguineo { get; set; }
        public string NumeroTelefonico { get; set; }
        public string CorreoElectronico { get; set; }

        public ICollection<Cita> HistorialCita { get; set; }
        public ICollection<HistoriaClinica> HistorialClinico { get; set; }
    }
}
