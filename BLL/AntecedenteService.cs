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

        public AntecendetenConsultaResponse Consult()
        {
            try
            {
                List<Antecedente> antecedentes = _context.Antecedentes.ToList();
                if (antecedentes != null)
                {
                    return new AntecendetenConsultaResponse(antecedentes);
                }
                return new AntecendetenConsultaResponse($"No se han agregado registros");
            }
            catch (Exception e) { return new AntecendetenConsultaResponse($"Error al Consultar: Se presento lo siguiente {e.Message}"); }
        }

        public AntecedenteLogResponse Find(string id){
            try
            {
                Antecedente antecedente = _context.Antecedentes.Find(id);

                if(antecedente != null){
                    return new AntecedenteLogResponse(antecedente);
                }
                return new AntecedenteLogResponse("Inicializar Historia Odontologia");
            }
            catch (Exception e)
            {
                return new AntecedenteLogResponse("Error en la aplicacion" + e.Message);
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

    public class AntecendetenConsultaResponse
    {
        public List<Antecedente> Antecedentes { get; set; }
        public string Mensaje { get; set; }
        public bool Error { get; set; }

        public AntecendetenConsultaResponse(List<Antecedente> antecedentes)
        {
            Antecedentes = antecedentes;
            Error = false;
        }

        public AntecendetenConsultaResponse(string mensaje)
        {
            Mensaje = mensaje;
            Error = true;
        }

    }
}
