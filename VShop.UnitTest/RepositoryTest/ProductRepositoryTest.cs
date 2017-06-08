using Microsoft.VisualStudio.TestTools.UnitTesting;
using VShop.Data;
using VShop.Model;
using VShop.Repository;

namespace VShop.UnitTest.RepositoryTest
{
    [TestClass]
    public class ProductRepositoryTest
    {
        private IDbFactory dbFactory;
        private IProductRepository objRepository;
        private IUnitOfWork uow;

        [TestInitialize]
        public void Initial()
        {
            dbFactory = new DbFactory();
            objRepository = new ProductRepository(dbFactory);
            uow = new UnitOfWork(dbFactory);
        }

        //[TestMethod]
        //public void Add_ShouldOK()
        //{
        //    var product = new Product()
        //    {
        //    };
        //}

        [TestMethod]
        public void Add_ShouldFail()
        {
            Product product = new Product();
            var result = objRepository.Add(product);
            Assert.AreEqual(null, result);
        }
    }
}