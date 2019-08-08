using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SystemVianda.Models
{
    public class TblRoles
    {

        [Key]
        public int IdRol { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        public string Rol { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        [Display(Name = "Descripción")]
        [DataType(DataType.MultilineText)]
        public string Descripcion { get; set; }

        //Relaciones
        public virtual ICollection<TblUsuarios> Usuarios { get; set; }
    }
}