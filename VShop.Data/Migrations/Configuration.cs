namespace VShop.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<VShop.Data.VShopDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(VShop.Data.VShopDbContext context)
        {
            SampleData.SampleData.CreateUser(context);
            SampleData.SampleData.AddProductCategorySample(context);
            SampleData.SampleData.AddBrandSample(context);
            SampleData.SampleData.AddProductSimple(context);
            SampleData.SampleData.AddSlideSample(context);
        }
    }
}
