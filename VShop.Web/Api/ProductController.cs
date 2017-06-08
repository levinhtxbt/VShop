using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
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
        public IHttpActionResult GetAll()
        {
            var list = _productService.GetAll().ToList();
            return Ok(list);
        }
    }
}
