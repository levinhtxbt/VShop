﻿using System;
using System.Collections.Generic;
using System.Linq;
using VShop.Model;
using VShop.Repository;

namespace VShop.Service.Implements
{
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly IProductCategoryRepository _productCategoryRepository;
        private readonly IUnitOfWork _uow;

        public ProductCategoryService(IProductCategoryRepository productCategoryRepository, IUnitOfWork uow)
        {
            _productCategoryRepository = productCategoryRepository;
            _uow = uow;
        }

        public ProductCategory Add(ProductCategory productCategory)
        {
            var result = _productCategoryRepository.Add(productCategory);
            return _uow.Commit() ? result : null;
        }

        public ProductCategory Update(ProductCategory productCategory)
        {
            var result = _productCategoryRepository.Update(productCategory);
            return _uow.Commit() ? result : null;
        }

        public ProductCategory Delete(int id)
        {
            var deleteTarget = _productCategoryRepository.GetSingleById(id);
            if (deleteTarget != null)
            {
                return Delete(deleteTarget);
            }
            return null;
        }

        public ProductCategory Delete(ProductCategory productCategory)
        {
            var result = _productCategoryRepository.Delete(productCategory);
            return _uow.Commit() ? result : null;
        }
        public int DeleteMultiple(List<int> ids)
        {
            if (ids.Count != 0)
            {
                _productCategoryRepository.DeleteMulti(x => ids.Contains(x.ID));
                return _uow.SaveChanges();
            }
            return -1;
        }

        public IEnumerable<ProductCategory> GetAll()
        {
            return _productCategoryRepository.GetAll();
        }

        public ProductCategory GetById(int id, string[] include = null)
        {
            if (include != null)
            {
                return _productCategoryRepository.GetMulti(x => x.ID == id, include).FirstOrDefault();
            }
            return _productCategoryRepository.GetSingleById(id);
        }

        public IEnumerable<ProductCategory> GetByPaging(string keyword, int pageIndex, int pageSize, out int totalCount, string[] include = null)
        {
            var listProduct = _productCategoryRepository.GetAll(include);

            if (!string.IsNullOrEmpty(keyword))
            {
                listProduct = listProduct.Where(x => x.Name.Contains(keyword));
            }

            totalCount = listProduct.Count();
            listProduct = listProduct.Skip(pageIndex * pageSize).Take(pageSize).ToList();

            return listProduct;
        }

        public IEnumerable<ProductCategory> GetMenuCategory()
        {
            return _productCategoryRepository.GetAll(includes: new string[] { "Children" }).Where(x => x.ParentID == null);
        }
    }
}