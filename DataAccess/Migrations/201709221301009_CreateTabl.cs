namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTabl : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Features", "SubMenuId", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Features", "SubMenuId", c => c.Int(nullable: false));
        }
    }
}
