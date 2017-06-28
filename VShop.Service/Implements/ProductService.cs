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

        public Product DeleteById(int id)
        {
            var product = GetById(id);
            if (product != null)
            {
                return Delete(product);
            }
            return null;
        }

        public int DeleteMultiple(List<int> ids)
        {
            if (ids.Count != 0)
            {
                foreach (var id in ids)
                {
                    _productRepository.Delete(id);
                }
                return _uow.SaveChanges();
            }
            return -1;
        }

        public IEnumerable<Product> GetAll()
        {
            return _productRepository.GetAll();
        }

        public IEnumerable<Product> GetByPaging(string keyword, int pageIndex, int pageSize, out int totalCount, string[] include = null)
        {
            var listProduct = _productRepository.GetAll(include);

            if (!string.IsNullOrEmpty(keyword))
            {
                listProduct = listProduct.Where(x => x.Name.Contains(keyword));
            }

            totalCount = listProduct.Count();
            listProduct = listProduct.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();

            return listProduct;
        }

        public Product GetById(int id, string[] include = null)
        {
            if (include != null)
            {
                return _productRepository.GetMulti(x => x.ID == id, include).FirstOrDefault();
            }
            return _productRepository.GetSingleById(id);
        }
    }
}