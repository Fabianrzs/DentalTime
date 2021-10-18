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
    public class PacienteController : ControllerBase
    {
        private PacienteService _pacienteService;

        public PacienteController(DentalTimeContext context)
        {
            _pacienteService = new PacienteService (context);
        }

        public ActionResult<Paciente> Guardar(PacienteImputModel pacienteImput)
        {
            Paciente paciente = MapearPaciente(pacienteImput);
            PacienteResponse pacienteResponse = _pacienteService.Guardar(paciente);
            if (pacienteResponse.Error)
            {
                return BadRequest(pacienteResponse.Mensaje);
            }
            return Ok(pacienteResponse.Paciente);
        }

        private Paciente MapearPaciente(PacienteImputModel pacienteImput)
        {
            var paciente = new Paciente();
            paciente.TipoDocumento = pacienteImput.TipoDocumento;
            paciente.NoDocumeto = pacienteImput.NoDocumeto;
            paciente.Nombres = pacienteImput.Nombres;
            paciente.Apellidos = pacienteImput.Apellidos;
            paciente.Sexo = pacienteImput.Sexo;
            paciente.FechaNacimiento = pacienteImput.FechaNacimiento;
            paciente.PaisNacimiento = pacienteImput.PaisNacimiento;
            paciente.CiudadNacimiento = pacienteImput.CiudadNacimiento;
            paciente.TipoSaguineo = pacienteImput.TipoSaguineo;
            paciente.NumeroTelefonico = pacienteImput.NumeroTelefonico;
            paciente.CorreoElectronico = pacienteImput.CorreoElectronico;
            return paciente;
        }
    }
}
