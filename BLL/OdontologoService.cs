using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class OdontologoService
    {
        private readonly DentalTimeContext _context;

        public OdontologoService (DentalTimeContext context)
        {
            _context = context;
        }

        public OdontologoLogResponse Save(Odontologo odontologo)
        {
            try
            {
                var buscarOdontologo = _context.Odontologos.Find(odontologo.NoDocumento);
                if (buscarOdontologo == null)
                {
                    _context.Odontologos.Add(odontologo);
                    _context.SaveChanges();
                    return new OdontologoLogResponse(odontologo);

                }
                return new OdontologoLogResponse ("Error el odontologo ya se encuentra registrado");
            }
            catch (Exception e)
            {
                return new OdontologoLogResponse ("Error en la aplicacion" + e.Message);
            }
        }

        public OdontologoLogResponse Find(string documento)
        {
            try
            {
                var buscarOdontologo = _context.Odontologos.Find(documento);
                if (buscarOdontologo != null)
                {
                    return new OdontologoLogResponse (buscarOdontologo);
                }
                return new OdontologoLogResponse ("Error el odontologo no se encuentra registrado");
            }
            catch (Exception e)
            {
                return new OdontologoLogResponse ("Error en la aplicacion" + e.Message);
            }
        }

        public OdontologoConsultaResponse Consult()
        {
            try
            {
                List<Odontologo> odontologos = _context.Odontologos.ToList();
                if (odontologos != null)
                {
                    return new OdontologoConsultaResponse (odontologos);
                }
                return new OdontologoConsultaResponse ($"No se han agregado registros");
            }
            catch (Exception e) { return new OdontologoConsultaResponse ($"Error al Consultar: Se presento lo siguiente {e.Message}"); }
        }

    }

    public class OdontologoLogResponse
    {
        public Odontologo Odontologo{ get; set; }
        public string Mensaje { get; set; }
        public bool Error { get; set; }


        public OdontologoLogResponse (string mensaje)
        {
            Mensaje = mensaje;
            Error = true;
        }

        public OdontologoLogResponse (Odontologo odontologo)
        {
            Odontologo = odontologo;
            Error = false;
        }

    }
    public class OdontologoConsultaResponse
    {
        public List<Odontologo> Odontologos { get; set; }
        public string Mensaje { get; set; }
        public bool Error { get; set; }


        public OdontologoConsultaResponse (string mensaje)
        {
            Mensaje = mensaje;
            Error = true;
        }

        public OdontologoConsultaResponse (List<Odontologo> odontologos)
        {
            Odontologos = odontologos;
            Error = false;
        }

    }
}

