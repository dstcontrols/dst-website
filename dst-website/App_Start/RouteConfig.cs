using System.Web.Mvc;
using System.Web.Routing;

namespace dst_website
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("contacts-form", "contacts/submit-form", new { area = string.Empty, controller = "Contact", action = "ContactForm" }, new[] { "dst_website.Controllers" });
            routes.MapRoute("menu-top", "menu/top", new { area = string.Empty, controller = "SiteMap", action = "Index" }, new[] { "dst_website.Controllers" });
            routes.MapRoute("menu-sub", "menu/submenu/{parentUrl}", new { area = string.Empty, controller = "SiteMap", action = "SubMenu" }, new[] { "dst_website.Controllers" });
            routes.MapRoute("blog-latest", "blog/latest/{categoryId}", new { area = string.Empty, controller = "Blog", action = "Index", categoryId = UrlParameter.Optional }, new[] { "dst_website.Controllers" });
            routes.MapRoute("blog-last", "blog/last", new { area = string.Empty, controller = "Blog", action = "Last" }, new[] { "dst_website.Controllers" });
            routes.MapRoute("blog-categories", "blog/categories", new { area = string.Empty, controller = "Blog", action = "GetCategories" }, new[] { "dst_website.Controllers" });
            routes.MapRoute("blog-feed", "blog/feed", new { area = string.Empty, controller = "Blog", action = "Feed" }, new[] { "dst_website.Controllers" });
        }
    }
}