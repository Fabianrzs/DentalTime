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
    public class CitaController : ControllerBase
    {
        private CitaService _service;
        
        public CitaController(DentalTimeContext context)
        {
            _service = new CitaService(context);
        }

        [HttpPost]
        public ActionResult<Cita> Guardar(CitaInputModel citaInput)
        {
            Cita cita = mapearCita(citaInput);
            var request = _service.Save(cita);
            if (request.Error) return BadRequest(request.Mensaje);
            return Ok(request.Cita);
        }

        private Cita mapearCita(CitaInputModel citaInput)
        {
            Cita cita = new Cita();
            cita.Motivo = citaInput.Motivo;
            return cita;
        }
    }
}
