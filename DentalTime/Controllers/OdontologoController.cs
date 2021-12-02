using BLL;
using DAL;
using DentalTime.Hubs;
using DentalTime.Models;
using Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentalTime.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OdontologoController : ControllerBase
    {
        private OdontologoService _service;
        private readonly IHubContext<SignalHub> _hubContext;

        public OdontologoController(DentalTimeContext context, IHubContext<SignalHub> hubContext)
        {
            _hubContext = hubContext;
            _service = new OdontologoService(context);
        }

        [HttpPost]
        public async Task<ActionResult<Odontologo>> GuardarAsync(OdontologoInputModel odontologoInput)
        {
            Odontologo detalles = MapearOdontologo(odontologoInput);
            var request = _service.Save(detalles);
            if (request.Error)
            {
                ModelState.AddModelError("Guardar Agenda", request.Mensaje);
                var problemDetails = new ValidationProblemDetails(ModelState)
                {
                    Status = StatusCodes.Status400BadRequest,
                };
                return BadRequest(problemDetails);
            }
            await _hubContext.Clients.All.SendAsync("SignalMessageReceived", odontologoInput);
            return Ok(request.Odontologo);
        }

        private Odontologo MapearOdontologo(OdontologoInputModel odontologoInput)
        {
            var odontologo = new Odontologo();
            odontologo.TipoDocumento = odontologoInput.TipoDocumento;
            odontologo.NoDocumento = odontologoInput.NoDocumento;
            odontologo.Nombres = odontologoInput.Nombres;
            odontologo.Apellidos = odontologoInput.Apellidos;
            return odontologo;
        }

        [HttpGet]
        public ActionResult<List<DetalleServicio>> Consult()
        {
            var request = _service.Consult();
            if (request.Error) return BadRequest(request.Error);
            return Ok(request.Odontologos);
        }
    }
}
