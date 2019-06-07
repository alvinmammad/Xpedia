namespace Xpedia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class someChanges : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SubComments", "CommentID", "dbo.Comments");
            DropIndex("dbo.SubComments", new[] { "CommentID" });
            DropTable("dbo.SubComments");
        }
        
        public override void Down()
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
                .PrimaryKey(t => t.ID);
            
            CreateIndex("dbo.SubComments", "CommentID");
            AddForeignKey("dbo.SubComments", "CommentID", "dbo.Comments", "ID", cascadeDelete: true);
        }
    }
}
