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
        private PacienteService _service;

        public PacienteController(DentalTimeContext context)
        {
            _service = new PacienteService (context);
        }

        [HttpPost]
        public ActionResult<Paciente> Guardar(PacienteInputModel pacienteImput)
        {
            Paciente paciente = MapearPaciente(pacienteImput);
            var request = _service.Save(paciente);
            if (request.Error)
            {
                return BadRequest(request.Mensaje);
            }
            return Ok(request.Paciente);
        }

        private Paciente MapearPaciente(PacienteInputModel pacienteImput)
        {
            var paciente = new Paciente();
            paciente.TipoDocumento = pacienteImput.TipoDocumento;
            paciente.NoDocumento = pacienteImput.NoDocumeto;
            paciente.Nombres = pacienteImput.Nombres;
            paciente.Apellidos = pacienteImput.Apellidos;
            paciente.Sexo = pacienteImput.Sexo;
            paciente.FechaNacimiento = pacienteImput.FechaNacimiento;
          /**  paciente.PaisNacimiento = pacienteImput.PaisNacimiento;
            paciente.CiudadNacimiento = pacienteImput.CiudadNacimiento;
            paciente.TipoSaguineo = pacienteImput.TipoSaguineo; **/
            paciente.NumeroTelefonico = pacienteImput.NumeroTelefonico;
            paciente.CorreoElectronico = pacienteImput.CorreoElectronico;
            return paciente;
        }

        [HttpGet]
        public ActionResult<List<Paciente>> Consulta()
        {
            var request = _service.Consult();
            if (request.Error) return BadRequest(request.Mensaje);
            return Ok(request.Pacientes);
        }

    }
}
