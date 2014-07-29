namespace dst_website.Controllers
{
    #region Namespace import directives

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

    public class SiteMapController : Controller
    {
        private static readonly Guid defaultSitemapId = new Guid("17ABFEE9-5AE6-470C-92E1-C2905036574B");

        public virtual ActionResult Index()
        {
            List<MenuItemViewModel> menuItems = new List<MenuItemViewModel>();

            using (IApiFacade api = ApiFactory.Create())
            {
                Guid? sitemapId = this.GetSitemapId(api);
                if (sitemapId.HasValue)
                {
                    GetSitemapTreeRequest request = new GetSitemapTreeRequest {SitemapId = sitemapId.Value};

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
            List<MenuItemViewModel> menuItems = new List<MenuItemViewModel>();

            using (IApiFacade api = ApiFactory.Create())
            {
                PageExistsRequest pageRequest = new PageExistsRequest {PageUrl = parentUrl};
                PageExistsResponse pageResponse = api.Pages.Page.Exists(pageRequest);

                Guid? sitemapId = this.GetSitemapId(api);
                if (sitemapId.HasValue)
                {
                    GetSitemapNodesRequest parentRequest = new GetSitemapNodesRequest();
                    parentRequest.SitemapId = sitemapId.Value;
                    parentRequest.Data.Take = 1;
                    parentRequest.Data.Filter.Add("ParentId", null);

                    DataFilter filter = new DataFilter(FilterConnector.Or);
                    parentRequest.Data.Filter.Inner.Add(filter);
                    filter.Add("Url", parentUrl);
                    if (pageResponse.Data.Exists)
                    {
                        filter.Add("PageId", pageResponse.Data.PageId.Value);
                    }
                    parentRequest.Data.Order.Add("DisplayOrder");

                    GetSitemapNodesResponse parentResponse = api.Pages.Sitemap.Nodes.Get(parentRequest);
                    if (parentResponse.Data.Items.Count == 1)
                    {
                        GetSitemapTreeRequest request = new GetSitemapTreeRequest {SitemapId = sitemapId.Value};
                        request.Data.NodeId = parentResponse.Data.Items[0].Id;
                        GetSitemapTreeResponse response = api.Pages.Sitemap.Tree.Get(request);
                        if (response.Data.Count > 0)
                        {
                            menuItems =
                                response.Data.Select(mi => new MenuItemViewModel {Caption = mi.Title, Url = mi.Url})
                                        .ToList();
                            menuItems.Insert(0, new MenuItemViewModel {Caption = "Main", Url = parentUrl});
                        }
                    }
                }
            }

            return this.View(menuItems);
        }

        private Guid? GetSitemapId(IApiFacade api)
        {
            GetSitemapsResponse allSitemaps = api.Pages.Sitemap.Get(new GetSitemapsRequest());
            if (allSitemaps.Data.Items.Count > 0)
            {
                SitemapModel sitemap = allSitemaps.Data.Items.FirstOrDefault(map => map.Id == defaultSitemapId) ??
                                       allSitemaps.Data.Items.First();
                return sitemap.Id;
            }

            return null;
        }
    }
}