namespace bigschool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateCategoryTable : DbMigration
    {
        public override void Up()
        {
            Sql("InSERT INTO CATEGORIES(ID, NAME) VALUES (1, 'Development')");
            Sql("InSERT INTO CATEGORIES(ID, NAME) VALUES (2, 'Business')");
            Sql("InSERT INTO CATEGORIES(ID, NAME) VALUES (3, 'Marketing')");
        }
        
        public override void Down()
        {
        }
    }
}
