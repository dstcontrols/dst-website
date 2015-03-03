﻿#region FileInformationAndLicensing

// ************************************************************************************************************************
// dst-website/dst-website/SocialHelper.cs
// 
// Creation Time     : 2014-07-28 10:32 PM
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

namespace dst_website.Helpers
{
    #region

    using System;
    using System.Web.Mvc;
    using BetterCms.Module.Root.ViewModels.Cms;

    #endregion

    public static class SocialHelper
    {
        public static MvcHtmlString TitleForSocial(this HtmlHelper<RenderWidgetViewModel> htmlHelper)
        {
            RenderWidgetViewModel model = htmlHelper.ViewData.Model;
            return MvcHtmlString.Create(OptionsHelper.GetValue(model.Options, "title"));
        }

        public static MvcHtmlString LinkForSocial(this HtmlHelper<RenderWidgetViewModel> htmlHelper,
                                                  string renderOptionName, string urlOptionName, string titleOptionName,
                                                  string cssClassOptionName)
        {
            RenderWidgetViewModel model = htmlHelper.ViewData.Model;
            string renderOption = OptionsHelper.GetValue(model.Options, renderOptionName);
            string urlOption = OptionsHelper.GetValue(model.Options, urlOptionName);
            string titleOption = OptionsHelper.GetValue(model.Options, titleOptionName);
            string cssClassOption = OptionsHelper.GetValue(model.Options, cssClassOptionName);

            if (!string.IsNullOrWhiteSpace(renderOption) && Convert.ToBoolean(renderOption))
            {
                return MvcHtmlString.Create(
                                            string.Format("<a href=\"{0}\" class=\"{1}\">{2}</a>",
                                                          urlOption ?? string.Empty, cssClassOption ?? string.Empty,
                                                          titleOption ?? string.Empty));
            }

            return MvcHtmlString.Empty;
        }
    }
}