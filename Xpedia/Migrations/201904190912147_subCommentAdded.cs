namespace Xpedia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class subCommentAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SubComments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Body = c.String(maxLength: 250),
                        Date = c.DateTime(nullable: false),
                        Author = c.String(),
                        CommentID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Comments", t => t.CommentID, cascadeDelete: true)
                .Index(t => t.CommentID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SubComments", "CommentID", "dbo.Comments");
            DropIndex("dbo.SubComments", new[] { "CommentID" });
            DropTable("dbo.SubComments");
        }
    }
}
