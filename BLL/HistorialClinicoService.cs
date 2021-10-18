using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class HistorialClinicoService
    {
        private readonly DentalTimeContext _context;

        public HistorialClinicoService(DentalTimeContext context)
        {
            _context = context;
        }

        public HistorialRegistroResponse Guardar(HistoriaClinica historia)
        {
            try
            {
                _context.HistoriasClinicas.Add(historia);
                return new HistorialRegistroResponse(historia);
            }
            catch (Exception e) 
            { 
                return new HistorialRegistroResponse($"Error al Guardar: Se presento lo siguiente {e.Message}"); 
            }
        }


    }
    public class HistorialRegistroResponse
    {
        public HistoriaClinica HistoriaClinica { get; set; }
        public string Mensaje { get; set; }
        public bool Error { get; set; }

        public HistorialRegistroResponse(HistoriaClinica historiaClinica)
        {
            HistoriaClinica = historiaClinica;
            Error = false;
        }

        public HistorialRegistroResponse(string mensaje)
        {
            Mensaje = mensaje;
            Error = true;
        }

    }
    public class HistorialConsultaResponse
    {
        public List<HistoriaClinica> HistoriasClinicas { get; set; }
        public string Mensaje { get; set; }
        public bool Error { get; set; }

        public HistorialConsultaResponse(List<HistoriaClinica> historiasClinicas)
        {
            HistoriasClinicas = historiasClinicas;
            Error = false;
        }

        public HistorialConsultaResponse(string mensaje)
        {
            Mensaje = mensaje;
            Error = true;
        }

    }
}
