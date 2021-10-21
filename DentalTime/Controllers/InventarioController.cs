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
    public class InventarioController : ControllerBase
    {
        private InventarioService service;

        public InventarioController(DentalTimeContext context)
        {
            service = new InventarioService(context);
        }

        [HttpPost]
        public ActionResult<Inventario> Guardar(InventarioInputModel inventarioInput)
        {
            Inventario inventario = new Inventario();
            inventario.IdInventario = inventarioInput.IdInventario;
            var request = service.Save(inventario);
            if (request.Error) return BadRequest(request.Mensaje);
            return Ok(request.Inventario);
        }
    }
}
