using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SystemVianda.Models
{
    public class TblDetallesCompras
    {
        [Key]
        public int DetallesC { get; set; }
        public int IdProductos { get; set; }

        [Display(Name = "Precio Compra")]
        public double PrecioCompra { get; set; }
        [Display(Name = "P/Compra")]
        public double PesoFactura { get; set; }
        [Display(Name = "P/Real")]
        public double PesoReal { get; set; }
        [Display(Name = "SubTotal")]
        public double SubTotal { get; set; }
        [Display(Name = "Tactico/F")]
        public double TacticoFactura { get; set; }
        [Display(Name = "Merma")]
        public double Merma { get; set; }
        public int Compra { get; set; }
        [DataType(DataType.MultilineText)]
        public string Descripcion { get; set; }

        //Relaciones
        public virtual TblProductos Productos { get; set; }
        public virtual TblCompras Compras { get; set; }
    }
}