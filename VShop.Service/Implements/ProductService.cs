using System;
using System.Collections.Generic;
using System.Linq;
using VShop.Common.Constants;
using VShop.Common.Helpers;
using VShop.Model;
using VShop.Repository;

namespace VShop.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductTagRepository _productTagRepository;
        private readonly ITagRepository _tagRepository;
        private readonly IUnitOfWork _uow;

        public ProductService(IProductRepository productRepository
            , IProductTagRepository productTagRepository
            , ITagRepository tagRepository
            , IUnitOfWork uow)
        {
            _productRepository = productRepository;
            _productTagRepository = productTagRepository;
            _tagRepository = tagRepository;
            _uow = uow;
        }

        public Product Add(Product product)
        {
            var productResult = _productRepository.Add(product);
            var saveResult = _uow.Commit();
            if (saveResult)
            {
                var tags = product.Tags.Split(',');
                foreach (var tag in tags)
                {
                    var unsignTag = StringHelper.ToUnsignString(tag);
                    var tagInDb = _tagRepository.GetMulti(x => x.ID == unsignTag).FirstOrDefault();
                    if (tagInDb == null)
                    {
                        tagInDb = new Tag()
                        {
                            ID = unsignTag,
                            Name = tag,
                            Type = TagTypeConstant.PRODUCT
                        };
                        _tagRepository.Add(tagInDb);
                    }

                    _productTagRepository.Add(new ProductTag()
                    {
                        TagID = tagInDb.ID,
                        ProductID = productResult.ID
                    });

                }
                _uow.Commit();
                return productResult;
            }
            return null;
        }

        public Product Update(Product product)
        {
            var productResult = _productRepository.Update(product);
            _productTagRepository.DeleteMulti(x => x.ProductID == productResult.ID);

            var tags = product.Tags.Split(',');
            foreach (var tag in tags)
            {
                var unsignTag = StringHelper.ToUnsignString(tag);
                var tagInDb = _tagRepository.GetMulti(x => x.ID == unsignTag).FirstOrDefault();
                if (tagInDb == null)
                {
                    tagInDb = new Tag()
                    {
                        ID = unsignTag,
                        Name = tag,
                        Type = TagTypeConstant.PRODUCT
                    };
                    _tagRepository.Add(tagInDb);
                }

                _productTagRepository.Add(new ProductTag()
                {
                    TagID = tagInDb.ID,
                    ProductID = productResult.ID
                });

            }
            _uow.Commit();
            return productResult;
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

        public IEnumerable<Product> GetLastestProduct(int count)
        {
            return _productRepository.GetAll().OrderByDescending(p => p.CreateDate).Take(count);
        }

        public IEnumerable<Product> GetHotProduct(int count)
        {
            return _productRepository.GetAll().Where(x=>x.HotFlag).OrderByDescending(p => p.ViewCount).Take(count);

        }
    }
}