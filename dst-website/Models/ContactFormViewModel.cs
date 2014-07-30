#region FileInformationAndLicensing

// ************************************************************************************************************************
// dst-website/dst-website/ContactFormViewModel.cs
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

    using System.ComponentModel.DataAnnotations;
    using BetterCms.Module.Root.ViewModels.Cms;
    using dst_website.Infrastructure;

    #endregion

    public class ContactFormViewModel : RenderWidgetViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required, Email(ErrorMessage = "Invalid Email address")]
        public string Email { get; set; }

        [Required]
        public string Message { get; set; }

        public string EmailTo { get; set; }

        public override string ToString()
        {
            return string.Format("Name: {0}, Email: {1}, Phone: {2}, Message: {3}", this.Name, this.Email, this.Message);
        }
    }
}
