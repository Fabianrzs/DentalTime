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
    public class ProductoController : ControllerBase
    {
        private ProductoService _service; 
        private readonly IHubContext<SignalHub> _hubContext;

        public ProductoController(DentalTimeContext contex, IHubContext<SignalHub> hubContext)
        {
            _hubContext = hubContext;
            _service = new ProductoService(contex);

        }

        [HttpPost]
        public async Task<ActionResult<Producto>> GuardarAsync (ProductoInputModel productoInput)
        {
            var producto = mapearProducto(productoInput);
            var request = _service.Save(producto);
            if (request.Error)
            {
                ModelState.AddModelError("Guardar Producto", request.Mensaje);
                var problemDetails = new ValidationProblemDetails(ModelState)
                {
                    Status = StatusCodes.Status400BadRequest,
                };
                return BadRequest(problemDetails);
            }
            await _hubContext.Clients.All.SendAsync("SignalMessageReceived", productoInput);
            return Ok(request.Producto);
        }

        private Producto mapearProducto (ProductoInputModel productoInput)
        {
            var producto = new Producto();

            producto.Referencia = productoInput.Referencia;
            producto.Nombre = productoInput.Nombre;
            producto.Laboratorio = productoInput.Laboratorio;
            producto.Marca = productoInput.Marca;
            producto.StockActual = productoInput.StockActual;
            producto.StockMax = productoInput.StockMax;
            producto.StockMin = productoInput.StockMin;
            producto.IdInventario = productoInput.IdInventario;

            return producto;
        }

        [HttpGet]
        public ActionResult<List<Producto>> Consult ()
        {
            var request = _service.Consult();
            if (request.Error) return BadRequest(request.Mensaje);
            return Ok(request.Productos);
        }

        [HttpGet ("Referencia")]
        public ActionResult<Producto> Find(string referencia)
        {
            var request = _service.Find(referencia);
            if (request.Error) return BadRequest(request.Mensaje);
            return Ok(request.Producto);
        }

        [HttpDelete ("Referencia")]
        public ActionResult<Producto> Delete(string referencia)
        {
            var request = _service.Delete(referencia);
            return Ok(request);
        }



    }
}
