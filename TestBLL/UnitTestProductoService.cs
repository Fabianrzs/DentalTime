using BLL;
using DAL;
using NUnit.Framework;

namespace TestBLL
{
    public class UnitTestProductoService
    {
        private ProductoService service;

        [SetUp]
        public void Setup()
        {
            service = new ProductoService(new DentalTimeContext());
        }

        [Test]
        public void SaveProducto()
        {
            var request = service.Save(new Entity.Producto());
            Assert.IsFalse(request.Error); //Sin error 
            Assert.IsNotNull(request.Producto); //Datos Enviados a guardar
        }

        [Test]
        public void SaveProductoFake()
        {
            var request = service.Save(new Entity.Producto());
            Assert.IsTrue(request.Error); //Con error al guardar
            Assert.AreEqual(request.Mensaje, "$Error al Guardar"); //Mensaje de error al Guardar
        }

        [Test]
        public void ConsultProducto()
        {
            var request = service.Consult();
            Assert.IsFalse(request.Error); //Sin error 
            Assert.IsNotNull(request.Productos); //Consultas
        }

        [Test]
        public void ConsultProductoFake()
        {
            var request = service.Consult();
            Assert.IsTrue(request.Error); //Con error al consultar
            Assert.AreEqual(request.Mensaje, $"No se han agregado registros"); //Mensaje de error al consultar
        }
    }
}