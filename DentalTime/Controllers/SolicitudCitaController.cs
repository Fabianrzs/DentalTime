﻿using BLL;
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
    public class SolicitudCitaController : ControllerBase
    {
        private SolicitudCitaService _service;
        
        public SolicitudCitaController(DentalTimeContext context)
        {
            _service = new SolicitudCitaService(context);
        }

        [HttpPost]
        public ActionResult<SolicitudCita> Guardar(SolicitudCitaInputModel citaInput)
        {
            SolicitudCita cita = mapearCita(citaInput);
            var request = _service.Save(cita);
            if (request.Error) return BadRequest(request.Mensaje);
            return Ok(request.Cita);
        }

        private SolicitudCita mapearCita(SolicitudCitaInputModel citaInput)
        {
            SolicitudCita cita = new SolicitudCita();
            cita.Fecha = citaInput.Fecha;
            cita.Estado = citaInput.Estado;
            cita.NoDocumentoPaciente = citaInput.NoDocumentoPaciente;
            return cita;
        }

        [HttpGet]
        public ActionResult<List<SolicitudCita>> Consultar()
        {
            var request = _service.Consult();
            if (request.Error) return BadRequest(request.Mensaje);
            return Ok(request.Citas);
        }

        [HttpGet("{id}")]
        public ActionResult<Paciente> Get(int id)
        {
            var request = _service.Find(id);
            if (request.Error) return BadRequest(request.Mensaje);
            return Ok(request.Cita);
        }

        [HttpPut("{id}")]
        public ActionResult<Paciente> Put(int id, SolicitudCita cita)
        {
            var request = _service.Update(cita, id);
            if (request.Error) return BadRequest(request.Mensaje);
            return Ok(request.Cita);
        }

    }
}
