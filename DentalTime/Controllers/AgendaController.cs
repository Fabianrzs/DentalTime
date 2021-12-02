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
    public class AgendaController : ControllerBase
    {
        private AgendaService _service;
        private readonly IHubContext<SignalHub> _hubContext;

        public AgendaController(DentalTimeContext context, IHubContext<SignalHub> hubContext)
        {
            _hubContext = hubContext;
            _service = new AgendaService(context);
        }

        [HttpPost]
        public async Task<ActionResult<Agenda>> GuardarAsync(AgendaInputModel agendaInput)
        {
            Agenda paciente = MapearPaciente(agendaInput);
            var request = _service.Save(paciente);
            if (request.Error)
            {
                ModelState.AddModelError("Guardar Agenda", request.Mensaje);
                var problemDetails = new ValidationProblemDetails(ModelState)
                {
                    Status = StatusCodes.Status400BadRequest,
                };
                return BadRequest(problemDetails);
            }
            await _hubContext.Clients.All.SendAsync("SignalMessageReceived", agendaInput);
            return Ok(request.Agenda);
        }

        private Agenda MapearPaciente(AgendaInputModel agendaInput)
        {
            var agenda = new Agenda();
            agenda.Estado = agendaInput.Estado;
            agenda.FechaInicio = agendaInput.FechaHoraInicio;
            agenda.FechaFin = agendaInput.FechaHoraFin;
            return agenda;
        }

        [HttpGet]
        public ActionResult<List<Agenda>> Consulta()
        {
            var request = _service.Consult();
            if (request.Error) return BadRequest(request.Mensaje);
            return Ok(request.Agendas);
        }

    }
}
