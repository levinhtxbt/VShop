using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using VShop.Model;
using VShop.Repository;
using VShop.Service;

namespace VShop.UnitTest.ServiceTest
{
    [TestClass]
    public class ProductServiceTest
    {
        private Mock<IProductRepository> _mockRepository;
        private Mock<IUnitOfWork> _mockUOW;
        private IProductService _objService;

        [TestInitialize]
        public void Initial()
        {
            _mockRepository = new Mock<IProductRepository>();
            _mockUOW = new Mock<IUnitOfWork>();
            _objService = new ProductService(_mockRepository.Object, _mockUOW.Object);
        }

        [TestMethod, TestCategory("B")]
        public void AddNewProduct_ShouldOk()
        {
            var product = new Product()
            {
                Name = "a",
                CategoryID = 1,
                BrandID = 1,
                CreateDate = DateTime.Now,
                Alias = "a",
                Content = "abc",
                CreateBy = "admin"
            };
            _mockRepository.Setup(x => x.Add(product)).Returns((Product x) =>
              {
                  x.ID = 1;
                  return x;
              });
            _mockUOW.Setup(x => x.Commit()).Returns(true);

            var result = _objService.Add(product);
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.ID);

        }
    }
}