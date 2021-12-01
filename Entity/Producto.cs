using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Producto
    {
        [Key]
        public string Referencia { get; set; }
        public string Nombre { get; set; }
        public string Laboratorio { get; set; }
        public string Marca { get; set; }

        public int StockActual { get; set; }

        public DetalleServicio DetalleServicio { get; set; }
        
        public void DescontarStockActual(int unidadesUsadas){
            this.StockActual = this.StockActual - unidadesUsadas;
            if(this.StockActual < 0){
                this.StockActual = 0;
            }
        }

        public void IgresarStockActual (int unidadesCompradas){
            this.StockActual = this.StockActual + unidadesCompradas;
        }
    }
}
