using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SystemVianda.Models
{
    public class TblProductos
    {
        [Key]
        public int IdProducto { get; set; }


        [Display(Name = "Producto"), Required(ErrorMessage = "Campo requerido.")]
        public string Nombre { get; set; }
        public string BarCode { get; set; }
        [Display(Name = "Stock")]
        public Nullable<int> Existencia { get; set; }
        [Display(Name = "Precio"), Required(ErrorMessage = "Campo Requerido")]
        public Nullable<double> Precio { get; set; }
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }
        public bool Estado { get; set; }
        public Nullable<DateTime> FechaRegistro { get; set; }
        public int IdCategoria { get; set; }
        public int IdUnidadMedida { get; set; }

        //Relaciones
        public virtual TblCategorias Categorias { get; set; }
        public virtual TblUnidadDeMedida UnidadDeMedida { get; set; }
        public ICollection<TblDetallesCompras> DetallesCompras { get; set; }

    }
}