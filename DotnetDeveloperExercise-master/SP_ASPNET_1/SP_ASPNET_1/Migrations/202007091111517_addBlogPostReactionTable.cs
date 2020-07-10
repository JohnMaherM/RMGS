namespace SP_ASPNET_1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addBlogPostReactionTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                 "dbo.BlogPostReaction",
                 c => new
                 {
                     BlogPostID = c.Int(nullable: false),
                     UserID = c.String(),
                 })
                 .PrimaryKey(t => t.BlogPostID)
                 .ForeignKey("dbo.BlogPost", t => t.BlogPostID)
                 .Index(t => t.BlogPostID);

        }
        
        public override void Down()
        {
    
        }
    }
}
