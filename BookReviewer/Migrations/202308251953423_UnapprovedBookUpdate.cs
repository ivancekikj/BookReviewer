namespace BookReviewer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UnapprovedBookUpdate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Reviews", "BookId", "dbo.Books");
            CreateTable(
                "dbo.UnapprovedBooks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Isbn = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        Genre = c.String(nullable: false),
                        DatePublished = c.DateTime(),
                        Image = c.Binary(),
                        AuthorId = c.Int(nullable: false),
                        PublisherId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.AuthorId)
                .Index(t => t.PublisherId);
            
            AddColumn("dbo.Reviews", "UnapprovedBook_Id", c => c.Int());
            CreateIndex("dbo.Reviews", "UnapprovedBook_Id");
            AddForeignKey("dbo.Reviews", "UnapprovedBook_Id", "dbo.UnapprovedBooks", "Id");
            DropColumn("dbo.Books", "Discriminator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Books", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            DropForeignKey("dbo.Reviews", "UnapprovedBook_Id", "dbo.UnapprovedBooks");
            DropIndex("dbo.UnapprovedBooks", new[] { "PublisherId" });
            DropIndex("dbo.UnapprovedBooks", new[] { "AuthorId" });
            DropIndex("dbo.Reviews", new[] { "UnapprovedBook_Id" });
            DropColumn("dbo.Reviews", "UnapprovedBook_Id");
            DropTable("dbo.UnapprovedBooks");
            AddForeignKey("dbo.Reviews", "BookId", "dbo.Books", "Id", cascadeDelete: true);
        }
    }
}
