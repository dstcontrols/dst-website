namespace dst_website
{
    #region Namespace import directives

    using System.Web.Mvc;

    #endregion

    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}