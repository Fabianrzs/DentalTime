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
    public class AntecedenteController : ControllerBase
    {
        private readonly AntecedenteService _service;

        public AntecedenteController(DentalTimeContext context)
        {
            _service = new AntecedenteService(context);
        }

        [HttpPost]
        public ActionResult<Antecedente> Guardar(AntecedenteInputModel inputModel)
        {
            Antecedente antecedente = mapearAntecedente(inputModel);
            var request = _service.Save(antecedente);
            if (request.Error)
            {
                ModelState.AddModelError("Guardar Antecedente", request.Mensaje);
                var problemDetails = new ValidationProblemDetails(ModelState)
                {
                    Status = StatusCodes.Status400BadRequest,
                };
                return BadRequest(problemDetails);
            }
            return Ok(request.Antecedente);
        }

        private Antecedente mapearAntecedente(AntecedenteInputModel inputModel)
        {
            Antecedente antecedente = new Antecedente();

            antecedente.IdAntecedente = inputModel.IdAntecedente;
            antecedente.Enfermedades = inputModel.Enfermedades;
            antecedente.Farmaceuticos = inputModel.Farmaceuticos;
            antecedente.Quimicos = inputModel.Quimicos;
            antecedente.Complicaciones = inputModel.Complicaciones;

            return antecedente;
        }
    }
}
