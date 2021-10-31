using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class AntecedenteService
    {
        private readonly DentalTimeContext _context;
        
        public AntecedenteService(DentalTimeContext context)
        {
            _context = context;
        }

        public AntecedenteLogResponse Save(Antecedente antecedentes)
        {
            try
            {
                if (_context.Antecedentes.Find(antecedentes.IdAntecedente) == null)
                {
                    _context.Antecedentes.Add(antecedentes);
                    _context.SaveChanges();
                    return new AntecedenteLogResponse(antecedentes);
                }
                return new AntecedenteLogResponse($"Ya esta persona tiene antedesendes registrados");
            }
            catch (Exception e)
            {
                return new AntecedenteLogResponse($"Error al Guardar: Se presento lo siguiente {e.Message}");
            }
        }

    }

    public class AntecedenteLogResponse
    {
        public Antecedente Antecedente { get; set; }
        public bool Error { get; set; }
        public string Mensaje { get; set; }

        public AntecedenteLogResponse(Antecedente antecedentes)
        {
            Antecedente = antecedentes;
            Error = false;
        }

        public AntecedenteLogResponse(string mensaje)
        {
            Mensaje = mensaje;
            Error = true;
        }

    }
}
