namespace VShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateproductfield : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Product", "BrandID", "dbo.Brand");
            DropIndex("dbo.Product", new[] { "BrandID" });
            AlterColumn("dbo.Product", "BrandID", c => c.Int());
            CreateIndex("dbo.Product", "BrandID");
            AddForeignKey("dbo.Product", "BrandID", "dbo.Brand", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Product", "BrandID", "dbo.Brand");
            DropIndex("dbo.Product", new[] { "BrandID" });
            AlterColumn("dbo.Product", "BrandID", c => c.Int(nullable: false));
            CreateIndex("dbo.Product", "BrandID");
            AddForeignKey("dbo.Product", "BrandID", "dbo.Brand", "ID", cascadeDelete: true);
        }
    }
}
