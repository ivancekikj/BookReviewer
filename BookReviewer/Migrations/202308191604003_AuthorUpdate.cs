namespace BookReviewer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AuthorUpdate : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Authors", "DateOfBirth");
            DropColumn("dbo.Authors", "Image");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Authors", "Image", c => c.Binary());
            AddColumn("dbo.Authors", "DateOfBirth", c => c.DateTime(nullable: false));
        }
    }
}
