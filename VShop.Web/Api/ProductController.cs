using AutoMapper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;
using VShop.Common.Helpers;
using VShop.Mapping.Extensions;
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
        [Route("")]
        public IHttpActionResult GetAll(string keyword = null, int? pageIndex = null, int? pageSize = null)
        {
            var _totalCount = 0;
            var _pageSize = pageSize ?? WebConfigHelper.GetPageSize();
            var _pageIndex = pageIndex ?? 0;
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
        [Route("")]
        public IHttpActionResult Create(CreateProductRequest model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var product = new Product();
            product.UpdateProduct(model);

            var result = _productService.Add(product);
            if (result != null)
            {
                return Ok(new { status = true });
            }

            return BadRequest();
        }

        [HttpPut]
        [Route("")]
        public IHttpActionResult Update(UpdateProductRequest model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var product = _productService.GetById(model.ID);
            if (product != null)
            {
                product.UpdateProduct(model);
                var result = _productService.Update(product);
                if (result != null)
                {
                    return Ok(new { status = true });
                }
            }
            return BadRequest();
        }

        [HttpDelete]
        [Route("")]
        public IHttpActionResult Delete(int id)
        {
            var result = _productService.DeleteById(id);
            if (result != null)
            {
                return Ok(new { status = true });
            }
            return BadRequest();
        }

        [HttpDelete]
        [Route("delete-multiple")]
        public IHttpActionResult Delete(string ids)
        {
            var listIds = new JavaScriptSerializer().Deserialize<List<int>>(ids);
            var result = _productService.DeleteMultiple(listIds);
            if (result != -1)
            {
                return Ok(new { status = true, data = result });
            }
            return BadRequest();

        }

    }
}
