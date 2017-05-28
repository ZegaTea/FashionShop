using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace FashionShop
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                 name: "Home",
                 url: "trang-chu",
                 defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                 namespaces: new[] { "FashionShop.Controllers" }
             );

            //routes.MapRoute(
            //     name: "Login",
            //     url: "nguoi-dung/dang-nhap",
            //     defaults: new { controller = "User", action = "Login", id = UrlParameter.Optional },
            //     namespaces: new[] { "FashionShop.Controllers" }
            // );

            routes.MapRoute(
                name: "List Products",
                url: "san-pham/{id}",
                defaults: new { controller = "Product", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "FashionShop.Controllers" }
            );

               routes.MapRoute(
               name: "Add Cart",
               url: "gio-hang",
               defaults: new { controller = "Cart", action = "Index", id = UrlParameter.Optional },
               namespaces: new[] { "FashionShop.Controllers" }
           );

            routes.MapRoute(
               name: "Payment",
               url: "gio-hang/thanh-toan",
               defaults: new { controller = "Cart", action = "Payment", id = UrlParameter.Optional },
               namespaces: new[] { "FashionShop.Controllers" }
           );

            routes.MapRoute(
                name: "Products detail",
                url: "san-pham/{metatitle}/{id}",
                defaults: new { controller = "Product", action = "Detail", id = UrlParameter.Optional },
                namespaces: new[] { "FashionShop.Controllers" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "FashionShop.Controllers" }
            );
        }
    }
}
