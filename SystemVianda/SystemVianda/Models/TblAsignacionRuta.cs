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
        public int IdRutas { get; set; }
        [Required]
        public int IdEmpleados { get; set; }

        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }

        //Relaciones

        public virtual TblRutas Rutas { get; set; }
        public virtual TblEmpleado Empleado { get; set; }

        public ICollection<Tbl_DetallesR> DetallesRs { get; set; }

    }
}