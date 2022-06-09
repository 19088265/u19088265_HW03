using System.Web;
using System.Web.Mvc;

namespace u19088265_HomeWork03
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
