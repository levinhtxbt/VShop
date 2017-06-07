namespace VShop.Data
{
    public class DbFactory : Disposable, IDbFactory
    {
        private VShopDbContext dbContext;

        public VShopDbContext Init()
        {
            return dbContext ?? (dbContext = new VShopDbContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
            {
                dbContext.Dispose();
            }
        }
    }
}