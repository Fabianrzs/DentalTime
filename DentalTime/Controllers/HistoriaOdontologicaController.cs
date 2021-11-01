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
        public ActionResult<HistoriaOdontologica> Guardar (HistoriaOdontologicaInputModel historiaInput)
        {
            HistoriaOdontologica historiaClinica = mapearHistoriaOdontologica(historiaInput);
            var request = _service.Save(historiaClinica);
            if (request.Error) return BadRequest(request.Mensaje);
            return Ok(request.HistoriaClinica);
        }

        private HistoriaOdontologica mapearHistoriaOdontologica (HistoriaOdontologicaInputModel historiaInput)
        {
            HistoriaOdontologica historiaClinica = new HistoriaOdontologica();
            historiaClinica.IdHistoriaOdontologica = historiaInput.IdHistoriaOdontologica;
            historiaClinica.FechaInicio = historiaInput.FechaInicio;
            historiaClinica.NoDocumentoPaciente = historiaInput.NoDocumentoPaciente;
            Antecedente antecedente = new Antecedente();
            antecedente.IdAntecedente = historiaInput.Antecedente.IdAntecedente;
            antecedente.Enfermedades = historiaInput.Antecedente.Enfermedades;
            antecedente.Farmaceuticos = historiaInput.Antecedente.Farmaceuticos;
            antecedente.Quimicos = historiaInput.Antecedente.Quimicos;
            antecedente.Complicaciones = historiaInput.Antecedente.Complicaciones;
            historiaClinica.Antecedentes = antecedente;
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
