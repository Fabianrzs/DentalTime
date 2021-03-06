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
    public class DetalleController : ControllerBase
    {
        private DetalleServicioService _service;
        private readonly IHubContext<SignalHub> _hubContext;

        public DetalleController(DentalTimeContext context, IHubContext<SignalHub> hubContext)
        {
            _hubContext = hubContext;
            _service = new DetalleServicioService(context);
        }

        [HttpPost]
        public async Task<ActionResult<DetalleServicio>> GuardarAsync(DetallesServicioInputModel detalleInput)
        {
            DetalleServicio detalles = MapearDetalles(detalleInput);
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
            await _hubContext.Clients.All.SendAsync("SignalMessageReceived", detalleInput);
            return Ok(request.DetalleServicio);
        }

        private DetalleServicio MapearDetalles(DetallesServicioInputModel detalleInput)
        {
            var detalle = new DetalleServicio();
            detalle.ReferenciaProducto = detalleInput.ReferenciaProducto;
            detalle.IdServicio = detalleInput.IdServicio;
            detalle.UnidadesUsadas = detalleInput.UnidadesUsadas;
            return detalle;
        }

        [HttpGet]
        public ActionResult<List<DetalleServicio>> Consult()
        {
            var request = _service.Consult();
            if (request.Error) return BadRequest(request.Error);
            return Ok(request.DetalleServicios);
        }

    }
}
