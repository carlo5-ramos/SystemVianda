using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SystemVianda.Models
{
    public class Contexto : DbContext
    {
        // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.

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
        public DbSet<TblUnidadDeMedida> UnidadDeMedidas { get; set; }
    }
}