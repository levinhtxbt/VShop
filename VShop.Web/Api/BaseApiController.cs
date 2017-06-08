using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using VShop.Common;
using VShop.Model;
using VShop.Service;

namespace VShop.Web.Api
{
    public class BaseApiController : ApiController
    {
        protected string Culture = "vi";
        protected int? UserId;
        protected int? SiteId;

        private ILogService _logErrorService;

        public BaseApiController(ILogService logErrorService)
        {
            this._logErrorService = logErrorService;
        }

        protected void LogError(Exception exception)
        {
            try
            {
                LogError error = new LogError()
                {
                    CreateDate = DateTime.Now,
                    Message = exception.Message,
                    StackTrace = exception.StackTrace
                };
                _logErrorService.CreateLog(error);
            }
            catch (Exception ex)
            {
                Log.WebAPI(ex);
                throw ex;
            }
        }

        public override Task<HttpResponseMessage> ExecuteAsync(HttpControllerContext controllerContext,
            CancellationToken cancellationToken)
        {
            try
            {
                if (controllerContext.Request.Headers.Contains("culture"))
                {
                    Culture = controllerContext.Request.Headers.GetValues("culture").First();
                    SetupCultureInfo(Culture);
                }
            }
            catch (Exception ex)
            {
                LogError(ex);
                Log.WebAPI(ex);
            }
            return base.ExecuteAsync(controllerContext, cancellationToken);
        }

        private static CultureInfo SetupCultureInfo(string cultureName)
        {
            var culture = new CultureInfo(cultureName)
            {
                DateTimeFormat = { FirstDayOfWeek = DayOfWeek.Monday }
            };

            if (culture.TwoLetterISOLanguageName.Equals("vi"))
            {
                culture.DateTimeFormat.AbbreviatedDayNames = new[] { "CN", "T2", "T3", "T4", "T5", "T6", "T7" };
                culture.DateTimeFormat.DayNames = new[] { "Chủ nhật", "Thứ 2", "Thứ 3", "Thứ 4", "Thứ 5", "Thứ 6", "Thứ 7" };

                culture.DateTimeFormat.AbbreviatedMonthNames = new[]
                {
                    "Tháng 1", "Tháng 2", "Tháng 3", "Tháng 4", "Tháng 5", "Tháng 6", "Tháng 7", "Tháng 8",
                    "Tháng 9",
                    "Tháng 10", "Tháng 11", "Tháng 12", ""
                };
                culture.DateTimeFormat.MonthNames = new[]
                {
                    "Tháng 1", "Tháng 2", "Tháng 3", "Tháng 4", "Tháng 5", "Tháng 6", "Tháng 7", "Tháng 8",
                    "Tháng 9",
                    "Tháng 10", "Tháng 11", "Tháng 12", ""
                };

                culture.DateTimeFormat.AMDesignator = "AM";
                culture.DateTimeFormat.PMDesignator = "PM";
            }

            return culture;
        }

        protected string ClientIp
        {
            get
            {
                return ((System.Web.HttpContextWrapper)Request.Properties["MS_HttpContext"]).Request.UserHostAddress;
            }
        }
    }
}
