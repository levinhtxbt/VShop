using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VShop.Service;

namespace VShop.Web.Api
{
    [Authorize]
    [RoutePrefix("api/home")]
    public class HomeController : BaseApiController
    {
        public HomeController(ILogService logErrorService) : base(logErrorService)
        {
        }

        [HttpGet]
        [Route("test-method")]
        public IHttpActionResult TestMethod()
        {
            return Ok("Welcome");
        }
    }
}
