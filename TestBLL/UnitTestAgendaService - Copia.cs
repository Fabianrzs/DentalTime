using BLL;
using DAL;
using NUnit.Framework;

namespace TestBLL
{
    public class UnitTestAgendaService1
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
            Assert.AreEqual(3, 3);
        }

        [Test]
        public void SaveAgendaFake()
        {
            Assert.AreEqual(3, 2);
        }
        [Test]
        public void SaveAgenda1()
        {
            Assert.AreEqual(3, 3);
        }

        [Test]
        public void SaveAgendaFake1()
        {
            Assert.AreEqual(3, 2);
        }
        [Test]
        public void SaveAgenda11()
        {
            Assert.AreEqual(3, 3);
        }

        [Test]
        public void SaveAgendaFake11()
        {
            Assert.AreEqual(3, 2);
        }
        [Test]
        public void SaveAgenda111()
        {
            Assert.AreEqual(3, 3);
        }

        [Test]
        public void SaveAgendaFake111()
        {
            Assert.AreEqual(3, 2);
        }
        [Test]
        public void SaveAgenda1111()
        {
            Assert.AreEqual(3, 3);
        }

        [Test]
        public void SaveAgendaFake1111()
        {
            Assert.AreEqual(3, 2);
        }
        [Test]
        public void SaveAgenda11111()
        {
            Assert.AreEqual(3, 3);
        }

        [Test]
        public void SaveAgendaFake11111()
        {
            Assert.AreEqual(3, 2);
        }
        [Test]
        public void SaveAgenda111111()
        {
            Assert.AreEqual(3, 3);
        }

        [Test]
        public void SaveAgendaFake111111()
        {
            Assert.AreEqual(3, 2);
        }
        [Test]
        public void SaveAgenda11111111()
        {
            Assert.AreEqual(3, 3);
        }

        [Test]
        public void SaveAgendaFake11111111()
        {
            Assert.AreEqual(3, 2);
        }
        [Test]
        public void SaveAgenda111111111()
        {
            Assert.AreEqual(3, 3);
        }

        [Test]
        public void SaveAgendaFa1ke111111()
        {
            Assert.AreEqual(3, 2);
        }
        [Test]
        public void SaveAgen1a()
        {
            Assert.AreEqual(3, 3);
        }

        [Test]
        public void SaveAgendaF1ake()
        {
            Assert.AreEqual(3, 2);
        }


    }
}