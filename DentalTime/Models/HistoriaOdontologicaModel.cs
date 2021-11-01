using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentalTime.Models
{
    public class HistoriaOdontologicaInputModel
    {
        public string IdHistoriaOdontologica { get; set; }
        public DateTime FechaInicio { get; set; }
        public string NoDocumentoPaciente { get; set; }
        public AntecedenteInputModel Antecedente { get; set; }
    }

    //public class HistoriaClinicaViewModel : HistoriaClinicaInputModel
    //{
    //    public HistoriaClinicaViewModel(HistoriaOdontologica historiaClinica)
    //    {
    //        IdHistoriaOdontologica = historiaClinica.IdHistoriaOdontologica;
    //        FechaInicio = historiaClinica.FechaInicio;
    //        NoDocumentoPaciente  = historiaClinica.NoDocumentoPaciente;
    //        Antecedente = new AntecedenteInputModel();
    //    }
    //}
}
