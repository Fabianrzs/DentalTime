using BLL;
using DAL;
using NUnit.Framework;

namespace TestBLL
{
    public class UnitTestAgendaService
    {
        private AgendaService service;

        [SetUp]
        public void Setup()
        {
            service = new AgendaService(new DentalTimeContext());
        }

        [Test]
        public void SaveAgenda()
        {
            //var request = service.Save(new Entity.Agenda());
            //Assert.IsFalse(request.Error); //Sin error 
            //Assert.IsNotNull(request.Agenda); //Datos Enviados a guardar
        }

        [Test]
        public void SaveAgendaFake()
        {
            var request = service.Save(new Entity.Agenda());
            Assert.IsTrue(request.Error); //Con error al guardar
            Assert.AreEqual(request.Mensaje, "$Error al Guardar:"); //Mensaje de error al Guardar
        }

        [Test]
        public void ConsultAgenda()
        {
            var request = service.Consult("1003315428");
            Assert.IsFalse(request.Error); //Sin error 
            Assert.IsNotNull(request.Agendas); //Consultas
        }

        [Test]
        public void ConsultAgendaFake()
        {
            var request = service.Consult("1003315428");
            Assert.IsTrue(request.Error); //Con error al consultar
            Assert.AreEqual(request.Mensaje, $"No se han agregado registros"); //Mensaje de error al consultar
        }
    }
}