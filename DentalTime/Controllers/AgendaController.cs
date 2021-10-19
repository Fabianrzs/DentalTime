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
            Agenda agenda = mapearAgenda(agendaInput);
            var request = _service.Save(agenda);
            if (request.Error) return BadRequest(request.Mensaje);
            return Ok(request.Agenda);
        }

        private Agenda mapearAgenda(AgendaInputModel agendaInput)
        {
            Agenda agenda = new Agenda();
            agenda.Estado = agendaInput.Estado;
            agenda.FechaHora = agendaInput.FechaHora;
            return agenda;
        }
    }
}
