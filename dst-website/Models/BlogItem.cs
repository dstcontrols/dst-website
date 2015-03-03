#region FileInformationAndLicensing

// ************************************************************************************************************************
// dst-website/dst-website/BlogItem.cs
// 
// Creation Time     : 2014-07-28 10:31 PM
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

namespace dst_website.Models
{
    #region

    using System;
    using System.Collections.Generic;

    #endregion

    public class BlogItem
    {
        public string Title { get; set; }

        public string IntroText { get; set; }

        public DateTime PublishedOn { get; set; }

        public string Url { get; set; }

        public string Author { get; set; }

        public string ImageUrl { get; set; }

        public List<string> Tags { get; set; }

        public override string ToString()
        {
            return string.Format(
                                 "Title: {0}, IntroText: {1}, PublishedOn: {2}, Url: {3}, Author: {4}, ImageUrl: {5}",
                                 this.Title, this.IntroText, this.PublishedOn, this.Url, this.Author, this.ImageUrl);
        }
    }
}
