using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SystemVianda.Models
{
    public class TblUnidadDeMedida
    {
        [Key]
        public int IdUnidadMedida { get; set; }
        public string Nombre { get; set; }
        [DataType(DataType.MultilineText)]
        public string Descripcion { get; set; }
    
        //Relaciones
        public ICollection<TblProductos> Productos { get; set; }
    }
}