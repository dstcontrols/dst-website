#region FileInformationAndLicensing

// ************************************************************************************************************************
// dst-website/dst-website/EmailHelper.cs
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

    using System.Text;
    using dst_website.Models;

    #endregion

    public static class EmailHelper
    {
        public static string FormatMessage(ContactFormViewModel contactForm)
        {
            var builder = new StringBuilder();
            builder.AppendFormat("<div>From: {0}</div>", contactForm.Name);
            builder.AppendFormat("<div>Email: {0}</div>", contactForm.Email);

            if (!string.IsNullOrWhiteSpace(contactForm.Message))
            {
                builder.AppendFormat("<div><br/>{0}</div>", contactForm.Message);
            }

            return builder.ToString();
        }
    }
}
