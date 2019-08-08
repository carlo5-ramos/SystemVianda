using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SystemVianda.Models
{
    public class TblDetallesRuta
    {
        [Key]
        public int IdDetallesRuta { get; set; }
        public int IdRuta { get; set; }

        public int IdCliente { get; set; }

        //Relaciones
        public virtual TblRutas Rutas { get; set; }
        public virtual TblClientes Clientes { get; set; }
    }
}