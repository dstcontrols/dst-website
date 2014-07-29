#region FileInformationAndLicensing

// ************************************************************************************************************************
// dst-website/dst-website/DSTSitemapController.cs
// 
// Creation Time     : 2014-07-29 9:24 AM
// Time Last Updated : 2014-07-29 11:43 AM
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

namespace dst_website.Controllers
{
    #region

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using BetterCms.Module.Api;
    using BetterCms.Module.Api.Infrastructure;
    using BetterCms.Module.Api.Infrastructure.Enums;
    using BetterCms.Module.Api.Operations.Pages.Pages.Page.Exists;
    using BetterCms.Module.Api.Operations.Pages.Sitemap;
    using BetterCms.Module.Api.Operations.Pages.Sitemap.Nodes;
    using BetterCms.Module.Api.Operations.Pages.Sitemap.Tree;
    using dst_website.Models;

    #endregion

    public class DSTSiteMapController : Controller
    {
        private static readonly Guid DefaultSitemapId = new Guid("17ABFEE9-5AE6-470C-92E1-C2905036574B");

        public virtual ActionResult Index()
        {
            var menuItems = new List<MenuItemViewModel>();

            using (IApiFacade api = ApiFactory.Create())
            {
                Guid? sitemapId = this.GetSitemapId(api);
                if (sitemapId.HasValue)
                {
                    var request = new GetSitemapTreeRequest {SitemapId = sitemapId.Value};

                    GetSitemapTreeResponse response = api.Pages.Sitemap.Tree.Get(request);
                    if (response.Data.Count > 0)
                    {
                        menuItems =
                            response.Data.Select(mi => new MenuItemViewModel {Caption = mi.Title, Url = mi.Url})
                                    .ToList();
                    }
                }
            }

            return this.View(menuItems);
        }

        public virtual ActionResult SubMenu(string parentUrl)
        {
            var menuItems = new List<MenuItemViewModel>();

            using (IApiFacade api = ApiFactory.Create())
            {
                var pageRequest = new PageExistsRequest {PageUrl = parentUrl};
                PageExistsResponse pageResponse = api.Pages.Page.Exists(pageRequest);

                Guid? sitemapId = this.GetSitemapId(api);
                if (!sitemapId.HasValue)
                {
                    return this.View(menuItems);
                }
                var parentRequest = new GetSitemapNodesRequest {SitemapId = sitemapId.Value, Data = {Take = 1}};
                parentRequest.Data.Filter.Add("ParentId", null);

                var filter = new DataFilter(FilterConnector.Or);
                parentRequest.Data.Filter.Inner.Add(filter);
                filter.Add("Url", parentUrl);
                if (pageResponse.Data.Exists)
                {
                    filter.Add("PageId", pageResponse.Data.PageId.Value);
                }
                parentRequest.Data.Order.Add("DisplayOrder");

                GetSitemapNodesResponse parentResponse = api.Pages.Sitemap.Nodes.Get(parentRequest);
                if (parentResponse.Data.Items.Count != 1)
                {
                    return this.View(menuItems);
                }
                var request = new GetSitemapTreeRequest
                              {
                                  SitemapId = sitemapId.Value,
                                  Data = {NodeId = parentResponse.Data.Items[0].Id}
                              };
                GetSitemapTreeResponse response = api.Pages.Sitemap.Tree.Get(request);
                if (response.Data.Count <= 0)
                {
                    return this.View(menuItems);
                }
                menuItems =
                    response.Data.Select(mi => new MenuItemViewModel {Caption = mi.Title, Url = mi.Url}).ToList();
                menuItems.Insert(0, new MenuItemViewModel {Caption = "Main", Url = parentUrl});
            }

            return this.View(menuItems);
        }

        private Guid? GetSitemapId(IApiFacade api)
        {
            GetSitemapsResponse allSitemaps = api.Pages.Sitemap.Get(new GetSitemapsRequest());
            if (allSitemaps.Data.Items.Count <= 0)
            {
                return null;
            }
            SitemapModel sitemap = allSitemaps.Data.Items.FirstOrDefault(map => map.Id == DefaultSitemapId) ??
                                   allSitemaps.Data.Items.First();
            return sitemap.Id;
        }
    }
}
