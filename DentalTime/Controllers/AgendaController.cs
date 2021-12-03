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
   
    // [Authorize]
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
        public async Task<ActionResult<AgendaViewModel>> GuardarAsync(AgendaInputModel agendaInput)
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
            return Ok(new AgendaViewModel(request.Agenda));
        }

        private Agenda MapearPaciente(AgendaInputModel agendaInput)
        {
            var agenda = new Agenda();
            agenda.FechaInicio = agendaInput.FechaHoraInicio;
            agenda.FechaFin = agendaInput.FechaHoraFin;
            agenda.NoDocumento = agendaInput.NoDocumento;

            return agenda;
        }

        [HttpGet("{identificacion}")]
        public ActionResult<List<Agenda>> Consulta(string identificacion)
        {
            var request = _service.Consult(identificacion);
            if (request.Error) return BadRequest(request.Mensaje);
            return Ok(request.Agendas.Select(a => new AgendaViewModel(a)));
        }
        [HttpPost("Filtro")]
        public ActionResult<List<Agenda>> ConsultaFiltro(FiltroInputModel filtroInput)
        {
            var request = _service.FiltroAgenda(filtroInput.Fecha, filtroInput.Documento);
            if (request.Error)
            {
                  ModelState.AddModelError("Consultar Agenda", request.Mensaje);
                var problemDetails = new ValidationProblemDetails(ModelState)
                {
                    Status = StatusCodes.Status400BadRequest,
                };
                return BadRequest(problemDetails);
            } 
            return Ok(request.Agendas.Select(a => new AgendaViewModel(a)));
        }

    }
}
