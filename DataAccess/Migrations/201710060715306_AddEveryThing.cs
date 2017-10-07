namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEveryThing : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FeatureAccessConfigs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Role_Id = c.Int(nullable: false),
                        Feature_Id = c.Int(nullable: false),
                        IsCheck = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Employees", "IsActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "IsActive");
            DropTable("dbo.FeatureAccessConfigs");
        }
    }
}
