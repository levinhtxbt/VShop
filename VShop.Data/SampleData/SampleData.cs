using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VShop.Model;

namespace VShop.Data.SampleData
{
    public class SampleData
    {
        public static void CreateUser(VShopDbContext context)
        {
            //var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            //var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            //var user = new ApplicationUser()
            //{
            //    UserName = "admin",
            //    Email = "vinh.le@gmail.com",
            //    EmailConfirmed = true,
            //    BirthDay = DateTime.Now,
            //    FirstName = "Vinh",
            //    LastName = "Le"
            //};
            //if (manager.Users.Count(x => x.UserName == "admin") == 0)
            //{
            //    manager.Create(user, "12345678");

            //    if (!roleManager.Roles.Any())
            //    {
            //        roleManager.Create(new IdentityRole { Name = "Admin" });
            //        roleManager.Create(new IdentityRole { Name = "User" });
            //    }

            //    var adminUser = manager.FindByEmail("vinh.le@gmail.com");

            //    manager.AddToRoles(adminUser.Id, new string[] { "Admin", "User" });
            //}
        }

        public static void AddProductCategorySample(VShopDbContext context)
        {
            if (context.ProductCategories.Count() > 0) return;

            List<ProductCategory> listProductCategories = new List<ProductCategory>();
            listProductCategories.Add(new ProductCategory()
            {
                Name = "Điện thoại di động",
                Alias = "dien-thoai-di-dong",
                HotFlag = false,
                MetaKeyword = "dien-thoai-di-dong",
                MetaDescription = "dien-thoai-di-dong",
                Status = true,
                Description = "Điện thoại di động",
                CreateDate = DateTime.Now,
                CreateBy = "admin",
            });
            listProductCategories.Add(new ProductCategory()
            {
                Name = "Máy tính bảng",
                Alias = "Máy tính bảng",
                HotFlag = false,
                MetaKeyword = "may-tinh-bang",
                MetaDescription = "may-tinh-bang",
                Status = true,
                Description = "Máy tính bảng",
                CreateDate = DateTime.Now,
                CreateBy = "admin",
            });
            listProductCategories.Add(new ProductCategory()
            {
                Name = "Laptop",
                Alias = "laptop",
                HotFlag = false,
                MetaKeyword = "laptop",
                MetaDescription = "laptop",
                Status = true,
                Description = "Laptop",
                CreateDate = DateTime.Now,
                CreateBy = "admin",
            });
            listProductCategories.Add(new ProductCategory()
            {
                Name = "Điện máy",
                Alias = "dien-may",
                HotFlag = false,
                MetaKeyword = "thiet-bi-dien-may",
                MetaDescription = "thiet-bi-dien-may",
                Status = true,
                Description = "Các thiết bị điện máy",
                CreateDate = DateTime.Now,
                CreateBy = "admin",
            });
            listProductCategories.Add(new ProductCategory()
            {
                Name = "Điện tử",
                Alias = "dien-tu",
                HotFlag = false,
                MetaKeyword = "thiet-bi-dien-tu",
                MetaDescription = "thiet-bi-dien-tu",
                Status = true,
                Description = "Các thiết bị điện tử",
                CreateDate = DateTime.Now,
                CreateBy = "admin"
            });
            context.ProductCategories.AddRange(listProductCategories);
            context.SaveChanges();
        }

        public static void AddBrandSample(VShopDbContext context)
        {
            if (context.Brands.Count() > 0) return;
            List<Brand> listBrand = new List<Brand>();
            listBrand.Add(new Brand()
            {
                Name = "Apple",
                Alias = "apple",
                CreateDate = DateTime.Now,
                CreateBy = "admin",
                Status = true,
                Description = "Apple Inc",
            });
            listBrand.Add(new Brand()
            {
                Name = "Sony",
                Alias = "sony",
                CreateDate = DateTime.Now,
                CreateBy = "admin",
                Status = true,
                Description = "Sony",
            });
            listBrand.Add(new Brand()
            {
                Name = "Samsung",
                Alias = "samsung",
                CreateDate = DateTime.Now,
                CreateBy = "admin",
                Status = true,
                Description = "Samsung",
            });
            listBrand.Add(new Brand()
            {
                Name = "Vivo",
                Alias = "vivo",
                CreateDate = DateTime.Now,
                CreateBy = "admin",
                Status = true,
                Description = "Vivo",
            });
            listBrand.Add(new Brand()
            {
                Name = "Lenovo",
                Alias = "lenovo",
                CreateDate = DateTime.Now,
                CreateBy = "admin",
                Status = true,
                Description = "Lenovo",
            });
            listBrand.Add(new Brand()
            {
                Name = "Acer",
                Alias = "acer",
                CreateDate = DateTime.Now,
                CreateBy = "admin",
                Status = true,
                Description = "Acer",
            });
            listBrand.Add(new Brand()
            {
                Name = "Oppo",
                Alias = "oppo",
                CreateDate = DateTime.Now,
                CreateBy = "admin",
                Status = true,
                Description = "Oppo",
            });
            listBrand.Add(new Brand()
            {
                Name = "Asus",
                Alias = "asus",
                CreateDate = DateTime.Now,
                CreateBy = "admin",
                Status = true,
                Description = "Asus",
            });
            listBrand.Add(new Brand()
            {
                Name = "Xiaomi",
                Alias = "xiaomi",
                CreateDate = DateTime.Now,
                CreateBy = "admin",
                Status = true,
                Description = "Xiaomi",
            });

            context.Brands.AddRange(listBrand);
            context.SaveChanges();
        }

