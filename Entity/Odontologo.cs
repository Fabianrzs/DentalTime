using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Entity
{
    public class Odontologo
    {
        public string TipoDocumento { get; set; }
        
        [Key]
        public string NoDocumento { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }

        public ICollection<Agenda> Agendas { get; set; }


    }
}