namespace BookReviewer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReviewDateUpdate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Reviews", "DateCreated", c => c.DateTime());
            AlterColumn("dbo.Reviews", "DateEdited", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Reviews", "DateEdited", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Reviews", "DateCreated", c => c.DateTime(nullable: false));
        }
    }
}
