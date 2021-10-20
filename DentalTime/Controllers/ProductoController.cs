using BLL;
using DAL;
using DentalTime.Models;
using Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentalTime.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private ProductoService _service; 

        public ProductoController(DentalTimeContext contex)
        {
            _service = new ProductoService(contex);
        }

        [HttpPost]
        public ActionResult<Producto> Save (ProductoInputModel productoInput)
        {
            var producto = mapearProducto(productoInput);
            var request = _service.Save(producto);
            if (request.Error) return BadRequest(request.Mensaje);
            return Ok(request.Producto);
        }

        private Producto mapearProducto (ProductoInputModel productoInput)
        {
            var producto = new Producto();

            producto.Referencia = productoInput.Referencia;
            producto.Nombre = productoInput.Nombre;
            producto.Marca = productoInput.Marca;
            producto.StockActual = productoInput.StockActual;
            producto.StockMax = productoInput.StockMax;
            producto.StockMin = productoInput.StockMin;

            return producto;
        }

        [HttpGet]
        public ActionResult<List<Producto>> Consult ()
        {
            var request = _service.Consult();
            if (request.Error) return BadRequest(request.Mensaje);
            return Ok(request.Productos);
        }

        [HttpGet ("Referencia")]
        public ActionResult<Producto> Find(string referencia)
        {
            var request = _service.Find(referencia);
            if (request.Error) return BadRequest(request.Mensaje);
            return Ok(request.Producto);
        }

        [HttpDelete ("Referencia")]
        public ActionResult<Producto> Delete(string referencia)
        {
            var request = _service.Delete(referencia);
            return Ok(request);
        }



    }
}
