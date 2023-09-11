namespace BookReviewer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BookUpdate4 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Books", "DatePublished", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Books", "DatePublished", c => c.DateTime());
        }
    }
}
