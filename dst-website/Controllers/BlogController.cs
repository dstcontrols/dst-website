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
    using BetterCms.Module.Api.Operations.Blog.BlogPosts;
    using BetterCms.Module.Api.Operations.Root.Categories;
    using dst_website.Models;

    #endregion

    public class BlogController : Controller
    {
        public virtual ActionResult Index(Guid? categoryId, string tagName)
        {
            IList<BlogItem> posts;

            using (IApiFacade api = ApiFactory.Create())
            {
                GetBlogPostsModel request = new GetBlogPostsModel {Take = 10, IncludeTags = true};

                DataFilter orFilter = new DataFilter(FilterConnector.Or);
                orFilter.Add("ExpirationDate", null);
                orFilter.Add("ExpirationDate", DateTime.Today, FilterOperation.GreaterOrEqual);

                request.Order.By.Add(new OrderItem("ActivationDate", OrderDirection.Desc));
                request.Order.By.Add(new OrderItem("Id"));
                request.Filter.Add("ActivationDate", DateTime.Today, FilterOperation.LessOrEqual);
                request.Filter.Inner.Add(orFilter);
                if (categoryId.HasValue)
                {
                    request.Filter.Add("CategoryId", categoryId.Value);
                }

                if (!string.IsNullOrEmpty(tagName))
                {
                    request.FilterByTags.Add(tagName);
                }

                GetBlogPostsResponse pages = api.Blog.BlogPosts.Get(new GetBlogPostsRequest {Data = request});

                posts = pages.Data.Items.Select(
                                                x => new BlogItem
                                                     {
                                                         IntroText = x.IntroText,
                                                         PublishedOn = x.ActivationDate,
                                                         Title = x.Title,
                                                         Url = x.BlogPostUrl,
                                                         Author = x.AuthorName,
                                                         Tags = x.Tags
                                                     }).ToList();
            }

            return this.View(posts);
        }

        public virtual ActionResult Last()
        {
            BlogItem post = null;

            using (IApiFacade api = ApiFactory.Create())
            {
                GetBlogPostsModel requestLatestNewsModel = new GetBlogPostsModel {Take = 1, IncludeTags = true};

                DataFilter orFilter = new DataFilter(FilterConnector.Or);

                orFilter.Add("ExpirationDate", null);
                orFilter.Add("ExpirationDate", DateTime.Today, FilterOperation.GreaterOrEqual);

                requestLatestNewsModel.Order.By.Add(new OrderItem("ActivationDate", OrderDirection.Desc));
                requestLatestNewsModel.Order.By.Add(new OrderItem("Id"));
                requestLatestNewsModel.Filter.Add("ActivationDate", DateTime.Today, FilterOperation.LessOrEqual);

                requestLatestNewsModel.Filter.Inner.Add(orFilter);

                GetBlogPostsRequest request = new GetBlogPostsRequest {Data = requestLatestNewsModel};

                GetBlogPostsResponse pages = api.Blog.BlogPosts.Get(request);

                post = pages.Data.Items.Select(
                                               x => new BlogItem
                                                    {
                                                        IntroText = x.IntroText,
                                                        PublishedOn = x.ActivationDate,
                                                        Title = x.Title,
                                                        Url = x.BlogPostUrl,
                                                        Author = x.AuthorName,
                                                        Tags = x.Tags
                                                    }).SingleOrDefault();
            }

            return this.View(post);
        }

        public virtual ActionResult GetCategories()
        {
            IList<CategoryItem> categories;

            using (IApiFacade api = ApiFactory.Create())
            {
                GetCategoriesRequest request = new GetCategoriesRequest();
                request.Data.Order.By.Add(new OrderItem("Name"));

                GetCategoriesResponse pages = api.Root.Categories.Get(request);

                categories = pages.Data.Items.Select(
                                                     x => new CategoryItem
                                                          {
                                                              Id = x.Id,
                                                              Name = x.Name
                                                          }).ToList();
            }

            return this.View(categories);
        }

        public virtual ActionResult Feed()
        {
            IList<BlogItem> posts;

            using (IApiFacade api = ApiFactory.Create())
            {
                GetBlogPostsModel request = new GetBlogPostsModel {Take = 10, IncludeTags = true};

                DataFilter orFilter = new DataFilter(FilterConnector.Or);
                orFilter.Add("ExpirationDate", null);
                orFilter.Add("ExpirationDate", DateTime.Today, FilterOperation.GreaterOrEqual);

                request.Order.By.Add(new OrderItem("ActivationDate", OrderDirection.Desc));
                request.Order.By.Add(new OrderItem("Id"));
                request.Filter.Add("ActivationDate", DateTime.Today, FilterOperation.LessOrEqual);

                GetBlogPostsResponse pages = api.Blog.BlogPosts.Get(new GetBlogPostsRequest {Data = request});

                posts = pages.Data.Items.Select(
                                                x => new BlogItem
                                                     {
                                                         IntroText = x.IntroText,
                                                         PublishedOn = x.ActivationDate,
                                                         Title = x.Title,
                                                         Url = x.BlogPostUrl,
                                                         Author = x.AuthorName,
                                                         ImageUrl = x.MainImageUrl,
                                                         Tags = x.Tags
                                                     }).ToList();
            }

            return this.View(posts);
        }
    }
}