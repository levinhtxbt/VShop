using System;

namespace VShop.Data
{
    public interface IDbFactory : IDisposable
    {
        VShopDbContext Init();
    }
}