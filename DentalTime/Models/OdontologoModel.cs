using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentalTime.Models
{
    public class OdontologoInputModel
    {
        public string TipoDocumento { get; set; }
        public string NoDocumento { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }

    }
    public class OdontologoViewModel: OdontologoInputModel
    {
        public OdontologoViewModel(Odontologo odontologo)
        {
            TipoDocumento = odontologo.TipoDocumento;
            NoDocumento = odontologo.NoDocumento;
            Nombres = odontologo.Nombres;
            Apellidos = odontologo.Apellidos;
        }

    }
}
