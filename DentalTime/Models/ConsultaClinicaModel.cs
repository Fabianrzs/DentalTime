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
        public ConsultaClinicaViewModel(ConsultaOdontologica consultaClinica)
        {
<<<<<<< HEAD
            /*CodConsultaClinica = consultaClinica.IConsultaOdontologica;
            Complicaciones = consultaClinica.Complicaciones;
            Motivo = consultaClinica.Motivo;
            Antecedentes = consultaClinica.Antecedentes;
            Medicacion = consultaClinica.RecetaClinica;
            UltimaConsulta = consultaClinica.UltimaConsulta;
            ValoracionMedica = consultaClinica.ValoracionMedica;*/
=======
            /**Complicaciones = consultaClinica.Complicaciones; **/
            Motivo = consultaClinica.Motivo;
           /** Antecedentes = consultaClinica.Antecedentes;**/
           /** Medicacion = consultaClinica.RecetaClinica;**/
           /** UltimaConsulta = consultaClinica.UltimaConsulta;**/
           /** ValoracionMedica = consultaClinica.ValoracionMedica;**/
>>>>>>> 4c67271d38f14c9e5d4ead7cecfdadf57afbdacc
        }
    }
}
