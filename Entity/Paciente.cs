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
        public string TipoSanguineo { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string LugarNacimiento { get; set; }
        public string CorreoElectronico { get; set; }
        public string NumeroTelefonico { get; set; }
        

        public ICollection<SolicitudCita> HistorialCitas { get; set; }
        public HistoriaOdontologica HistorialOdontologico { get; set; }
    }
}
