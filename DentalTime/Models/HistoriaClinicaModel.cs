﻿using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentalTime.Models
{
    public class HistoriaClinicaInputModel
    {
        public DateTime FechaHora { get; set; }
        public string NoDocumentoOfHistoria { get; set; }
        public int CodConsultaOfHistoria { get; set; }
        public PacienteViewModel PacienteView { get; set; }
        public ConsultaClinicaViewModel ConsultaView { get; set; }
    }

    public class HistoriaClinicaViewModel : HistoriaClinicaInputModel
    {
        public int CodHistoriaClinica { get; set; }
        public HistoriaClinicaViewModel(HistoriaOdontologica historiaClinica)
        {
        }
    }
}
