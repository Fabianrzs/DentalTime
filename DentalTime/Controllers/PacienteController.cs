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
    public class PacienteController : ControllerBase
    {
        private PacienteService _service;
        private readonly IHubContext<SignalHub> _hubContext;

        public PacienteController(DentalTimeContext context,  IHubContext<SignalHub> hubContext)
        {
            _hubContext = hubContext;
            _service = new PacienteService(context);
        }

        [HttpPost]
        public async Task<ActionResult<Paciente>> GuardarAsync(PacienteInputModel pacienteInput)
        {
            Paciente paciente = MapearPaciente(pacienteInput);
            var request = _service.Save(paciente);
            if (request.Error)
            {
                ModelState.AddModelError("Guardar Paciente", request.Mensaje);
                var problemDetails = new ValidationProblemDetails(ModelState)
                {
                    Status = StatusCodes.Status400BadRequest,
                };
                return BadRequest(problemDetails);
            }
            await _hubContext.Clients.All.SendAsync("SignalMessageReceived", pacienteInput);
            return Ok(request.Paciente);
        }

        private Paciente MapearPaciente(PacienteInputModel pacienteImput)
        {
            var paciente = new Paciente();
            paciente.TipoDocumento = pacienteImput.TipoDocumento;
            paciente.NoDocumento = pacienteImput.NoDocumento;
            paciente.Nombres = pacienteImput.Nombres;
            paciente.Apellidos = pacienteImput.Apellidos;
            paciente.Sexo = pacienteImput.Sexo;
            paciente.TipoSanguineo = pacienteImput.TipoSanguineo;
            paciente.FechaNacimiento = pacienteImput.FechaNacimiento;
            paciente.LugarNacimiento = pacienteImput.LugarNacimiento;
            paciente.NumeroTelefonico = pacienteImput.NumeroTelefonico;
            paciente.CorreoElectronico = pacienteImput.CorreoElectronico;
            return paciente;
        }

        [HttpGet]
        public ActionResult<List<Paciente>> Consulta()
        {
            var request = _service.Consult();
            if (request.Error) return BadRequest(request.Mensaje);
            return Ok(request.Pacientes);
        }

        [HttpGet("{identificacion}")]
        public ActionResult<Paciente> Get(string identificacion)
        {
            var request = _service.Find(identificacion);
            if (request.Error) return BadRequest(request.Mensaje);
            return Ok(request.Paciente);
        }

        [HttpPut("{identificacion}")]
        public ActionResult<Paciente> Put(string identificacion, Paciente paciente)
        {
            var request = _service.Update(paciente, identificacion);
            if (request.Error) return BadRequest(request.Mensaje);
            return Ok(request.Paciente);
        }

    }
}
