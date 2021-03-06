﻿using System.Collections.Generic;
using VShop.Model;

namespace VShop.Service
{
    public interface IProductCategoryService
    {
        ProductCategory Add(ProductCategory productCategory);

        ProductCategory Update(ProductCategory productCategory);

        ProductCategory Delete(ProductCategory productCategory);

        ProductCategory Delete(int id);

        int DeleteMultiple(List<int> id);

        IEnumerable<ProductCategory> GetAll();

        ProductCategory GetById(int id, string[] include = null);

        IEnumerable<ProductCategory> GetByPaging(string keyword, int pageIndex, int pageSize, out int totalCount, string[] include = null);

        IEnumerable<ProductCategory> GetMenuCategory();
    }
}