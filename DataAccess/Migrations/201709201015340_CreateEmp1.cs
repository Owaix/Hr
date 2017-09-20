namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateEmp1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employee", "Salary", c => c.Single());
            AlterColumn("dbo.Employee", "Age", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employee", "Age", c => c.Int(nullable: false));
            AlterColumn("dbo.Employee", "Salary", c => c.Single(nullable: false));
        }
    }
}
