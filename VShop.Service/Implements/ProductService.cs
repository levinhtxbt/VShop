using System.Collections.Generic;
using System.Linq;
using VShop.Model;
using VShop.Repository;

namespace VShop.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _uow;

        public ProductService(IProductRepository productRepository
            , IUnitOfWork uow)
        {
            _productRepository = productRepository;
            _uow = uow;
        }

        public Product Add(Product product)
        {
            var result = _productRepository.Add(product);
            return _uow.Commit() ? result : null;
        }

        public Product Update(Product product)
        {
            var result = _productRepository.Update(product);
            return _uow.Commit() ? result : null;
        }

        public Product Delete(Product product)
        {
            var result = _productRepository.Delete(product);
            return _uow.Commit() ? result : null;
        }

        public IEnumerable<Product> GetAll()
        {
            return _productRepository.GetAll();
        }

        public IEnumerable<Product> GetPaging(int pageIndex, int pageSize, out int totalCount)
        {
            var listProduct = _productRepository.GetAll();
            totalCount = listProduct.Count();
            listProduct = listProduct.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            return listProduct;
        }


    }
}