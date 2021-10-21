using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class InventarioService
    {
        private readonly DentalTimeContext _context;

        public InventarioService(DentalTimeContext context)
        {
            _context = context;
        }

        public InventarioLogResponse Save(Inventario inventario)
        {
            try
            {
                _context.Inventarios.Add(inventario);
                _context.SaveChanges();
                return new InventarioLogResponse(inventario);
            }
            catch (Exception e){ return new InventarioLogResponse($"Error al Guardar: Se presento lo siguiente {e.Message}"); }
        }

        public InventarioLogResponse Find(string idInventario)
        {
            try
            {
                Inventario inventario = _context.Inventarios.Find(idInventario);
                if (inventario != null)
                {
                    return new InventarioLogResponse(inventario);
                }
                return new InventarioLogResponse($"No se encuentra el registro buscado");
            }
            catch (Exception e) { return new InventarioLogResponse($"Error al Buscar: Se presento lo siguiente {e.Message}"); }
        }
    }

    public class InventarioLogResponse
    {
        public Inventario Inventario { get; set; }
        public string Mensaje { get; set; }
        public bool Error { get; set; }

        public InventarioLogResponse(Inventario inventario)
        {
            Inventario = inventario;
            Error = false;
        }

        public InventarioLogResponse(string mensaje)
        {
            Mensaje = mensaje;
            Error = true;
        }
    }
}