        public static void AddProductSimple(VShopDbContext context)
        {
            if (context.Products.Count() > 0) return;

            var listProducts = new List<Product>();

            listProducts.Add(new Product()
            {
                Name = "Iphone 6 32Gb Red",
                Alias = "iphone-6-32gb-red",
                Content = "Iphone 6 32Gb Red",
                CategoryID = 2,
                BrandID = 1,
                Status = true,
                Price = 10000000,
                Warranty = 12,
                HomeFlag = true,
                HotFlag = true,
                ViewCount = 100,
                CreateBy = "admin",
                CreateDate = DateTime.Now
            });

            listProducts.Add(new Product()
            {
                Name = "Iphone 6 32Gb Gray",
                Alias = "iphone-6-32gb-gray",
                Content = "Iphone 6 32Gb Gray",
                CategoryID = 2,
                BrandID = 1,
                Status = true,
                Price = 12000000,
                Warranty = 12,
                HomeFlag = true,
                HotFlag = true,
                ViewCount = 100,
                CreateBy = "admin",
                CreateDate = DateTime.Now
            });

            listProducts.Add(new Product()
            {
                Name = "IPhone 6 64Gb Gray",
                Alias = "iphone-6-64gb-gray",
                Content = "IPhone 6 64Gb Gray",
                CategoryID = 4,
                BrandID = 1,
                Status = true,
                Price = 14000000,
                Warranty = 12,
                HomeFlag = true,
                HotFlag = true,
                ViewCount = 100,
                CreateBy = "admin",
                CreateDate = DateTime.Now
            });
            listProducts.Add(new Product()
            {
                Name = "IPhone 6s 64Gb",
                Alias = "iphone-6-64gb",
                Content = "IPhone 6 64Gb Gray",
                CategoryID = 4,
                BrandID = 1,
                Status = true,
                Price = 16000000,
                Warranty = 12,
                HomeFlag = true,
                HotFlag = true,
                ViewCount = 100,
                CreateBy = "admin",
                CreateDate = DateTime.Now
            });
            listProducts.Add(new Product()
            {
                Name = "IPhone 6 128Gb",
                Alias = "iphone-6-128gb",
                Content = "IPhone 6 128Gb Gray",
                CategoryID = 4,
                BrandID = 1,
                Status = true,
                Price = 15000000,
                Warranty = 12,
                HomeFlag = true,
                HotFlag = true,
                ViewCount = 100,
                CreateBy = "admin",
                CreateDate = DateTime.Now
            });
            listProducts.Add(new Product()
            {
                Name = "IPhone 7 64Gb",
                Alias = "iphone-7-64gb",
                Content = "IPhone 7 64Gb Gray",
                CategoryID = 4,
                BrandID = 1,
                Status = true,
                Price = 20000000,
                Warranty = 12,
                HomeFlag = true,
                HotFlag = true,
                ViewCount = 100,
                CreateBy = "admin",
                CreateDate = DateTime.Now
            });
            listProducts.Add(new Product()
            {
                Name = "IPhone 6 32Gb",
                Alias = "iphone-6-32gb",
                Content = "IPhone 6 32Gb Gray",
                CategoryID = 4,
                BrandID = 1,
                Status = true,
                Price = 12000000,
                Warranty = 12,
                HomeFlag = true,
                HotFlag = true,
                ViewCount = 100,
                CreateBy = "admin",
                CreateDate = DateTime.Now
            });

            context.Products.AddRange(listProducts);
            context.SaveChanges();
        }

        public static void AddSlideSample(VShopDbContext context)
        {
            if (context.Slides.Count() > 0) return;

            var slides = new List<Slide>();
            slides.Add(new Slide()
            {
                Name = "Slide 1",
                Description = "This is description for slide 1",
                Status = true,
                Image = "/Content/client/images/bag.jpg",
                URL = "/Content/client/images/bag.jpg",
                MetaDescription = "slide-1",
                MetaKeyword = "slide-1",
                CreateBy = "admin",
                CreateDate = DateTime.Now
            });
            slides.Add(new Slide()
            {
                Name = "Slide 2",
                Description = "This is description for slide 2",
                Status = true,
                Image = "/Content/client/images/bag1.jpg",
                URL = "/Content/client/images/bag1.jpg",
                MetaDescription = "slide-2",
                MetaKeyword = "slide-2",
                CreateBy = "admin",
                CreateDate = DateTime.Now
            });
            slides.Add(new Slide()
            {
                Name = "Slide 3",
                Description = "This is description for slide 3",
                Status = true,
                Image = "/Content/client/images/bag.jpg",
                URL = "/Content/client/images/bag.jpg",
                MetaDescription = "slide-2",
                MetaKeyword = "slide-2",
                CreateBy = "admin",
                CreateDate = DateTime.Now
            });

            context.Slides.AddRange(slides);
            context.SaveChanges();
        }
    }
}
