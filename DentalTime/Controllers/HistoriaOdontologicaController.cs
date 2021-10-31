using BLL;
using DAL;
using DentalTime.Models;
using Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentalTime.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoriaOdontologicaController : ControllerBase
    {
        private HistorialClinicoService _service;
        
        public HistoriaOdontologicaController(DentalTimeContext dentalTimeContext)
        {
            _service = new HistorialClinicoService(dentalTimeContext);            
        }

        [HttpPost]
        public ActionResult<HistoriaOdontologica> Guardar(HistoriaClinicaInputModel historiaInput)
        {
            HistoriaOdontologica historiaClinica = mapearHistoriaOdontologica(historiaInput);
            var request = _service.Save(historiaClinica);
            if (request.Error) return BadRequest(request.Mensaje);
            return Ok(request.HistoriaClinica);
        }

        private HistoriaOdontologica mapearHistoriaOdontologica(HistoriaClinicaInputModel historiaInput)
        {
            HistoriaOdontologica historiaClinica = new HistoriaOdontologica();

            historiaClinica.IdHistoriaOdontologica = historiaInput.IdHistoriaOdontologica;
            historiaClinica.FechaInicio = historiaInput.FechaInicio;
            historiaClinica.NoDocumentoPaciente = historiaInput.NoDocumentoPaciente;
            historiaClinica.Antecedentes = new Antecedente();
            historiaClinica.Antecedentes.IdAntecedente = historiaInput.Antecedente.IdAntecedente;
            historiaClinica.Antecedentes.Enfermedades = historiaInput.Antecedente.Enfermedades;
            historiaClinica.Antecedentes.Farmaceuticos = historiaInput.Antecedente.Farmaceuticos;
            historiaClinica.Antecedentes.Quimicos = historiaInput.Antecedente.Quimicos;
            historiaClinica.Antecedentes.Complicaciones = historiaInput.Antecedente.Complicaciones;

            return historiaClinica;
        }

        [HttpGet]
        public ActionResult<List<HistoriaOdontologica>> Consulta()
        {
            var request = _service.Consult();
            if (request.Error) return BadRequest(request.Mensaje);
            return Ok(request.HistoriasClinicas);
        }
    }
}
