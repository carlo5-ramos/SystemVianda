using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SystemVianda.Models
{
    public class ComprasAndDetalles
    {
        public List<TblCompras> Compras { get; set; }
        public List<TblDetallesCompras> DetallesCompras { get; set; }
    }
}