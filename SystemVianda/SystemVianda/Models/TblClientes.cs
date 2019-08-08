using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SystemVianda.Models
{
    public class TblClientes
    {
        [Key]

        public int IdCliente { get; set; }

        [Display(Name = "Nombre")]
        [MinLength(3)]
        public string Nombre { get; set; }

        [Display(Name = "Apellido")]
        [MinLength(3)]
        public string Apellido { get; set; }

        [Display(Name = "DUI"), Required]
        [StringLength(10, ErrorMessage = "Formato inválido {0}", MinimumLength = 10)]
        public string Dui { get; set; }


        [Display(Name = "Teléfono")]
        public string Telefono { get; set; }

        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        public bool Estado { get; set; }

        [Display(Name = "Dirección")]
        [DataType(DataType.MultilineText)]
        public string Direccion { get; set; }

        public string Foto { get; set; }

        [Required]
        public string CordenadasGPS { get; set; }
        [Required]
        public DateTime FechaRegistro { get; set; }

        public int IdUsuarios { get; set; }

        //Relaciones
        public virtual TblUsuarios TblUsuarios { get; set; }
        public ICollection<TblDetallesRuta> DetallesRutas { get; set; }

       

    }
}