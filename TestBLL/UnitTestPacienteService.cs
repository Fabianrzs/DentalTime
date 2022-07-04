using BLL;
using DAL;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace TestBLL
{
    public class UnitTestPacienteService
    {
        private PacienteService service;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<DentalTimeContext>().UseSqlServer("Server=DKP-FABIAN\\SQLEXPRESS;Database=DBDental;Trusted_Connection = True; MultipleActiveResultSets = true");
            service = new PacienteService(new DentalTimeContext());
        }

        [Test]
        public void SavePaciente()
        {

            var paciente = new Entity.Paciente()
            {
                TipoDocumento = "CC",
                NoDocumento = "1004121505",
                Nombres = "Andres alfonso",
                Apellidos = "Pertuz Perez",
                FechaNacimiento = new System.DateTime(),
                LugarNacimiento = "Pivijay",
                CorreoElectronico = "aalfonsopertuz@unicesar.edu.co",
                NumeroTelefonico = " 321987456",
                Sexo = "M",
                TipoSanguineo = "O-"
            };

            var request = service.Save(paciente);
            Assert.AreEqual("", (request.Mensaje));
            Assert.IsFalse(request.Error); //Sin error 
            Assert.IsNotNull(request.Paciente); //Datos Enviados a guardar
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