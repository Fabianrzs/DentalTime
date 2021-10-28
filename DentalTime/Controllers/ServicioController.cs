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
    public class ServicioController : ControllerBase
    {
        private ServicioService _service;
        
        public ServicioController(DentalTimeContext context)
        {
            _service = new ServicioService(context);
        }

        [HttpPost]
        public ActionResult<Servicio> Guardar(ServicioInputModel servicioInput)
        {
            Servicio servicio = mapearServicio(servicioInput);
            var request = _service.Save(servicio);
            if (request.Error) return BadRequest(request.Error);
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
            if (request.Error) return BadRequest(request.Mensaje);
            return Ok(request.Servicios);
        }
    }
}
