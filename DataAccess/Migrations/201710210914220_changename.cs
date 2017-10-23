namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changename : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Features", "MenuId", c => c.Int());
            DropColumn("dbo.Features", "SubMenuId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Features", "SubMenuId", c => c.Int());
            DropColumn("dbo.Features", "MenuId");
        }
    }
}
