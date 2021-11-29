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
    public class ConsultaOdontologicaController : ControllerBase
    {

        private ConsultaClinicaService _service;
        private readonly IHubContext<SignalHub> _hubContext;

        public ConsultaOdontologicaController(DentalTimeContext context, IHubContext<SignalHub> hubContext)
        {
            _hubContext = hubContext;
            _service = new ConsultaClinicaService(context);
        }

        [HttpPost]
        public async Task<ActionResult<ConsultaOdontologica>> GuardarAsync(ConsultaClinicaInputModel consultaInput)
        {
            var consultaClinica = MapearConsultaClinica(consultaInput);
            var request = _service.Save(consultaClinica);
            if (request.Error)
            {
                ModelState.AddModelError("Guardar Consulta Odontologica", request.Mensaje);
                var problemDetails = new ValidationProblemDetails(ModelState)
                {
                    Status = StatusCodes.Status400BadRequest,
                };
                return BadRequest(problemDetails);
            }
            await _hubContext.Clients.All.SendAsync("SignalMessageReceived", consultaInput);
            return Ok(request.ConsultaClinica);
        }

        private ConsultaOdontologica MapearConsultaClinica(ConsultaClinicaInputModel consultaInput)
        {
            ConsultaOdontologica consultaClinica = new ConsultaOdontologica();
            consultaClinica.Motivo = consultaInput.Motivo;
            /*consultaClinica.Antecedentes = consultaClinicaImputModel.Antecedentes;
            consultaClinica.RecetaClinica = consultaClinicaImputModel.Medicacion;
            consultaClinica.UltimaConsulta = consultaClinicaImputModel.UltimaConsulta;
            consultaClinica.ValoracionMedica = consultaClinicaImputModel.ValoracionMedica;*/
            return consultaClinica;
        }
    }
}
