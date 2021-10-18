using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PacienteService
    {
        private readonly DentalTimeContext _context;

        public PacienteService(DentalTimeContext context)
        {
            _context = context;
        }

        public PacienteResponse Guardar(Paciente paciente)
        {
            try
            {
                var buscarPaciente = _context.Pacientes.Find(paciente.NoDocumeto);
                if (buscarPaciente != null)
                {
                    return new PacienteResponse("Error el paciente ya se encuentra registrada");
                }
                _context.Pacientes.Add(paciente);
                _context.SaveChanges();
                return new PacienteResponse(paciente);
            }
            catch (Exception e)
            {
                return new PacienteResponse("Error en la aplicacion"+e.Message);
            }
        }

    }

    public class PacienteResponse
    {
        public Paciente Paciente { get; set; }
        public string Mensaje { get; set; }
        public bool Error { get; set; }


        public PacienteResponse(string mensaje)
        {
            Mensaje = mensaje;
            Error = true;
        }

        public PacienteResponse(Paciente paciente)
        {
            Paciente = paciente;
            Error = false;
        }

    }
}
