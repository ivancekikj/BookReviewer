namespace BookReviewer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DateTimeUpdate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "LockoutEndDateUtc", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Reviews", "DateCreated", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Reviews", "DateEdited", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Books", "DatePublished", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.UnapprovedBooks", "DatePublished", c => c.DateTime(precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UnapprovedBooks", "DatePublished", c => c.DateTime());
            AlterColumn("dbo.Books", "DatePublished", c => c.DateTime());
            AlterColumn("dbo.Reviews", "DateEdited", c => c.DateTime());
            AlterColumn("dbo.Reviews", "DateCreated", c => c.DateTime());
            AlterColumn("dbo.AspNetUsers", "LockoutEndDateUtc", c => c.DateTime());
        }
    }
}
