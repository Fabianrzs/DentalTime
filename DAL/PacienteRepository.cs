using Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL
{
    public class PacienteRepository
    {
        private readonly SqlConnection _connection;
        public PacienteRepository(ConnectionManager connection)
        {
            _connection = connection.connection;
        }

        public void GuardarPaciente(Paciente paciente)
        {
            using(var command = _connection.CreateCommand())
            {
                command.CommandText = @"insert into Paciente (Identificacion, Nombres, Apellidos,Sexo,FechaNacimiento,Tipo, TipoSaguineo, NumeroTelefonico, CorreoElectronico, Antecedentes, Complicaciones)
                    values(@Identificacion,@Nombres,@Apellidos,@Sexo,@FechaNacimiento,@Tipo,@TipoSaguineo,@NumeroTelefonico,@CorreoElectronico,@Antecedentes,@Complicaciones); ";
                command.Parameters.AddWithValue("@Identificacion",paciente.Identificacion);
                command.Parameters.AddWithValue("@Nombres", paciente.Nombres);
                command.Parameters.AddWithValue("@Apellidos", paciente.Apellidos);
                command.Parameters.AddWithValue("@Sexo", paciente.Sexo);
                command.Parameters.AddWithValue("@FechaNacimiento", paciente.FechaNacimiento);
                command.Parameters.AddWithValue("@Tipo", paciente.Tipo);
                command.Parameters.AddWithValue("@TipoSaguineo", paciente.TipoSaguineo);
                command.Parameters.AddWithValue("@NumeroTelefonico", paciente.NumeroTelefonico);
                command.Parameters.AddWithValue("@CorreoElectronico", paciente.CorreoElectronico);
                command.Parameters.AddWithValue("@Antecedentes", paciente.Antecedentes);
                command.Parameters.AddWithValue("@Complicaciones", paciente.Complicaciones);
                command.ExecuteNonQuery();
            }
        }

    }
}
