using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentalTime.Models
{
    public class CitaModel
    {
        public class CitaInputModel
        {
            public string Motivo { get; set; }
        }

        public class CitaViewModel : CitaInputModel
        {
            public int CodCita { get; set; }
            public CitaViewModel(Cita cita)
            {
                CodCita = cita.CodCita;
                Motivo = cita.Motivo;
            }
        }


    }
}
