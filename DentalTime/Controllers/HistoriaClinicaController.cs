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
    public class HistoriaClinicaController : ControllerBase
    {
        private HistorialClinicoService _service;
        
        public HistoriaClinicaController(DentalTimeContext dentalTimeContext)
        {
            _service = new HistorialClinicoService(dentalTimeContext);            
        }

        [HttpPost]
        public ActionResult<HistoriaOdontologica> Guardar(HistoriaClinicaInputModel historiaClinicaInput)
        {
            HistoriaOdontologica historiaClinica = mapearHistoria(historiaClinicaInput);
            var request = _service.Save(historiaClinica);
            if (request.Error) return BadRequest(request.Mensaje);
            return Ok(request.HistoriaClinica);
        }

        private HistoriaOdontologica mapearHistoria(HistoriaClinicaInputModel historiaClinicaInput)
        {
            HistoriaOdontologica historiaClinica = new HistoriaOdontologica();
            /*historiaClinica.CodConsultaOfHistoria = historiaClinicaInput.CodConsultaOfHistoria;
            historiaClinica.NoDocumentoOfHistoria = historiaClinicaInput.NoDocumentoOfHistoria;     */
            historiaClinica.FechaInicio = historiaClinicaInput.FechaHora;

            return historiaClinica;
        }
    }
}
