using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SystemVianda.Models
{
    public class TblCompras
    {
        [Key]
        public int Compra { get; set; }

        [Display(Name = "COD/Factura")]
        public string CodigoFactura { get; set; }
        public int IdProveedor { get; set; }
        public int IdUsuario { get; set; }

        [Display(Name = "F/Compra")]
        public DateTime FecCompra { get; set; }
        [Display(Name = "F/Registro")]
        public DateTime FechaRegistro { get; set; }
        public bool Estado { get; set; }
        [DataType(DataType.MultilineText)]
        public string Descripcion { get; set; }

        //Relaciones
        public virtual TblUsuarios Usuarios { get; set; }
        public virtual TblProveedores Proveedores { get; set; }
        public ICollection<TblDetallesCompras> DetallesCompras { get; set; }
    }
}