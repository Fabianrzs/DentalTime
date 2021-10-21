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
using static DentalTime.Models.CitaModel;

namespace DentalTime.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitaController : ControllerBase
    {
        private SolicitudCitaService _service;
        
        public CitaController(DentalTimeContext context)
        {
            _service = new SolicitudCitaService(context);
        }

        [HttpPost]
        public ActionResult<SolicitudCita> Guardar(CitaInputModel citaInput)
        {
            SolicitudCita cita = mapearCita(citaInput);
            var request = _service.Save(cita);
            if (request.Error) return BadRequest(request.Mensaje);
            return Ok(request.Cita);
        }

        private SolicitudCita mapearCita(CitaInputModel citaInput)
        {
            SolicitudCita cita = new SolicitudCita();
            //cita.Motivo = citaInput.Motivo;
            return cita;
        }
    }
}
