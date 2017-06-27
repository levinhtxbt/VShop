using System.Collections.Generic;
using System.Linq;
using VShop.Model;
using VShop.Repository;

namespace VShop.Service
{
    public class BrandService : IBrandService
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IUnitOfWork _uow;

        public BrandService(IBrandRepository brandRepository, IUnitOfWork uow)
        {
            _brandRepository = brandRepository;
            _uow = uow;
        }

        public Brand Add(Brand brand)
        {
            var result = _brandRepository.Add(brand);
            return _uow.Commit() ? result : null;
        }

        public Brand Update(Brand brand)
        {
            var result = _brandRepository.Update(brand);
            return _uow.Commit() ? result : null;
        }

        public Brand Delete(int id)
        {
            var deleteTarget = _brandRepository.GetSingleById(id);
            if (deleteTarget != null)
            {
                return Delete(deleteTarget);
            }
            return null;
        }

        public Brand Delete(Brand brand)
        {
            var result = _brandRepository.Delete(brand);
            return _uow.Commit() ? result : null;
        }

        public int DeleteMultiple(List<int> ids)
        {
            if (ids.Count != 0)
            {
                _brandRepository.DeleteMulti(x => ids.Contains(x.ID));
                return _uow.SaveChanges();
            }
            return -1;
        }

        public IEnumerable<Brand> GetAll()
        {
            return _brandRepository.GetAll();
        }

        public Brand GetById(int id, string[] include = null)
        {
            if (include != null)
            {
                return _brandRepository.GetMulti(x => x.ID == id, include).FirstOrDefault();
            }
            return _brandRepository.GetSingleById(id);
        }

        public IEnumerable<Brand> GetByPaging(string keyword, int pageIndex, int pageSize, out int totalCount, string[] include = null)
        {
            var listBrand = _brandRepository.GetAll(include);

            if (!string.IsNullOrEmpty(keyword))
            {
                listBrand = listBrand.Where(x => x.Name.Contains(keyword));
            }

            totalCount = listBrand.Count();
            listBrand = listBrand.Skip(pageIndex * pageSize).Take(pageSize).ToList();

            return listBrand;
        }
    }
}