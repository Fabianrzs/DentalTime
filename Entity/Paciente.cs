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
        public string NoDocumeto { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Sexo { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string TipoSaguineo { get; set; }
        public string NumeroTelefonico { get; set; }
        public string CorreoElectronico { get; set; }
        public string PaisNacimiento { get; set; }
        public string CiudadNacimiento { get; set; }


        public ICollection<Cita> Citas { get; set; }
        public ICollection<HistoriaClinica> historiasClinicas { get; set; }
    }
}
