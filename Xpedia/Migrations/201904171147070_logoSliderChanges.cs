namespace Xpedia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class logoSliderChanges : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.LogoSliders", "Title");
            DropColumn("dbo.LogoSliders", "Desc");
        }
        
        public override void Down()
        {
            AddColumn("dbo.LogoSliders", "Desc", c => c.String(maxLength: 80));
            AddColumn("dbo.LogoSliders", "Title", c => c.String(maxLength: 20));
        }
    }
}
