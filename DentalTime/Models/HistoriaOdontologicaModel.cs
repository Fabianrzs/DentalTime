using Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DentalTime.Models
{
    public class HistoriaOdontologicaInputModel
    {
        [Required(ErrorMessage = "Id Historia odontologica requerido")]
        public string IdHistoriaOdontologica { get; set; }
        [Required(ErrorMessage = "no documento Paciente requerido")]
        public string NoDocumentoPaciente { get; set; }
        [Required(ErrorMessage = "Fecha de inicio requerido")]
        public DateTime FechaInicio { get; set; }
        [Required(ErrorMessage = "Id de antecendetes requerido")]
        public string IdAntecedente { get; set; }
        [Required(ErrorMessage = "Enfermedades requerido")]
        public Antecedente Antecedente { get; set; }
    }


    public class HistoriaClinicaViewModel : HistoriaOdontologicaInputModel
    {

       public HistoriaClinicaViewModel(HistoriaOdontologica historiaClinica)
       {
           IdHistoriaOdontologica = historiaClinica.IdHistoriaOdontologica;
           FechaInicio = historiaClinica.FechaInicio;
           NoDocumentoPaciente  = historiaClinica.NoDocumentoPaciente;
           Antecedente = historiaClinica.Antecedentes;
       }
    }
}
