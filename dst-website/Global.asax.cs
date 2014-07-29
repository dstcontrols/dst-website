namespace dst_website
{
    #region Namespace import directives

    using System;
    using System.Web;
    using System.Web.Http;
    using System.Web.Mvc;
    using BetterCms.Core;
    using BetterCms.Core.Environment.Host;

    #endregion

    public class MvcApplication : HttpApplication
    {
        private static ICmsHost cmsHost;

        protected void Application_Start()
        {
            cmsHost = CmsContext.RegisterHost();
            AreaRegistration.RegisterAllAreas();
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            cmsHost.OnApplicationStart(this);
        }

        protected void Application_BeginRequest()
        {
            cmsHost.OnBeginRequest(this);
        }

        protected void Application_EndRequest()
        {
            cmsHost.OnEndRequest(this);
        }

        protected void Application_Error()
        {
            cmsHost.OnApplicationError(this);
        }

        protected void Application_End()
        {
            cmsHost.OnApplicationEnd(this);
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            cmsHost.OnAuthenticateRequest(this);
        }
    }
}