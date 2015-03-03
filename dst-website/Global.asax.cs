#region FileInformationAndLicensing

// ************************************************************************************************************************
// dst-website/dst-website/Global.asax.cs
// 
// Creation Time     : 2014-07-28 7:54 PM
// Time Last Updated : 2014-07-29 8:08 PM
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
