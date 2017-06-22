using AutoMapper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VShop.Common.Helpers;
using VShop.Model;
using VShop.Service;

namespace VShop.Web.Api
{
    [RoutePrefix("api/product")]
    public class ProductController : BaseApiController
    {
        private readonly IProductService _productService;

        public ProductController(ILogService logErrorService
            , IProductService productService) : base(logErrorService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IHttpActionResult GetAll(string keyword = null, int? pageIndex = null, int? pageSize = null)
        {
            var _totalCount = 0;
            var _pageSize = pageSize ?? WebConfigHelper.GetPageSize();
            var _pageIndex = pageIndex ?? 1;
            var listProduct = _productService.GetByPaging(keyword, _pageIndex, _pageSize, out _totalCount, new string[] { "ProductCategory", "Brand" });
            var _totalPage = (int)Math.Ceiling((decimal)_totalCount / _pageSize);
            var listProductResponse = Mapper.Map<IEnumerable<ProductListResponse>>(listProduct);
            var paging = new PaginationSet<ProductListResponse>()
            {
                Items = listProductResponse,
                Page = _pageIndex,
                TotalCount = _totalCount,
                TotalPages = _totalPage,
                PageSize = _pageSize
            };

            return Ok(paging);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult GetById(int id)
        {
            var product = _productService.GetById(id, new string[] { "ProductCategory", "Brand" });
            var productVm = Mapper.Map<ProductDetailResponse>(product);
            return Ok(productVm);
        }

        [HttpPost]
        public IHttpActionResult Create(ProductDetailRequest model)
        {
            return Ok();
        }

        [HttpPut]
        public IHttpActionResult Update(ProductDetailRequest model)
        {
            return Ok();
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IHttpActionResult Delete()
        {
            return Ok();
        }

    }
}
