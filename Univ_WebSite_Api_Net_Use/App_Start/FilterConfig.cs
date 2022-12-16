using System.Web;
using System.Web.Mvc;

namespace Univ_WebSite_Api_Net_Use
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
