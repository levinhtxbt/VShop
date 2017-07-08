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
    [RoutePrefix("api/brand")]
    public class BrandController : BaseApiController
    {
        #region Property / Contructor

        private readonly IBrandService _brandService;

        public BrandController(ILogService logErrorService
            , IBrandService brandService) : base(logErrorService)
        {
            _brandService = brandService;
        }

        #endregion Property / Contructor

        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAll(string keyword = null, int? pageIndex = null, int? pageSize = null)
        {
            var _pageIndex = pageIndex ?? 0;
            var _pageSize = pageSize ?? WebConfigHelper.GetPageSize();
            var _totalCount = 0;

            var brands = _brandService.GetByPaging(keyword, _pageIndex, _pageSize, out _totalCount);
            var _totalPage = (int)Math.Ceiling((decimal)_totalCount / _pageSize);
            var brandResponses = Mapper.Map<IEnumerable<BrandListResponse>>(brands);
            var paging = new PaginationSet<BrandListResponse>()
            {
                Items = brandResponses,
                Page = _pageIndex,
                TotalCount = _totalCount,
                TotalPages = _totalPage,
                PageSize = _pageSize
            };

            return Ok(paging);
        }

        [HttpGet]
        [Route("getall")]
        public IHttpActionResult GetAll()
        {
            var brands = _brandService.GetAll();
            return Ok(brands.Select(b => new { ID = b.ID, Name = b.Name }));
        }

        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult GetById(int id)
        {
            var brand = _brandService.GetById(id);
            if (brand != null)
            {
                var brandVm = Mapper.Map<BrandDetailResponse>(brand);
                return Ok(brandVm);
            }
            return BadRequest();
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult Create(CreateBrandRequest requestModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var model = new Brand();
            model.UpdateBrand(requestModel);
            var result = _brandService.Add(model);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPut]
        [Route("")]
        public IHttpActionResult Update(UpdateBrandRequest requestModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            try
            {
                var brand = _brandService.GetById(requestModel.ID);
                if (brand != null)
                {
                    brand.UpdateBrand(requestModel);
                    var result = _brandService.Update(brand);
                    if (result != null)
                    {
                        var productCategoryVm = Mapper.Map<BrandDetailResponse>(result);
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
            var result = _brandService.Delete(id);
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
            var result = _brandService.DeleteMultiple(listIds);
            if (result != -1)
            {
                return Ok(new { status = true, result = result });
            }
            return BadRequest();
        }
    }
}