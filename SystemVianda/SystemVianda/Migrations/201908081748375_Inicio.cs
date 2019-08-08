namespace SystemVianda.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicio : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TblAsignacionRutas",
                c => new
                    {
                        IdAsignacionRuta = c.Int(nullable: false, identity: true),
                        IdRutas = c.Int(nullable: false),
                        IdEmpleados = c.Int(nullable: false),
                        Fecha = c.DateTime(nullable: false),
                        Empleado_IdEmpleado = c.Int(),
                        Rutas_IdRuta = c.Int(),
                    })
                .PrimaryKey(t => t.IdAsignacionRuta)
                .ForeignKey("dbo.TblEmpleados", t => t.Empleado_IdEmpleado)
                .ForeignKey("dbo.TblRutas", t => t.Rutas_IdRuta)
                .Index(t => t.Empleado_IdEmpleado)
                .Index(t => t.Rutas_IdRuta);
            
            CreateTable(
                "dbo.TblDetallesRutas",
                c => new
                    {
                        IdDetallesRuta = c.Int(nullable: false, identity: true),
                        IdRuta = c.Int(nullable: false),
                        IdCliente = c.Int(nullable: false),
                        TblAsignacionRuta_IdAsignacionRuta = c.Int(),
                    })
                .PrimaryKey(t => t.IdDetallesRuta)
                .ForeignKey("dbo.TblClientes", t => t.IdCliente, cascadeDelete: false)
                .ForeignKey("dbo.TblRutas", t => t.IdRuta, cascadeDelete: false)
                .ForeignKey("dbo.TblAsignacionRutas", t => t.TblAsignacionRuta_IdAsignacionRuta)
                .Index(t => t.IdRuta)
                .Index(t => t.IdCliente)
                .Index(t => t.TblAsignacionRuta_IdAsignacionRuta);
            
            CreateTable(
                "dbo.TblClientes",
                c => new
                    {
                        IdCliente = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Apellido = c.String(),
                        Dui = c.String(nullable: false, maxLength: 10),
                        Telefono = c.String(),
                        Email = c.String(),
                        Estado = c.Boolean(nullable: false),
                        Direccion = c.String(),
                        Foto = c.String(),
                        CordenadasGPS = c.String(nullable: false),
                        FechaRegistro = c.DateTime(nullable: false),
                        IdUsuarios = c.Int(nullable: false),
                        TblUsuarios_IdUsuario = c.Int(),
                    })
                .PrimaryKey(t => t.IdCliente)
                .ForeignKey("dbo.TblUsuarios", t => t.TblUsuarios_IdUsuario)
                .Index(t => t.TblUsuarios_IdUsuario);
            
            CreateTable(
                "dbo.TblUsuarios",
                c => new
                    {
                        IdUsuario = c.Int(nullable: false, identity: true),
                        Usuario = c.String(nullable: false),
                        Password = c.String(nullable: false, maxLength: 100),
                        ConfirmPassword = c.String(),
                        Estado = c.Boolean(nullable: false),
                        IdEmpleado = c.Int(nullable: false),
                        IdRol = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdUsuario)
                .ForeignKey("dbo.TblEmpleados", t => t.IdEmpleado, cascadeDelete: false)
                .ForeignKey("dbo.TblRoles", t => t.IdRol, cascadeDelete: false)
                .Index(t => t.IdEmpleado)
                .Index(t => t.IdRol);
            
            CreateTable(
                "dbo.TblCompras",
                c => new
                    {
                        Compra = c.Int(nullable: false, identity: true),
                        CodigoFactura = c.String(),
                        IdProveedor = c.Int(nullable: false),
                        IdUsuario = c.Int(nullable: false),
                        FecCompra = c.DateTime(nullable: false),
                        FechaRegistro = c.DateTime(nullable: false),
                        Estado = c.Boolean(nullable: false),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.Compra)
                .ForeignKey("dbo.TblProveedores", t => t.IdProveedor, cascadeDelete: false)
                .ForeignKey("dbo.TblUsuarios", t => t.IdUsuario, cascadeDelete: false)
                .Index(t => t.IdProveedor)
                .Index(t => t.IdUsuario);
            
            CreateTable(
                "dbo.TblDetallesCompras",
                c => new
                    {
                        DetallesC = c.Int(nullable: false, identity: true),
                        IdProductos = c.Int(nullable: false),
                        PrecioCompra = c.Double(nullable: false),
                        PesoFactura = c.Double(nullable: false),
                        PesoReal = c.Double(nullable: false),
                        SubTotal = c.Double(nullable: false),
                        TacticoFactura = c.Double(nullable: false),
                        Merma = c.Double(nullable: false),
                        Compra = c.Int(nullable: false),
                        Descripcion = c.String(),
                        Productos_IdProducto = c.Int(),
                    })
                .PrimaryKey(t => t.DetallesC)
                .ForeignKey("dbo.TblCompras", t => t.Compra, cascadeDelete: false)
                .ForeignKey("dbo.TblProductos", t => t.Productos_IdProducto)
                .Index(t => t.Compra)
                .Index(t => t.Productos_IdProducto);
            
            CreateTable(
                "dbo.TblProductos",
                c => new
                    {
                        IdProducto = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false),
                        BarCode = c.String(),
                        Existencia = c.Int(),
                        Precio = c.Double(nullable: false),
                        Descripcion = c.String(),
                        Estado = c.Boolean(nullable: false),
                        FechaRegistro = c.DateTime(),
                        IdCategoria = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdProducto)
                .ForeignKey("dbo.TblCategorias", t => t.IdCategoria, cascadeDelete: false)
                .Index(t => t.IdCategoria);
            
            CreateTable(
                "dbo.TblCategorias",
                c => new
                    {
                        IdCategoria = c.Int(nullable: false, identity: true),
                        Categoria = c.String(nullable: false),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.IdCategoria);
            
            CreateTable(
                "dbo.TblProveedores",
                c => new
                    {
                        IdProveedor = c.Int(nullable: false, identity: true),
                        Empresa = c.String(nullable: false),
                        Contacto = c.String(nullable: false),
                        Telefono = c.String(nullable: false),
                        Direccion = c.String(nullable: false),
                        Email = c.String(),
                        Dui = c.String(maxLength: 10),
                        Nrc = c.String(),
                        Nit = c.String(maxLength: 17),
                        Web = c.String(),
                        FechaRegistro = c.DateTime(nullable: false),
                        IdUsuario = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdProveedor)
                .ForeignKey("dbo.TblUsuarios", t => t.IdUsuario, cascadeDelete: false)
                .Index(t => t.IdUsuario);
            
            CreateTable(
                "dbo.TblEmpleados",
                c => new
                    {
                        IdEmpleado = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Apellido = c.String(),
                        Edad = c.Int(nullable: false),
                        Dui = c.String(nullable: false, maxLength: 10),
                        Nit = c.String(nullable: false, maxLength: 17),
                        Direccion = c.String(),
                        Telefono = c.String(nullable: false),
                        Celular = c.String(),
                        Sexo = c.String(nullable: false),
                        EstadoCivil = c.String(),
                        Cargo = c.String(),
                    })
                .PrimaryKey(t => t.IdEmpleado);
            
            CreateTable(
                "dbo.TblRoles",
                c => new
                    {
                        IdRol = c.Int(nullable: false, identity: true),
                        Rol = c.String(nullable: false),
                        Descripcion = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.IdRol);
            
            CreateTable(
                "dbo.TblRutas",
                c => new
                    {
                        IdRuta = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false),
                        Descripcion = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.IdRuta);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TblDetallesRutas", "TblAsignacionRuta_IdAsignacionRuta", "dbo.TblAsignacionRutas");
            DropForeignKey("dbo.TblDetallesRutas", "IdRuta", "dbo.TblRutas");
            DropForeignKey("dbo.TblAsignacionRutas", "Rutas_IdRuta", "dbo.TblRutas");
            DropForeignKey("dbo.TblUsuarios", "IdRol", "dbo.TblRoles");
            DropForeignKey("dbo.TblUsuarios", "IdEmpleado", "dbo.TblEmpleados");
            DropForeignKey("dbo.TblAsignacionRutas", "Empleado_IdEmpleado", "dbo.TblEmpleados");
            DropForeignKey("dbo.TblCompras", "IdUsuario", "dbo.TblUsuarios");
            DropForeignKey("dbo.TblProveedores", "IdUsuario", "dbo.TblUsuarios");
            DropForeignKey("dbo.TblCompras", "IdProveedor", "dbo.TblProveedores");
            DropForeignKey("dbo.TblDetallesCompras", "Productos_IdProducto", "dbo.TblProductos");
            DropForeignKey("dbo.TblProductos", "IdCategoria", "dbo.TblCategorias");
            DropForeignKey("dbo.TblDetallesCompras", "Compra", "dbo.TblCompras");
            DropForeignKey("dbo.TblClientes", "TblUsuarios_IdUsuario", "dbo.TblUsuarios");
            DropForeignKey("dbo.TblDetallesRutas", "IdCliente", "dbo.TblClientes");
            DropIndex("dbo.TblProveedores", new[] { "IdUsuario" });
            DropIndex("dbo.TblProductos", new[] { "IdCategoria" });
            DropIndex("dbo.TblDetallesCompras", new[] { "Productos_IdProducto" });
            DropIndex("dbo.TblDetallesCompras", new[] { "Compra" });
            DropIndex("dbo.TblCompras", new[] { "IdUsuario" });
            DropIndex("dbo.TblCompras", new[] { "IdProveedor" });
            DropIndex("dbo.TblUsuarios", new[] { "IdRol" });
            DropIndex("dbo.TblUsuarios", new[] { "IdEmpleado" });
            DropIndex("dbo.TblClientes", new[] { "TblUsuarios_IdUsuario" });
            DropIndex("dbo.TblDetallesRutas", new[] { "TblAsignacionRuta_IdAsignacionRuta" });
            DropIndex("dbo.TblDetallesRutas", new[] { "IdCliente" });
            DropIndex("dbo.TblDetallesRutas", new[] { "IdRuta" });
            DropIndex("dbo.TblAsignacionRutas", new[] { "Rutas_IdRuta" });
            DropIndex("dbo.TblAsignacionRutas", new[] { "Empleado_IdEmpleado" });
            DropTable("dbo.TblRutas");
            DropTable("dbo.TblRoles");
            DropTable("dbo.TblEmpleados");
            DropTable("dbo.TblProveedores");
            DropTable("dbo.TblCategorias");
            DropTable("dbo.TblProductos");
            DropTable("dbo.TblDetallesCompras");
            DropTable("dbo.TblCompras");
            DropTable("dbo.TblUsuarios");
            DropTable("dbo.TblClientes");
            DropTable("dbo.TblDetallesRutas");
            DropTable("dbo.TblAsignacionRutas");
        }
    }
}
