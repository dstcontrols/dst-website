#region FileInformationAndLicensing

// ************************************************************************************************************************
// dst-website/dst-website/RouteConfig.cs
// 
// Creation Time     : 2014-07-28 7:54 PM
// Time Last Updated : 2014-07-30 10:16 PM
// Copyright         : (C) 2014 Devbridge Group LLC
// Contributions By  : (C) 2014 DST Controls
// License           : Better CMS License Agreement
// License URL:      : https://raw.githubusercontent.com/devbridge/BetterCMS/dev/license.txt
// 
// Author            : Andrew Pong
// Email             : apong@dstcontrols.com
// Website           : www.dstcontrols.com
// Phone             : 1(800) 251-0773
// 
// Use of this software is subject to the terms and conditions provided in dst-website/dst-website/betterCMS.license.txt
// 
// ************************************************************************************************************************

#endregion

namespace dst_website
{
    #region

    using System.Web.Mvc;
    using System.Web.Routing;

    #endregion

    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("contacts-form", "contacts/submit-form",
                            new {area = string.Empty, controller = "Contact", action = "ContactForm"},
                            new[] {"dst_website.Controllers"});
            routes.MapRoute("menu-top", "menu/top",
                            new { area = string.Empty, controller = "Navigation", action = "Index" },
                            new[] {"dst_website.Controllers"});
            routes.MapRoute("menu-sub", "menu/submenu/{parentUrl}",
                            new { area = string.Empty, controller = "Navigation", action = "SubMenu" },
                            new[] {"dst_website.Controllers"});
            routes.MapRoute("blog-latest", "blog/latest/{categoryId}",
                            new {area = string.Empty, controller = "Blog", action = "Index", categoryId = UrlParameter.Optional},
                            new[] {"dst_website.Controllers"});
            routes.MapRoute("blog-last", "blog/last",
                            new {area = string.Empty, controller = "Blog", action = "Last"},
                            new[] {"dst_website.Controllers"});
            routes.MapRoute("blog-categories", "blog/categories",
                            new {area = string.Empty, controller = "Blog", action = "GetCategories"},
                            new[] {"dst_website.Controllers"});
            routes.MapRoute("blog-feed", "blog/feed",
                            new {area = string.Empty, controller = "Blog", action = "Feed"},
                            new[] {"dst_website.Controllers"});
        }
    }
}
