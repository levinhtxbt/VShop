using System.Collections.Generic;
using VShop.Model;

namespace VShop.Service
{
    public interface IProductService
    {
        Product Add(Product product);

        Product Update(Product product);

        Product Delete(Product product);

        IEnumerable<Product> GetAll();

        IEnumerable<Product> GetPaging(int pageIndex, int pageSize, out int totalCount);
    }
}