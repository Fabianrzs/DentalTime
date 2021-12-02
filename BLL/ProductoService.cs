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

        public ProductoLogResponse Save (Producto producto)
        {
            try
            {
                if (_context.Productos.Find(producto.Referencia) == null)
                {
                    _context.Productos.Add(producto);
                    _context.SaveChanges();
                    return new ProductoLogResponse(producto);
                }
                return new ProductoLogResponse($"El producto ya se encuentra registrado"); 
            }
            catch (Exception e) { return new ProductoLogResponse($"Error al Guardar: Se presento lo siguiente {e.Message}"); }
        }

        public ProductoLogResponse Update (int unidades, string referencia)
        {
            try
            {
                Producto producto = _context.Productos.Find(referencia);
                if (producto != null)
                {
                    producto.IgresarStockActual(unidades);
                    _context.Productos.Update(producto);
                    _context.SaveChanges();
                    return new ProductoLogResponse(producto);
                }
                return new ProductoLogResponse($"No se encuentra registro a modificar");
            }
            catch (Exception e) { return new ProductoLogResponse($"Error al Modificar: Se presento lo siguiente {e.Message}"); }
        }

        public ProductoLogResponse Find (string referencia)
        {
            try
            {
                Producto producto = _context.Productos.Find(referencia);
                if (producto != null)
                {
                    return new ProductoLogResponse(producto);
                }
                return new ProductoLogResponse($"No se encuentra el registro buscado");
            }
            catch (Exception e) { return new ProductoLogResponse($"Error al Buscar: Se presento lo siguiente {e.Message}"); }
        }

        public string Delete (string referencia)
        {
            try
            {
                Producto producto = _context.Productos.Find(referencia);
                if (producto != null)
                {
                    _context.Productos.Remove(producto);
                    _context.SaveChanges();
                    return "Producto eliminado satisfactoriamente";
                }
                return ($"No se encuentra el producto a eliminar");
            }
            catch (Exception e) { return ($"Error al Eliminar: Se presento lo siguiente {e.Message}"); }
        }

        public ProductoConsultaResponse Consult ()
        {
            try
            {
                List<Producto> productos = _context.Productos.ToList();
                if (productos != null)
                {
                    return new ProductoConsultaResponse(productos);
                }
                return new ProductoConsultaResponse($"No se han agregado registros");
            }
            catch (Exception e) { return new ProductoConsultaResponse($"Error al Consultar: Se presento lo siguiente {e.Message}"); }
        }
    }

    public class ProductoLogResponse
    {
        public Producto Producto { get; set; }
        public string Mensaje { get; set; }
        public bool Error { get; set; }

        public ProductoLogResponse(Producto producto)
        {
            Producto = producto;
            Error = false;
        }

        public ProductoLogResponse(string mensaje)
        {
            Mensaje = mensaje;
            Error = true;
        }
    }

    public class ProductoConsultaResponse
    {
        public List<Producto> Productos { get; set; }
        public string Mensaje { get; set; }
        public bool Error { get; set; }
        public ProductoConsultaResponse(List<Producto> productos)
        {
            Productos = productos;
            Error = false;
        }
        public ProductoConsultaResponse(string mensaje)
        {
            Mensaje = mensaje;
            Error = true;
        }
    }
}
