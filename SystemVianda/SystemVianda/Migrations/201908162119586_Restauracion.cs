namespace SystemVianda.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Restauracion : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TblDetallesCompras", "SubTotal", c => c.Double(nullable: false));
            AddColumn("dbo.TblDetallesCompras", "Descripcion", c => c.String());
            DropColumn("dbo.TblDetallesCompras", "PesoReal");
            DropColumn("dbo.TblDetallesCompras", "Total");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TblDetallesCompras", "Total", c => c.Double(nullable: false));
            AddColumn("dbo.TblDetallesCompras", "PesoReal", c => c.Double(nullable: false));
            DropColumn("dbo.TblDetallesCompras", "Descripcion");
            DropColumn("dbo.TblDetallesCompras", "SubTotal");
        }
    }
}
