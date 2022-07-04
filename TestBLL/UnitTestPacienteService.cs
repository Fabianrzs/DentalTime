using BLL;
using DAL;
using NUnit.Framework;

namespace TestBLL
{
    public class UnitTestPacienteService
    {
        private PacienteService service;

        [SetUp]
        public void Setup()
        {
            service = new PacienteService(new DentalTimeContext());
        }

        [Test]
        public void SavePaciente()
        {
            var request = service.Save(new Entity.Paciente());
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