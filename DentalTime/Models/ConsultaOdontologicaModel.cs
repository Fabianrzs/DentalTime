using Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DentalTime.Models
{
    public class ConsultaClinicaInputModel
    {
        [Required(ErrorMessage = "Identificacion del Paciente requerido")]
        public string IdentificacionPaciente { get; set; }
        [Required(ErrorMessage = "Motivo requerido")]
        public string Motivo { get; set; }
        [Required(ErrorMessage = "Complicaciones requerido")]
        public string Complicaciones { get; set; }
        [Required(ErrorMessage = "Antecedentes requerido")]
        public string Antecedentes { get; set; }
        [Required(ErrorMessage = "Mendicacion requerido")]
        public string Medicacion { get; set; }
        [Required(ErrorMessage = "Ultima consulta  requerido")]
        public DateTime UltimaConsulta { get; set; }
        [Required(ErrorMessage = "Valoracion Medica requerido")]
        public string ValoracionMedica { get; set; }
    }

    public class ConsultaClinicaViewModel : ConsultaClinicaInputModel
    {
        public int CodConsultaClinica { get; set; }
        public ConsultaClinicaViewModel(ConsultaOdontologica consultaClinica)
        {
            /*CodConsultaClinica = consultaClinica.IConsultaOdontologica;
            Complicaciones = consultaClinica.Complicaciones;
            Motivo = consultaClinica.Motivo;
            Antecedentes = consultaClinica.Antecedentes;
            Medicacion = consultaClinica.RecetaClinica;
            UltimaConsulta = consultaClinica.UltimaConsulta;
            ValoracionMedica = consultaClinica.ValoracionMedica;*/
        }
    }
}
