using Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DentalTime.Models
{
    public class AntecedenteInputModel
    {

        [Required(ErrorMessage = "Enfermedades requerido")]
        public string Enfermedades { get; set; }
        [Required(ErrorMessage = "Farmaceuticos requerido")]
        public string Farmaceuticos { get; set; }
        [Required(ErrorMessage = "Quimicos requerido")]
        public string Quimicos { get; set; }
        [Required(ErrorMessage = "Complicaciones requerido")]
        public string Complicaciones { get; set; }
    }

    public class AntecedenteViewModel : AntecedenteInputModel
    {
        public int IdAntecedente { get; set; }
        public ConsultaOdontologica ConsultaOdontologica { get; set; }
        public AntecedenteViewModel(Antecedente antecedente)
        {
            IdAntecedente = antecedente.IdAntecedente;
            Enfermedades = antecedente.Enfermedades;
            Farmaceuticos = antecedente.Farmaceuticos;
            Quimicos = antecedente.Quimicos;
            Complicaciones = antecedente.Complicaciones;
            ConsultaOdontologica = antecedente.ConsultaOdontologica;
        }
    }
}
