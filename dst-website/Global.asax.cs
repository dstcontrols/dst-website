namespace dst_website
{
    #region Namespace import directives

    using System;
    using System.Web;
    using BetterCms.Core;
    using BetterCms.Core.Environment.Host;

    #endregion

    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : HttpApplication
    {
        //protected void Application_Start()
        //{
        //    AreaRegistration.RegisterAllAreas();

        //    WebApiConfig.Register(GlobalConfiguration.Configuration);
        //    FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
        //    RouteConfig.RegisterRoutes(RouteTable.Routes);
        //}

        private static ICmsHost cmsHost;

        protected void Application_Start()
        {
            cmsHost = CmsContext.RegisterHost();

            /* DO NOT FORGET TO REMOVE DEFAULT ROUTE REGISTRATION! 
               FOLLOWING SOURCE CODE SHOULD BE REMOVED: 

               routes.MapRoute(
                        name: "Default",
                        url: "{controller}/{action}/{id}",
                        defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
                    );
            */

            // [YOUR CODE]  

            cmsHost.OnApplicationStart(this);
        }

        protected void Application_BeginRequest()
        {
            // [YOUR CODE]

            cmsHost.OnBeginRequest(this);
        }

        protected void Application_EndRequest()
        {
            // [YOUR CODE]

            cmsHost.OnEndRequest(this);
        }

        protected void Application_Error()
        {
            // [YOUR CODE]

            cmsHost.OnApplicationError(this);
        }

        protected void Application_End()
        {
            // [YOUR CODE]

            cmsHost.OnApplicationEnd(this);
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            // [YOUR CODE]

            // Uncomment following source code for a quick Better CMS test if you don't have implemented users authentication. 
            // Do not use this code for production!
            /*
            var roles = new[] { "BcmsEditContent", "BcmsPublishContent", "BcmsDeleteContent", "BcmsAdministration" };
            var principal = new GenericPrincipal(new GenericIdentity("TestUser"), roles);
            HttpContext.Current.User = principal;
            */

            cmsHost.OnAuthenticateRequest(this);
        }
    }
}