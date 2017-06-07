namespace VShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initdb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Brand",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 250),
                        Alias = c.String(nullable: false, maxLength: 250, unicode: false),
                        Logo = c.String(maxLength: 500),
                        Description = c.String(maxLength: 500),
                        MetaDescription = c.String(maxLength: 250),
                        MetaKeyword = c.String(maxLength: 250),
                        CreateDate = c.DateTime(nullable: false),
                        CreateBy = c.String(nullable: false, maxLength: 50),
                        UpdateDate = c.DateTime(),
                        UpdateBy = c.String(maxLength: 50),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 250),
                        Alias = c.String(nullable: false, maxLength: 250, unicode: false),
                        CategoryID = c.Int(nullable: false),
                        BrandID = c.Int(nullable: false),
                        Image = c.String(maxLength: 500),
                        MoreImage = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PromotionPrice = c.Decimal(precision: 18, scale: 2),
                        Warranty = c.Int(),
                        Description = c.String(maxLength: 500),
                        Content = c.String(),
                        HomeFlag = c.Boolean(nullable: false),
                        HotFlag = c.Boolean(nullable: false),
                        ViewCount = c.Int(nullable: false),
                        Tags = c.String(),
                        MetaDescription = c.String(maxLength: 250),
                        MetaKeyword = c.String(maxLength: 250),
                        CreateDate = c.DateTime(nullable: false),
                        CreateBy = c.String(nullable: false, maxLength: 50),
                        UpdateDate = c.DateTime(),
                        UpdateBy = c.String(maxLength: 50),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Brand", t => t.BrandID, cascadeDelete: true)
                .ForeignKey("dbo.ProductCategory", t => t.CategoryID, cascadeDelete: true)
                .Index(t => t.CategoryID)
                .Index(t => t.BrandID);
            
            CreateTable(
                "dbo.OrderDetail",
                c => new
                    {
                        OrderID = c.Int(nullable: false),
                        ProductID = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.OrderID, t.ProductID })
                .ForeignKey("dbo.Order", t => t.OrderID, cascadeDelete: true)
                .ForeignKey("dbo.Product", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.OrderID)
                .Index(t => t.ProductID);
            
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CustomerName = c.String(nullable: false, maxLength: 250),
                        CustomerAddress = c.String(nullable: false, maxLength: 250),
                        CustomerEmail = c.String(nullable: false, maxLength: 250),
                        CustomerMobile = c.String(nullable: false, maxLength: 50),
                        CustomerMessage = c.String(maxLength: 500),
                        CreateDate = c.DateTime(nullable: false),
                        CreateBy = c.String(nullable: false, maxLength: 50),
                        PaymentMethod = c.String(maxLength: 250),
                        PaymentStatus = c.String(nullable: false, maxLength: 50),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ProductCategory",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 250),
                        Alias = c.String(nullable: false, maxLength: 250, unicode: false),
                        Description = c.String(maxLength: 500),
                        ParentID = c.Int(),
                        DisplayOrder = c.Int(),
                        Image = c.String(maxLength: 500),
                        HotFlag = c.Boolean(nullable: false),
                        MetaDescription = c.String(maxLength: 250),
                        MetaKeyword = c.String(maxLength: 250),
                        CreateDate = c.DateTime(nullable: false),
                        CreateBy = c.String(nullable: false, maxLength: 50),
                        UpdateDate = c.DateTime(),
                        UpdateBy = c.String(maxLength: 50),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ProductCategory", t => t.ParentID)
                .Index(t => t.ParentID);
            
            CreateTable(
                "dbo.ProductTag",
                c => new
                    {
                        ProductID = c.Int(nullable: false),
                        TagID = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => new { t.ProductID, t.TagID })
                .ForeignKey("dbo.Product", t => t.ProductID, cascadeDelete: true)
                .ForeignKey("dbo.Tag", t => t.TagID, cascadeDelete: true)
                .Index(t => t.ProductID)
                .Index(t => t.TagID);
            
            CreateTable(
                "dbo.Tag",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 50, unicode: false),
                        Name = c.String(nullable: false, maxLength: 250),
                        Type = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.PostTag",
                c => new
                    {
                        PostID = c.Int(nullable: false),
                        TagID = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => new { t.PostID, t.TagID })
                .ForeignKey("dbo.Post", t => t.PostID, cascadeDelete: true)
                .ForeignKey("dbo.Tag", t => t.TagID, cascadeDelete: true)
                .Index(t => t.PostID)
                .Index(t => t.TagID);
            
            CreateTable(
                "dbo.Post",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 250),
                        Alias = c.String(nullable: false, maxLength: 250, unicode: false),
                        CategoryID = c.Int(nullable: false),
                        Image = c.String(maxLength: 500),
                        Description = c.String(maxLength: 500),
                        Content = c.String(),
                        HomeFlag = c.Boolean(nullable: false),
                        HotFlag = c.Boolean(nullable: false),
                        ViewCount = c.Int(nullable: false),
                        MetaDescription = c.String(maxLength: 250),
                        MetaKeyword = c.String(maxLength: 250),
                        CreateDate = c.DateTime(nullable: false),
                        CreateBy = c.String(nullable: false, maxLength: 50),
                        UpdateDate = c.DateTime(),
                        UpdateBy = c.String(maxLength: 50),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.PostCategory", t => t.CategoryID, cascadeDelete: true)
                .Index(t => t.CategoryID);
            
            CreateTable(
                "dbo.PostCategory",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 250),
                        Alias = c.String(nullable: false, maxLength: 250, unicode: false),
                        Description = c.String(maxLength: 500),
                        ParentID = c.Int(nullable: false),
                        DisplayOrder = c.Int(),
                        Image = c.String(maxLength: 500),
                        HomeFlag = c.Boolean(nullable: false),
                        MetaDescription = c.String(maxLength: 250),
                        MetaKeyword = c.String(maxLength: 250),
                        CreateDate = c.DateTime(nullable: false),
                        CreateBy = c.String(nullable: false, maxLength: 50),
                        UpdateDate = c.DateTime(),
                        UpdateBy = c.String(maxLength: 50),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Footer",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 250),
                        Content = c.String(nullable: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.LogError",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Message = c.String(nullable: false),
                        StackTrace = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.MenuGroup",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 250),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Menu",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 250),
                        URL = c.String(nullable: false, maxLength: 500),
                        DisplayOrder = c.Int(),
                        GroupID = c.Int(nullable: false),
                        Target = c.String(maxLength: 10),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.MenuGroup", t => t.GroupID, cascadeDelete: true)
                .Index(t => t.GroupID);
            
            CreateTable(
                "dbo.Page",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 250),
                        Alias = c.String(nullable: false, maxLength: 250, unicode: false),
                        Content = c.String(),
                        MetaDescription = c.String(maxLength: 250),
                        MetaKeyword = c.String(maxLength: 250),
                        CreateDate = c.DateTime(nullable: false),
                        CreateBy = c.String(nullable: false, maxLength: 50),
                        UpdateDate = c.DateTime(),
                        UpdateBy = c.String(maxLength: 50),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Product_ProductAttribute_Mapping",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ProductID = c.Int(nullable: false),
                        ProductAttributeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Product", t => t.ProductID, cascadeDelete: true)
                .ForeignKey("dbo.ProductAttribute", t => t.ProductAttributeID, cascadeDelete: true)
                .Index(t => t.ProductID)
                .Index(t => t.ProductAttributeID);
            
            CreateTable(
                "dbo.ProductAttribute",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ProductAttributeValue",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ProductAttributeMappingID = c.Int(nullable: false),
                        Value = c.String(),
                        Unit = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Product_ProductAttribute_Mapping", t => t.ProductAttributeMappingID, cascadeDelete: true)
                .Index(t => t.ProductAttributeMappingID);
            
            CreateTable(
                "dbo.Slide",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 250),
                        Description = c.String(maxLength: 500),
                        Image = c.String(nullable: false, maxLength: 500),
                        URL = c.String(nullable: false, maxLength: 500),
                        DisplayOrder = c.Int(),
                        MetaDescription = c.String(maxLength: 250),
                        MetaKeyword = c.String(maxLength: 250),
                        CreateDate = c.DateTime(nullable: false),
                        CreateBy = c.String(nullable: false, maxLength: 50),
                        UpdateDate = c.DateTime(),
                        UpdateBy = c.String(maxLength: 50),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.SupportOnline",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 250),
                        Department = c.String(maxLength: 250),
                        Skype = c.String(maxLength: 250),
                        Mobile = c.String(maxLength: 250),
                        Email = c.String(maxLength: 250),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.SystemConfig",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false, maxLength: 50, unicode: false),
                        StringValue = c.String(maxLength: 500),
                        IntegerValue = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.VisitorStatistics",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        VisitedDate = c.DateTime(nullable: false),
                        IPAddress = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductAttributeValue", "ProductAttributeMappingID", "dbo.Product_ProductAttribute_Mapping");
            DropForeignKey("dbo.Product_ProductAttribute_Mapping", "ProductAttributeID", "dbo.ProductAttribute");
            DropForeignKey("dbo.Product_ProductAttribute_Mapping", "ProductID", "dbo.Product");
            DropForeignKey("dbo.Menu", "GroupID", "dbo.MenuGroup");
            DropForeignKey("dbo.ProductTag", "TagID", "dbo.Tag");
            DropForeignKey("dbo.PostTag", "TagID", "dbo.Tag");
            DropForeignKey("dbo.PostTag", "PostID", "dbo.Post");
            DropForeignKey("dbo.Post", "CategoryID", "dbo.PostCategory");
            DropForeignKey("dbo.ProductTag", "ProductID", "dbo.Product");
            DropForeignKey("dbo.Product", "CategoryID", "dbo.ProductCategory");
            DropForeignKey("dbo.ProductCategory", "ParentID", "dbo.ProductCategory");
            DropForeignKey("dbo.OrderDetail", "ProductID", "dbo.Product");
            DropForeignKey("dbo.OrderDetail", "OrderID", "dbo.Order");
            DropForeignKey("dbo.Product", "BrandID", "dbo.Brand");
            DropIndex("dbo.ProductAttributeValue", new[] { "ProductAttributeMappingID" });
            DropIndex("dbo.Product_ProductAttribute_Mapping", new[] { "ProductAttributeID" });
            DropIndex("dbo.Product_ProductAttribute_Mapping", new[] { "ProductID" });
            DropIndex("dbo.Menu", new[] { "GroupID" });
            DropIndex("dbo.Post", new[] { "CategoryID" });
            DropIndex("dbo.PostTag", new[] { "TagID" });
            DropIndex("dbo.PostTag", new[] { "PostID" });
            DropIndex("dbo.ProductTag", new[] { "TagID" });
            DropIndex("dbo.ProductTag", new[] { "ProductID" });
            DropIndex("dbo.ProductCategory", new[] { "ParentID" });
            DropIndex("dbo.OrderDetail", new[] { "ProductID" });
            DropIndex("dbo.OrderDetail", new[] { "OrderID" });
            DropIndex("dbo.Product", new[] { "BrandID" });
            DropIndex("dbo.Product", new[] { "CategoryID" });
            DropTable("dbo.VisitorStatistics");
            DropTable("dbo.SystemConfig");
            DropTable("dbo.SupportOnline");
            DropTable("dbo.Slide");
            DropTable("dbo.ProductAttributeValue");
            DropTable("dbo.ProductAttribute");
            DropTable("dbo.Product_ProductAttribute_Mapping");
            DropTable("dbo.Page");
            DropTable("dbo.Menu");
            DropTable("dbo.MenuGroup");
            DropTable("dbo.LogError");
            DropTable("dbo.Footer");
            DropTable("dbo.PostCategory");
            DropTable("dbo.Post");
            DropTable("dbo.PostTag");
            DropTable("dbo.Tag");
            DropTable("dbo.ProductTag");
            DropTable("dbo.ProductCategory");
            DropTable("dbo.Order");
            DropTable("dbo.OrderDetail");
            DropTable("dbo.Product");
            DropTable("dbo.Brand");
        }
    }
}
