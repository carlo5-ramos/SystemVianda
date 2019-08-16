namespace SystemVianda.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CambiosController : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TblDetallesCompras", "PesoReal", c => c.Double(nullable: false));
            AddColumn("dbo.TblDetallesCompras", "Total", c => c.Double(nullable: false));
            DropColumn("dbo.TblDetallesCompras", "SubTotal");
            DropColumn("dbo.TblDetallesCompras", "Descripcion");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TblDetallesCompras", "Descripcion", c => c.String());
            AddColumn("dbo.TblDetallesCompras", "SubTotal", c => c.Double(nullable: false));
            DropColumn("dbo.TblDetallesCompras", "Total");
            DropColumn("dbo.TblDetallesCompras", "PesoReal");
        }
    }
}
