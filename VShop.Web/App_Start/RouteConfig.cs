using System.Web.Mvc;
using System.Web.Routing;

namespace VShop.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
               name: "About",
               url: "gioi-thieu",
               defaults: new { controller = "About", action = "Index", id = UrlParameter.Optional },
               namespaces: new string[] { "VShop.Web.Controllers" }
           );

            routes.MapRoute(
              name: "Login",
              url: "dang-nhap",
              defaults: new { controller = "Account", action = "Login", id = UrlParameter.Optional },
              namespaces: new string[] { "VShop.Web.Controllers" }
          );
            routes.MapRoute(
              name: "Register",
              url: "dang-ky",
              defaults: new { controller = "Account", action = "Register", id = UrlParameter.Optional },
              namespaces: new string[] { "VShop.Web.Controllers" }
          );
            routes.MapRoute(
              name: "MyProfile",
              url: "thong-tin-ca-nhan/{username}",
              defaults: new { controller = "Account", action = "Register", id = UrlParameter.Optional },
              namespaces: new string[] { "VShop.Web.Controllers" }
          );

            routes.MapRoute(
             name: "Product_Detail",
             url: "chi-tiet/{alias}-{id}",
             defaults: new { controller = "Product", action = "Detail", id = UrlParameter.Optional },
             namespaces: new string[] { "VShop.Web.Controllers" }
         );
            routes.MapRoute(
             name: "Product_Category_Detail",
             url: "danh-muc/{alias}-{id}",
             defaults: new { controller = "ProductCategory", action = "Detail", id = UrlParameter.Optional },
             namespaces: new string[] { "VShop.Web.Controllers" }
         );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "VShop.Web.Controllers" }
            );
        }
    }
}