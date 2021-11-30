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
        [Required(ErrorMessage = "Id Consulta Odontologica requerido")]
        public int IdConsultaOdontologica { get; set; }
        [Required(ErrorMessage = "Motivo requerido")]
        public string Motivo { get; set; }
        [Required(ErrorMessage = "Medicacion requerido")]
        public string Medicacion { get; set; }
        [Required(ErrorMessage = "Diagnostico requerido")]
        public string Diagnostico { get; set; }
        [Required(ErrorMessage = "Valoracion requerido")]
        public string Valoracion { get; set; }
        [Required(ErrorMessage = "Receta Medica requerido")]
        public string RecetaMedica { get; set; }
        [Required(ErrorMessage = "IdSolicitudCita requerido")]
        public int IdSolicitudCita { get; set; }
        [Required(ErrorMessage = "Id Historia Odontologica requerido")]
        public string IdHistoriaOdontologica { get; set; }

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
