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
    public class AgendaController : ControllerBase
    {
        private AgendaService _service;

        public AgendaController(DentalTimeContext context)
        {
            _service = new AgendaService(context);
        }

        [HttpPost]
        public ActionResult<Agenda> Guardar(AgendaInputModel agendaInput)
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
            return Ok(request.Agenda);
        }

        private Agenda MapearPaciente(AgendaInputModel agendaInput)
        {
            var agenda = new Agenda();
            agenda.Estado = agendaInput.Estado;
            agenda.FechaHoraInicio = agendaInput.FechaHoraInicio;
            agenda.FechaHoraFin = agendaInput.FechaHoraFin;
            return agenda;
        }

        [HttpGet]
        public ActionResult<List<Paciente>> Consulta()
        {
            var request = _service.Consult();
            if (request.Error) return BadRequest(request.Mensaje);
            return Ok(request.Agendas);
        }

    }
}
