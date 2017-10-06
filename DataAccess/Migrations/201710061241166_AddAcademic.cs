namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAcademic : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AcademicProfiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Emp_Id = c.Int(nullable: false),
                        Institute = c.String(),
                        Degree = c.String(),
                        Year = c.String(),
                        ImageId = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AcademicProfiles");
        }
    }
}
