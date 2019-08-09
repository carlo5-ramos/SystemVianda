using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SystemVianda.Models
{
    public class Contexto : DbContext
    {
        public DbSet<TblUsuarios> Usuarios { get; set; }
        public DbSet<TblRoles> Roles { get; set; }

        public DbSet<TblEmpleados> Empleados { get; set; }
        public DbSet<TblProveedores> Proveedores { get; set; }
        public DbSet<TblCategorias> Categorias { get; set; }

        public DbSet<TblRutas> Rutas { get; set; }
        public DbSet<TblAsignacionRuta> AsignacionRutas { get; set; }

        public DbSet<TblClientes> Clientes { get; set; }
        public DbSet<TblDetallesRuta> DetallesRutas { get; set; }
        public DbSet<TblCompras> Compras { get; set; }
        public DbSet<TblDetallesCompras> DetallesCompras { get; set; }
        public DbSet<TblProductos> Productos { get; set; }
    }
}