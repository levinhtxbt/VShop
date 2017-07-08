using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Script.Serialization;
using VShop.Common;
using VShop.Common.Helpers;
using VShop.Mapping.Extensions;
using VShop.Model;
using VShop.Service;

namespace VShop.Web.Api
{
    [Authorize]
    [RoutePrefix("api/product-category")]
    public class ProductCategoryController : BaseApiController
    {
        #region Property / Contructor
        private readonly IProductCategoryService _productCategoryService;

        public ProductCategoryController(ILogService logErrorService
            , IProductCategoryService productCategoryService) : base(logErrorService)
        {
            _productCategoryService = productCategoryService;
        }
        #endregion

        [HttpGet]
        [Route("getall")]
        public IHttpActionResult GetAll()
        {
            var productCategories = _productCategoryService.GetAll();
            //only get Id and Name
            return Ok(productCategories.Select(x => new { ID = x.ID, Name = x.Name, DisplayOrder = x.DisplayOrder }));
        }

        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult GetById(int id)
        {
            var productCategory = _productCategoryService.GetById(id);
            if (productCategory != null)
            {
                var productCategoryVm = Mapper.Map<ProductCategoryDetailResponse>(productCategory);
                return Ok(productCategoryVm);
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("")]
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
        [Route("")]
        public IHttpActionResult Create(CreateProductCategoryRequest model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

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

        [HttpPut]
        [Route("")]
        public IHttpActionResult Update(UpdateProductCategoryRequest model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var productCategory = _productCategoryService.GetById(model.ID);
                if (productCategory != null)
                {
                    productCategory.UpdateProductCategory(model);
                    var result = _productCategoryService.Update(productCategory);
                    if (result != null)
                    {
                        var productCategoryVm = Mapper.Map<ProductCategoryDetailResponse>(result);

                        return Ok(productCategoryVm);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Website(ex);
            }

            return BadRequest();
        }

        [HttpDelete]
        [Route("")]
        public IHttpActionResult Delete(int id)
        {
            var result = _productCategoryService.Delete(id);
            if (result != null)
            {
                return Ok(new { status = true });
            }
            return BadRequest();
        }

        [HttpDelete]
        [Route("delete-multiple")]
        public IHttpActionResult DeleteMulti(string ids)
        {
            var listIds = new JavaScriptSerializer().Deserialize<List<int>>(ids);
            var result = _productCategoryService.DeleteMultiple(listIds);
            if (result != -1)
            {
                return Ok(new { status = true, result = result });
            }
            return BadRequest();
        }
    }
}