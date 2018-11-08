namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Shtraf", "discount", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Udostover", "Kod_driver_FK", "dbo.Driver");
            DropForeignKey("dbo.Shtraf", "Kod_driver_FK", "dbo.Driver");
            DropIndex("dbo.Udostover", new[] { "Kod_driver_FK" });
            DropIndex("dbo.Shtraf", new[] { "Kod_driver_FK" });
            DropTable("dbo.Udostover");
            DropTable("dbo.Shtraf");
            DropTable("dbo.Driver");
        }
    }
}
