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
    public class ServicioController : ControllerBase
    {
        private ServicioService _service;
        
        private readonly IHubContext<SignalHub> _hubContext;
        public ServicioController(DentalTimeContext context, IHubContext<SignalHub> hubContext)
        {
            _hubContext = hubContext;
            _service = new ServicioService(context);
        }

        [HttpPost]
        public async Task<ActionResult<Servicio>> Guardar(ServicioInputModel servicioInput)
        {
            Servicio servicio = mapearServicio(servicioInput);
            var request = _service.Save(servicio);
            if (request.Error){
                ModelState.AddModelError("Guardar Sevicio", request.Mensaje);
                var problemDetails = new ValidationProblemDetails(ModelState)
                {
                    Status = StatusCodes.Status400BadRequest,
                };
                return BadRequest(problemDetails);
            }
            await _hubContext.Clients.All.SendAsync("SignalMessageReceived", servicioInput);
            return Ok(request.Servicio);
        }

        private Servicio mapearServicio(ServicioInputModel servicioInput)
        {
            Servicio servicio = new Servicio();
            servicio.IdServico = servicioInput.IdServico;
            servicio.Nombre = servicioInput.Nombre;
            servicio.Precio = servicioInput.Precio;
            servicio.Duracion = servicioInput.Duracion;
            return servicio;
        }

        [HttpGet]
        public ActionResult<List<Producto>> Consult()
        {
            var request = _service.Consult();
            if (request.Error) return BadRequest(request.Error);
            return Ok(request.Servicios);
        }
    }
}
