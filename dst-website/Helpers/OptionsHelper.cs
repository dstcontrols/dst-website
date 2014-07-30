#region FileInformationAndLicensing

// ************************************************************************************************************************
// dst-website/dst-website/OptionsHelper.cs
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

    using System.Collections.Generic;
    using System.Linq;
    using BetterCms.Core.DataContracts;

    #endregion

    public static class OptionsHelper
    {
        public static string GetValue(IList<IOptionValue> options, string key)
        {
            IOptionValue option = options.FirstOrDefault(o => o.Key == key);
            if (option != null && option.Value != null)
            {
                return option.Value.ToString();
            }

            return null;
        }
    }
}
