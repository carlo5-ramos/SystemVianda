using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SystemVianda.Models
{
    public class TblAsignacionRuta
    {
        [Key]
        public int IdAsignacionRuta { get; set; }


        [Required]
        public int IdRuta { get; set; }
        [Required]
        public int IdEmpleado { get; set; }

        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }

        //Relaciones

        public virtual TblRutas Rutas { get; set; }
        public virtual TblEmpleados Empleado { get; set; }

        public ICollection<TblDetallesRuta> DetallesRutas { get; set; }

    }
}