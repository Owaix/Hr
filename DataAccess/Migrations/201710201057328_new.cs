namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _new : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Department = c.String(),
                        Designation = c.String(),
                        Salary = c.Single(),
                        Age = c.Int(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Features",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        SubMenuId = c.Int(),
                    })
                .PrimaryKey(t => t.id);
            
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
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Roles");
            DropTable("dbo.FeatureAccessConfigs");
            DropTable("dbo.Features");
            DropTable("dbo.Employees");
        }
    }
}
