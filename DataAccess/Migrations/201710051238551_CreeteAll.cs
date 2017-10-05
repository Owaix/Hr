namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreeteAll : DbMigration
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
            
            DropTable("dbo.Employees");
        }
        
        public override void Down()
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
                    })
                .PrimaryKey(t => t.Id);
            
            DropTable("dbo.FeatureAccessConfigs");
        }
    }
}
