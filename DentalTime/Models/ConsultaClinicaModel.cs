using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentalTime.Models
{
    public class ConsultaClinicaInputModel
    {
        public string IdentificacionPaciente { get; set; }
        public string Motivo { get; set; }
        public string Complicaciones { get; set; }
        public string Antecedentes { get; set; }
        public string Medicacion { get; set; }
        public DateTime UltimaConsulta { get; set; }
        public string ValoracionMedica { get; set; }
    }

    public class ConsultaClinicaViewModel : ConsultaClinicaInputModel
    {
        public int CodConsultaClinica { get; set; }
        public ConsultaClinicaViewModel(ConsultaClinica consultaClinica)
        {
            CodConsultaClinica = consultaClinica.CodConsultaClinica;
            Complicaciones = consultaClinica.Complicaciones;
            Motivo = consultaClinica.Motivo;
            Antecedentes = consultaClinica.Antecedentes;
            Medicacion = consultaClinica.Medicacion;
            UltimaConsulta = consultaClinica.UltimaConsulta;
            ValoracionMedica = consultaClinica.ValoracionMedica;
        }
    }
}
