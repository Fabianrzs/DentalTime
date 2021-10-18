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
        public ActionResult<ConsultaClinica> Guardar(ConsultaClinicaImputModel consultaClinicaImputModel)
        {
            ConsultaClinica consultaClinica = MapearConsultaClinica(consultaClinicaImputModel);
            var respuesta = _service.Guardar(consultaClinica);
            if (respuesta.Error)
            {
                return BadRequest(respuesta.Mensaje);
            }
            return Ok(respuesta.ConsultaClinica);
        }

        private ConsultaClinica MapearConsultaClinica(ConsultaClinicaImputModel consultaClinicaImputModel)
        {
            ConsultaClinica consultaClinica = new ConsultaClinica();
            consultaClinica.Motivo = consultaClinicaImputModel.Motivo;
            consultaClinica.Antecedentes = consultaClinicaImputModel.Antecedentes;
            consultaClinica.Medicacion = consultaClinicaImputModel.Medicacion;
            consultaClinica.UltimaConsulta = consultaClinicaImputModel.UltimaConsulta;
            consultaClinica.ValoracionMedica = consultaClinicaImputModel.ValoracionMedica;
            return consultaClinica;
        }
    }
}
