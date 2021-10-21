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
    public class ConsultaClinicaController : ControllerBase
    {

        private ConsultaClinicaService _service;

        public ConsultaClinicaController(DentalTimeContext context)
        {
            _service = new ConsultaClinicaService(context);
        }

        [HttpPost]
        public ActionResult<ConsultaOdontologica> Guardar(ConsultaClinicaInputModel consultaClinicaImputModel)
        {
            var consultaClinica = MapearConsultaClinica(consultaClinicaImputModel);
            var request = _service.Save(consultaClinica);
            if (request.Error) return BadRequest(request.Mensaje);
            return Ok(request.ConsultaClinica);
        }

        private ConsultaOdontologica MapearConsultaClinica(ConsultaClinicaInputModel consultaClinicaImputModel)
        {
            ConsultaOdontologica consultaClinica = new ConsultaOdontologica();
            consultaClinica.Motivo = consultaClinicaImputModel.Motivo;
            /*consultaClinica.Antecedentes = consultaClinicaImputModel.Antecedentes;
            consultaClinica.RecetaClinica = consultaClinicaImputModel.Medicacion;
            consultaClinica.UltimaConsulta = consultaClinicaImputModel.UltimaConsulta;
            consultaClinica.ValoracionMedica = consultaClinicaImputModel.ValoracionMedica;*/
            return consultaClinica;
        }
    }
}
