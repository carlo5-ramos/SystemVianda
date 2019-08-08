using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SystemVianda.Models
{
    public class TblUsuarios
    {
        [Key]

        public int IdUsuario { get; set; }

        [Required]
        [Display(Name = "Usuario")]
        public string Usuario { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public bool Estado { get; set; }
        public int IdEmpleado { get; set; }
        public int IdRol { get; set; }

        //Relaciones


        public virtual TblRoles Roles { get; set; }
        public virtual TblEmpleados Empleado { get; set; }
        public ICollection<TblClientes> Clientes { get; set; }
        public ICollection<TblProveedores> Proveedores { get; set; }
        public ICollection<TblCompras> Compras { get; set; }
    }
}