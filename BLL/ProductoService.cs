using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ProductoService
    {
        private readonly DentalTimeContext _context;
        public ProductoService(DentalTimeContext context)
        {
            _context = context;
        }

        public LogResponse Guardar(Producto producto)
        {
            try
            {
                if(_context.Productos.Find(producto.Referencia) == null)
                {
                    _context.Productos.Add(producto);
                    return new LogResponse(producto);
                }
                return new LogResponse($"El producto ya se encuentra registrado");
            }
            catch (Exception e) { return new LogResponse($"Error al Guardar: Se presento lo siguiente {e.Message}"); }
        }

        public LogResponse Modificar(Producto productoNew, string referencia)
        {
            try
            {
                Producto producto = _context.Productos.Find(referencia);
                if (producto != null)
                {
                    producto = productoNew;
                    _context.Productos.Update(producto);
                    return new LogResponse(producto);
                }
                return new LogResponse($"No se encuentra registro a modificar");
            }
            catch (Exception e) { return new LogResponse($"Error al Modificar: Se presento lo siguiente {e.Message}"); }
        }

        public LogResponse Find (string referencia)
        {
            try
            {
                Producto producto = _context.Productos.Find(referencia);
                if (producto != null)
                {
                    return new LogResponse(producto);
                }
                return new LogResponse($"No se encuentra el registro buscado");
            }
            catch (Exception e) { return new LogResponse($"Error al Buscar: Se presento lo siguiente {e.Message}"); }
        }

        public string Delete (string referencia)
        {
            try
            {
                Producto producto = _context.Productos.Find(referencia);
                if (producto != null)
                {
                    _context.Productos.Remove(producto);
                    return "Registro eliminado satisfactoriamente";
                }
                return ($"No se encuentra el registro a eliminar");
            }
            catch (Exception e) { return ($"Error al Eliminar: Se presento lo siguiente {e.Message}"); }
        }

        public ConsultaResponse Consultar ()
        {
            try
            {
                List<Producto> productos = _context.Productos.ToList();
                if (productos != null)
                {
                    return new ConsultaResponse(productos);
                }
                return new ConsultaResponse($"No se han agregado registros");
            }
            catch (Exception e) { return new ConsultaResponse($"Error al Consultar: Se presento lo siguiente {e.Message}"); }
        }
    }

    public class LogResponse
    {
        public Producto Producto { get; set; }
        public string Mensaje { get; set; }
        public bool Error { get; set; }

        public LogResponse(Producto producto)
        {
            Producto = producto;
            Error = false;
        }

        public LogResponse(string mensaje)
        {
            Mensaje = mensaje;
            Error = true;
        }
    }

    public class ConsultaResponse
    {
        public List<Producto> Productos { get; set; }
        public string Mensaje { get; set; }
        public bool Error { get; set; }
        public ConsultaResponse(List<Producto> productos)
        {
            Productos = productos;
            Error = false;
        }
        public ConsultaResponse(string mensaje)
        {
            Mensaje = mensaje;
            Error = true;
        }
    }
}
