using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SystemVianda.Models
{
    public class TblEmpleados
    {

        [Key]
        public int IdEmpleado { get; set; }

        [Display(Name = "Nombre")]
        [MinLength(3)]
        public string Nombre { get; set; }

        [Display(Name = "Apellido")]
        [MinLength(3)]
        public string Apellido { get; set; }

        public int Edad { get; set; }

        [Display(Name = "DUI"), Required]
        [StringLength(10, ErrorMessage = "Formato inválido {0}", MinimumLength = 10)]
        public string Dui { get; set; }

        [Display(Name = "NIT"), Required]
        [StringLength(17, ErrorMessage = "Formato inválido {0}", MinimumLength = 17)]

        public string Nit { get; set; }

        [Display(Name = "Direccion")]
        public string Direccion { get; set; }

        [Display(Name = "Teléfono")]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Campo requerido.")]
        public string Telefono { get; set; }


        [Display(Name = "Celular")]

        public string Celular { get; set; }

        [Display(Name = "Sexo")]
        [Required(ErrorMessage = "Campo requerido.")]
        public string Sexo { get; set; }


        [Display(Name = "Esta Civil")]

        public string EstadoCivil { get; set; }

        [DataType(DataType.MultilineText)]
        public string Cargo { get; set; }

        //Relaciones

        public ICollection<TblUsuarios> Usuarios { get; set; }

        public ICollection<TblAsignacionRuta> AsignacionRutas { get; set; }

    }
}