namespace bigschool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsCanceledColumnToCourse : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CourseViewModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Place = c.String(nullable: false),
                        Date = c.String(nullable: false),
                        Time = c.String(nullable: false),
                        Category = c.Byte(nullable: false),
                        Heading = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CourseViewModels");
        }
    }
}
