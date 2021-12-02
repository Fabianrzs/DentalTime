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
    public class SolicitudCitaController : ControllerBase
    {
        private SolicitudCitaService _service;
        private readonly IHubContext<SignalHub> _hubContext;
        
        public SolicitudCitaController(DentalTimeContext context, IHubContext<SignalHub> hubContext)
        {
            _hubContext = hubContext;
            _service = new SolicitudCitaService(context);
        }

        [HttpPost]
        public async Task<ActionResult<SolicitudCita>> GuardarAsync(SolicitudCitaInputModel citaInput)
        {
            SolicitudCita cita = mapearCita(citaInput);
            var request = _service.Save(cita);
            if (request.Error)
            {
                ModelState.AddModelError("Guardar Cita", request.Mensaje);
                var problemDetails = new ValidationProblemDetails(ModelState)
                {
                    Status = StatusCodes.Status400BadRequest,
                };
                return BadRequest(problemDetails);
            }
            await _hubContext.Clients.All.SendAsync("SignalMessageReceived", citaInput);
            return Ok(request.Cita);
        }

        private SolicitudCita mapearCita(SolicitudCitaInputModel citaInput)
        {
            SolicitudCita cita = new SolicitudCita();
            cita.NoDocumento = citaInput.NoDocumento;
            cita.CodAgenda = citaInput.CodAgenda;
            return cita;
        }

        [HttpGet]
        public ActionResult<List<SolicitudCita>> Consultar()
        {
            var request = _service.Consult();
            if (request.Error) return BadRequest(request.Mensaje);
            return Ok(request.Citas);
        }

        [HttpGet("{id}")]
        public ActionResult<Paciente> Get(int id)
        {
            var request = _service.Find(id);
            if (request.Error) return BadRequest(request.Mensaje);
            return Ok(request.Cita);
        }

        [HttpPut("{id}")]
        public ActionResult<Paciente> Put(int id, SolicitudCita cita)
        {
            var request = _service.Update(cita, id);
            if (request.Error) return BadRequest(request.Mensaje);
            return Ok(request.Cita);
        }

        // [HttpPut("{identificacion}")]
        // public ActionResult<Paciente> Put(string identificacion, Paciente paciente)
        // {
        //     var request = _service.Update(paciente, identificacion);
        //     if(request.Error) return BadRequest(request.Mensaje);
        //     return Ok(request.Paciente);
        // }

    }
}
