using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SystemVianda.Models
{
    public class TblRutas
    {
        [Key]
        public int IdRuta { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        [Display(Name = "Nombre de Ruta")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        [Display(Name = "Descripción")]
        [DataType(DataType.MultilineText)]
        public string Descripcion { get; set; }

        //Relaciones

        public ICollection<TblAsignacionRuta> AsignacionRutas { get; set; }
        public ICollection<TblDetallesRuta> DetallesRutas { get; set; }
    }
}