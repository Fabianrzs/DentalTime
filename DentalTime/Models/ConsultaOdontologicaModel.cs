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
        public Antecedente Antecedente { get; set; }
        [Required(ErrorMessage = "NoDocumento es requerido")]
        public string NoDocumento { get; set; }

        [Required(ErrorMessage = "IdSolicitudCita requerido")]
        public int IdSolicitudCita { get; set; }
        [Required(ErrorMessage = "IdServicio es requerido")]
        public int IdServicio { get; set; }

    }

    public class ConsultaClinicaViewModel : ConsultaClinicaInputModel
    {
        public int CodConsultaClinica { get; set; }
        public Servicio Servicio { get; set; }
        public SolicitudCita SolicitudCita { get; set; }
        public Paciente Paciente { get; set; }
        
        public ConsultaClinicaViewModel(ConsultaOdontologica consultaClinica)
        {
            CodConsultaClinica = consultaClinica.IdConsultaOdontologica;
            Motivo = consultaClinica.Motivo;
            Medicacion = consultaClinica.Medicacion;
            Diagnostico = consultaClinica.Diagnostico;
            Valoracion = consultaClinica.Valoracion;
            RecetaMedica = consultaClinica.RecetaMedica;
            NoDocumento = consultaClinica.NoDocumento;
            Paciente = consultaClinica.Paciente;
            IdSolicitudCita = consultaClinica.IdAntecedentes;
            Servicio = consultaClinica.Servicio;
            IdServicio = consultaClinica.IdServicio;
            SolicitudCita = consultaClinica.SolicitudCita;

        }
    }
}
