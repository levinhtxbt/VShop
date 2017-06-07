using System.Data.Entity;
using VShop.Model;

namespace VShop.Data
{
    public class VShopDbContext : DbContext
    {
        public VShopDbContext() : base("VShopConnectionString")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        //For Site Component
        public DbSet<Slide> Slides { get; set; }

        public DbSet<Footer> Footers { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<MenuGroup> MenuGroups { get; set; }

        //For System / Configurations
        public DbSet<SystemConfig> SystemConfigs { get; set; }

        public DbSet<VisitorStatistic> VisitorStatistics { get; set; }
        public DbSet<LogError> LogErrors { get; set; }

        //For Product Management
        public DbSet<Product> Products { get; set; }

        public DbSet<ProductTag> ProductTags { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductAttribute> ProductAttributes { get; set; }
        public DbSet<Product_ProductAttribute_Mapping> Product_ProductAttribute_Mappings { get; set; }
        public DbSet<ProductAttributeValue> ProductAttributeValues { get; set; }

        //For Content Management
        public DbSet<Post> Posts { get; set; }

        public DbSet<PostCategory> PostCategories { get; set; }
        public DbSet<PostTag> PostTags { get; set; }

        //Other
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<SupportOnline> SupportOnlines { get; set; }
        public DbSet<Tag> Tags { get; set; }
    }
}