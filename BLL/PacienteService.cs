using System;
using DAL;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace BLL
{
    public class PacienteService
    {
        private readonly ConnectionManager connection;
        private readonly PacienteRepository repository;
        public PacienteService(string connectionString)
        {
            connection = new ConnectionManager(connectionString);
            repository = new PacienteRepository(connection);
        }

        public LogResponse GuardarPaciente(Paciente paciente)
        {
            try
            {
                connection.Open();
                repository.GuardarPaciente(paciente);
                return new LogResponse(paciente);
            }
            catch (Exception e) { return new LogResponse($"Error al Registra el pasciente se presento el siguien error {e.Message}"); }
            finally
            {
                connection.Close();
            }
        }

        public class LogResponse
        {
            public Paciente Paciente { get; set; }
            public string Mensaje { get; set; }
            public bool Error { get; set; }
            public LogResponse(string mensaje)
            {
                Mensaje = mensaje;
                Error = true;
            }
            public LogResponse(Paciente paciente)
            {
                Paciente = paciente;
                Error = false;
            }
        }

    }
}
