namespace SystemVianda.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Asig : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TblAsignacionRutas", "Empleado_IdEmpleado", "dbo.TblEmpleados");
            DropForeignKey("dbo.TblAsignacionRutas", "Rutas_IdRuta", "dbo.TblRutas");
            DropIndex("dbo.TblAsignacionRutas", new[] { "Empleado_IdEmpleado" });
            DropIndex("dbo.TblAsignacionRutas", new[] { "Rutas_IdRuta" });
            RenameColumn(table: "dbo.TblAsignacionRutas", name: "Empleado_IdEmpleado", newName: "IdEmpleado");
            RenameColumn(table: "dbo.TblAsignacionRutas", name: "Rutas_IdRuta", newName: "IdRuta");
            AlterColumn("dbo.TblAsignacionRutas", "IdEmpleado", c => c.Int(nullable: false));
            AlterColumn("dbo.TblAsignacionRutas", "IdRuta", c => c.Int(nullable: false));
            CreateIndex("dbo.TblAsignacionRutas", "IdRuta");
            CreateIndex("dbo.TblAsignacionRutas", "IdEmpleado");
            AddForeignKey("dbo.TblAsignacionRutas", "IdEmpleado", "dbo.TblEmpleados", "IdEmpleado", cascadeDelete: false);
            AddForeignKey("dbo.TblAsignacionRutas", "IdRuta", "dbo.TblRutas", "IdRuta", cascadeDelete: false);
            DropColumn("dbo.TblAsignacionRutas", "IdRutas");
            DropColumn("dbo.TblAsignacionRutas", "IdEmpleados");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TblAsignacionRutas", "IdEmpleados", c => c.Int(nullable: false));
            AddColumn("dbo.TblAsignacionRutas", "IdRutas", c => c.Int(nullable: false));
            DropForeignKey("dbo.TblAsignacionRutas", "IdRuta", "dbo.TblRutas");
            DropForeignKey("dbo.TblAsignacionRutas", "IdEmpleado", "dbo.TblEmpleados");
            DropIndex("dbo.TblAsignacionRutas", new[] { "IdEmpleado" });
            DropIndex("dbo.TblAsignacionRutas", new[] { "IdRuta" });
            AlterColumn("dbo.TblAsignacionRutas", "IdRuta", c => c.Int());
            AlterColumn("dbo.TblAsignacionRutas", "IdEmpleado", c => c.Int());
            RenameColumn(table: "dbo.TblAsignacionRutas", name: "IdRuta", newName: "Rutas_IdRuta");
            RenameColumn(table: "dbo.TblAsignacionRutas", name: "IdEmpleado", newName: "Empleado_IdEmpleado");
            CreateIndex("dbo.TblAsignacionRutas", "Rutas_IdRuta");
            CreateIndex("dbo.TblAsignacionRutas", "Empleado_IdEmpleado");
            AddForeignKey("dbo.TblAsignacionRutas", "Rutas_IdRuta", "dbo.TblRutas", "IdRuta");
            AddForeignKey("dbo.TblAsignacionRutas", "Empleado_IdEmpleado", "dbo.TblEmpleados", "IdEmpleado");
        }
    }
}
