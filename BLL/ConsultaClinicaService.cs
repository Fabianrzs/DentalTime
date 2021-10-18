using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ConsultaClinicaService
    {

        private readonly DentalTimeContext _context;

        public ConsultaClinicaService (DentalTimeContext context)
        {
            _context = context;
        }

        public ConsultaClinicaGuardarResponse Guardar(ConsultaClinica consultaClinica)
        {
            try
            {
                _context.ConsultasClinicas.Add(consultaClinica);
                _context.SaveChanges();
                return new ConsultaClinicaGuardarResponse(consultaClinica);
            }
            catch (Exception e)
            {
                return new ConsultaClinicaGuardarResponse ($"Error al Guardar: Se presento lo siguiente {e.Message}");
            }
        }

    }

    public class ConsultaClinicaGuardarResponse
    {
        public ConsultaClinica ConsultaClinica{ get; set; }
        public string Mensaje { get; set; }
        public bool Error { get; set; }

        public ConsultaClinicaGuardarResponse(ConsultaClinica consultaClinica)
        {
            ConsultaClinica = consultaClinica;
            Error = false;
        }

        public ConsultaClinicaGuardarResponse(string mensaje)
        {
            Mensaje = mensaje;
            Error = true;
        }

    }
}
