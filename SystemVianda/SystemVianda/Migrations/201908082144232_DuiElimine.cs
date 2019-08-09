namespace SystemVianda.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DuiElimine : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.TblProveedores", "Dui");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TblProveedores", "Dui", c => c.String(maxLength: 10));
        }
    }
}
