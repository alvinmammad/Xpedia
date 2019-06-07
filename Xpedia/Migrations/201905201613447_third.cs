namespace Xpedia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class third : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "CarID", "dbo.Cars");
            DropIndex("dbo.Orders", new[] { "CarID" });
            AlterColumn("dbo.Orders", "CarID", c => c.Int(nullable: false));
            CreateIndex("dbo.Orders", "CarID");
            AddForeignKey("dbo.Orders", "CarID", "dbo.Cars", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "CarID", "dbo.Cars");
            DropIndex("dbo.Orders", new[] { "CarID" });
            AlterColumn("dbo.Orders", "CarID", c => c.Int());
            CreateIndex("dbo.Orders", "CarID");
            AddForeignKey("dbo.Orders", "CarID", "dbo.Cars", "ID");
        }
    }
}
