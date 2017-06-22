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

        Product GetById(int id, string[] include = null);

        IEnumerable<Product> GetByPaging(string keyword, int pageIndex, int pageSize, out int totalCount, string[] include = null);
    }
}