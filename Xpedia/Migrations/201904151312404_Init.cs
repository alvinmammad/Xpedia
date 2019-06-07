namespace Xpedia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AboutStories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Desc = c.String(),
                        Photo = c.String(),
                        Signature = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Accessories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PricePerDay = c.Decimal(nullable: false, storeType: "money"),
                        Quantity = c.Int(nullable: false),
                        Name = c.String(),
                        Info = c.String(),
                        Photo = c.String(maxLength: 200),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        OrderNumber = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                        CarID = c.Int(nullable: false),
                        AccessoryID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Accessories", t => t.AccessoryID, cascadeDelete: true)
                .ForeignKey("dbo.Cars", t => t.CarID, cascadeDelete: true)
                .ForeignKey("dbo.Locations", t => t.LocationID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID)
                .Index(t => t.CarID)
                .Index(t => t.AccessoryID)
                .Index(t => t.LocationID);
            
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PricePerDay = c.Decimal(nullable: false, storeType: "money"),
                        ReviewCount = c.Int(nullable: false),
                        Information = c.String(storeType: "ntext"),
                        TwoAir = c.Int(nullable: false),
                        Fuel = c.Int(nullable: false),
                        Transmission = c.Int(nullable: false),
                        CarType = c.Int(nullable: false),
                        Year = c.String(),
                        EngineCapacity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EnginePower = c.Int(nullable: false),
                        IsRented = c.Boolean(nullable: false),
                        Discount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DoorCount = c.Int(nullable: false),
                        CarModelID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.CarModels", t => t.CarModelID, cascadeDelete: true)
                .ForeignKey("dbo.Locations", t => t.LocationID, cascadeDelete: false)
                .Index(t => t.CarModelID)
                .Index(t => t.LocationID);
            
            CreateTable(
                "dbo.CarModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        BrandID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Brands", t => t.BrandID, cascadeDelete: true)
                .Index(t => t.BrandID);
            
            CreateTable(
                "dbo.Brands",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PickUpLocation = c.String(nullable: false),
                        DropOffLocation = c.String(nullable: false),
                        PickUpDate = c.DateTime(nullable: false),
                        DropOffDate = c.DateTime(nullable: false),
                        OpeningHour = c.DateTime(nullable: false),
                        ClosingHour = c.DateTime(nullable: false),
                        Phone = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 20),
                        LastName = c.String(nullable: false, maxLength: 25),
                        Username = c.String(nullable: false, maxLength: 25),
                        Password = c.String(nullable: false, maxLength: 50),
                        ConfirmPassword = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Phone = c.String(),
                        Address = c.String(),
                        PostalCode = c.String(),
                        DriverLicenseID = c.String(),
                        IsUser = c.Boolean(nullable: false),
                        Photo = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Fullname = c.String(maxLength: 30),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Blockquotes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Background = c.String(maxLength: 50),
                        Image = c.String(maxLength: 100),
                        Title = c.String(maxLength: 50),
                        AuthorID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Authors", t => t.AuthorID, cascadeDelete: true)
                .Index(t => t.AuthorID);
            
            CreateTable(
                "dbo.Blogs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 30),
                        Date = c.DateTime(nullable: false),
                        Comment = c.Int(nullable: false),
                        Info = c.String(maxLength: 120),
                        Desc = c.String(storeType: "ntext"),
                        AuthorID = c.Int(nullable: false),
                        CategoryID = c.Int(nullable: false),
                        BlogCategory_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Authors", t => t.AuthorID, cascadeDelete: true)
                .ForeignKey("dbo.BlogCategories", t => t.BlogCategory_ID)
                .Index(t => t.AuthorID)
                .Index(t => t.BlogCategory_ID);
            
            CreateTable(
                "dbo.BlogCategories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 15),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.BlogPhotoes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 100),
                        BlogID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Blogs", t => t.BlogID, cascadeDelete: true)
                .Index(t => t.BlogID);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Body = c.String(maxLength: 250),
                        Date = c.DateTime(nullable: false),
                        Author = c.String(),
                        BlogID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Blogs", t => t.BlogID, cascadeDelete: true)
                .Index(t => t.BlogID);
            
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 20),
                        Desc = c.String(maxLength: 100),
                        Address = c.String(maxLength: 80),
                        Phone = c.String(maxLength: 25),
                        Email = c.String(maxLength: 35),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Drivers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Desc = c.String(),
                        Photo = c.String(),
                        Fullname = c.String(),
                        Age = c.Int(nullable: false),
                        ExperienceYear = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Facts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Icon = c.String(),
                        Key = c.Int(nullable: false),
                        Value = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.FeaturedDestinations",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Info = c.String(),
                        Photo = c.String(),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.LogoSliders",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 20),
                        Desc = c.String(maxLength: 80),
                        Logo = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Metas",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        URL = c.String(),
                        Title = c.String(),
                        Desc = c.String(),
                        Image = c.String(),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ServiceCards",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 25),
                        Info = c.String(maxLength: 70),
                        Icon = c.String(maxLength: 30),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 25),
                        Desc = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Settings",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Logo = c.String(maxLength: 250),
                        Facebook = c.String(),
                        Instagram = c.String(),
                        Youtube = c.String(),
                        Lattitude = c.String(maxLength: 50),
                        Longitude = c.String(maxLength: 50),
                        ChooseUsTitle = c.String(),
                        ChooseUsDesc = c.String(),
                        ChooseUsButtonText = c.String(),
                        ChooseUsPhoto = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.SliderPhotoes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 200),
                        Slider_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Sliders", t => t.Slider_ID)
                .Index(t => t.Slider_ID);
            
            CreateTable(
                "dbo.Sliders",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Info = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.TeamCategories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 30),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Photo = c.String(),
                        Fullname = c.String(),
                        TeamCategoryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.TeamCategories", t => t.TeamCategoryID, cascadeDelete: true)
                .Index(t => t.TeamCategoryID);
            
            CreateTable(
                "dbo.TestimonialItems",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Photo = c.String(),
                        Review = c.String(),
                        Fullname = c.String(),
                        TestimonialRoleID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.TestimonialRoles", t => t.TestimonialRoleID, cascadeDelete: true)
                .Index(t => t.TestimonialRoleID);
            
            CreateTable(
                "dbo.TestimonialRoles",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Testimonials",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 15),
                        Desc = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TestimonialItems", "TestimonialRoleID", "dbo.TestimonialRoles");
            DropForeignKey("dbo.Teams", "TeamCategoryID", "dbo.TeamCategories");
            DropForeignKey("dbo.SliderPhotoes", "Slider_ID", "dbo.Sliders");
            DropForeignKey("dbo.Comments", "BlogID", "dbo.Blogs");
            DropForeignKey("dbo.BlogPhotoes", "BlogID", "dbo.Blogs");
            DropForeignKey("dbo.Blogs", "BlogCategory_ID", "dbo.BlogCategories");
            DropForeignKey("dbo.Blogs", "AuthorID", "dbo.Authors");
            DropForeignKey("dbo.Blockquotes", "AuthorID", "dbo.Authors");
            DropForeignKey("dbo.Orders", "UserID", "dbo.Users");
            DropForeignKey("dbo.Orders", "LocationID", "dbo.Locations");
            DropForeignKey("dbo.Orders", "CarID", "dbo.Cars");
            DropForeignKey("dbo.Cars", "LocationID", "dbo.Locations");
            DropForeignKey("dbo.Cars", "CarModelID", "dbo.CarModels");
            DropForeignKey("dbo.CarModels", "BrandID", "dbo.Brands");
            DropForeignKey("dbo.Orders", "AccessoryID", "dbo.Accessories");
            DropIndex("dbo.TestimonialItems", new[] { "TestimonialRoleID" });
            DropIndex("dbo.Teams", new[] { "TeamCategoryID" });
            DropIndex("dbo.SliderPhotoes", new[] { "Slider_ID" });
            DropIndex("dbo.Comments", new[] { "BlogID" });
            DropIndex("dbo.BlogPhotoes", new[] { "BlogID" });
            DropIndex("dbo.Blogs", new[] { "BlogCategory_ID" });
            DropIndex("dbo.Blogs", new[] { "AuthorID" });
            DropIndex("dbo.Blockquotes", new[] { "AuthorID" });
            DropIndex("dbo.CarModels", new[] { "BrandID" });
            DropIndex("dbo.Cars", new[] { "LocationID" });
            DropIndex("dbo.Cars", new[] { "CarModelID" });
            DropIndex("dbo.Orders", new[] { "LocationID" });
            DropIndex("dbo.Orders", new[] { "AccessoryID" });
            DropIndex("dbo.Orders", new[] { "CarID" });
            DropIndex("dbo.Orders", new[] { "UserID" });
            DropTable("dbo.Testimonials");
            DropTable("dbo.TestimonialRoles");
            DropTable("dbo.TestimonialItems");
            DropTable("dbo.Teams");
            DropTable("dbo.TeamCategories");
            DropTable("dbo.Tags");
            DropTable("dbo.Sliders");
            DropTable("dbo.SliderPhotoes");
            DropTable("dbo.Settings");
            DropTable("dbo.Services");
            DropTable("dbo.ServiceCards");
            DropTable("dbo.Metas");
            DropTable("dbo.LogoSliders");
            DropTable("dbo.FeaturedDestinations");
            DropTable("dbo.Facts");
            DropTable("dbo.Drivers");
            DropTable("dbo.Contacts");
            DropTable("dbo.Comments");
            DropTable("dbo.BlogPhotoes");
            DropTable("dbo.BlogCategories");
            DropTable("dbo.Blogs");
            DropTable("dbo.Blockquotes");
            DropTable("dbo.Authors");
            DropTable("dbo.Users");
            DropTable("dbo.Locations");
            DropTable("dbo.Brands");
            DropTable("dbo.CarModels");
            DropTable("dbo.Cars");
            DropTable("dbo.Orders");
            DropTable("dbo.Accessories");
            DropTable("dbo.AboutStories");
        }
    }
}
