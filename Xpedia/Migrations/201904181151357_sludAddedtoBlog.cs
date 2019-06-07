namespace Xpedia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sludAddedtoBlog : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Blogs", "Slug", c => c.String(maxLength: 1000));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Blogs", "Slug");
        }
    }
}
