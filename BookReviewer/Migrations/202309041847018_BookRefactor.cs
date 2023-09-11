namespace BookReviewer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BookRefactor : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Reviews", "UnapprovedBook_Id", "dbo.UnapprovedBooks");
            DropIndex("dbo.Reviews", new[] { "UnapprovedBook_Id" });
            DropColumn("dbo.Reviews", "UnapprovedBook_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reviews", "UnapprovedBook_Id", c => c.Int());
            CreateIndex("dbo.Reviews", "UnapprovedBook_Id");
            AddForeignKey("dbo.Reviews", "UnapprovedBook_Id", "dbo.UnapprovedBooks", "Id");
        }
    }
}
