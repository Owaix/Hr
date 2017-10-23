namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changenam : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Features", "Class", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Features", "Class");
        }
    }
}
