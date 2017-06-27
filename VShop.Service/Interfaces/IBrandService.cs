using System.Collections.Generic;
using VShop.Model;

namespace VShop.Service
{
    public interface IBrandService
    {
        Brand Add(Brand brand);

        Brand Update(Brand brand);

        Brand Delete(Brand brand);

        Brand Delete(int id);

        int DeleteMultiple(List<int> id);

        IEnumerable<Brand> GetAll();

        Brand GetById(int id, string[] include = null);

        IEnumerable<Brand> GetByPaging(string keyword, int pageIndex, int pageSize, out int totalCount, string[] include = null);
    }
}