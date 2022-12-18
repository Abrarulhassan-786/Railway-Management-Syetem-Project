using System.Web;
using System.Web.Mvc;

namespace DBMS_RMS_PROJECT
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
