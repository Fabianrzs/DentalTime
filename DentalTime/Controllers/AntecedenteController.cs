using BLL;
using DAL;
using DentalTime.Hubs;
using DentalTime.Models;
using Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
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
        private readonly IHubContext<SignalHub> _hubContext;

        public AntecedenteController(DentalTimeContext context, IHubContext<SignalHub> hubContext)
        {
            _hubContext = hubContext;
            _service = new AntecedenteService(context);
        }

        [HttpPost]
        public async Task<ActionResult<Antecedente>> GuardarAsync(AntecedenteInputModel antecedetesInput)
        {
            Antecedente antecedente = mapearAntecedente(antecedetesInput);
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
            await _hubContext.Clients.All.SendAsync("SignalMessageReceived", antecedetesInput);
            return Ok(request.Antecedente);
        }

        private Antecedente mapearAntecedente(AntecedenteInputModel antecedentesInput)
        {
            Antecedente antecedente = new Antecedente();

            antecedente.IdAntecedente = antecedentesInput.IdAntecedente;
            antecedente.Enfermedades = antecedentesInput.Enfermedades;
            antecedente.Farmaceuticos = antecedentesInput.Farmaceuticos;
            antecedente.Quimicos = antecedentesInput.Quimicos;
            antecedente.Complicaciones = antecedentesInput.Complicaciones;

            return antecedente;
        }
    }
}
