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
        public string NoDocumentoPaciente { get; set; }
        public DateTime FechaInicio { get; set; }
        public string IdAntecedente { get; set; }
        public string Enfermedades { get; set; }
        public string Farmaceuticos { get; set; }
        public string Quimicos { get; set; }
        public string Complicaciones { get; set; }
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
