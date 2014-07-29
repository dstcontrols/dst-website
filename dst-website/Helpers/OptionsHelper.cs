namespace dst_website.Helpers
{
    #region Namespace import directives

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