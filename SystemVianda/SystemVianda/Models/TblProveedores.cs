using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SystemVianda.Models
{
    public class TblProveedores
    {
        [Key]
        public int IdProveedor { get; set; }

        [Required(ErrorMessage = "Campo requerido.")]
        public string Empresa { get; set; }

        [Required(ErrorMessage = "Campo requerido.")]
        public string Contacto { get; set; }

        [Display(Name = "Teléfono"), Required(ErrorMessage = "Campo requerido.")]
        public string Telefono { get; set; }

        [Display(Name = "Dirección"), Required(ErrorMessage = "Campo requerido.")]
        public string Direccion { get; set; }

        [EmailAddress(ErrorMessage = "Digite una cuenta valida.")]
        public string Email { get; set; }

        [Display(Name = "DUI")]
        [StringLength(10, ErrorMessage = "Formato inválido {0}", MinimumLength = 10)]
        public string Dui { get; set; }

        [Display(Name = "NRC")]
        public string Nrc { get; set; }

        [Display(Name = "NIT")]
        [StringLength(17, ErrorMessage = "Formato inválido {0}", MinimumLength = 17)]
        public string Nit { get; set; }

        [DataType(DataType.MultilineText)]
        public string Web { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Fecha De Registro")]
        public DateTime FechaRegistro { get; set; }

        public int IdUsuario { get; set; }

        //Relaciones

        public virtual TblUsuarios Usuarios { get; set; }
        public ICollection<TblCompras> Compras { get; set; }


    }
}