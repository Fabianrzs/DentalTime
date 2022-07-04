using BLL;
using DAL;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace TestBLL
{
    public class UnitTestPacienteService
    {
        private PacienteService service;

        string stringConnections = "Server=DKP-FABIAN\\SQLEXPRESS;Database=DBDental;Trusted_Connection = True; MultipleActiveResultSets = true";

        [SetUp]
        public void Setup()
        {
            var contextOptions = new DbContextOptionsBuilder<DentalTimeContext>().UseSqlServer(stringConnections).Options;
            DentalTimeContext Db = new DentalTimeContext(contextOptions);
            service = new PacienteService(Db);
        }

        [Test]
        public void SavePaciente()
        {

            var paciente = new Entity.Paciente()
            {
                TipoDocumento = "CC",
                NoDocumento = "1001505431",
                Nombres = "Fabian",
                Apellidos = "This",
                LugarNacimiento = "Valledupar",
                CorreoElectronico = "RR@unicesar.edu.co",
                NumeroTelefonico = " 3219874560",
                Sexo = "M",
                TipoSanguineo = "A-"
            };

            var request = service.Save(paciente);
            Assert.IsNotNull(request.Paciente); //Datos Enviados a guardar
        }

        [Test]
        public void SavePacienteFallo()
        {

            var paciente = new Entity.Paciente()
            {
                TipoDocumento = null, //Campo que falla 
                NoDocumento = "1001505431",
                Nombres = "Fabian",
                Apellidos = "This",
                LugarNacimiento = "Valledupar",
                CorreoElectronico = "RR@unicesar.edu.co",
                NumeroTelefonico = " 3219874560",
                Sexo = "M",
                TipoSanguineo = "A-"
            };

            var request = service.Save(paciente);
            Assert.IsNotNull(request.Paciente.TipoDocumento);
        }

        [Test]
        public void SavePacienteFake()
        {
            var request = service.Save(new Entity.Paciente());
            Assert.IsTrue(request.Error); //Con error al guardar
            Assert.AreEqual(request.Mensaje, "$Error al Guardar:"); //Mensaje de error al Guardar
        }

        [Test]
        public void ConsultPaciente()
        {
            var request = service.Consult();
            Assert.IsFalse(request.Error); //Sin error 
            Assert.IsNotNull(request.Pacientes); //Consultas
        }

        [Test]
        public void ConsultPacienteFake()
        {
            var request = service.Consult();
            Assert.IsTrue(request.Error); //Con error al consultar
            Assert.AreEqual(request.Mensaje, $"No se han agregado registros"); //Mensaje de error al consultar
        }
    }
}