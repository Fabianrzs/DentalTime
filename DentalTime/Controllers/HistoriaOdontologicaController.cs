using BLL;
using DAL;
using DentalTime.Models;
using Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentalTime.Controllers
{
    [Authorize]
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
            if (request.Error)
            {
                ModelState.AddModelError("Guardar Historio Odontologica", request.Mensaje);
                var problemDetails = new ValidationProblemDetails(ModelState)
                {
                    Status = StatusCodes.Status400BadRequest,
                };
                return BadRequest(problemDetails);
            }
            return Ok(request.HistoriaClinica);
        }

        private HistoriaOdontologica mapearHistoriaOdontologica (HistoriaOdontologicaInputModel historiaInput)
        {
            HistoriaOdontologica historiaClinica = new HistoriaOdontologica();
            historiaClinica.IdHistoriaOdontologica = historiaInput.IdHistoriaOdontologica;
            historiaClinica.FechaInicio = historiaInput.FechaInicio;
            historiaClinica.NoDocumentoPaciente = historiaInput.NoDocumentoPaciente;
            Antecedente antecedente = new Antecedente();
            antecedente.IdAntecedente = historiaInput.IdAntecedente;
            antecedente.Enfermedades = historiaInput.Enfermedades;
            antecedente.Farmaceuticos = historiaInput.Farmaceuticos;
            antecedente.Quimicos = historiaInput.Quimicos;
            antecedente.Complicaciones = historiaInput.Complicaciones;
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

        [HttpGet("{id}")]
        public ActionResult<HistoriaOdontologica> Get(string id)
        {
            var request = _service.Find(id);
            if (request.Error) return BadRequest(request.Mensaje);
            return Ok(request.HistoriaClinica);
        }

    }
}
