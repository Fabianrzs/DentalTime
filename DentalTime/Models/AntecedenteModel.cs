using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentalTime.Models
{
    public class AntecedenteInputModel
    {
        public string IdAntecedente { get; set; }
        public string Enfermedades { get; set; }
        public string Farmaceuticos { get; set; }
        public string Quimicos { get; set; }
        public string Complicaciones { get; set; }
    }

    //public class AntecedenteViewModel: AntecedenteInputModel
    //{
    //    public AntecedenteViewModel(Antecedente antecedente)
    //    {
    //        IdAntecedente = antecedente.IdAntecedente;
    //        Enfermedades = antecedente.Enfermedades;
    //        Farmaceuticos = antecedente.Farmaceuticos;
    //        Quimicos = antecedente.Quimicos;
    //        Complicaciones = antecedente.Complicaciones;
    //    }
    //}
}
