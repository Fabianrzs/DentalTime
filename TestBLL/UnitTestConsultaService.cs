using BLL;
using DAL;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace TestBLL
{
    public class UnitTestConsultaService
    {
        private ConsultaClinicaService service;

        string stringConnections = "Server=DKP-FABIAN\\SQLEXPRESS;Database=DBDental;Trusted_Connection = True; MultipleActiveResultSets = true";

        [SetUp]
        public void Setup()
        {
            var contextOptions = new DbContextOptionsBuilder<DentalTimeContext>().UseSqlServer(stringConnections).Options;
            DentalTimeContext Db = new DentalTimeContext(contextOptions);
            service = new ConsultaClinicaService(Db);
        }

        [Test]
        public void SaveConsulta()
        {
            var consulta = new Entity.ConsultaOdontologica()
            {
                IdSolicitudCita = 001,
                IdAntecedentes = 4541,
                IdConsultaOdontologica = 0321,
                IdServicio = 504,
                Diagnostico = "Valoreacion por diagnostico",
                Medicacion = "Paracetamol",
                Motivo = "Dolor en los superiores temporales",
                RecetaMedica = "Tabletas cada que el dolor aunmente o en su defecto cada 24 Horas",
                Valoracion = "El dolor se da por razones de caries"
            };

            var request = service.Save(consulta);
            Assert.IsNotNull(request.ConsultaClinica); //Datos Enviados a guardar
        }

        [Test]
        public void SaveConsultaNull()
        {
            var consulta = new Entity.ConsultaOdontologica()
            {
                //Datos de la consulta nulos 
            };
            var request = service.Save(consulta);
            Assert.IsFalse(request.Error); //Error por valores nulos
        }

        //[Test]
        //public void SaveAgendaFake()
        //{
        //    var request = service.Save(new Entity.Agenda());
        //    Assert.IsTrue(request.Error); //Con error al guardar
        //    Assert.AreEqual(request.Mensaje, "$Error al Guardar:"); //Mensaje de error al Guardar
        //}

        //[Test]
        //public void ConsultAgenda()
        //{
        //    var request = service.Consult("1003315428");
        //    Assert.IsFalse(request.Error); //Sin error 
        //    Assert.IsNotNull(request.Agendas); //Consultas
        //}

        //[Test]
        //public void ConsultAgendaFake()
        //{
        //    var request = service.Consult("1003315428");
        //    Assert.IsTrue(request.Error); //Con error al consultar
        //    Assert.AreEqual(request.Mensaje, $"No se han agregado registros"); //Mensaje de error al consultar
        //}
    }
}