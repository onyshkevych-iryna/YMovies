using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using YMovies.Web.Utilities;

namespace YMovies.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            MovieDbService.Utilities.AutoMap.RegisterMapping();
            AutoMap.RegisterMapping();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
