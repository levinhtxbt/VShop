using AutoMapper;
using System;
using System.Collections.Generic;
using System.Web.Http;
using VShop.Common;
using VShop.Common.Helpers;
using VShop.Mapping.Extensions;
using VShop.Model;
using VShop.Service;

namespace VShop.Web.Api
{
    [RoutePrefix("api/product-category")]
    public class ProductCategoryController : BaseApiController
    {
        private readonly IProductCategoryService _productCategoryService;

        public ProductCategoryController(ILogService logErrorService
            , IProductCategoryService productCategoryService) : base(logErrorService)
        {
            _productCategoryService = productCategoryService;
        }

        [HttpGet]
        [Route("getall")]
        public IHttpActionResult GetAll()
        {
            var productCategories = _productCategoryService.GetAll();
            var productCategoryVMs = Mapper.Map<IEnumerable<ProductCategoryViewModel>>(productCategories);
            return Ok(productCategoryVMs);
        }

        [HttpGet]
        public IHttpActionResult GetAll(string keyword = null, int? pageIndex = null, int? pageSize = null)
        {
            var _totalCount = 0;
            var _pageSize = pageSize ?? WebConfigHelper.GetPageSize();
            var _pageIndex = pageIndex ?? 0;
            var listProduct = _productCategoryService.GetByPaging(keyword, _pageIndex, _pageSize, out _totalCount, new string[] { "Products" });
            var _totalPage = (int)Math.Ceiling((decimal)_totalCount / _pageSize);
            var listProductResponse = Mapper.Map<IEnumerable<ProductCategoryListResponse>>(listProduct);
            var paging = new PaginationSet<ProductCategoryListResponse>()
            {
                Items = listProductResponse,
                Page = _pageIndex,
                TotalCount = _totalCount,
                TotalPages = _totalPage,
                PageSize = _pageSize
            };

            return Ok(paging);
        }

        [HttpPost]
        public IHttpActionResult Create(CreateProductCategoryRequest model)
        {
            try
            {
                var newProductCategory = new ProductCategory();
                newProductCategory.UpdateProductCategory(model);
                var result = _productCategoryService.Add(newProductCategory);
                if (result != null)
                {
                    return Ok(result);
                }
            }
            catch (Exception ex)
            {
                Log.Website(ex);
            }

            return BadRequest();
        }
    }
}