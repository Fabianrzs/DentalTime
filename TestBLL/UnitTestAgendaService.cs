using BLL;
using DAL;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace TestBLL
{
    public class UnitTestAgendaService
    {
        private AgendaService service;

        string stringConnections = "Server=DKP-FABIAN\\SQLEXPRESS;Database=DBDental;Trusted_Connection = True; MultipleActiveResultSets = true";

        [SetUp]
        public void Setup()
        {
            var contextOptions = new DbContextOptionsBuilder<DentalTimeContext>().UseSqlServer(stringConnections).Options;
            DentalTimeContext Db = new DentalTimeContext(contextOptions);
            service = new AgendaService(Db);
        }

        [Test]
        public void SaveAgenda()
        {
            var agenda = new Entity.Agenda()
            {
                NoDocumento = "1234",
                FechaInicio = new System.DateTime(06/16/2022),
                FechaFin = new System.DateTime(07 / 16 / 2022),
                Estado = "Disponible"
            };

            var request = service.Save(agenda);
            Assert.IsNotNull(request.Agenda); //Datos Enviados a guardar
        }

        [Test]
        public void SaveAgendaFechaOcupada()
        {
            var agenda = new Entity.Agenda()
            {
                NoDocumento = "1234",
                FechaInicio = new System.DateTime(06/16/2022),
                FechaFin = new System.DateTime(07/16/ 2022),
                Estado = "Disponible"
            };
            var request = service.Save(agenda);
            Assert.AreEqual("Error al Guardar: Fecha Ocupada",request.Mensaje); //Datos Enviados a guardar
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