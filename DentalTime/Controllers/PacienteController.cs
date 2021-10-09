using BLL;
using DentalTime.Models;
using Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentalTime.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        private readonly PacienteService service;
        public IConfiguration Configuration { get; }

        public PacienteController(IConfiguration configuration)
        {
            Configuration = configuration;
            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            service = new PacienteService(connectionString);
        }

        private Paciente mapPaciente(PacienteInputModels pacienModels)
        {
            Paciente paciente = new Paciente();
            paciente.Identificacion = pacienModels.Identificacion;
            paciente.Nombres = pacienModels.Nombres;
            paciente.Apellidos = pacienModels.Apellidos;
            paciente.Sexo = pacienModels.Sexo;
            paciente.FechaNacimiento = pacienModels.FechaNacimiento;
            paciente.Tipo = pacienModels.Tipo;
            paciente.TipoSaguineo = pacienModels.TipoSaguineo;
            paciente.NumeroTelefonico = pacienModels.NumeroTelefonico;
            paciente.CorreoElectronico = pacienModels.CorreoElectronico;
            paciente.Antecedentes = pacienModels.Antecedentes;
            paciente.Complicaciones = pacienModels.Complicaciones;

            return paciente;
        }

        [HttpPost]
        public ActionResult<Paciente> Guardar(PacienteInputModels pacienModels)
        {
            var paciente = mapPaciente(pacienModels);
            var respuesta = service.GuardarPaciente(paciente);
            if(respuesta.Error) return BadRequest(respuesta.Mensaje);
            return Ok(paciente);
        }
    }
}
