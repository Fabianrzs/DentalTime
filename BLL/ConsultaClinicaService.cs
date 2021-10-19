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

        public ConsultaClinicaService(DentalTimeContext context)
        {
            _context = context;
        }

        public ConsultaClinicaLogResponse Save(ConsultaClinica consultaClinica)
        {
            try
            {
                _context.ConsultasClinicas.Add(consultaClinica);
                _context.SaveChanges();
                return new ConsultaClinicaLogResponse(consultaClinica);
            }
            catch (Exception e)
            {
                return new ConsultaClinicaLogResponse($"Error al Guardar: Se presento lo siguiente {e.Message}");
            }
        }

        public ConsultaClinicaLogResponse Find()
        {
            try
            {
                ConsultaClinica consulta = _context.ConsultasClinicas.OrderByDescending(c => c.CodConsultaClinica).FirstOrDefault();

                if (consulta == null)
                {
                    return new ConsultaClinicaLogResponse($"Error al buscar: consulta no asociada");
                }
                return new ConsultaClinicaLogResponse(consulta);
            }
            catch (Exception e)
            {
                return new ConsultaClinicaLogResponse($"Error al Buscar: Se presento lo siguiente {e.Message}");
            }

        }

        public ConsultaClinicaConsultaResponse Consult()
        {
            try
            {
                List<ConsultaClinica> consultas = _context.ConsultasClinicas.ToList();
                if (consultas != null)
                {
                    return new ConsultaClinicaConsultaResponse(consultas);
                }
                return new ConsultaClinicaConsultaResponse($"No se han agregado registros");
            }
            catch (Exception e) { return new ConsultaClinicaConsultaResponse($"Error al Consultar: Se presento lo siguiente {e.Message}"); }
        }

    }

    public class ConsultaClinicaLogResponse
    {
        public ConsultaClinica ConsultaClinica { get; set; }
        public string Mensaje { get; set; }
        public bool Error { get; set; }

        public ConsultaClinicaLogResponse(ConsultaClinica consultaClinica)
        {
            ConsultaClinica = consultaClinica;
            Error = false;
        }

        public ConsultaClinicaLogResponse(string mensaje)
        {
            Mensaje = mensaje;
            Error = true;
        }

    }

    public class ConsultaClinicaConsultaResponse
    {
        public List<ConsultaClinica> ConsultaClinicas { get; set; }
        public string Mensaje { get; set; }
        public bool Error { get; set; }

        public ConsultaClinicaConsultaResponse(List<ConsultaClinica> consultaClinica)
        {
            ConsultaClinicas = consultaClinica;
            Error = false;
        }

        public ConsultaClinicaConsultaResponse(string mensaje)
        {
            Mensaje = mensaje;
            Error = true;
        }

    }
}
