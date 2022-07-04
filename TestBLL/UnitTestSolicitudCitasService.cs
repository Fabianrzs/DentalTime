using BLL;
using DAL;
using NUnit.Framework;

namespace TestBLL
{
    public class UnitTestSolicitudCitaService
    {
        private SolicitudCitaService service;

        [SetUp]
        public void Setup()
        {
            service = new SolicitudCitaService(new DentalTimeContext());
        }

        [Test]
        public void SaveSolicitudCita()
        {
            var request = service.Save(new Entity.SolicitudCita());
            Assert.IsFalse(request.Error); //Sin error 
            Assert.IsNotNull(request.Cita); //Datos Enviados a guardar
        }

        [Test]
        public void SaveSolicitudCitaFake()
        {
            var request = service.Save(new Entity.SolicitudCita());
            Assert.IsTrue(request.Error); //Con error al guardar
            Assert.AreEqual(request.Mensaje, "$Error al Guardar"); //Mensaje de error al Guardar
        }

        [Test]
        public void ConsultSolicitudCita()
        {
            var request = service.Consult();
            Assert.IsFalse(request.Error); //Sin error 
            Assert.IsNotNull(request.Citas); //Consultas
        }

        [Test]
        public void ConsultSolicitudCitaFake()
        {
            var request = service.Consult();
            Assert.IsTrue(request.Error); //Con error al consultar
            Assert.AreEqual(request.Mensaje, $"No se han agregado registros"); //Mensaje de error al consultar
        }
    }
}