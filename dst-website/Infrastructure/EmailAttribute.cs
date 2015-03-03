#region FileInformationAndLicensing

// ************************************************************************************************************************
// dst-website/dst-website/EmailAttribute.cs
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

namespace dst_website.Infrastructure
{
    #region

    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    #endregion

    public class EmailAttribute : RegularExpressionAttribute, IClientValidatable
    {
        public EmailAttribute()
            : base(@"^[\w_\+-]+(\.[\w_\+-]+)*@[\w-]+(\.[\w-]+)*\.([a-zA-Z]{2,4})$")
        {
        }

        #region IClientValidatable Members

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata,
                                                                               ControllerContext context)
        {
            yield return
                new ModelClientValidationRule
                {
                    ErrorMessage = this.FormatErrorMessage(metadata.GetDisplayName()),
                    ValidationType = "customemail"
                };
        }

        #endregion
    }
}
