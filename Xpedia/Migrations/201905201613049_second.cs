namespace Xpedia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class second : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CarOrders", "Car_ID", "dbo.Cars");
            DropForeignKey("dbo.CarOrders", "Order_ID", "dbo.Orders");
            DropIndex("dbo.CarOrders", new[] { "Car_ID" });
            DropIndex("dbo.CarOrders", new[] { "Order_ID" });
            AddColumn("dbo.Orders", "CarID", c => c.Int());
            CreateIndex("dbo.Orders", "CarID");
            AddForeignKey("dbo.Orders", "CarID", "dbo.Cars", "ID");
            DropTable("dbo.CarOrders");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.CarOrders",
                c => new
                    {
                        Car_ID = c.Int(nullable: false),
                        Order_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Car_ID, t.Order_ID });
            
            DropForeignKey("dbo.Orders", "CarID", "dbo.Cars");
            DropIndex("dbo.Orders", new[] { "CarID" });
            DropColumn("dbo.Orders", "CarID");
            CreateIndex("dbo.CarOrders", "Order_ID");
            CreateIndex("dbo.CarOrders", "Car_ID");
            AddForeignKey("dbo.CarOrders", "Order_ID", "dbo.Orders", "ID", cascadeDelete: true);
            AddForeignKey("dbo.CarOrders", "Car_ID", "dbo.Cars", "ID", cascadeDelete: true);
        }
    }
}
