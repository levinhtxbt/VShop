using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VShop.Mapping.Extensions;
using VShop.Model;
using VShop.Service;

namespace VShop.Web.Controllers
{

    public class HomeController : Controller
    {
        #region Properties / Contructor

        private readonly IProductCategoryService _productCategoryService;
        private readonly IProductService _productService;
        private readonly ICommonService _commonService;

        public HomeController(IProductCategoryService productCategoryService
            , IProductService productService
            , ICommonService commonService)
        {
            _productCategoryService = productCategoryService;
            _productService = productService;
            _commonService = commonService;
        }

        #endregion

        public ActionResult Index()
        {
            var lastestProducts = _productService.GetLastestProduct(3);
            var hotProducts = _productService.GetHotProduct(3);
            var lastestProductVms = Mapper.Map<IEnumerable<SimpleProductViewModel>>(lastestProducts);
            var hotProductVms = Mapper.Map<IEnumerable<SimpleProductViewModel>>(hotProducts);
            ViewBag.lastestProducts = lastestProductVms;
            ViewBag.hotProducts = hotProductVms;

            return View();
        }

        #region Partial

        [ChildActionOnly]
        public ActionResult Slide()
        {
            var slide = _commonService.GetSlide();
            var slideVms = Mapper.Map<IEnumerable<SlideViewModel>>(slide);
            return View("_Slide", slideVms);
        }

        [ChildActionOnly]
        public ActionResult Header()
        {
            return PartialView("_Header");
        }

        [ChildActionOnly]
        public ActionResult Footer()
        {
            return PartialView("_Footer");
        }

        [ChildActionOnly]
        public ActionResult MenuCategory()
        {
            var menuCategories = _productCategoryService.GetMenuCategory().ToList();
            var menuCategoriesVm = menuCategories.Select(x => x.ToMenuCategoryViewModel());
            return PartialView("_MenuCategory", menuCategoriesVm);
        }
        #endregion
    }
}