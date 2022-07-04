using BLL;
using DAL;
using NUnit.Framework;

namespace TestBLL
{
    public class UnitTestServicioService
    {
        private ServicioService service;

        [SetUp]
        public void Setup()
        {
            service = new ServicioService(new DentalTimeContext());
        }

        [Test]
        public void SaveServicio()
        {
            var request = service.Save(new Entity.Servicio());
            Assert.IsFalse(request.Error); //Sin error 
            Assert.IsNotNull(request.Servicio); //Datos Enviados a guardar
        }

        [Test]
        public void SaveServicioFake()
        {
            var request = service.Save(new Entity.Servicio());
            Assert.IsTrue(request.Error); //Con error al guardar
            Assert.AreEqual(request.Mensaje, "$Error al Guardar"); //Mensaje de error al Guardar
        }

        [Test]
        public void ConsultServicio()
        {
            var request = service.Consult();
            Assert.IsFalse(request.Error); //Sin error 
            Assert.IsNotNull(request.Servicios); //Consultas
        }

        [Test]
        public void ConsultServicioFake()
        {
            var request = service.Consult();
            Assert.IsTrue(request.Error); //Con error al consultar
            Assert.AreEqual(request.Mensaje, $"No se han agregado registros"); //Mensaje de error al consultar
        }
    }
}