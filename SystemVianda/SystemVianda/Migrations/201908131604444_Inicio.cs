namespace SystemVianda.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicio : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TblUnidadDeMedidas",
                c => new
                    {
                        IdUnidadMedida = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.IdUnidadMedida);
            
            AddColumn("dbo.TblProductos", "IdUnidadMedida", c => c.Int(nullable: false));
            CreateIndex("dbo.TblProductos", "IdUnidadMedida");
            AddForeignKey("dbo.TblProductos", "IdUnidadMedida", "dbo.TblUnidadDeMedidas", "IdUnidadMedida", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TblProductos", "IdUnidadMedida", "dbo.TblUnidadDeMedidas");
            DropIndex("dbo.TblProductos", new[] { "IdUnidadMedida" });
            DropColumn("dbo.TblProductos", "IdUnidadMedida");
            DropTable("dbo.TblUnidadDeMedidas");
        }
    }
}
