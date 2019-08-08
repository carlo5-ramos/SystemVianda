using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SystemVianda.Models
{
    public class TblCategorias
    {
        [Key]
        public int IdCategoria { get; set; }
        [Display(Name = "Categoria"), Required(ErrorMessage = "Campo requerido.")]
        public string Categoria { get; set; }
        [DataType(DataType.MultilineText)]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        //Relaciones
        public virtual List<TblProductos> Productos { get; set; }
    }
}