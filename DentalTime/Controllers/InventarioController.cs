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
    public class InventarioController : ControllerBase
    {
        private InventarioService service;
        private readonly IHubContext<SignalHub> _hubContext;
        public InventarioController(DentalTimeContext context, IHubContext<SignalHub> hubContext)
        {
            _hubContext = hubContext;
            service = new InventarioService(context);
        }

        [HttpPost]
        public async Task<ActionResult<Inventario>> GuardarAsync(InventarioInputModel inventarioInput)
        {
            Inventario inventario = new Inventario();
            inventario.IdInventario = inventarioInput.IdInventario;
            var request = service.Save(inventario);
            if (request.Error)
            {
                ModelState.AddModelError("Guardar Inventario", request.Mensaje);
                var problemDetails = new ValidationProblemDetails(ModelState)
                {
                    Status = StatusCodes.Status400BadRequest,
                };
                return BadRequest(problemDetails);
            }
            await _hubContext.Clients.All.SendAsync("SignalMessageReceived", inventarioInput);
            return Ok(request.Inventario);
        }
    }
}
