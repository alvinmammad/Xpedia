namespace Xpedia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class blogChanges : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Blogs", "BlogCategory_ID", "dbo.BlogCategories");
            DropIndex("dbo.Blogs", new[] { "BlogCategory_ID" });
            DropColumn("dbo.Blogs", "CategoryID");
            RenameColumn(table: "dbo.Blogs", name: "BlogCategory_ID", newName: "CategoryID");
            AlterColumn("dbo.Blogs", "CategoryID", c => c.Int(nullable: false));
            CreateIndex("dbo.Blogs", "CategoryID");
            AddForeignKey("dbo.Blogs", "CategoryID", "dbo.BlogCategories", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Blogs", "CategoryID", "dbo.BlogCategories");
            DropIndex("dbo.Blogs", new[] { "CategoryID" });
            AlterColumn("dbo.Blogs", "CategoryID", c => c.Int());
            RenameColumn(table: "dbo.Blogs", name: "CategoryID", newName: "BlogCategory_ID");
            AddColumn("dbo.Blogs", "CategoryID", c => c.Int(nullable: false));
            CreateIndex("dbo.Blogs", "BlogCategory_ID");
            AddForeignKey("dbo.Blogs", "BlogCategory_ID", "dbo.BlogCategories", "ID");
        }
    }
}
